/*
 * @lc app=leetcode.cn id=209 lang=csharp
 *
 * [209] 长度最小的子数组
 */

// @lc code=start
public class Solution {
    public int MinSubArrayLen(int s, int[] nums) {

        // Solution#2 - two pointers 
        // O(n) O(1)
        int len = nums.Length;
        int l=0,r=0;
        int ans = len+1;
        int slidingSum = 0;

        while (r<len)
        {
            // execute at least once
            do
            {
                slidingSum += nums[r++];
            } while (slidingSum<s && r<len);
            // check if left marging is movable
            while (slidingSum-nums[l]>=s && l<r)
            {
                slidingSum-=nums[l++];
            }
            // update answer if meets all criteria
            if (slidingSum>=s)
                ans = Math.Min(ans, r-l);
        }
        return (ans>len)?0:ans;


        /*
        // Solution#1b
        // O(n), O(n)
        int len = nums.Length;
        if (len==0) return 0;           // empty input

        int[] sums = new int[len];  // cumulative sums
        int j = 0;      // starting index
        int ans = len+1;// beyond max possible
        for(int i=0;i<len;i++)
        {
            sums[i] = nums[i];
            if (i>0) sums[i] += sums[i-1];

            if (sums[i]>=s)
            {
                while (j<i && sums[i]-sums[j]>=s) j++;
                ans = Math.Min(ans, i-j+1);
            }
        }
        // displayArray(sums, "sums");
        // displayArray(lens, "lens");
        return (ans>len)?0:ans;
        */

        /*
        // Solution#1 - O(2n), O(2n)
        int len = nums.Length;
        if (len==0) return 0;           // empty input

        int[] sums = new int[len];  // cumulative sums
        for(int i=0;i<len;i++)
        {
            sums[i] = nums[i];
            if (i>0) sums[i] += sums[i-1];
        }
        if (sums[len-1]<s) return 0;    // sum of whole array < target
        if (sums[len-1]==s) return len; // sum of whole array ==target

        int ans = len;  // max possible
        int j = 0;  // starting index
        int[] lens = new int[len];
        for(int i=0;i<len;i++)
        {
            if (sums[i]<s)
            {
                lens[i] = len;
            }
            else
            {
                while (j < i && sums[i]-sums[j]>=s) j++;
                lens[i] = i-j+1;
                ans = Math.Min(ans, lens[i]);
            }
        }

        return ans;
        */
    }
    // private void displayArray<T>(T[] array, string title = "")
    // {
    //     string s = "";
    //     foreach (T element in array)
    //     {
    //         s += element.ToString() + ',';
    //     }
    //     s = string.Format("[{0}]", s.TrimEnd(','));
    //     if (!string.IsNullOrEmpty(title))
    //         s = string.Format("{0}:{1}", title, s);
    //     Console.WriteLine(s);
    // }    
}
// @lc code=end

