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
        // string ans = recursiveSerialization(root, "");
        // Console.WriteLine(ans);
        // return ans;

        return recursiveSerialization(root, "");
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        string[] values = data.Split(',');
        int idx = 0;
        return recursiveDeserialization(ref values, ref idx);
    }

    private string recursiveSerialization(TreeNode node, string s)
    {
        // DFS, pre-order
        if (node == null)
            s += "null,";
        else
        {
            s += node.val.ToString() + ",";
            s = recursiveSerialization(node.left, s);
            s = recursiveSerialization(node.right, s);
        }
        return s;
    }

    private TreeNode recursiveDeserialization(ref string[] values, ref int idx)
    {
        TreeNode currNode = null;
        if (Int32.TryParse(values[idx++], out int val))
        {
            currNode = new TreeNode(val);
            currNode.left = recursiveDeserialization(ref values, ref idx);
            currNode.right = recursiveDeserialization(ref values, ref idx);
        }
        return currNode;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));
// @lc code=end

