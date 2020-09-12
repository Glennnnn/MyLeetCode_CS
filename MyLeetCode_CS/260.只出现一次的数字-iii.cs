/*
 * @lc app=leetcode.cn id=260 lang=csharp
 *
 * [260] 只出现一次的数字 III
 */

// @lc code=start
public class Solution {
    public int[] SingleNumber(int[] nums) {

        // // Solution#1 - O(n), O(n)
        // HashSet<int> newSet = new HashSet<int>();
        // foreach(int num in nums)
        // {
        //     if (newSet.Contains(num))
        //         newSet.Remove(num);
        //     else
        //         newSet.Add(num);
        // }
        // return newSet.ToArray();

        // // Solution#2 - O(n), O(1)
        // int[] ans = new int[]{0,0};

        // if (nums != null && nums.Length>0)
        // {
        //     int xor = 0;
        //     foreach(int num in nums) 
        //         xor ^= num;
        //     // xor = ans[0] ^ ans[1]
        //     // use any bit that is different (i.e. ==1)
        //     // here we take the last '1'
        //     string s = "";
        //     s += string.Format("{0}^{1}", xor, -xor);
        //     xor = xor & (-xor);
        //     s += string.Format("={0}", xor);
        //     Console.WriteLine(s);
            // // choose the highest 1
            // int n = 0;
            // while(diff>1)
            // {
            //     diff>>=1;
            //     n++;
            // }
            // n = 1<<n;
            // // choose the lowest 1
            // int n=0;
            // while ((diff&1)==0)
            // {
            //     diff>>=1;
            //     n++;
            // }
            // n = 1<<n;
        //     // use the different bit to classify the array 
        //     // into two groups
        //     s = string.Format("[{0},{1}]->", ans[0], ans[1]);
        //     foreach(int num in nums)
        //     {
        //         if ((xor&num) == 0)
        //             ans[0] ^= num;
        //         else
        //             ans[1] ^= num;
        //         s += string.Format("[{0},{1}]->", ans[0], ans[1]);
        //     }
        //     Console.WriteLine(s+"Done");
        // }
        // return ans;

        // Solution#2b - O(n), O(1)
        int[] ans = new int[]{0,0};

        if (nums != null && nums.Length>0)
        {
            int diff = 0;
            foreach(int num in nums) 
                diff ^= num;
            int n = diff & (-diff);
            //Console.WriteLine("[{0},{1}]", diff, n);
            foreach(int num in nums)
            {
                if ((n&num)==0)
                    ans[0] ^= num;
                else
                    ans[1] ^= num;
            }
        }
        return ans;        
    }
}
// @lc code=end

