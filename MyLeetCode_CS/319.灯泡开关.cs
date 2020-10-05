/*
 * @lc app=leetcode.cn id=319 lang=csharp
 *
 * [319] 灯泡开关
 */

// @lc code=start
public class Solution {


    // Only square numbered lights will be on
    // due to repeated factor
    // e.g. 1,4,9,16,25,...
    // number of them = floor(sqrt(n))
    public int BulbSwitch(int n) {

        // // Solution#2
        // int ans = 0;
        // for (int i=1;i*i<=n;i++) ans++;
        // return ans;

        // Solution#3
        return (int)Math.Sqrt(n);
    }


    /*
    // Solution#1 - Time out
    public int BulbSwitch(int n) {
        int ans = 0;

        for(int i=0;i<n;i++)
        {
            ans += numOfFactors(i+1) % 2;
        }

        return ans;
    }

    private int numOfFactors(int n)
    {
        // string s = string.Format("{0}: ", n);
        int ans = 0;
        int a = 1, b = 1;
        while (true)
        {
            b = n/a;
            if (a>b) break;
            if (a*b==n)
            {
                // s += string.Format("[{0},{1}] ", a,b);
                ans += (a==b? 1:2);
            }
            a++;
        }
        // s += string.Format("({0})", ans);
        // Console.WriteLine(s);
        return ans;
    }
    */
}
// @lc code=end

