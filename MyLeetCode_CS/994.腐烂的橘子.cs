/*
 * @lc app=leetcode.cn id=994 lang=csharp
 *
 * [994] 腐烂的橘子
 */

// @lc code=start
public class Solution {
    int R,C;
    Queue<int[]> queue = new Queue<int[]>(); // queue of infection
    int freshCount = 0;

    public int OrangesRotting(int[][] grid) {
        R = grid.Length;
        C = grid[0].Length;
        
        // O(n^2)
        for (int r=0;r<R;r++)
        {
            for (int c=0;c<C;c++)
            {
                if (grid[r][c]==2)
                    queue.Enqueue(new int[]{r,c});
                if (grid[r][c]==1)
                    freshCount++;
            }
        }
        
        // O(n^2) - pass each cell at most once
        int numRounds=0;
        int numInfection=queue.Count;
        do
        {
            for(int k=0;k<numInfection;k++)
            {
                int[] rotten = queue.Dequeue();
                infect(rotten[0]-1, rotten[1], grid);
                infect(rotten[0]+1, rotten[1], grid);
                infect(rotten[0], rotten[1]-1, grid);
                infect(rotten[0], rotten[1]+1, grid);
            }
            //displayQ();
            numInfection = queue.Count;
            numRounds ++;
        } while (numInfection > 0);

        if (freshCount>0)
            return -1;
        else
            return numRounds-1;
    }
    private void infect(int r, int c, int[][] grid)
    {
        if (r<0 || r>=R) return;
        if (c<0 || c>=C) return;
        if (grid[r][c]==1)  // was a fresh orange
        {
            int[] newInfection = new int[]{r,c};
            if (!queue.Contains(newInfection))
            {
                queue.Enqueue(new int[]{r,c});
                grid[r][c]=2;   // is now rotten
                freshCount --;
            }
        }
    }    
    private void displayQ()
    {
        int[][] array = new int[queue.Count][];
        queue.CopyTo(array, 0);

        string s = "";
        foreach (int[] coor in array)
        {
            s += string.Format("[{0},{1}],", coor[0], coor[1]);
        }
        Console.WriteLine(s.TrimEnd(','));
    }




    /*
    // Solution#1
    // O(3*n^2), where input is n^2
    int R,C;
    public int OrangesRotting(int[][] grid) {
        R = grid.Length;
        C = grid[0].Length;
        int r,c;    // iterators
        int numInfection, numRounds=0;

        do {
            // reset
            numInfection = 0;
            // flag infection
            for (r=0;r<R;r++)
            {
                for (c=0;c<C;c++)
                {
                    if (grid[r][c]==2)
                    {
                        infect(r-1,c, ref grid);
                        infect(r+1,c, ref grid);
                        infect(r,c-1, ref grid);
                        infect(r,c+1, ref grid);
                    }
                }
            }
            // turns flag into infected
            for (r=0;r<R;r++)
            {
                for (c=0;c<C;c++)
                {
                    if (grid[r][c]==-1)
                    {
                        grid[r][c] = 2;
                        numInfection ++;
                    }
                }
            }
            if (numInfection > 0) numRounds ++;
        } while (numInfection > 0);
        
        // check if any remaining unrotten orange
        for (r=0;r<R;r++)
        {
            for (c=0;c<C;c++)
            {
                if (grid[r][c]==1)
                {
                    return -1;
                }
            }
        }
        return numRounds;
    }

    private void infect(int r, int c, ref int[][] grid)
    {
        if (r<0 || r>=R) return;
        if (c<0 || c>=C) return;
        if (grid[r][c]==1)  // is a fresh orange
            grid[r][c]=-1;  // flag as to be infected
    }
    */
}
// @lc code=end

