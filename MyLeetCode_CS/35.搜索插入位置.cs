/*
 * @lc app=leetcode.cn id=35 lang=csharp
 *
 * [35] 搜索插入位置
 */

// @lc code=start
public class Solution {
    public int SearchInsert(int[] nums, int target) {
        // int l=0, r=nums.Length-1;
        // while (l<r)
        // {
        //     int m = (l+r)/2;
        //     if (nums[m]==target) return m;
        //     else if (nums[m]>target) r = m-1;
        //     else if (nums[m]<target) l = m+1;
        // }
        // return nums[l]<target? l+1 : l;

        int l=0, r = nums.Length;
        while (l<r)
        {
            int m = (l+r)/2;
            if (nums[m] >= target) r = m;
            if (nums[m] <= target) l = m+1;
        }
        //Console.WriteLine("[{0},{1}]", l,r);
        return r;
    }
}
// @lc code=end

