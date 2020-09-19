/*
 * @lc app=leetcode.cn id=1351 lang=csharp
 *
 * [1351] 统计有序矩阵中的负数
 */

// @lc code=start
public class Solution {
    public int CountNegatives(int[][] grid) {
        // Solution#2 - BinarySearch
        // best: O(logm*logn), worst: O(m*logn)
        int count = 0;
        int m=grid.Length;
        int n=grid[0].Length;

        int rowTop=0, rowBot=m;
        while (rowTop < rowBot)
        {
            int rowMid = (rowTop + rowBot)/2;
            if (grid[rowMid][0]>=0)
                rowTop = rowMid+1;
            else
                rowBot = rowMid;
        }
        //Console.WriteLine("top={0}, bottom={1}", rowTop, rowBot);
        // everything below will be 0
        count += (m-rowTop)*n;
        

        for(int i=0;i<rowTop;i++)
        {
            int colL=0, colR=n;
            while (colL < colR)
            {
                int colM = (colL + colR)/2;
                if (grid[i][colM]>=0)
                    colL = colM+1;
                else
                    colR = colM;
            }
            //Console.WriteLine("Row{0}: left={1}, right={2}", i, colL, colR);
            // everything to the right will be 0
            count += (n-colL);
        }
        return count;


        /*
        // Solution#1 - O(n^2)
        int count = 0;
        int m=grid.Length;
        int n=grid[0].Length;
        
        for(int i=0;i<m;i++)
        {
            if (grid[i][0]<0)
            {
                // everything below will be 0
                count += (m-i)*n;
                break;
            }
            for (int j=0;j<n;j++)
            {
                if (grid[i][j]<0)
                {
                    // everything to the right will be 0
                    count += (n-j);
                    break;
                }
            }
        }
        return count;
        */
    }
}
// @lc code=end

