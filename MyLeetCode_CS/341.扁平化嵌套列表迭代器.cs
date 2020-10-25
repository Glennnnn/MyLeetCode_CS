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

    Queue<int> q;
    public NestedIterator(IList<NestedInteger> nestedList) {
        q = new Queue<int>();
        recursiveFlatten(nestedList);
    }
    public bool HasNext() {
        return q.Count>0;
    }

    public int Next() {
        return q.Dequeue();
    }

    private void recursiveFlatten (IList<NestedInteger> lni)
    {
        foreach(NestedInteger ni in lni)
        {
            if (ni.IsInteger()) // is an int
                q.Enqueue(ni.GetInteger());
            else                // is a list
                recursiveFlatten(ni.GetList());
        }
    }
}

/**
 * Your NestedIterator will be called like this:
 * NestedIterator i = new NestedIterator(nestedList);
 * while (i.HasNext()) v[f()] = i.Next();
 */
// @lc code=end

