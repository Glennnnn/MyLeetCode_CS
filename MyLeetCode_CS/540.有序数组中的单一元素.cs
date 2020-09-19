/*
 * @lc app=leetcode.cn id=540 lang=csharp
 *
 * [540] 有序数组中的单一元素
 */

// @lc code=start
public class Solution {
    public int SingleNonDuplicate(int[] nums) {

        int len = nums.Length;  // must be odd number
        int l=0, r=len-1, m=-1;    // always even until last

        while (l<r)
        {
            m = (l+r)/2;
            //Console.Write("[{0},{1},{2}]->", l, m, r);
            if (nums[m] != nums[m-1]) 
            {
                if ((m&1)==0) l = m;
                else r = m-1;          
            }
            if (nums[m] != nums[m+1]) 
            {
                if ((m&1)==0) r = m;
                else l = m+1;
            }
        }
        //Console.WriteLine("[{0},{1},{2}]", l, m, r);
        return nums[l];
    }
}
// @lc code=end

