/*
 * @lc app=leetcode.cn id=15 lang=csharp
 *
 * [15] 三数之和
 */

// @lc code=start
public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        int len = nums.Length;
        List<IList<int>> ans = new List<IList<int>>();
        if (nums==null || len<3) return ans;

        Array.Sort(nums);   // O(nlogn)
        // displayArray(nums);

        int a=0,b=0,c=0;
        while (a<len-2 && nums[a]<=0)   // sum>0 if the smallest of three is >0
        {
            b=a+1;
            c=len-1;
            while (b<c)
            {
                int tmpSum = nums[a]+nums[b]+nums[c];
                if (tmpSum == 0)
                    ans.Add(new List<int>(){nums[a], nums[b], nums[c]});
                if (tmpSum>=0) 
                    while (b<c && nums[c]==nums[--c]);  // skip repeated c
                if (tmpSum<=0) 
                    while (b<c && nums[b]==nums[++b]);  // skip repeated b
            }
            while (a<len-2 && nums[a]==nums[++a]);  // skip repeated a
        }
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

}
// @lc code=end

