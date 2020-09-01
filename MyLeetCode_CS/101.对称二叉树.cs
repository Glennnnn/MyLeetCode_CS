/*
 * @lc app=leetcode.cn id=101 lang=csharp
 *
 * [101] 对称二叉树
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

    // Solution#2 - iteration
    public bool IsSymmetric(TreeNode root) {
        if (root == null) return true;
        
        TreeNode nodeL, nodeR;
        Queue<TreeNode> q = new Queue<TreeNode>();
        
        q.Enqueue(root.left);
        q.Enqueue(root.right);
        
        while (q.Count > 0)
        {
            nodeL = q.Dequeue();
            nodeR = q.Dequeue();
            
            if (nodeL == null && nodeR == null)
                continue;       // both are null
            if (nodeL == null || nodeR == null)
                return false;   // only one null
            if (nodeL.val != nodeR.val)
                return false;
            
            q.Enqueue(nodeL.left);
            q.Enqueue(nodeR.right);
            q.Enqueue(nodeL.right);
            q.Enqueue(nodeR.left);
        }
        return true;
    }


    /*
    //Solution#1 - recursion
    public bool IsSymmetric(TreeNode root) {
        return recursion(root, root);
    }

    private bool recursion(TreeNode l, TreeNode r)
    {
        if (l == null && r == null)
            return true;    // both are null
        if (l == null || r == null)
            return false;   // only one null
        return (l.val == r.val) 
            && recursion(l.left, r.right) 
            && recursion(l.right, r.left);
    }
    */
}
// @lc code=end

