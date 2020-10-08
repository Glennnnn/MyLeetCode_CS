/*
 * @lc app=leetcode.cn id=32 lang=csharp
 *
 * [32] 最长有效括号
 */

// @lc code=start
public class Solution {
    public int LongestValidParentheses(string s) {

        // Solution#2 - loop forward and backward
        int ans = 0;
        if (string.IsNullOrEmpty(s)) 
            return ans;
        int left, right;

        // O(n) forward pass
        left  = 0;
        right = 0;
        for(int i=0;i<s.Length;i++)
        {
            if (s[i]=='(') left++;
            if (s[i]==')') right++;
            
            if (left == right)
                ans = Math.Max(ans, left+right);
            else if (left < right)
            {
                left = 0;
                right = 0;
            }
        }
        // O(n) reverse pass
        left  = 0;
        right = 0;
        for(int i=s.Length-1;i>=0;i--)
        {
            if (s[i]=='(') left++;
            if (s[i]==')') right++;
            
            if (left == right)
                ans = Math.Max(ans, left+right);
            else if (left > right)
            {
                left = 0;
                right = 0;
            }
        }

        return ans;



        /*
        // Solution#1 - Stack
        if (string.IsNullOrEmpty(s))
            return 0;
        
        int ans = 0;
        Stack<int> stack = new Stack<int>();
        stack.Push(-1); // boundary

        for(int i=0;i<s.Length;i++)
        {
            if (s[i] == '(')
            {
                stack.Push(i);
            }
            if (s[i] == ')')
            {
                if (stack.Count>1 && s[stack.Peek()]=='(')
                {
                    stack.Pop();
                    ans = Math.Max(ans, i - stack.Peek());
                }
                else
                {
                    stack.Push(i);
                }
            }
        }
        return ans;
        */
    }
}
// @lc code=end

