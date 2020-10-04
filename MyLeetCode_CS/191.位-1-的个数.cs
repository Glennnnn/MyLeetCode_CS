/*
 * @lc app=leetcode.cn id=191 lang=csharp
 *
 * [191] 位1的个数
 */

// @lc code=start
public class Solution {
    public int HammingWeight(uint n) {
        
        /*
        // Solution#1 - loop
        uint ans = 0;
        while (n>0)
        {
            ans += (n&1);
            n >>= 1;
        }
        return (int)ans;
        */

        /*
        // Solution#2 - recursion
        if (n==0) return 0;
        return (int)(n&1) + HammingWeight(n>>1);
        */

        // Solution#3 - O(1)
        const uint a = 0x55555555;  // 0101 0101
        const uint b = 0x33333333;  // 0011 0011
        const uint c = 0x0F0F0F0F;  // 0000 1111
        const uint d = 0x01010101;  // 0000 0001

        uint w = n;

        Console.WriteLine("{0:X8}", w);
        w = (w & a) + ((w>>1) & a);
        Console.WriteLine("{0:X8}", w);
        w = (w & b) + ((w>>2) & b);
        Console.WriteLine("{0:X8}", w);
        w = (w & c) + ((w>>4) & c);
        Console.WriteLine("{0:X8}", w);
        w = (w * d) >> 24;
        Console.WriteLine("{0:X8}", w);

        return (int)w;
    }
}
// @lc code=end

