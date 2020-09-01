/*
 * @lc app=leetcode.cn id=94 lang=csharp
 *
 * [94] 二叉树的中序遍历
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
    // Solution#1 Recursion
    List<int> list = new List<int>();

    public IList<int> InorderTraversal(TreeNode root) {
        recursion(root);
        return list;
    }

    private void recursion(TreeNode node)
    {
        if (node != null)
        {
            recursion(node.left);
            list.Add(node.val);
            recursion(node.right);
        }
    }
    */

    // Solution#2 Iteration
    public IList<int> InorderTraversal(TreeNode root) {

        List<int> list = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode node = root;

        while(true)
        {
            // keep pushing into stack and going left
            if (node != null)
            {
                stack.Push(node);
                node = node.left;
            }
            // reaches left leaf node, backtrack to prev level and go right
            else if (stack.Count > 0)
            {
                node = stack.Pop();
                list.Add(node.val);
                node = node.right;
            }
            // no where else to go
            else
            {
                break;
            }
        }
        return list;
    }

}
// @lc code=end

