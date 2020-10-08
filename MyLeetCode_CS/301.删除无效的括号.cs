/*
 * @lc app=leetcode.cn id=301 lang=csharp
 *
 * [301] 删除无效的括号
 */

// @lc code=start
public class Solution {
    Queue<string> queue = new Queue<string>();
    HashSet<string> hashset = new HashSet<string>();
        
    public IList<string> RemoveInvalidParentheses(string s) {
        List<string> list = new List<string>();
        queue.Enqueue(s);
        hashset.Add(s);
        bool flag = false;

        while (queue.Count > 0)
        {
            string curr = queue.Dequeue();
            if (flag)
            {
                if (validate(curr))
                    list.Add(curr);
            }
            else
            {
                if (forwardPass(curr))
                {
                    list.Add(curr);
                    flag = true;
                }
                else if (backwardPass(curr))
                {
                    list.Add(curr);
                    flag = true;
                }
                // else flag stays false
            }
        }

        if (list.Count == 0) list.Add("");
        return list;
    }

    private bool validate(string s)
    {
        int n = 0;  // number of brackets remaining open
        for (int i=0;i<s.Length;i++)
        {
            if (s[i] == '(') n++;
            if (s[i] == ')') n--;
            if (n<0) break; // more close than open
        }
        return (n==0);  // any open remaining
    }

    private bool forwardPass(string s)
    {
        int n = 0;  // number of brackets remaining open
        for (int i=0;i<s.Length;i++)
        {
            if (s[i] == '(') n++;
            if (s[i] == ')') n--;

            if (n<0)    // s is invalid
            {
                //删除不符合的')'  多种情况
                for (int j=i;j>=0;j--)
                    deleteExtraBracket(j, s, ')');
                break;
            }
        }
        return (n==0);
    }

    private bool backwardPass(string s)
    {
        int n = 0;  // number of brackets remaining open
        for (int i=s.Length-1;i>=0;i--)
        {
            if (s[i] == ')') n++;
            if (s[i] == '(') n--;

            if (n<0)    // s is invalid
            {
                //删除不符合的'('  多种情况
                for (int j=i;j<s.Length;j++)
                    deleteExtraBracket(j, s, '(');
                break;
            }
        }
        return (n==0);
    }

    private void deleteExtraBracket(int idx, string s, char bracket)
    {
        if (s[idx] == bracket)
        {
            string tmp = s.Substring(0, idx) + s.Substring(idx+1);
            if (!hashset.Contains(tmp))
            {
                hashset.Add(tmp);
                queue.Enqueue(tmp);
            }
        }
    }

}
// @lc code=end

