/*
 * @lc app=leetcode.cn id=26 lang=csharp
 *
 * [26] 删除排序数组中的重复项
 */

// @lc code=start
public class Solution {
    public int RemoveDuplicates(int[] nums) {
        int j = 1;
        for (int i=1;i<nums.Length;i++)
        {
            if (nums[i] != nums[i-1])
            {
                if (j != i) 
                    nums[j] = nums[i];
                j ++;
            }
        }
        return (nums.Length == 0)? 0 : j;
    }
}
// @lc code=end

