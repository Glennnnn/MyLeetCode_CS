/*
 * @lc app=leetcode.cn id=107 lang=csharp
 *
 * [107] 二叉树的层次遍历 II
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
    public IList<IList<int>> LevelOrderBottom(TreeNode root) {

        List<IList<int>> list = new List<IList<int>>();
        Queue<TreeNode> queue = new Queue<TreeNode>();

        if (root == null) return list;
        queue.Enqueue(root);
        int numNodes = 1;   // number of nodes on current level

        while (numNodes > 0)
        {
            List<int> level = new List<int>();
            while (numNodes-- > 0)
            {
                TreeNode node = queue.Dequeue();
                level.Add(node.val);

                if (node.left != null)
                    queue.Enqueue(node.left);
                if (node.right != null)
                    queue.Enqueue(node.right);
            }
            list.Insert(0, level);  // always insert to the top
            numNodes = queue.Count;
        }
        return list;
    }
}
// @lc code=end

