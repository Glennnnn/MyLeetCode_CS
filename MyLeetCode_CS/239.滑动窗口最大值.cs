/*
 * @lc app=leetcode.cn id=239 lang=csharp
 *
 * [239] 滑动窗口最大值
 */

// @lc code=start
public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {

        LinkedList<int> ll = new LinkedList<int>();
        List<int> ans = new List<int>();

        for (int i=0;i<nums.Length;i++)
        {
            // Enqueue - O(k)
            while (ll.Count > 0 && nums[ll.Last()] < nums[i])
                ll.RemoveLast();    // O(1)
            ll.AddLast(i);          // O(1)
            // Dequeue
            if (ll.First() == i-k)
                ll.RemoveFirst();   // O(1)
            // Add to ans
            if (i>=k-1)
                ans.Add(nums[ll.First()]);
        }
        return ans.ToArray();
    }
}
// @lc code=end

