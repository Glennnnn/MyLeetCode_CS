/*
 * @lc app=leetcode.cn id=122 lang=csharp
 *
 * [122] 买卖股票的最佳时机 II
 */

// @lc code=start
public class Solution {
    // Solution#1 - DP
    public int MaxProfit(int[] prices) {
        int len = prices.Length;
        if (len<2) return 0;
        int[,] dp = new int[len,2];

        for(int i=0;i<len;i++)
        {
            int wait, sell, hold, buy;
            if (i==0)
            {
                wait = 0;               // do nothing, no prev day
                sell = int.MinValue;    // impossible
                hold = int.MinValue;    // impossible
                buy  = - prices[i];     // buy at today's price
            }
            else
            {
                wait = dp[i-1, 0];  // do nothing, carried in from prev day
                sell = dp[i-1, 1] + prices[i];  // sold at today's price
                hold = dp[i-1, 1];  // do nothing, carried in from prev day
                buy  = dp[i-1, 0] - prices[i];  // buy at today's price
            }
            dp[i,0] = Math.Max(wait, sell); // end today with NO stock
            dp[i,1] = Math.Max(hold, buy);  // end today with stock
        }
        // display2DArray(dp);
        return dp[len-1, 0];
    }
    private void display2DArray<T>(T[,] array){
        string s0 = "", s1 = "";
        for(int i=0;i<array.GetLength(0);i++)
        {
            s0 += array[i,0].ToString() + ",";
            s1 += array[i,1].ToString() + ",";
        }
        Console.WriteLine(s0.TrimEnd(','));
        Console.WriteLine(s1.TrimEnd(','));
    }
}
// @lc code=end

