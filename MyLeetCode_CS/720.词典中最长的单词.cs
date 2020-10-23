/*
 * @lc app=leetcode.cn id=720 lang=csharp
 *
 * [720] 词典中最长的单词
 */

// @lc code=start
public class Solution {
    public string LongestWord(string[] words) {

        Array.Sort(words, (x, y) => x.Length.CompareTo(y.Length));

        HashSet<string> myhs = new HashSet<string>();
        List<string> candidates = new List<string>();
        int maxLength = 0;

        foreach (string word in words)
        {
            int currLength = word.Length;
            string prefix = word.Remove(currLength-1);

            if (currLength == 1 || myhs.Contains(prefix))  // O(1) for hashset
            {
                myhs.Add(word);
                if (currLength > maxLength)
                {
                    candidates.Clear();
                    maxLength = currLength;
                }
                if (currLength == maxLength)
                {
                    candidates.Add(word);
                }
            }
        }

        if (candidates.Count == 0) 
            return "";
        else
        {
            if (candidates.Count > 1)
                candidates.Sort();
            return candidates[0];
        }
    }
}
// @lc code=end

