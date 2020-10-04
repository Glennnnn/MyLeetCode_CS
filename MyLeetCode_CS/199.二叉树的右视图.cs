/*
 * @lc app=leetcode.cn id=199 lang=csharp
 *
 * [199] 二叉树的右视图
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

    public IList<int> RightSideView(TreeNode root) {
        
        List<int> ans = new List<int>();
        Queue<TreeNode> row = new Queue<TreeNode>();

        if (root == null) return ans;
        
        TreeNode node = null;
        row.Enqueue(root);
        int nodeCount = 1;

        while (nodeCount>0)
        {
            for(int i=0;i<nodeCount;i++)
            {
                node = row.Dequeue();
                if (node.left != null) 
                    row.Enqueue(node.left);
                if (node.right != null) 
                    row.Enqueue(node.right);
            }
            ans.Add(node.val);
            nodeCount = row.Count;
        }

        return ans;
    }



/*
    List<int> inorder = new List<int>();
    List<int> preorder = new List<int>();
    List<int> postorder = new List<int>();

    List<int> ans = new List<int>();

    public IList<int> RightSideView(TreeNode root) {

        Preorder(root);
        Inorder(root);
        Postorder(root);

        displayList(preorder, "Preorder");
        displayList(inorder, "Inorder");
        displayList(postorder, "Postorder");

        return ans;
    }

    private void Preorder (TreeNode node)
    {
        if (node != null)
        {
            preorder.Add(node.val);
            Preorder(node.left);
            Preorder(node.right);
        }
    }
    private void Inorder (TreeNode node)
    {
        if (node != null)
        {
            Inorder(node.left);
            inorder.Add(node.val);
            Inorder(node.right);
        }
    }
    private void Postorder (TreeNode node)
    {
        if (node != null)
        {
            Postorder(node.left);
            Postorder(node.right);
            postorder.Add(node.val);
        }
    }
    private void displayList<T>(List<T> list, string title = "")
    {
        string s = title;
        if (s.Length>0) s += ": ";

        foreach (T element in list)
        {
            s += element.ToString() + ',';
        }
        s = string.Format("[{0}]", s.TrimEnd(','));
        Console.WriteLine(s);
    }    
*/
}
// @lc code=end

