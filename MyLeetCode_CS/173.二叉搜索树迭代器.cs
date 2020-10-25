/*
 * @lc app=leetcode.cn id=173 lang=csharp
 *
 * [173] 二叉搜索树迭代器
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
public class BSTIterator {

    Stack<TreeNode> stack;
    TreeNode curr;

    public BSTIterator(TreeNode root) {
        stack = new Stack<TreeNode>();
        curr = root;
    }
    
    /** @return the next smallest number */
    public int Next() {
        if (HasNext())
        {
            TreeNode node = stack.Pop();
            curr = node.right;
            return node.val;
        }
        else
            return -1;
    }
    
    /** @return whether we have a next smallest number */
    public bool HasNext() {
        if (curr != null || stack.Count>0)
        {
            while (curr != null)
            {
                stack.Push(curr);
                curr = curr.left;
            }
        }
        return stack.Count>0;
    }
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */
// @lc code=end

