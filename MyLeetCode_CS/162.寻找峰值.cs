/*
 * @lc app=leetcode.cn id=162 lang=csharp
 *
 * [162] 寻找峰值
 */

// @lc code=start
public class Solution {
    public int FindPeakElement(int[] nums) {
        /*
        因为数组两端都是负无穷，
        这意味着从nums[0]开始，
        一直找到有个值nums[i]>nums[i+1]，
        那么数组肯定有一个峰值，
        我们将他的索引返回就行了。
        */
        int l=0, r = nums.Length-1;
        while (l<r)
        {
            int m = (l+r)/2;
            if (nums[m]>nums[m+1]) 
                r = m;
            else 
                l = m+1;
        }
        return l;
    }
}
// @lc code=end

