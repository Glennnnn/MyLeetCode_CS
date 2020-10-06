/*
 * @lc app=leetcode.cn id=877 lang=csharp
 *
 * [877] 石子游戏
 */

// @lc code=start
public class Solution {
    public bool StoneGame(int[] piles) {

        // Solution#2 - Cheat
        // Three conditions makes Alex always winning:
        // 1) Alex is the first player
        // 2) Even number of piles
        // 3) Total amount of stones is odd number
        // Alex picks in any order. 
        // If he ends up losing, do the opposite picks.
        // he can repick ALL opposite picks due to #2
        return true;    // the first player always wins

        /*
        // Solution#1 - DP
        // O(n2), O(n2)
        // dp[i][j] 表示当剩下的石子堆为下标 ii 到下标 jj 时，
        // 当前玩家与另一个玩家的石子数量之差的最大值
        // state transfer equation
        //     dp[i,j] = Math.Max(
        //         piles[i] - dp[i+1, j],
        //         piles[j] - dp[i, j-1]
        //     )
        // need only to fill the right upper triangle
        // final answer would be (dp[0, len-1] > 0)
        
        int len = piles.Length;
        int[,] dp = new int[len,len];
        for (int i=len-1; i>=0; i--)
        {
            for (int j=i; j<len; j++)
            {
                if (j==i)
                    dp[i,j] = piles[i];
                else
                    dp[i,j] = Math.Max(
                        piles[i] - dp[i+1, j],
                        piles[j] - dp[i, j-1]);
            }
        }
        //displayMatrix(dp);
        return dp[0, len-1] > 0;
        */

        /*
        // Solution#1v2 - DP
        // O(n2), O(n)
        // dp[i][j] 表示当剩下的石子堆为下标 ii 到下标 jj 时，
        // 当前玩家与另一个玩家的石子数量之差的最大值
        // state transfer equation
        //     dp[i,j] = Math.Max(
        //         piles[i] - dp[i+1, j],
        //         piles[j] - dp[i, j-1]
        //     )
        // need only to fill the right upper triangle
        // final answer would be (dp[0, len-1] > 0)
        
        int len = piles.Length;
        int[] dp = new int[len];

        for(int i=0;i<len;i++)
            dp[i] = piles[i];

        for(int i=len-2;i>=0;i--)
        {
            for (int j=i+1;j<len;j++)
            {
                dp[j] = Math.Max(
                    piles[i] - dp[j],
                    piles[j] - dp[j-1]);
                //displayArray(dp);
            }
            //Console.WriteLine();
        }

        return dp[len-1]>0;
        */
    }
    private void displayMatrix<T>(T[,] grid)
    {
        string s = "";
        for(int i=0;i<grid.GetLength(0);i++)
        {
            for (int j=0;j<grid.GetLength(1);j++)
            {
                s += string.Format("{0} ", grid[i,j]);
            }
            s += "\r\n";
        }
        Console.WriteLine(s);
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

