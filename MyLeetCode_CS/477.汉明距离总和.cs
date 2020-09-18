/*
 * @lc app=leetcode.cn id=477 lang=csharp
 *
 * [477] 汉明距离总和
 */

// @lc code=start
public class Solution {

    public int TotalHammingDistance(int[] nums) {
        int ans = 0;
        int len = nums.Length;
        
        int[] bitCount = new int[32];   //int is 32 bits

        for(int i=0;i<len;i++)
        {
            for(int j=0;j<bitCount.Length;j++)
            {
                bitCount[j] += (nums[i]&1);
                nums[i] >>=1;
                if (nums[i]==0) break;
            }
        }

        foreach(int countOfOnes in bitCount)
        {
            ans += countOfOnes*(len-countOfOnes);
        }
        return ans;
    }


    /*
    // Solution#1 - O(n2)
    public int TotalHammingDistance(int[] nums) {

        int ans = 0;
        int len = nums.Length;

        //string s = "0";
        for(int i=0;i<len;i++)
        {
            for(int j=i+1;j<len;j++)
            {
                ans += HammingDistance(nums[i], nums[j]);
                //s += string.Format("->{0}", ans);
            }
        }
        //Console.WriteLine(s);
        return ans;
    }
    private int HammingDistance(int x, int y)
    {
        int hd = 0;
        int z = x^y;
        while (z>0)
        {
            hd += (z&1);
            z >>=1;
        }
        return hd;
    }
    */
}
// @lc code=end

