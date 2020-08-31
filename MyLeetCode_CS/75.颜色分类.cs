/*
 * @lc app=leetcode.cn id=75 lang=csharp
 *
 * [75] 颜色分类
 */

// @lc code=start
public class Solution {
    public void SortColors(int[] nums) {

        int l=0,r=nums.Length-1;

        for(int i=0;i<=r;i++)
        {
            if (nums[i]==0)
            {
                swap(ref nums[i], ref nums[l++]);
            }
            else if (nums[i]==2)
            {
                // need to check what we swapped to the front
                swap(ref nums[i--], ref nums[r--]);
            }
            //displayArray(nums);            
        }
    }

    private void swap(ref int a, ref int b)
    {
        int c = a;
        a = b;
        b = c;
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

