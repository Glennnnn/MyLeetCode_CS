/*
 * @lc app=leetcode.cn id=946 lang=csharp
 *
 * [946] 验证栈序列
 */

// @lc code=start
public class Solution {
    public bool ValidateStackSequences(int[] pushed, int[] popped) {
        
        /*
        // O(2n)
        int len = pushed.Length;
        int i,j,k;

        i=0; j=len-1; k=0;
        while (i<len && pushed[i++]==popped[j--]);
        while (i<len && pushed[i++]==popped[k++]);
        bool b1 = k==j+1;

        i=0; j=len-1; k=0;
        while (i<len && pushed[i++]==popped[k++]);
        while (i<len && pushed[i++]==popped[j--]);
        bool b2 = k==j+1;

        Console.WriteLine(b1);
        Console.WriteLine(b2);
        return b1||b2;
        */

        // Just as the question described ...
        // O(n), O(n)
        int len = pushed.Length;
        Stack<int> stack = new Stack<int>();

        int j = 0;  // pop index

        for(int i=0;i<len;i++)
        {
            stack.Push(pushed[i]);
            while (stack.Count>0 && j<len && stack.Peek()==popped[j])
            {
                stack.Pop();
                j++;
            }
        }

        return stack.Count==0;

    }
}
// @lc code=end

