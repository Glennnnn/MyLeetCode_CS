/*
 * @lc app=leetcode.cn id=4 lang=csharp
 *
 * [4] 寻找两个正序数组的中位数
 */

// @lc code=start
public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int m = nums1.Length;
        int n = nums2.Length;

        if (m>n)
        {
            int[] tmpArray = nums1;
            nums1 = nums2;
            nums2 = tmpArray;

            int tmpInt = m;
            m = n;
            n = tmpInt;
        }

        int l=0, r=m;
        while(l<=r)
        {
            int a = (l + r)/2;
            int b = (m+n+1)/2 - a;

            if (a>0 && nums1[a-1]>nums2[b])
            {
                r = a-1;
            }
            else if (a<m && nums2[b-1]>nums1[a])
            {
                l = a+1;
            }
            else
            {
                int mid1=0;
                if (a>0 && b>0)
                    mid1 = Math.Max(nums1[a-1], nums2[b-1]);
                else if (a==0) mid1 = nums2[b-1];
                else if (b==0) mid1 = nums1[a-1];

                if ((m+n)%2==1)
                {
                    return (double)mid1;
                }
                else
                {
                    int mid2=0;
                    if (a<m && b<n)
                        mid2 = Math.Min(nums1[a], nums2[b]);
                    else if (a==m) mid2 = nums2[b];
                    else if (b==n) mid2 = nums1[a];
                    return (double)(mid1+mid2)/2;
                }
            }
        }

        return Double.NegativeInfinity;
    }

    private void displayArray<T>(T[] array)
    {
        string s = "";
        foreach (T element in array)
        {
            s += element.ToString() + ',';
        }
        s = string.Format("[{0}]", s.TrimEnd(','));
        Console.WriteLine(s);
    }

}
// @lc code=end

