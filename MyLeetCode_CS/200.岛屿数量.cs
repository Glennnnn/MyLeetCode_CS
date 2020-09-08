/*
 * @lc app=leetcode.cn id=200 lang=csharp
 *
 * [200] 岛屿数量
 */

// @lc code=start
public class Solution {
    public int NumIslands(char[][] grid) {
        int ans = 0;
        for(int i=0;i<grid.Length;i++)
        {
            for (int j=0;j<grid[i].Length;j++)
            {
                if (grid[i][j] == '1')
                {
                    if (isDeadEnd(i,j, ref grid))
                    {
                        ans ++;
                        //displayMatrix(grid);
                    }
                }
            }
        }
        return ans;
    }

    private bool isDeadEnd(int i, int j, ref char [][] input)
    {
        if (i<0 || i==input.Length || 
            j<0 || j==input[i].Length)
            return true;    // OOR
        if (input[i][j]=='*' || input[i][j]=='0')
            return true;
        input[i][j] = '*'; // flag as visited
        return isDeadEnd(i+1,j, ref input) 
            && isDeadEnd(i-1,j, ref input) 
            && isDeadEnd(i,j+1, ref input) 
            && isDeadEnd(i,j-1, ref input);
    }

    private void displayMatrix<T>(T[][] grid)
    {
        string s = "";
        foreach(T[] row in grid)
        {
            foreach(T cell in row)
            {
                s += cell.ToString();
            }
            s += "\r\n";
        }
        Console.WriteLine(s);
    }
}
// @lc code=end

