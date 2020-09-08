/*
 * @lc app=leetcode.cn id=201 lang=csharp
 *
 * [201] 数字范围按位与
 */

// @lc code=start
public class Solution {
    public int RangeBitwiseAnd(int m, int n) {
        /*
        // Solution1
        int bit = 0;
        int m2 = m, n2 = n;
        while (m2 != n2)
        {
            bit ++;
            m2 >>= 1;
            n2 >>= 1;
            //Console.WriteLine("shift {0} bits: m={1}, n={2}", bit, m2, n2);
        }

        //Console.WriteLine("shift {0} bits: m={1}, n={2}", bit, m2, n2);
        m2 <<= bit;
        n2 <<= bit;

        return m2;
        */
        
        // Solution1b
        int bit=0;
        while (m != n)
        {
            bit ++;
            m >>=1;
            n >>=1;
        }
        return (m<<bit);

        /*
        // Solution2
        uint d = uint.MaxValue;
        while ((m&d) != (n&d)) d <<=1;
        return (int)(m&d);
        */
    }
}
// @lc code=end

