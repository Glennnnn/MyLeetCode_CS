/*
 * @lc app=leetcode.cn id=172 lang=csharp
 *
 * [172] 阶乘后的零
 */

// @lc code=start
public class Solution {
    public int TrailingZeroes(int n) {
        /*
        Count number of 5,25,125,525,etc
        (There's always more 2,4,6,8,... to pair with)
        */
        int ans = 0;
        while (n>=5)
        {
            n/=5;
            ans += n;
        }
        return ans;

    }
}
// @lc code=end

