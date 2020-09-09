/*
 * @lc app=leetcode.cn id=202 lang=csharp
 *
 * [202] 快乐数
 */

// @lc code=start
public class Solution {

    // Solution#1
    public bool IsHappy(int n) {
        HashSet<int> history = new HashSet<int>();
        while (!history.Contains(n))
        {
            //Console.Write("{0}->", n);
            history.Add(n);
            n = SquareSum(n);
        }
        //Console.WriteLine(n);
        return n==1;
    }

    /*
    // Solution#2
    // unhappy loop: 4 → 16 → 37 → 58 → 89 → 145 → 42 → 20 → 4 
    public bool IsHappy(int n) {
        while (true)
        {
            if (n == 1) return true;
            if (n == 4) return false;
            n = SquareSum(n);
        }
        Console.WriteLine("Should never be here");
        return false;
    }
    */

    private int SquareSum(int n)
    {
        int ans = 0;
        while (n>0)
        {
            ans += (n%10)*(n%10);
            n /= 10;
        }
        return ans;
    }

}
// @lc code=end

