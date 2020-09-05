/*
 * @lc app=leetcode.cn id=150 lang=csharp
 *
 * [150] 逆波兰表达式求值
 */

// @lc code=start
public class Solution {
    public int EvalRPN(string[] tokens) {
        Stack<int> stack = new Stack<int>();
        foreach (string token in tokens)
        {
            int tmp = 0;
            if (!Int32.TryParse(token, out tmp))
            {
                int operand2 = stack.Pop();
                int operand1 = stack.Pop();
                if (token == "+") tmp = operand1 + operand2;
                else if (token == "-") tmp = operand1 - operand2;
                else if (token == "*") tmp = operand1 * operand2;
                else if (token == "/") tmp = operand1 / operand2;
            }
            stack.Push(tmp);
        }
        return stack.Pop(); // there should only be one element
    }
}
// @lc code=end

