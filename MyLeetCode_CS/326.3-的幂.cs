/*
 * @lc app=leetcode.cn id=326 lang=csharp
 *
 * [326] 3的幂
 */

// @lc code=start
public class Solution {
    public bool IsPowerOfThree(int n) {
        // // Solution#1 - Recursion
        // if (n==1) return true;
        // if (n==0 || n%3 != 0) return false;
        // return IsPowerOfThree(n/3);

        // // Solution#2 - Iteration
        // while (n>1)
        // {
        //     if (n%3 != 0) break;
        //     n/=3;
        // }
        // return n==1;

        // Solution#3
        // max power of 3 is 3^19 within range of int
        int max3power = (int)Math.Pow(3, 19);
        return n>0 && max3power%n==0;
    }
}
// @lc code=end

