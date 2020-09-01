/*
 * @lc app=leetcode.cn id=102 lang=csharp
 *
 * [102] 二叉树的层序遍历
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
public class Solution {
    public IList<IList<int>> LevelOrder(TreeNode root) {


        List<IList<int>> ans = new List<IList<int>>();
        Queue<TreeNode> queue = new Queue<TreeNode>();
        
        if (root == null) return ans;
        else queue.Enqueue(root);

        int NumNodesOnThisLevel = 1;

        while (NumNodesOnThisLevel > 0)
        {
            List<int> level = new List<int>();

            for(int i=0;i<NumNodesOnThisLevel;i++)
            {
                TreeNode node = queue.Dequeue();
                level.Add(node.val);

                if (node.left != null)
                    queue.Enqueue(node.left);
                if (node.right != null)
                    queue.Enqueue(node.right);
            }
            ans.Add(level);
            NumNodesOnThisLevel = queue.Count;
        }

        return ans;

    }
}
// @lc code=end

