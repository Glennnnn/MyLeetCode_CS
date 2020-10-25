/*
 * @lc app=leetcode.cn id=297 lang=csharp
 *
 * [297] 二叉树的序列化与反序列化
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {
    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        List<string> sequenceBFS = new List<string>();
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);
        int nullCount = 0;
        int nodeCount = 1;

        while (true)
        {
            for (int i=0;i<nodeCount;i++)   // loop through the whole level
            {
                TreeNode node = q.Dequeue();
                if (node == null)
                {
                    sequenceBFS.Add("null");
                    q.Enqueue(null);
                    q.Enqueue(null);
                    nullCount++;
                }
                else
                {
                    sequenceBFS.Add(node.val.ToString());
                    q.Enqueue(node.left);
                    q.Enqueue(node.right);
                }
            }
            //Console.WriteLine("{0}/{1}", nullCount, nodeCount);
            if (nullCount == nodeCount) // all nodes at this level are nulls
            {
                sequenceBFS.RemoveRange(sequenceBFS.Count - nodeCount, nodeCount);
                break;
            }
            else
            {
                nodeCount *=2;  // move on to next level
                nullCount = 0;
            }
        }

        string ans = string.Join(",", sequenceBFS);
        Console.WriteLine(ans);
        return ans;
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        /*
        List<TreeNode> allNodes = new List<TreeNode>();
        foreach (string d in data.Split(','))
        {
            if (Int32.TryParse(d, out int i))
                allNodes.Add(new TreeNode(i));
            else
                allNodes.Add(null);
        }

        // connect
        int startIdx  = 0;
        int nodeCount = 1;
        while(startIdx+nodeCount<allNodes.Count)
        {
            for (int i=0;i<nodeCount;i++)
            {
                if (allNodes[startIdx+i] != null)
                {
                    allNodes[startIdx+i].left = allNodes[startIdx + nodeCount + i*2];
                    allNodes[startIdx+i].right = allNodes[startIdx + nodeCount + i*2+1];
                }
            }
            startIdx += nodeCount;
            nodeCount *= 2;
        }
        
        return allNodes[0];
        */

        return recursion(data.Split(','), 0);
    }

    private TreeNode recursion(string[] values, int idx)
    {
        TreeNode currNode = null;
        if (idx < values.Length && 
            Int32.TryParse(values[idx], out int val))
        {
            currNode = new TreeNode(val);
            currNode.left = recursion(values, 2*idx+1);
            currNode.right = recursion(values, 2*idx+2);
        }
        return currNode;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));
// @lc code=end

