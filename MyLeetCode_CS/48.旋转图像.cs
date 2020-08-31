/*
 * @lc app=leetcode.cn id=48 lang=csharp
 *
 * [48] 旋转图像
 */

// @lc code=start
public class Solution {
    public void Rotate(int[][] matrix) {

        int n = matrix.Length;

        for (int r=0;r<n/2;r++)
        {
            for (int c=r;c<n-1-r;c++)
            {
                int tmp = matrix[r][c];

                matrix[r][c] = matrix[n-1-c][r];        // top = left
                matrix[n-1-c][r] = matrix[n-1-r][n-1-c];// left = bottom
                matrix[n-1-r][n-1-c] = matrix[c][n-1-r];// bottom = right
                matrix[c][n-1-r] = tmp;                 // right = top
            }
        }
        return;
    }
}
// @lc code=end

