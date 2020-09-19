/*
 * @lc app=leetcode.cn id=695 lang=csharp
 *
 * [695] 岛屿的最大面积
 */

// @lc code=start
public class Solution {
    public int MaxAreaOfIsland(int[][] grid) {
        // Solution - DFS
        // O(n2), O(1), where n=grid.Length
        int ans = 0;
        for (int i=0;i<grid.Length;i++)
        {
            for (int j=0;j<grid[i].Length;j++)
            {
                ans = Math.Max(ans, DFS(i,j, ref grid));
            }
        }
        return ans;
    }

    private int DFS(int r, int c, ref int[][] grid)
    {
        if (r<0 || r==grid.Length || 
            c<0 || c==grid[r].Length)   // OOR
            return 0;
        else if (grid[r][c] < 1)        // water, or visited
            return 0;
        else
        {
            grid[r][c] = -1;            // flag as visited
            return 1 + 
                DFS(r+1, c, ref grid) + 
                DFS(r-1, c, ref grid) + 
                DFS(r, c+1, ref grid) + 
                DFS(r, c-1, ref grid);
        }
    }
}
// @lc code=end

