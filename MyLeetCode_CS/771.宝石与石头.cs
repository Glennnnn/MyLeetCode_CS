/*
 * @lc app=leetcode.cn id=771 lang=csharp
 *
 * [771] 宝石与石头
 */

// @lc code=start
public class Solution {
    // O(n), O(1)
    public int NumJewelsInStones(string J, string S) {
        // O(J.Length), O(52)
        bool[] isGem = new bool[52];    //[A~Za~z]
        foreach(char c in J)
        {
            int idx = (c<'a')?(int)(c-'A'):(int)(c-'a')+26;
            isGem[idx] = true;
        }
        // O(S.Length), O(1)
        int gemCount = 0;
        foreach(char s in S)
        {
            int idx = (s<'a')?(int)(s-'A'):(int)(s-'a')+26;
            if (isGem[idx]) gemCount++;
        }
        return gemCount;
    }
}
// @lc code=end

