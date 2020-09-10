/*
 * @lc app=leetcode.cn id=231 lang=csharp
 *
 * [231] 2的幂
 */

// @lc code=start
public class Solution {
    public bool IsPowerOfTwo(int n) {
        // Solution#2
        return (n>0 && (n & (n-1))==0);

        /*
        // Solution#1
        while (n>1)
        {
            if ((n&1) == 1) 
                return false;
            else 
                n>>=1;
        }
        return n==1;
        */
    }
}
// @lc code=end

