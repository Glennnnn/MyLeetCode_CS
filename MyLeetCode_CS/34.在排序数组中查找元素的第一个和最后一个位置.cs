/*
 * @lc app=leetcode.cn id=34 lang=csharp
 *
 * [34] 在排序数组中查找元素的第一个和最后一个位置
 */

// @lc code=start
public class Solution {

    public int[] SearchRange(int[] nums, int target) {
        int[] ans = new int[]{-1,-1};
        int l=0,r=0;

        r = nums.Length-1;
        while (l<r)
        {
            int m = (l+r)/2;
            if (nums[m]<target) l = m+1;
            else r = m;
        }

        if (l>r || nums[l] != target)
            return ans;
        else
            ans[0] = l;

        r = nums.Length-1;
        while (l<r)
        {
            int m = (l+r+1)/2;
            if (nums[m] > target) r = m-1;
            else l = m;
        }

        ans[1] = r;

        return ans;
    }


    /*
    // solution #1
    public int[] SearchRange(int[] nums, int target) {
        int[] ans = new int[]{-1,-1};
        if (nums.Length>0)
        {
            ans[0] = BinarySearch(nums, target, 0, 0);
            ans[1] = BinarySearch(nums, target, ans[0], 1);
        }
        return ans;
    }

    private int BinarySearch (int[] nums, int target, int start, int opt)
    {
        if (start < 0) return -1;   // not exist

        int l=start, r = nums.Length-1;
        while (l<r)
        {
            int m = (l+r+opt)/2;
            if (nums[m]==target)
            {
                if (opt==0) r=m;    //find start position
                if (opt==1) l=m;    //find end   position
            }
            else if (nums[m] > target) r = m-1;
            else if (nums[m] < target) l = m+1;
        }
        return nums[l]==target? l:-1;
    }
    */
}
// @lc code=end

