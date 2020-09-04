/*
 * @lc app=leetcode.cn id=128 lang=csharp
 *
 * [128] 最长连续序列
 */

// @lc code=start
public class Solution {

    // Solution#2 - Time: O(3n) Space: O(1)
    public int LongestConsecutive(int[] nums) {
        // convert array to hash set
        // first scan O(n)
        HashSet<int> newSet = new HashSet<int>();
        foreach(int num in nums)
            newSet.Add(num);

        // scan through the hash set
        // worst case: each number is passed by two times
        // once by outter loop and once by inner loop
        // each pass is O(1), so sum up to O(2n)
        int maxStreak = 0;
        foreach(int num in newSet)
        {
            // start inner loop only if this is the beginning of a series
            if (!newSet.Contains(num-1))
            {
                int currStreak = 0;
                while (newSet.Contains(num + ++currStreak));
                maxStreak = Math.Max(maxStreak, currStreak);
            }
        }
        return maxStreak;
    }

    /*
    // Solution#1 - Time: O(nlogn) Space: O(1)
    public int LongestConsecutive(int[] nums) {
        
        if (nums.Length==0) return 0;

        int ans = 1;
        Array.Sort(nums);
        //displayArray(nums);
        
        int tmpLen = 1;
        for (int i=1;i<nums.Length;i++)
        {
            if (nums[i] == nums[i-1]+1)
            {
                tmpLen ++;
            }
            else if (nums[i] == nums[i-1])
            {
                // do nothing
            }
            else
            {
                ans = Math.Max(tmpLen, ans);
                tmpLen = 1;
            }
        }
        ans = Math.Max(tmpLen, ans);
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
}
// @lc code=end

