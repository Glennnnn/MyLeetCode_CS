/*
 * @lc app=leetcode.cn id=283 lang=csharp
 *
 * [283] 移动零
 */

// @lc code=start
public class Solution {
    public void MoveZeroes(int[] nums) {
        
        int len = nums.Length;
        int j=0;

        for(int i=0;i<len;i++)
        {
            while (j<len && nums[j]==0) j++;    // find next non-zero
            if (j==len) nums[i] = 0;            // ran out of non-zeros
            else nums[i] = nums[j++];           // consume
            // displayArray(nums);
        }
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
}
// @lc code=end

