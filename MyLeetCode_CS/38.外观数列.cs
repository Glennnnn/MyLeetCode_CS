/*
 * @lc app=leetcode.cn id=38 lang=csharp
 *
 * [38] 外观数列
 */

// @lc code=start
public class Solution {
    
    // // Solution#2 - dp
    // public string CountAndSay(int n) {
    //     string dp = "1";
    //     for(int i=2;i<=n;i++) 
    //         dp = convert(dp);
    //     return dp;
    // }

    // Solution#1 - recursion
    public string CountAndSay(int n) {
        if (n==1) return "1";
        return convert(CountAndSay(n-1));
    }    

    private string convert(string prevn)
    {
        string currn = "";

        int cnt = 0;
        char ch = ' ';
        for(int i=0;i<=prevn.Length;i++)
        {
            if (i==0)
            {
                ch = prevn[i];
                cnt =1;
            }
            else if (i==prevn.Length)
            {
                currn += cnt.ToString() + ch.ToString();
            }
            else if (prevn[i]==ch)
                cnt ++;
            else
            {
                currn += cnt.ToString() + ch.ToString();
                ch = prevn[i];
                cnt =1;
            }
        }
        //Console.WriteLine("n={0}: {1}", cnt, currn);
        return currn;
    }

}
// @lc code=end

