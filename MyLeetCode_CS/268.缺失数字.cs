/*
 * @lc app=leetcode.cn id=268 lang=csharp
 *
 * [268] 缺失数字
 */

// @lc code=start
public class Solution {
    public int MissingNumber(int[] nums) {

        /*
        // Solution#1
        int n = nums.Length;
        int ans = n;
        for(int i=0;i<nums.Length;i++)
        {
            ans ^= nums[i];
            ans ^= i;
        }
        return ans;

        // ans = (0...n)^(array)
        // where array = (0...n) with one missing element
        */

        // Solution#2
        int n = nums.Length;
        int sum1 = n*(n+1)/2;
        int sum2 = nums.Sum();
        return (sum1-sum2);
    }
}
// @lc code=end

