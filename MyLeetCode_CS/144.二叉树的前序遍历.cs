/*
 * @lc app=leetcode.cn id=144 lang=csharp
 *
 * [144] 二叉树的前序遍历
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
    public IList<int> PreorderTraversal(TreeNode root) {
        List<int> preorder = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode node = root;
        while (true)
        {
            if (node != null)
            {
                preorder.Add(node.val);
                stack.Push(node);
                node = node.left;
            }
            else if (stack.Count > 0)
            {
                node = stack.Pop();
                node = node.right;
            }
            else
                break;
        }
        return preorder;
    }

    /*
    // Solution#1 - recursion
    List<int> preorder = new List<int>();
    public IList<int> PreorderTraversal(TreeNode root) {
        DFSpre(root);
        return preorder;
    }
    private void DFSpre (TreeNode node)
    {
        if (node != null)
        {
            preorder.Add(node.val);
            DFSpre(node.left);
            DFSpre(node.right);
        }
    }
    */
}
// @lc code=end

