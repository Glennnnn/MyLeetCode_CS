/*
 * @lc app=leetcode.cn id=229 lang=csharp
 *
 * [229] 求众数 II
 */

// @lc code=start
public class Solution {
    public IList<int> MajorityElement(int[] nums) {
        // Solution#2 - Boyer Moore Voting
        
        List<int> ans = new List<int>();
        int len = nums.Length;
        if (len==0) return ans;

        int cnddt1 = nums[0], count1=0;
        int cnddt2 = nums[0], count2=0;

        // Pairing phase
        foreach(int num in nums)
        {
            if (num == cnddt1) 
            {
                count1++;
            }
            else if (num == cnddt2)
            {
                count2++;
            }
            else if (count1==0)
            {
                cnddt1 = num;
                count1 = 1;
            }
            else if (count2==0)
            {
                cnddt2 = num;
                count2 = 1;
            }
            else 
            {
                count1--;
                count2--;
            }
        }

        // Counting phase
        count1 = 0;
        count2 = 0;
        foreach (int num in nums)
        {
            if (num == cnddt1) 
                count1++;
            else if (num == cnddt2) 
                count2++;
        }

        // final output
        if (count1 > nums.Length/3) ans.Add(cnddt1);
        if (count2 > nums.Length/3) ans.Add(cnddt2);
        return ans;


        /*
        // Solution#1
        int len = nums.Length;

        // Count occurrances of all elements
        // O(n), O(n)
        Dictionary<int, int> myDic = new Dictionary<int, int>();
        for(int i=0;i<len;i++)
        {
            if (!myDic.ContainsKey(nums[i]))
                myDic.Add(nums[i], 1);
            else
                myDic[nums[i]] ++;
        }

        // Put the elements with high occurrances into list
        // O(n), O(n)
        List<int> ans = new List<int>();
        foreach(KeyValuePair<int, int> kvp in myDic)
        {
            if (kvp.Value > len/3)
                ans.Add(kvp.Key);
        }

        return ans;
        */
    }
}
// @lc code=end

