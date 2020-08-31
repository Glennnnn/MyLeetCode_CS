/*
 * @lc app=leetcode.cn id=58 lang=csharp
 *
 * [58] 最后一个单词的长度
 */

// @lc code=start
public class Solution {
    public int LengthOfLastWord(string s) {

        s = s.TrimEnd();
        int ans = 0;

        for(int i=s.Length-1;i>=0;i--)
        {
            if (s[i]==' ') break;
            else ans++;
        }
        return ans;
    }
}
// @lc code=end

