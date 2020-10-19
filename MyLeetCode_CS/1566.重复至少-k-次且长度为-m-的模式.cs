/*
 * @lc app=leetcode.cn id=1566 lang=csharp
 *
 * [1566] 重复至少 K 次且长度为 M 的模式
 */

// @lc code=start
public class Solution {
    public bool ContainsPattern(int[] arr, int m, int k) {
        for (int i=0;i<=arr.Length-m*k;i++)
        {
            bool match = true;   // assumption
            for (int j=0;j<m*k && match;j++)
            {
                match = arr[i+j%m] == arr[i+j];
            }
            if (match) return true;
        }
        return false;
    }
}
// @lc code=end

