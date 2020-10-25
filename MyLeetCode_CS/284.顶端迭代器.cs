/*
 * @lc app=leetcode.cn id=284 lang=csharp
 *
 * [284] 顶端迭代器
 */

// @lc code=start
// C# IEnumerator interface reference:
// https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerator?view=netframework-4.8

class PeekingIterator {

    Queue<int> queue;

    // iterators refers to the first element of the array.
    public PeekingIterator(IEnumerator<int> iterator) {
        // initialize any member here.
        queue = new Queue<int>();
        do 
        {
            queue.Enqueue(iterator.Current);
        } while(iterator.MoveNext());        
    }
    
    // Returns the next element in the iteration without advancing the iterator.
    public int Peek() {
        if (this.HasNext())
            return queue.Peek();
        else
            return -1;
    }
    
    // Returns the next element in the iteration and advances the iterator.
    public int Next() {
        if (this.HasNext())
            return queue.Dequeue();
        else
            return -1;
    }
    
    // Returns false if the iterator is refering to the end of the array of true otherwise.
    public bool HasNext() {
		return queue.Count > 0;
    }
}
// @lc code=end

