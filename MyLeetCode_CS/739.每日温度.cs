/*
 * @lc app=leetcode.cn id=739 lang=csharp
 *
 * [739] 每日温度
 */

// @lc code=start
public class Solution {
    public int[] DailyTemperatures(int[] T) {

        int len = T.Length;
        int[] ans = new int[len];
        Stack<int> stack = new Stack<int>();

        for(int i=0;i<len;i++)
        {
            int j = 0;
            while (stack.Count>0)
            {
                j = stack.Peek();
                if (T[j] >= T[i]) break;
                stack.Pop();    // remove
                ans[j] = (i-j);
            }

            stack.Push(i);

            //displayArray(ans);
        }

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
}
// @lc code=end

