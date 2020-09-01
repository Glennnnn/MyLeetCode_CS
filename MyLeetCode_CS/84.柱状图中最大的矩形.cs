/*
 * @lc app=leetcode.cn id=84 lang=csharp
 *
 * [84] 柱状图中最大的矩形
 */

// @lc code=start
public class Solution {
    public int LargestRectangleArea(int[] heights) {

        int maxArea = 0;
        int len = heights.Length;
        Stack<int> stack = new Stack<int>();

        for (int i=0;i<len;i++)
        {
            int currElement = (i==len)? -1: heights[i];
            while (stack.Count>0 && heights[stack.Peek()]>=currElement)
            {
                int high = heights[stack.Pop()];
                int width = stack.Count>0? (i-stack.Peek()-1):i;

                maxArea = Math.Max(maxArea, high*width);
            }
            stack.Push(i);
        }
        return maxArea;
    }
}
// @lc code=end

