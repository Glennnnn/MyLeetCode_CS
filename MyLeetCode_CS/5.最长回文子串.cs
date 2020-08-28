/*
 * @lc app=leetcode.cn id=5 lang=csharp
 *
 * [5] 最长回文子串
 */

// @lc code=start
public class Solution {
    public string LongestPalindrome(string s) {

        if (s.Length <= 1) return s;

        string pMax = "";
        for (int i=0;i<s.Length;i++)
        {
            palindromFromCenter(i-0, i, s, ref pMax);   // odd palindrom
            palindromFromCenter(i-1, i, s, ref pMax);   // even palindrom
        }
        return pMax;
    }

    private void palindromFromCenter(int l, int r, string s, ref string pMax)
    {
        while (l>=0 && r<s.Length && s[l] == s[r])
        {
            l--;
            r++;
        }
        string pTmp = s.Substring(l+1, r-l-1);
        if (pTmp.Length > pMax.Length) pMax = pTmp;
    }
}
// @lc code=end

