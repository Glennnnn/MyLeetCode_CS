/*
 * @lc app=leetcode.cn id=242 lang=csharp
 *
 * [242] 有效的字母异位词
 */

// @lc code=start
public class Solution {
    public bool IsAnagram(string s, string t) {

        /*
        // Solution#1
        List<char> schars = s.ToCharArray().ToList();
        foreach(char c in t)
        {
            if (schars.Remove(c) == false)
                return false;
        }
        return schars.Count==0;
        */

        // Solution#2 - O(2n)
        int[] alphabet = new int[26];
        foreach(char c in s)
        {
            alphabet[(int)(c-'a')] ++;
        }
        foreach(char c in t)
        {
            alphabet[(int)(c-'a')] --;
        }
        foreach (int i in alphabet)
        {
            if (i!=0) return false;
        }
        return true;
    }
}
// @lc code=end

