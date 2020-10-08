/*
 * @lc app=leetcode.cn id=218 lang=csharp
 *
 * [218] 天际线问题
 */

// @lc code=start
public class Solution {

    public IList<IList<int>> GetSkyline(int[][] buildings) {
        return merge(buildings, 0, buildings.Length-1);
    }

    private List<IList<int>> merge (int[][] buildings, int l, int r)
    {
        List<IList<int>> list = new List<IList<int>>();

        if (l>r)
            return list;
        if (l==r)
        {
            List<int> LH = new List<int>(){buildings[l][0], buildings[l][2]};
            List<int> R0 = new List<int>(){buildings[l][1], 0};
            list.Add(LH);
            list.Add(R0);
            return list;
        }

        int m = (l+r)/2;
        List<IList<int>> skyline1 = merge(buildings, l, m);
        List<IList<int>> skyline2 = merge(buildings, m+1, r);

        int h1=0, h2=0;
        int i=0, j=0;

        while (i<skyline1.Count || j<skyline2.Count)
        {
            long x1 = (i<skyline1.Count)? skyline1[i][0]: long.MaxValue;
            long x2 = (j<skyline2.Count)? skyline2[j][0]: long.MaxValue;
            long x = 0;

            if (x1 <= x2)
            {
                h1 = skyline1[i][1];
                x = x1;
                i++;
            }
            if (x1 >= x2)
            {
                h2 = skyline2[j][1];
                x = x2;
                j++;
            }

            int height = Math.Max(h1, h2);
            if (list.Count==0 || height != list[list.Count-1][1])
            {
                List<int> tmp = new List<int>(){(int)x, height};
                list.Add(tmp);
            }
        }
        return list;
    }



    /*
    public IList<IList<int>> GetSkyline(int[][] buildings) {
        List<IList<int>> ans = new List<IList<int>>();
        
        if (buildings.Length==0) return ans;


        // find starting and ending point
        int min = int.MaxValue;
        int max = int.MinValue;
        foreach(int[] building in buildings)
        {
            min = Math.Min(min, building[0]);
            max = Math.Max(max, building[1]);
        }
        int len = max-min+1;
        Console.WriteLine("min={0}, max={1}", min, max);

        // process building overlap
        int[] skyline = new int[len];
        foreach(int[] building in buildings)
        {
            for(int i=building[0];i<=building[1];i++)
            {
                skyline[i-min] = Math.Max(skyline[i-min], building[2]);
            }
        }
        displayArray(skyline);

        // scan for level changes
        int currLevel=0,prevLevel=0;
        for(int i=0;i<len;i++)
        {
            currLevel = skyline[i];

            if (currLevel == prevLevel) 
                continue;
            else if (currLevel > prevLevel)
            {
                ans.Add(new List<int>(){i+min, currLevel});
                prevLevel = currLevel;
            }
            else if (currLevel < prevLevel)
            {
                ans.Add(new List<int>(){i+min-1, skyline[i]});
                prevLevel = currLevel;
            }
        }
        ans.Add(new List<int>(){max, 0});   // last one

        return ans;
    }
    private void displayArray<T>(T[] array)
    {
        string s = "";
        foreach (T element in array)
        {
            s += element.ToString() + ',';
        }
        s = string.Format("[{0}]", s.TrimEnd(','));
        Console.WriteLine(s);
    }
    */
}
// @lc code=end

