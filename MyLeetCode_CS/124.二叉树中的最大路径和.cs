/*
 * @lc app=leetcode.cn id=124 lang=csharp
 *
 * [124] 二叉树中的最大路径和
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

    private int ans = int.MinValue;

    public int MaxPathSum(TreeNode root) {
        recursion(root);
        return ans;
    }

    private int recursion(TreeNode node)
    {
        if (node == null) return 0;
        
        int maxSumL = Math.Max(0, recursion(node.left));
        int maxSumR = Math.Max(0, recursion(node.right));
        int maxIsolated = maxSumL+maxSumR+node.val;
        ans = Math.Max(maxIsolated, ans);
        return Math.Max(maxSumL+node.val, maxSumR+node.val);
    }
}
// @lc code=end

