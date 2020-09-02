/*
 * @lc app=leetcode.cn id=118 lang=csharp
 *
 * [118] 杨辉三角
 */

// @lc code=start
public class Solution {
    public IList<IList<int>> Generate(int numRows) {

        List<IList<int>> yh = new List<IList<int>>();

        for (int i=0;i<numRows;i++)
        {
            List<int> level = new List<int>();
            level.Add(1);
            for (int j=1;j<i;j++)
            {
                int newNum = yh[i-1][j-1] + yh[i-1][j];
                level.Add(newNum);
            }
            if (i>0) level.Add(1);
            yh.Add(level);
        }
        return yh;
    }
}
// @lc code=end

