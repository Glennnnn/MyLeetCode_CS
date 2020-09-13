/*
 * @lc app=leetcode.cn id=344 lang=csharp
 *
 * [344] 反转字符串
 */

// @lc code=start
public class Solution {
    public void ReverseString(char[] s) {
        int l=0, r=s.Length-1;
        while (l<r)
        {
            // must pass by ref
            swap(ref s[l++], ref s[r--]);
        }
    }
    private void swap(ref char a, ref char b)
    {
        char c = a;
        a = b;
        b = c;
    }
}
// @lc code=end

