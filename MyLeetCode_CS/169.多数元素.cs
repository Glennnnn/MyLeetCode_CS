/*
 * @lc app=leetcode.cn id=169 lang=csharp
 *
 * [169] 多数元素
 */

// @lc code=start
public class Solution {
    public int MajorityElement(int[] nums) {

        // Solution#2, Boyer–Moore majority vote algorithm
        // O(n), O(1)
        int candidate = 0, count=0;
        foreach (int num in nums)
        {
            if (count==0) candidate = num;
            count += (num == candidate?1:-1);
        }
        return candidate;


        /*
        // Solution#1
        Array.Sort(nums);   //O(nlogn)~O(n2)
        return nums[nums.Length/2];
        */
    } 
}
// @lc code=end

