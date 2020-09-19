/*
 * @lc app=leetcode.cn id=530 lang=csharp
 *
 * [530] 二叉搜索树的最小绝对差
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
    List<int> list = new List<int>();
    public int GetMinimumDifference(TreeNode root) {
        DFS(root);  // O(n)
        //displayList(list);

        int minDiff = int.MaxValue;
        for(int i=1;i<list.Count;i++)   // O(n)
        {
            minDiff = Math.Min(minDiff,
                Math.Abs(list[i] - list[i-1]));
        }
        return minDiff;
    }

    // in-order: comes out sorted
    private void DFS(TreeNode node)
    {
        if (node != null)
        {
            DFS(node.left);
            list.Add(node.val);
            DFS(node.right);
        }
    }
    private void displayList<T>(List<T> list)
    {
        string s = "";
        foreach (T element in list)
        {
            s += element.ToString() + ',';
        }
        s = string.Format("[{0}]", s.TrimEnd(','));
        Console.WriteLine(s);
    }
}
// @lc code=end

