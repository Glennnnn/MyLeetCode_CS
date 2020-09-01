/*
 * @lc app=leetcode.cn id=88 lang=csharp
 *
 * [88] 合并两个有序数组
 */

// @lc code=start
public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {

        /*
        // solution 1
        int i=m-1, j=n-1;

        while (i>=0 || j>=0)
        {
            if (i<0) 
                nums1[i+j+1] = nums2[j--];
            else if (j<0)
                nums1[i+j+1] = nums1[i--];
            else if (nums1[i] > nums2[j])
                nums1[i+j+1] = nums1[i--];
            else
                nums1[i+j+1] = nums2[j--];
        }
        */
        
        // solution 1 - optimized
        while (n>0) // while not done merging
        {
            // insert value from nums2 if
            // either nothing left in nums1
            // or nums1 value if smaller
            if (m==0 || nums1[m-1] < nums2[n-1])
                nums1[m+n-1] = nums2[--n];
            else
                nums1[m+n-1] = nums1[--m];
        }
    }
}
// @lc code=end

