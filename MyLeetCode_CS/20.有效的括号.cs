/*
 * @lc app=leetcode.cn id=20 lang=csharp
 *
 * [20] 有效的括号
 */

// @lc code=start
public class Solution {
    public bool IsValid(string s) {

        Stack<char> stack = new Stack<char>();

        foreach(char c in s)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                stack.Push(c);
            }
            else if (stack.Count()==0)
            {
                Console.WriteLine("A");
                return false;
            }
            else
            {
                char top = stack.Pop();
                
                if (top == '(' && c == ')') continue;
                if (top == '[' && c == ']') continue;
                if (top == '{' && c == '}') continue;
                
                Console.WriteLine("B");
                Console.WriteLine("c={0}, top={1}", c, top);
                return false;
            }
        }

        if (stack.Count() > 0)
        {
            Console.WriteLine("C");
            return false;
        }
        return true;
    }
}
// @lc code=end

