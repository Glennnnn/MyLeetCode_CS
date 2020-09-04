/*
 * @lc app=leetcode.cn id=137 lang=csharp
 *
 * [137] 只出现一次的数字 II
 */

// @lc code=start
public class Solution {
    public int SingleNumber(int[] nums) {

        //solution1
        int ones=0, twos=0;

        foreach (int num in nums)
        {
            ones = (ones ^ num) & (~twos);
            twos = (twos ^ num) & (~ones);
        }

        return ones;


        // //solution1-b
        // int ones=0, twos=0, threes=0;
        
        // foreach(int num in nums)
        // {
        //     twos = twos | (ones & num);
        //     ones = ones ^ num;
        //     threes = ones & twos;
        //     ones = ones & ~threes;
        //     twos = twos & ~threes;
        // }
        // return ones;
    }
}
// @lc code=end

