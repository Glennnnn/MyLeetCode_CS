/*
 * @lc app=leetcode.cn id=1137 lang=csharp
 *
 * [1137] 第 N 个泰波那契数
 */

// @lc code=start
public class Solution {

    // Solution#1 - DP
    // O(n), O(1)
    public int Tribonacci(int n) {
        int[] dp = new int[]{0,1,1};
        while(n >= 3)
        {
            int sum = dp[0]+dp[1]+dp[2];
            dp[0] = dp[1];
            dp[1] = dp[2];
            dp[2] = sum;
            // Console.WriteLine(
            //     "n={0}: [{1},{2},{3}]", n, dp[0],dp[1],dp[2]);
            n--;
        }
        return dp[n];
    }
    
    // // Recursion
    // // time limit exceeded
    // public int Tribonacci(int n) {
    //     if (n==0) return 0;
    //     if (n==1) return 1;
    //     if (n==2) return 1;
    //     return Tribonacci(n-1)+Tribonacci(n-2)+Tribonacci(n-3);
    // }
}
// @lc code=end

