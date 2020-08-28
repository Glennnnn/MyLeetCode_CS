/*
 * @lc app=leetcode.cn id=3 lang=csharp
 *
 * [3] 无重复字符的最长子串
 */

// @lc code=start
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int[] exist = new int[128];    // ASCII chars
        for(int i=0;i<exist.Length;i++) exist[i] = -1;

        int start=0;    // boundary of moving window
        int record = 0; // answer

        for (int i=0;i<s.Length;i++)
        {
            int idx = (int)s[i];
            if (start <= exist[idx]) 
                start = exist[idx]+1;
            exist[idx] = i;
            if (i+1-start > record) 
                record = i+1-start;
        }

        return record;
    }
}
// @lc code=end

