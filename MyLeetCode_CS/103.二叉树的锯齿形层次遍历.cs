/*
 * @lc app=leetcode.cn id=103 lang=csharp
 *
 * [103] 二叉树的锯齿形层次遍历
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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        List<IList<int>> ans = new List<IList<int>>();
        Queue<TreeNode> queue = new Queue<TreeNode>();
        
        if (root == null) return ans;
        else queue.Enqueue(root);

        bool l2r = true;    // left to right
        int NumNodesOnThisLevel = 1;

        while (NumNodesOnThisLevel > 0)
        {
            List<int> level = new List<int>();

            for(int i=0;i<NumNodesOnThisLevel;i++)
            {
                TreeNode node = queue.Dequeue();
                
                if (l2r) level.Add(node.val);
                else level.Insert(0, node.val);

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
            ans.Add(level);
            NumNodesOnThisLevel = queue.Count;
            l2r = !l2r;
        }

        return ans;
    }
}
// @lc code=end

