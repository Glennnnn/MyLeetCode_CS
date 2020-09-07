/*
 * @lc app=leetcode.cn id=155 lang=csharp
 *
 * [155] 最小栈
 */

// @lc code=start
public class MinStack {

    /** initialize your data structure here. */
        
    List<int> stackEle, stackMin;
    int top;

    public MinStack() {
        stackEle = new List<int>();
        stackMin = new List<int>();
        top = 0;
    }
    
    public void Push(int x) {
        stackEle.Add(x);
        int prevMin = (top>0? stackMin[top-1]: x);
        stackMin.Add(Math.Min(x, prevMin));
        top++;
    }
    
    public void Pop() {
        if (top>0)
        {
            top--;
            stackEle.RemoveAt(top);
            stackMin.RemoveAt(top);
        }
    }
    
    public int Top() {
        return top>0? stackEle[top-1]:0;
    }
    
    public int GetMin() {
        return top>0? stackMin[top-1]:0;
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(x);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */
// @lc code=end

