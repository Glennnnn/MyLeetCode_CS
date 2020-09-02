/*
 * @lc app=leetcode.cn id=120 lang=csharp
 *
 * [120] 三角形最小路径和
 */

// @lc code=start
public class Solution {

    // Solution#3 - DP
    public int MinimumTotal(IList<IList<int>> triangle) {

        int n = triangle.Count;
        for (int i=1;i<n;i++)
        {
            int m = triangle[i].Count;
            for (int j=0;j<m;j++)
            {
                int prevRow_prevCol = (j>0)? triangle[i-1][j-1]:int.MaxValue;
                int prevRow_currCol = (j<m-1)? triangle[i-1][j]:int.MaxValue;
                triangle[i][j] += Math.Min(prevRow_prevCol, prevRow_currCol);
            }
        }
        return (n == 0)? 0: triangle[n-1].Min();
    }


    private void displayList<T>(List<T> list)
    {
        string s = "";
        foreach (T element in list)
        {
            s += element.ToString() + ',';
        }
        s = string.Format("[{0}]", s.TrimEnd(','));
        Console.WriteLine(s);
    }    

    /*
    // Solution#2 - DP
    public int MinimumTotal(IList<IList<int>> triangle) {

        int n = triangle.Count;
        List<int> row = new List<int>();
        for (int i=n-1; i>=0; i--)
        {
            for (int j=0; j<n; j++)
            {
                if (i==n-1)
                    row.Add(triangle[i][j]);
                else if (j>i) 
                    row[j] = -1;    // not used anymore
                else
                    row[j] = Math.Min(row[j], row[j+1]) + triangle[i][j];
            }
            //displayList(row);
        }
        return (n == 0)? 0: row[0];
    }

    // Solution#1 - Recursion
    public int MinimumTotal(IList<IList<int>> triangle) {
        return pathSum(0,0,triangle);
    }

    private int pathSum(int i, int j, IList<IList<int>> triangle)
    {
        if (i >= triangle.Count) return 0;
        if (j >= triangle.Count) return int.MaxValue;
        return triangle[i][j] + 
            Math.Min(
                pathSum(i+1, j, triangle), 
                pathSum(i+1, j+1, triangle)
                );
    }
    */
}
// @lc code=end

