/*
 * @lc app=leetcode.cn id=139 lang=csharp
 *
 * [139] 单词拆分
 */

// @lc code=start
public class Solution {
    public bool WordBreak(string s, IList<string> wordDict) {
        int size = s.Length;

        bool[] dp = new bool[size+1];
        dp[0] = true;

        for(int i=1;i<=size;i++)
        {
            for(int j=0;j<i;j++)
            {
                string prefix = s.Substring(j, i-j);
                if (wordDict.Contains(prefix) && dp[j])
                {
                    dp[i] = true;
                    break;
                }
            }
        }
        return dp[size];
    }
}
// @lc code=end

