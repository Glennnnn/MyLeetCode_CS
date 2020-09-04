/*
 * @lc app=leetcode.cn id=136 lang=csharp
 *
 * [136] 只出现一次的数字
 */

// @lc code=start
public class Solution {
    public int SingleNumber(int[] nums) {

        int ans = 0;
        foreach (int num in nums)
            ans ^= num;
        return ans;
    }
}
// @lc code=end

