/*
 * @lc app=leetcode.cn id=350 lang=csharp
 *
 * [350] 两个数组的交集 II
 */

// @lc code=start
public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {

        // convert nums1 into dictionary
        // key = number, value = occurrance
        Dictionary<int, int> myDic1 = new Dictionary<int, int>();
        foreach(int num in nums1)
        {
            if (myDic1.ContainsKey(num))
                myDic1[num] ++;
            else
                myDic1.Add(num, 1);
        }

        // for each number that exist in nums2 as well
        // add to ans, then update the dictionary (i.e. occurrance-1)
        List<int> ans = new List<int>();
        foreach (int num in nums2)
        {
            if (myDic1.ContainsKey(num) && myDic1[num]>0)
            {
                ans.Add(num);
                myDic1[num]--;
            }
        }

        return ans.ToArray();
    }
}
// @lc code=end

