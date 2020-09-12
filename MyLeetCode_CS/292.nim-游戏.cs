/*
 * @lc app=leetcode.cn id=292 lang=csharp
 *
 * [292] Nim 游戏
 */

// @lc code=start
public class Solution {
    public bool CanWinNim(int n) {
        return n%4>0;
        // // alternatively, use bit manipulation
        // return (n&3)!=0 || (n>>2)==0;
    }
}
// @lc code=end

