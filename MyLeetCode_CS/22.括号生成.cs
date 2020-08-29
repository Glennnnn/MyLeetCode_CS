/*
 * @lc app=leetcode.cn id=22 lang=csharp
 *
 * [22] 括号生成
 */

// @lc code=start
public class Solution {

    

    public IList<string> GenerateParenthesis(int n) {

        // solution#2 - DP
        List<string>[] ans = new List<string>[n+1];
        ans[0] = new List<string>(){""};

        for (int i=1;i<=n;i++)
        {
            ans[i] = new List<string>(){};
            for (int j=0;j<i;j++)
            {
                foreach(string sj in ans[j])
                {
                    foreach(string sk in ans[i-1-j])
                    {
                        ans[i].Add(string.Format("({0}){1}", sj, sk));
                    }
                }
            }
        }
        return ans[n];
    }


    /*
    // solution#1 - DFS
    List<string> ans = new List<string>();

    public IList<string> GenerateParenthesis(int n) {
        dfs(n, n, "");
        Console.WriteLine(ans.Count);
        return ans;
    }

    private void dfs(int open, int close, string s)
    {
        // remaining open brackets must not be greater than remaining close brackets
        if (open <= close)
        {
            if (open==0 && close==0) ans.Add(s);
            if (open > 0) dfs(open-1, close, s+ "(");
            if (close > 0) dfs(open, close-1, s+ ")");
        }
    }
    */
}
// @lc code=end

