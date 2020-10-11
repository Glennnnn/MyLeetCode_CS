/*
 * @lc app=leetcode.cn id=42 lang=csharp
 *
 * [42] 接雨水
 */

// @lc code=start
public class Solution {
    public int Trap(int[] height) {
        
        // Solution#1 - Two pointers
        // O(n), O(1)
        int vol = 0;
        int l = 0,r = height.Length-1;
        int maxL = 0, maxR = 0;

        while (l <= r) 
        {
            if (maxL < maxR) 
            {
                vol += Math.Max(maxL - height[l], 0);
                maxL = Math.Max(maxL, height[l]);
                l++;
            }
            else 
            {
                vol += Math.Max(maxR - height[r], 0);
                maxR = Math.Max(maxR, height[r]);
                r--;
            }
        }
        return vol;


        /*
        // Soltuion#2 - Stack
        // Time: O(2n), Space: O(n)
        int vol = 0;
        Stack<int> stack = new Stack<int>();
        for(int i=0;i<height.Length;i++)
        {
            while (stack.Count>0 && height[i] > height[stack.Peek()])
            {
                int m = stack.Pop();
                if (stack.Count == 0) break;
                int l = stack.Peek();
                int r = i;

                int w = r-l-1;
                int h = Math.Min(height[r], height[l]) - height[m];
                vol += w * h;
            }
            stack.Push(i);
        }
        return vol;
        */



        /*
        // Solution#2
        int len = height.Length;
        if (len<=2) return 0;

        int vol = 0;
        
        int[] maxL = new int[len];
        int[] maxR = new int[len];
        maxR[0] = height[1];    // to trigger the search on right

        for(int i=1;i<len-1;i++)
        {
            // find the max on the left 
            maxL[i] = Math.Max(height[i-1], maxL[i-1]);

            // find the max on the right
            if (height[i] == maxR[i-1])
            {
                maxR[i] = 0;
                for (int j=i+1;j<len;j++)
                {
                    if (height[j]>maxR[i])
                        maxR[i] = height[j];
                }
            }
            else
                maxR[i] = maxR[i-1];
        }

        // Console.Write("maxL: ");
        // displayArray(maxL);
        // Console.Write("maxR: ");
        // displayArray(maxR);

        for (int i=1;i<len-1;i++)
        {
            int heightWithWater = Math.Min(maxL[i], maxR[i]);
            if (heightWithWater>height[i])
                vol += (heightWithWater-height[i]);
        }

        return vol;
        */
        /*
        // solution1 - time out
        int vol = 0;

        for(int i=1;i<height.Length-1;i++)
        {
            int maxL=height[i], maxR=height[i];
            for (int j=0;j<height.Length;j++)
            {
                if (height[j]>maxL && j<i)
                    maxL = height[j];
                if (height[j]>maxR && j>i)
                    maxR = height[j];
            }

            int deltaV = Math.Min(maxL, maxR) - height[i];

            if (deltaV > 0)
            {
                height[i] += deltaV;
                vol += deltaV;
            }
        }

        return vol;
        */
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

