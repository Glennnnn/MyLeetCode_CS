/*
 * @lc app=leetcode.cn id=53 lang=csharp
 *
 * [53] 最大子序和
 */

// @lc code=start
public class Solution {
    
    /*
    // Solution#1 - DP
    public int MaxSubArray(int[] nums) {
        int ans = int.MinValue;
        
        // use nums as dp array
        for(int i=0;i<nums.Length;i++)
        {
            if (i>0 && nums[i-1]>0) 
                nums[i] += nums[i-1];
            if (nums[i]>ans) 
                ans = nums[i];
        }
        //displayArray(nums);
        return ans;
    }
    private void displayArray<T>(T[] array)
    {
        string s = "";
        foreach (T element in array)
        {
            s += element.ToString() + ',';
        }
        s = string.Format("[{0}]", s.TrimEnd(','));
        Console.WriteLine(s);
    }
    */
    // Solution#1v2 - DP
    public int MaxSubArray(int[] nums) {
        int ans = int.MinValue;
        int tmp = 0;
        foreach (int n in nums)
        {
            // find maxsubarray ending with n
            tmp = Math.Max(tmp, 0) + n;
            // update max
            ans = Math.Max(tmp, ans);
        }
        return ans;
    }

}
// @lc code=end

