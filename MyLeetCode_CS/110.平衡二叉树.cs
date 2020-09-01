/*
 * @lc app=leetcode.cn id=110 lang=csharp
 *
 * [110] 平衡二叉树
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
    // Solution1
    public bool IsBalanced(TreeNode root) {
        return recursion(root) >=0;
    }

    private int recursion(TreeNode node)
    {
        if (node == null) return 0;

        int depthL = recursion(node.left);
        if (depthL<0) return depthL;

        int depthR = recursion(node.right);
        if (depthR<0) return depthR;

        if (Math.Abs(depthL-depthR) > 1)
            return int.MinValue;
        else
            return Math.Max(depthL, depthR)+1;
    }
    */

    // Solution1 - Alternative
    bool isBalanced = true;

    public bool IsBalanced(TreeNode root) {
        recursion(root);    // returns height, but not needed
        return isBalanced;
    }

    private int recursion(TreeNode node)
    {
        if (node == null) return 0;

        int depthL = recursion(node.left);
        int depthR = recursion(node.right);

        if (Math.Abs(depthL-depthR) > 1)
            isBalanced = false; // final answer
        return Math.Max(depthL, depthR)+1;
    }

}
// @lc code=end

