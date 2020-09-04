/*
 * @lc app=leetcode.cn id=131 lang=csharp
 *
 * [131] 分割回文串
 */

// @lc code=start
public class Solution {
    List<IList<string>> ans = new List<IList<string>>();
    public IList<IList<string>> Partition(string s) {
        dfs(s, new List<string>(), 0);
        return ans;
    }
    private void dfs(string s, List<string> remain, int l)
    {
        if (l == s.Length)
        {
            //displayList(remain);
            ans.Add(new List<string>(remain));  // make a copy
            return;
        }

        for (int r=l; r<s.Length; r++)
        {
            string part = s.Substring(l, r-l+1);
            if (isPalindrom(part))
            {
                //Console.Write("{0},", part);
                remain.Add(part);
                dfs(s, remain, r+1);
                remain.RemoveAt(remain.Count-1);
            }
        }
    }

    private bool isPalindrom(string s)
    {
        int l=0, r=s.Length-1;
        while (l<r)
        {
            if (s[l++] != s[r--])
                return false;
        }
        return true;
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

