/*
 * @lc app=leetcode.cn id=9 lang=csharp
 *
 * [9] 回文数
 */

// @lc code=start
public class Solution {
    public bool IsPalindrome(int x) {

        if (x<0) return false;  // neg number
        if (x==0) return true;  // 0 is palindrom
        if (x%10 == 0) return false;    // numbers don't begin with 0

        int x2 = x;
        int x3 = 0;

        while (x2>0)
        {
            x3 = (x3*10) + x2%10;
            x2 /= 10;
        }

        //Console.WriteLine("x={0}, x2={1}, x3={2}", x, x2, x3);

        return (x3 == x);



        /*
        // Solution#1
        if (x<0) return false;
        if (x==0) return true;
        if (x%10 == 0) return false;

        Queue<int> queue = new Queue<int>();
        Stack<int> stack = new Stack<int>();

        while (x>0)
        {
            queue.Enqueue(x%10);
            stack.Push(x%10);
            x/=10;
        }

        while (queue.Count>0 && stack.Count>0)
        {
            if (queue.Dequeue() != stack.Pop())
            {
                return false;
            }
        }

        return (queue.Count==0 && stack.Count==0);
        */
    }
}
// @lc code=end

