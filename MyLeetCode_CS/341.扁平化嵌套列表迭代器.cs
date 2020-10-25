/*
 * @lc app=leetcode.cn id=341 lang=csharp
 *
 * [341] 扁平化嵌套列表迭代器
 */

// @lc code=start
/**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */
public class NestedIterator {
    Stack<NestedInteger> stack;

    public NestedIterator(IList<NestedInteger> nestedList) {

        stack = new Stack<NestedInteger>();
        pushToStack(nestedList);
    }
    
    private void pushToStack(IList<NestedInteger> nestedList)
    {
        for (int i=nestedList.Count-1;i>=0;i--)
            stack.Push(nestedList[i]);
    }

    public bool HasNext() {
        if (stack.Count ==0)
            return false;
        if (stack.Peek().IsInteger())
            return true;
        else
        {
            pushToStack(stack.Pop().GetList());
            return HasNext();
        }
    }

    public int Next() {
        var nextObj = stack.Pop();

        if (nextObj.IsInteger())
        {
            return nextObj.GetInteger();
        }
        else
        {
            pushToStack(nextObj.GetList());
            return Next();
        }
    }
}

/**
 * Your NestedIterator will be called like this:
 * NestedIterator i = new NestedIterator(nestedList);
 * while (i.HasNext()) v[f()] = i.Next();
 */
// @lc code=end

