/*
 * @lc app=leetcode.cn id=1078 lang=csharp
 *
 * [1078] Bigram 分词
 */

// @lc code=start
public class Solution {
    public string[] FindOcurrences(string text, string first, string second) {

        string[] words = text.Split();
        int l = words.Length;

        List<string> ans = new List<string>();

        for(int i=0;i<l-2;i++)
        {
            if (words[i]==first && words[i+1]==second)
            {
                ans.Add(words[i+2]);
            }
        }

        return ans.ToArray();


    }
}
// @lc code=end

