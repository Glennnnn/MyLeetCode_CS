/*
 * @lc app=leetcode.cn id=290 lang=csharp
 *
 * [290] 单词规律
 */

// @lc code=start
public class Solution {
    public bool WordPattern(string pattern, string s) {
        // Solution#1 - O(3n), O(n)
        Dictionary<string, string> c2s = new Dictionary<string, string>();
        Dictionary<string, string> s2c = new Dictionary<string, string>();

        string[] tokens = s.Split();
        int len = tokens.Length;
        if (len != pattern.Length) 
            return false;

        // make dictionaries O(n)
        for(int i=0;i<len;i++)
        {
            string c = pattern[i].ToString();
            string t = tokens[i];

            if (!c2s.ContainsKey(c)) 
                c2s.Add(c, t);
            else if (c2s[c] != t) 
                return false;  // collision

            if (!s2c.ContainsKey(t))
                s2c.Add(t, c);
            else if (s2c[t] != c)
                return false;  // collision
        }
        // displayDictionary(c2s);
        // displayDictionary(s2c);

        // Reconstruct string from pattern and dictionary O(n)
        string s2 = "";
        foreach (char c in pattern)
            s2 += c2s[c.ToString()] + " ";
        s2 = s2.TrimEnd();  // remove extra space
        //Console.WriteLine("\"{0}\" - \"{1}\"", s, s2);
        // Reconstruct pattern from string and dictionary O(n)
        string pattern2 = "";
        foreach (string t in tokens)
            pattern2 += s2c[t];
        //Console.WriteLine("\"{0}\" - \"{1}\"", pattern, pattern2);
        
        // cross check
        return (pattern==pattern2) && (s==s2);
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
    private void displayDictionary<T>(Dictionary<T, T> dict)
    {
        string s = "";
        foreach (KeyValuePair<T,T> kvp in dict)
        {
			s += string.Format("[{0}:{1}],", kvp.Key, kvp.Value);
        }
        Console.WriteLine(s.TrimEnd(','));
    }
}
// @lc code=end

