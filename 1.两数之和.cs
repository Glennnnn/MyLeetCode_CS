/*
 * @lc app=leetcode.cn id=1 lang=csharp
 *
 * [1] 两数之和
 */

// @lc code=start
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        
        int[] ans = new int[]{-1, -1};

        Dictionary<int, int> dictionary = new Dictionary<int, int>();

        for(int i=0;i<nums.Length;i++)
        {
            int remainder = target-nums[i];

            if (dictionary.ContainsKey(remainder))
            {
               ans[0] = dictionary[remainder];
               ans[1] = i;
               break;
            }
            else
            {
                if (dictionary.ContainsKey(nums[i]))
                {
                    dictionary[nums[i]] = i;
                }
                else
                {
                    dictionary.Add(nums[i], i);
                }
            }
        }
        
        return ans;
    }
}
// @lc code=end

