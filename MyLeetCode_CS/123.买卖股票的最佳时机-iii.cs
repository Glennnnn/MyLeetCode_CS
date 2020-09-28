/*
 * @lc app=leetcode.cn id=123 lang=csharp
 *
 * [123] 买卖股票的最佳时机 III
 */

// @lc code=start
public class Solution {
    // Solution#1 - DP
    public int MaxProfit(int[] prices) {
        int k =2;
        int len = prices.Length;
        if (len<2) return 0;
        int[,,] dp = new int[len,k+1,2];

        for(int i=0;i<len;i++)
        {
            for (int j=k;j>0;j--)
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
                    wait = dp[i-1,j,0];  // do nothing, carried in from prev day
                    sell = dp[i-1,j,1] + prices[i];     // sold at today's price
                    hold = dp[i-1,j,1];  // do nothing, carried in from prev day
                    buy  = dp[i-1,j-1,0] - prices[i];   // buy at today's price
                }
                dp[i,j,0] = Math.Max(wait, sell); // end today with NO stock
                dp[i,j,1] = Math.Max(hold, buy);  // end today with stock
            }
        }
        // display3DArray(dp);
        return dp[len-1, k, 0];
    }
    private void display3DArray<T>(T[,,] array){
        string s = "";
        for(int i=0;i<array.GetLength(0);i++)
        {
            for(int j=0;j<array.GetLength(1);j++)
            {
                s += string.Format("{0}/{1}, ", array[i,j,0], array[i,j,1]);
            }
            s += "\r\n";
        }
        Console.Write(s);
    }
}
// @lc code=end

