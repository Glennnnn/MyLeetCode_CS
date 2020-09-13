/*
 * @lc app=leetcode.cn id=342 lang=csharp
 *
 * [342] 4的幂
 */

// @lc code=start
public class Solution {
    public bool IsPowerOfFour(int num) {
        /*
        // Solution#1 - loop
        // 1,100,10000,1000000, etc..
        // always 1+n tailing 0s, where n is even nubmer
        if (num<=0) return false;

        int n = 0;  // number of tailing zeros
        while((num&1)==0)
        {
            num>>=1;
            n++;
        }        
        return n%2==0 && num==1;
        */

        // Solution#2
        // exclude antyhing less than 4^0
        if (num<=0) return false;
        // if num is not power of 2
        if ((num & (num-1)) != 0) 
            return false;
        //1010101010101010101010101010101
        const int magic = 0x55555555;
        if ((num & magic) == num)
            return true;
        
        return false;
    }
}
// @lc code=end

