/*
 * @lc app=leetcode.cn id=219 lang=csharp
 *
 * [219] 存在重复元素 II
 */

// @lc code=start
public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {

        /*
        // Solution#1 - loop
        // O(nk), O(1)
        int i,j, len=nums.Length;
        for (i=0; i<len; i++)
        {
            for(j=i+1; j<=i+k && j<len; j++)
            {
                if (nums[j]==nums[i])
                {
                    //Console.WriteLine("i={0}, j={1}", i,j);
                    return true;
                }
            }
        }
        return false;
        */

        /*
        // Solution#2 - Dictionary
        // O(n), O(n)
        Dictionary<int, int> myDic = new Dictionary<int, int>();

        for(int i=0;i<nums.Length;i++)
        {
            if (myDic.ContainsKey(nums[i]))
            {
                int j = myDic[nums[i]];
                if (i-j <= k)
                {
                    Console.WriteLine("i={0}, j={1}", i,j);
                    return true;
                }
                else
                    myDic[nums[i]] = i;
            }
            else
            {
                myDic.Add(nums[i], i);
            }
        }
        return false;
        */

        // Solution#3 - Hashset
        // O(n), O(k)
        HashSet<int> record = new HashSet<int>();
        for(int i=0;i<nums.Length;i++)
        {
            if (record.Contains(nums[i]))
                return true;
            record.Add(nums[i]);
            if (record.Count>k)
                record.Remove(nums[i-k]);
        }
        return false;
    }
}
// @lc code=end

