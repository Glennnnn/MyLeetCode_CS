/*
 * @lc app=leetcode.cn id=461 lang=csharp
 *
 * [461] 汉明距离
 */

// @lc code=start
public class Solution {
    public int HammingDistance(int x, int y) {

        /*
        // solution#1
        int hd = 0;
        while (x>0 || y>0)
        {
            if ((x&1) != (y&1))
                hd++;
            x >>=1;
            y >>=1;
        }
        return hd;

        // solution#1b
        int hd = 0;
        x^=y;
        while (x>0)
        {
            hd += (x&1);
            x>>=1;
        }
        return hd;
        

        // solution#2
        x ^= y;
        x -= ((x>>1) & 0x55555555);
        x = (x & 0x33333333) + ((x>>2) & 0x33333333);
        x = ((x + (x>>4)) & 0x0F0F0F0F);
        x += (x>>8);
        x += (x>>16);
        return (x & 0x3F);
        */
        
        // solution#2b
        int z = x^y;
        z = (z & 0x55555555) + ((z >>  1) & 0x55555555);
		z = (z & 0x33333333) + ((z >>  2) & 0x33333333);
		z = (z & 0x0F0F0F0F) + ((z >>  4) & 0x0F0F0F0F);
		z = (z & 0x00FF00FF) + ((z >>  8) & 0x00FF00FF);
		z = (z & 0x0000FFFF) + ((z >> 16) & 0x0000FFFF);
		return (int)z;
    }
}
// @lc code=end

