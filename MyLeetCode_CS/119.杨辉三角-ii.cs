/*
 * @lc app=leetcode.cn id=119 lang=csharp
 *
 * [119] 杨辉三角 II
 */

// @lc code=start
public class Solution {

    // Solution#2
    // 对于杨辉三角的同一行，第 ( i + 1) 项是第 i 项的 ( k - i ) /( i + 1 ) 倍
    public IList<int> GetRow(int rowIndex) {
        List<int> ans = new List<int>();

        long idx = 1;
        for (int i=0;i<=rowIndex;i++)
        {
            ans.Add((int)idx);
            idx = idx*(rowIndex-i)/(i+1);
        }

        return ans;
    }

    /*
    // Solution#1
    public IList<int> GetRow(int rowIndex) {
        
        List<int> prevRow = new List<int>(){1};
        for (int i=1;i<=rowIndex;i++)
        {
            List<int> currRow = new List<int>();
            currRow.Add(1);
            for (int j=1;j<i;j++)
            {
                int newNum = prevRow[j-1] + prevRow[j];
                currRow.Add(newNum);
            }
            if (i>0) currRow.Add(1);

            // Console.WriteLine("row#{0}", i);
            // displayList(prevRow);
            // displayList(currRow);
            prevRow = currRow;
        }
        return prevRow;

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
    */
}
// @lc code=end

