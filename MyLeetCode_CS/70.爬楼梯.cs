/*
 * @lc app=leetcode.cn id=70 lang=csharp
 *
 * [70] 爬楼梯
 */

// @lc code=start
public class Solution {

    /*
    // solution 1, Time: O(n), Space: O(1)
    public int ClimbStairs(int n) {
        
        if (n<3) return n;

        int _2stepsAgo=1;  // n=1
        int _1stepsAgo=2;  // n=2
        int currStep=3;

        for (int i=3;i<=n;i++)
        {
            currStep = _2stepsAgo+_1stepsAgo;
            _2stepsAgo = _1stepsAgo;
            _1stepsAgo = currStep;
        }

        return currStep;

    }
    */

    
    // solution 1, Time: O(n), Space: O(n)
    public int ClimbStairs(int n) {
        int[] dp = new int[n+1];
        for (int i=0;i<dp.Length;i++)
        {
            if (i<3) 
                dp[i] = i;
            else
                dp[i] = dp[i-1] + dp[i-2];
        }
        //displayArray(dp);
        return dp[n];

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

