/*
 * @lc app=leetcode.cn id=349 lang=csharp
 *
 * [349] 两个数组的交集
 */

// @lc code=start
public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
        HashSet<int> set1 = new HashSet<int>(nums1);
        HashSet<int> set2 = new HashSet<int>(nums2);

        if (set1.Count < set2.Count)
            return FindIntersection(set1, set2);
        else
            return FindIntersection(set2, set1);
    }

    private int[] FindIntersection(HashSet<int> set1, HashSet<int> set2)
    {
        // set 1 is always shorter
        // O(n), where n=set1.Length
        List<int> ans = new List<int>();
        foreach(int num in set1)
        {
            if (set2.Contains(num)) // O(1)
                ans.Add(num);       //O(1) 
        }
        return ans.ToArray();
    }

}
// @lc code=end

