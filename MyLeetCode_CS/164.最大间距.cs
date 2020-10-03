/*
 * @lc app=leetcode.cn id=164 lang=csharp
 *
 * [164] 最大间距
 */

// @lc code=start
public class Solution {

    // Bucket sort, Time-O(3n), Space-O(2n)
    public int MaximumGap(int[] nums) {

        int i=0;    //iterator
        int len = nums.Length;
        if (len<2) return 0;

        // O(n) - find min and max in the array
        int min = int.MaxValue;
        int max = int.MinValue;
        for(i=0;i<len;i++)
        {
            min = Math.Min(min, nums[i]);
            max = Math.Max(max, nums[i]);
        }

        // O(n) - put into buckets
        int[][] buckets = new int[len][];
        int bucketSize = (int)Math.Max(1, Math.Ceiling((double)(max-min)/len));
        // Console.WriteLine(
        //     "min={0}, max={1}, len={2}, size={3}", 
        //     min, max, len, bucketSize);
        for(i=0;i<len;i++)
        {
            int loc = (nums[i]-min)/bucketSize;
            if (loc==len) loc--;

            if (buckets[loc] == null)
            {
                buckets[loc] = new int[] {nums[i], nums[i]};
            }
            else
            {
                buckets[loc][0] = Math.Min(buckets[loc][0], nums[i]);
                buckets[loc][1] = Math.Max(buckets[loc][1], nums[i]);
            }
        }
        //displayMatrix(buckets);

        // O(n) - find max gap among the buckets
        int maxGap = 0;
        int prevMax = int.MaxValue;
        for(i=0;i<len;i++)
        {
            if (buckets[i]==null) continue;     // skip empty bucket
            // max of the 3 possible numbers
            maxGap = Math.Max(maxGap, Math.Max( // existing gap
                    buckets[i][1]-buckets[i][0],// curr bucket max - curr bucket min
                    buckets[i][0]-prevMax));    // curr bucket min - prev bucket max
            prevMax = buckets[i][1];
        }
        return maxGap;
    }
    private void displayMatrix<T>(T[][] matrix)
    {
        foreach (T[] array in matrix)
        {
            if (array == null)
            {
                Console.WriteLine("[]");
            }
            else
            {
                string s = "";
                foreach (T element in array)
                {
                    s += string.Format("{0},", element);
                }
                Console.WriteLine("[{0}]", s.TrimEnd(','));
            }
        }
    }


    /*
    // Solution#1 - O(nlogn)
    public int MaximumGap(int[] nums) {
        int ans = 0;
        int len = nums.Length;
        if (len>=2)
        {
            Array.Sort(nums);   //O(nlogn)
            // displayArray(nums);
            for(int i=1;i<len;i++)
                ans = Math.Max(ans, nums[i]-nums[i-1]);
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
    */
}
// @lc code=end

