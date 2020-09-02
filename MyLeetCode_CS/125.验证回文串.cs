/*
 * @lc app=leetcode.cn id=125 lang=csharp
 *
 * [125] 验证回文串
 */

// @lc code=start
public class Solution {
    public bool IsPalindrome(string s) {

        // Solution#2 - Time O(n), Space O(1)
        int l=0, r=s.Length-1;

        while (l<r)
        {
            //Console.Write("[{0},{1}]->", l,r);
            while (l<r && !Char.IsLetterOrDigit(s[l])) l++;
            while (l<r && !Char.IsLetterOrDigit(s[r])) r--;
            //Console.WriteLine("[{0},{1}]", l,r);
            if (l<r)
            {
                if (Char.ToLower(s[l]) != Char.ToLower(s[r]))
                {
                    //Console.WriteLine("Mismatch: s[{0}]={1}, s[{2}]={3}", l, s[l], r, s[r]);
                    return false;
                }
                else
                {
                    l++;
                    r--;
                }
            }
        }
        return true;



        /*
        // Solution#1 - Time O(n), Space O(n)
        string sForward = "", sReverse = "";

        for (int i=0;i<s.Length;i++)
        {
            if (Char.IsLetterOrDigit(s[i]))
            {
                sForward = sForward + Char.ToLower(s[i]);
                sReverse = Char.ToLower(s[i]) + sReverse;
            }
        }

        Console.WriteLine(sForward);
        Console.WriteLine(sReverse);

        return sForward==sReverse;
        */
    }
}
// @lc code=end

