/*
 * @lc app=leetcode.cn id=189 lang=csharp
 *
 * [189] 旋转数组
 */

// @lc code=start
public class Solution {
    public void Rotate(int[] nums, int k) {

        // Solution#1 - O(n), O(1)
        int len = nums.Length;
        k %= len;
        
        Array.Reverse(nums, 0, len);
        Array.Reverse(nums, 0, k);
        Array.Reverse(nums, k, len-k);

        /*
        // Solution#2 - O(k*n), O(1)
        int len = nums.Length;
        k %= len;

        for (int i=0;i<k;i++)
        {
            int tmp = nums[len-1];
            for(int j=len-1;j>0;j--)
            {
                nums[j] = nums[j-1];
            }
            nums[0] = tmp;
            //displayArray(nums);
        }
        */
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

