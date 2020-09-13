/*
 * @lc app=leetcode.cn id=387 lang=csharp
 *
 * [387] 字符串中的第一个唯一字符
 */

// @lc code=start
public class Solution {
    public int FirstUniqChar(string s) {
        // Soltuion#2
        const int numAlphabet = 26;
        int[] alphabet = new int[numAlphabet];

        foreach(char c in s)
        {
            alphabet[c-'a']++;
        }
        
        int ans = -1;
        for(int i=0;i<s.Length;i++)
        {
            if (alphabet[s[i]-'a']==1)
            {
                ans = i;
                break;
            }
        }
        return ans;


        /*
        // Solution#1 - Dictionary
        // Add into dictionary
        // Key - char, Value = occurrence
        Dictionary<char, int> newDict = new Dictionary<char, int>();
        for(int i=0;i<s.Length;i++)
        {
            if (newDict.ContainsKey(s[i]))
                newDict[s[i]]++;
            else
                newDict.Add(s[i], 1);
        }
        displayDictionary(newDict);
        
        char ansChar = ' ';
        foreach(KeyValuePair<char, int> kvp in newDict)
        {
            if (kvp.Value == 1)
            {
                ansChar = kvp.Key;
                break;
            }
        }

        int ansIdx = -1;
        if (ansChar != ' ')
            ansIdx = s.IndexOf(ansChar);
        return ansIdx;
        */
    }
    private void displayDictionary(Dictionary<char, int> dict)
    {
        string s = "";
        foreach (KeyValuePair<char, int> kvp in dict)
        {
			s += string.Format("[{0}:{1}],", kvp.Key, kvp.Value);
        }
        Console.WriteLine(s.TrimEnd(','));
    }
}
// @lc code=end

