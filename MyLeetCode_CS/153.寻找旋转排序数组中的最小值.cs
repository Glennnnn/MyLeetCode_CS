/*
 * @lc app=leetcode.cn id=153 lang=csharp
 *
 * [153] 寻找旋转排序数组中的最小值
 */

// @lc code=start
public class Solution {
    public int FindMin(int[] nums) {
        // // Solution#1 - Linear O(n)
        // for(int i=1;i<nums.Length;i++)
        // {
        //     if (nums[i]<nums[i-1])
        //         return nums[i];
        // }
        // return nums[0];

        // Solution#2 - Binary O(logn)
        int l=0, r=nums.Length-1;

        while (l<r)
        {
            int m = (l+r)/2;
            //Console.WriteLine("{0}-{1}-{2}", l,m,r);
            if (nums[m] < nums[r]) 
                r=m;
            else if (nums[m] >= nums[l]) 
                l=m+1;
        }
        return nums[l];

    }
}
// @lc code=end

