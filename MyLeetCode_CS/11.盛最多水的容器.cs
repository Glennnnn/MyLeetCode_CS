/*
 * @lc app=leetcode.cn id=11 lang=csharp
 *
 * [11] 盛最多水的容器
 */

// @lc code=start
public class Solution {
    public int MaxArea(int[] height) {

        int l=0, r = height.Length-1;
        int areaMax = 0;

        while (l<r)
        {
            // int areaTmp = 0;
            // if (height[l] == height[r])
            // {
            //     areaTmp = (r-l)* height[l];
            //     l++;
            //     r--;
            // }
            // else if (height[l] < height[r])
            // {
            //     areaTmp = (r-l)* height[l];
            //     l++;
            // }
            // else if (height[l] > height[r])
            // {
            //     areaTmp = (r-l)* height[r];
            //     r--;
            // }

            int areaTmp = r-l;
            if (height[l] <= height[r])
                areaTmp *= height[l++];
            else
                areaTmp *= height[r--];

            if (areaMax < areaTmp)
                areaMax = areaTmp;
        }
        
        return areaMax;
    }
}
// @lc code=end

