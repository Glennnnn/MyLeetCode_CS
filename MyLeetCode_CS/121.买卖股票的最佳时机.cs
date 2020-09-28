/*
 * @lc app=leetcode.cn id=121 lang=csharp
 *
 * [121] 买卖股票的最佳时机
 */

// @lc code=start
public class Solution {

    // Solution#2 - DP
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
                buy  = - prices[i]; // buy at today's price
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


    /*
    // Solution#1 - O(n), O(n)
    public int MaxProfit(int[] prices) {
        int len = prices.Length;
        int[] profit = new int[len];
        
        int ans = 0;
        int buyIn = int.MaxValue;
        for(int i=0;i<len;i++)
        {
            if (prices[i]<buyIn)
            {
                buyIn = prices[i];
                profit[i] = 0;
            }
            else
            {
                profit[i] = prices[i]-buyIn;
            }
            ans = Math.Max(ans, profit[i]);
        }
        //displayArray(profit);
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


