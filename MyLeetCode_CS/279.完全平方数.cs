/*
 * @lc app=leetcode.cn id=279 lang=csharp
 *
 * [279] 完全平方数
 */

// @lc code=start
public class Solution {

    /*
    // Solution#1 - DFS (too slow)
    public int NumSquares(int n) {
        return dfs(n);
    }
    private int dfs(int n)
    {
        if (n==0) return 0;
        if (n==1) return 1;
        int ans = n;    // can't be smaller than all ones
        for (int i=1;i*i<=n;i++)
        {
            ans = Math.Min(ans, dfs(n-i*i)+1);
        }
        return ans;
    }
    */

    /*
    // Solution#2 - BFS
    public int NumSquares(int n) {
        
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(n);
        int count = 1;
        int level = 0;

        while (count>0)
        {
            //displayQ(queue);
            for(int i=0;i<count;i++)
            {
                int m = queue.Dequeue();
                for (int j=1;j*j<=m;j++)
                {
                    if (m==j*j) return level+1;
                    else queue.Enqueue(m-j*j);
                }
            }
            count = queue.Count;
            level++;
        }
        return -1;
    }

    private void displayQ<T> (Queue<T> queue)
    {
        string s = "";
        foreach (T element in queue)
        {
            s += element.ToString() + ',';
        }
        s = string.Format("[{0}]", s.TrimEnd(','));
        Console.WriteLine(s);        
    }
    */

    // Solution#3 - Four Squares
    public int NumSquares(int n) {
        /* 四平方定理
        四平方定理讲的就是任何一个正整数都可以表示成不超过四个整数的平方之和
            也就是说，这道题的答案只有 1，2 ，3，4 这四种可能
        同时，还有一个非常重要的推论满足四数平方和定理的数n, 必定满足 n = 4a * (8b + 7)
            (这里要满足由四个数构成，小于四个不行)
        */
        //check if n is in form of 4^a * (8b+7)
        while (n%4==0) n/=4;        // now n==(8b+7)
        while (n%8==7) return 4;    // affirmative, answer is 4

        for(int a=0;a*a<=n;a++)
        {
            for (int b=0;b*b<=n;b++)
            {
                if (a*a+b*b==n)
                    return (a>0?1:0) + (b>0?1:0);
            }
        }
        return 3;
    }    

}
// @lc code=end

