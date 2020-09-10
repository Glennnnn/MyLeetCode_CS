/*
 * @lc app=leetcode.cn id=215 lang=csharp
 *
 * [215] 数组中的第K个最大元素
 */

// @lc code=start
public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        /*
        // Solution#1 - naive
        // O(nlogn), O(1)
        Array.Sort(nums);
        return nums[nums.Length-k];
        */

        /*
        // Solution#2 - heap
        PriorityQueue<int> heap = new PriorityQueue<int>();
        foreach(int num in nums)
        {
            heap.Enqueue(num);
            Console.WriteLine(heap.ToString());
        }

        int ans = 0, tmp = 0;
        string s = "Heap dequeue: ";
        for(int i=0;i<nums.Length;i++)
        {
            tmp = heap.Dequeue();
            if (i==nums.Length-k) ans = tmp;
            s += string.Format("{0},", tmp);
        }
        Console.WriteLine(s.TrimEnd(','));
        return ans;
        */
        
        // Solution#2b - heap
        // O(2n), O(n)
        PriorityQueue<int> heap = new PriorityQueue<int>();
        foreach(int num in nums)
            heap.Enqueue(num);

        int ans = -1;
        for(int i=0;i<=nums.Length-k;i++)
            ans = heap.Dequeue();
        return ans;
    }
}
public class PriorityQueue<T> where T : IComparable<T> {
	private List<T> data;

	public PriorityQueue() {
		this.data = new List<T>();
	}

	public void Enqueue(T item) {
		data.Add(item);
		int ci = data.Count - 1; // child index; start at end
		while (ci > 0) {
			int pi = (ci - 1) / 2; // parent index
			if (data[ci].CompareTo(data[pi]) >= 0)
				break; // child item is larger than (or equal) parent so we're done
			T tmp = data[ci];
			data[ci] = data[pi];
			data[pi] = tmp;
			ci = pi;
		}
	}

	public T Dequeue() {
		// assumes pq is not empty; up to calling code
		int li = data.Count - 1; // last index (before removal)
		T frontItem = data[0];   // fetch the front
		data[0] = data[li];
		data.RemoveAt(li);

		--li; // last index (after removal)
		int pi = 0; // parent index. start at front of pq
		while (true) {
			int ci = pi * 2 + 1; // left child index of parent
			if (ci > li)
				break;  // no children so done
			int rc = ci + 1;     // right child
			if (rc <= li && data[rc].CompareTo(data[ci]) < 0) // if there is a rc (ci + 1), and it is smaller than left child, use the rc instead
                ci = rc;
			if (data[pi].CompareTo(data[ci]) <= 0)
				break; // parent is smaller than (or equal to) smallest child so done
			T tmp = data[pi];
			data[pi] = data[ci];
			data[ci] = tmp; // swap parent and child
			pi = ci;
		}
		return frontItem;
	}

	public override string ToString() {
		string s = "";
		for (int i = 0; i < data.Count; ++i)
			s += data[i].ToString() + " ";
		s += "count = " + data.Count;
		return s;
	}
}
// @lc code=end

