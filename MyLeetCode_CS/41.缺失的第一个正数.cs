/*
 * @lc app=leetcode.cn id=41 lang=csharp
 *
 * [41] 缺失的第一个正数
 */

// @lc code=start
public class Solution {
    public int FirstMissingPositive(int[] nums) {
        
        // Solution#2 - O(n), O(1)
        int len = nums.Length;
        for (int i=0;i<len;i++)
        {
            if (nums[i]>0 && nums[i]<=len && 
                swap(ref nums[nums[i]-1], ref nums[i]))
                i--;
        }

        int ans=1;
        for(ans=1;ans<=len;ans++)
        {
            if (ans!=nums[ans-1]) break;
        }
        return ans;



        /*
        // Solution#1 - O(n), O(n)
        int len = nums.Length;
        bool[] exist = new bool[len+1];

        for (int i=0;i<len;i++)
        {
            if (nums[i]>0 && nums[i] <= len)
                exist[nums[i]] = true;
        }
        displayArray(exist);
        for (int i=1;i<=len;i++)
        {
            if (exist[i] == false)
                return i;
        }
        return (len+1);
        */
    }
    private bool swap(ref int a, ref int b)
    {
        if (a!=b)
        {
            int tmp = a;
            a = b;
            b = tmp;
            return true;
        }
        else
            return false;
    }
    private void displayArray<T>(T[] array, string title="")
    {
        string s = title;
        foreach (T element in array)
        {
            s += element.ToString() + ',';
        }
        s = string.Format("[{0}]", s.TrimEnd(','));
        Console.WriteLine(s);
    }    
}
// @lc code=end

