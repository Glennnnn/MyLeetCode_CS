/*
 * @lc app=leetcode.cn id=232 lang=csharp
 *
 * [232] 用栈实现队列
 */

// @lc code=start
public class MyQueue {

    Stack<int> stack, dummy;

    /** Initialize your data structure here. */
    // O(1), O(1)
    public MyQueue() {
        stack = new Stack<int>();
    }
    
    /** Push element x to the back of queue. */
    // O(n), O(n)
    public void Push(int x) {
        Stack<int> dummy = new Stack<int>();
        while (stack.Count>0)
            dummy.Push(stack.Pop());
        stack.Push(x);
        while (dummy.Count>0)
            stack.Push(dummy.Pop());
    }
    
    /** Removes the element from in front of queue and returns that element. */
    // O(1), O(1)
    public int Pop() {
        return stack.Pop();
    }
    
    /** Get the front element. */
    // O(1), O(1)
    public int Peek() {
        return stack.Peek();
    }
    
    /** Returns whether the queue is empty. */
    // O(1), O(1)
    public bool Empty() {
        return stack.Count == 0;

    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */
// @lc code=end

