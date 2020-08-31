/*
 * @lc app=leetcode.cn id=66 lang=csharp
 *
 * [66] 加一
 */

// @lc code=start
public class Solution {
    public int[] PlusOne(int[] digits) {

        int len = digits.Length;

        for (int i=len-1;i>=0;i--)
        {
            if (digits[i]==9)
            {
                digits[i] = 0;
            }
            else
            {
                digits[i]++;
                return digits;
            }
        }

        // carry=1 if not yet returned
        int[] newDigits = new int[len+1];
        newDigits[0] = 1;
        return newDigits;
    }
}
// @lc code=end

