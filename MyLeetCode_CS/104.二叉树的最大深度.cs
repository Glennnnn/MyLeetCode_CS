/*
 * @lc app=leetcode.cn id=104 lang=csharp
 *
 * [104] 二叉树的最大深度
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

    /*
    // Solution#1
    public int MaxDepth(TreeNode root) {
        return recursion(root, 0);
    }

    private int recursion(TreeNode node, int depth)
    {
        if (node == null) return depth;
        return Math.Max(
            recursion(node.left, depth+1),
            recursion(node.right, depth+1));
    }

    // Solution#1 - Optimized (time-O(n), space-worst:O(n) best:O(logn))
    public int MaxDepth(TreeNode root) {

        if (root == null)  return 0;
        return 1 + Math.Max(MaxDepth(root.right), MaxDepth(root.left));
    }
    */

    // Solution#2 - Iteration
    public int MaxDepth(TreeNode root) {
        
        int numLevel = 0;
        int numNodes = 1;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        
        if (root == null) return numLevel;
        else queue.Enqueue(root);

        while (numNodes > 0)
        {
            while (numNodes-- >0)
            {
                TreeNode node = queue.Dequeue();
                if (node.left!=null) queue.Enqueue(node.left);
                if (node.right!=null) queue.Enqueue(node.right);
            }
            numLevel++;
            numNodes = queue.Count; // num nodes of next level
        }

        return numLevel;
    }
}
// @lc code=end

