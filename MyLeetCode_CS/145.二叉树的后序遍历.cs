/*
 * @lc app=leetcode.cn id=145 lang=csharp
 *
 * [145] 二叉树的后序遍历
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    // Solution#2 - iteration
    public IList<int> PostorderTraversal(TreeNode root) {
        List<int> postorder = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode node = root;
        while (true)
        {
            if (node != null)
            {
                postorder.Insert(0, node.val);
                stack.Push(node);
                node = node.right;
            }
            else if (stack.Count > 0)
            {
                node = stack.Pop();
                node = node.left;
            }
            else
                break;
        }
        return postorder;
    }

    /*
    // Solution#2 - iteration
    public IList<int> PostorderTraversal(TreeNode root) {
        List<int> postorder = new List<int>();
        if (root == null) return postorder;

        Stack<TreeNode> stack = new Stack<TreeNode>();       
        stack.Push(root);
        
        while (stack.Count > 0)
        {
            TreeNode node = stack.Pop();
            postorder.Insert(0, node.val);
            if (node.left != null)
                stack.Push(node.left);
            if (node.right != null)
                stack.Push(node.right);
        }
        return postorder;
    }
    */

    /*
    // Solution#1 - recursion
    List<int> postorder = new List<int>();
    public IList<int> PostorderTraversal(TreeNode root) {
        DFSpost(root);
        return postorder;
    }
    private void DFSpost (TreeNode node)
    {
        if (node != null)
        {
            DFSpost(node.left);
            DFSpost(node.right);
            postorder.Add(node.val);
        }
    }
    */
}
// @lc code=end

