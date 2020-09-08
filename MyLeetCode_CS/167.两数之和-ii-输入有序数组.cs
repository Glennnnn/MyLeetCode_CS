/*
 * @lc app=leetcode.cn id=167 lang=csharp
 *
 * [167] 两数之和 II - 输入有序数组
 */

// @lc code=start
public class Solution {
    public int[] TwoSum(int[] numbers, int target) {

        int[] ans = new int[]{-1, -1};
        int l=0, r=numbers.Length-1;

        while (l<r)
        {
            int tmpSum = numbers[l]+numbers[r];
            if (tmpSum==target)
            {
                ans[0] = l+1;
                ans[1] = r+1;
                break;
            }
            else if (tmpSum<target) l++;
            else if (tmpSum>target) r--;
        }
        return ans;
    }
}
// @lc code=end

