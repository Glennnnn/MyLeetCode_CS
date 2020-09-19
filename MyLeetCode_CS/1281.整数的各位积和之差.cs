/*
 * @lc app=leetcode.cn id=1281 lang=csharp
 *
 * [1281] 整数的各位积和之差
 */

// @lc code=start
public class Solution {
    public int SubtractProductAndSum(int n) {
        ulong prod = 1;
        ulong sum = 0;
        while (n>0)
        {
            prod *= (ulong)(n%10);
            sum += (ulong)(n%10);
            n /= 10;
        }
        return (int)(prod-sum);

    }
}
// @lc code=end

