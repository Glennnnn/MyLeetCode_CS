/*
 * @lc app=leetcode.cn id=447 lang=csharp
 *
 * [447] 回旋镖的数量
 */

// @lc code=start
public class Solution {
    public int NumberOfBoomerangs(int[][] points) {

        // O(n2), O(n)
        int bmrgCount = 0;
        int len = points.Length;
        for(int i=0; i<len;i++)
        {
            // key = distance to points[i]
            // value = #points to points[i] at $key distance
            Dictionary<int, int> myDic = new Dictionary<int, int>();
            for(int j=0;j<len;j++)
            {
                // skip itself
                if (i==j) continue;
                // calculate distance squared
                int diffX = points[i][0] - points[j][0];
                int diffY = points[i][1] - points[j][1];
                int d = diffX*diffX + diffY*diffY;
                // add to or update dictionary
                if (myDic.ContainsKey(d)) 
                    myDic[d] ++;
                else 
                    myDic.Add(d, 1);
            }
            foreach(KeyValuePair<int, int> kvp in myDic)
            {
                // # of possible combinations = n(n-1)
                bmrgCount += kvp.Value * (kvp.Value-1);
            }
        }
        return bmrgCount;
    }
}
// @lc code=end

