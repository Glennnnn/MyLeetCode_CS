/*
 * @lc app=leetcode.cn id=1025 lang=csharp
 *
 * [1025] 除数博弈
 */

// @lc code=start
public class Solution {
    public bool DivisorGame(int N) {


        // Solution#3 - cheat
        // always winning if N is even
        return N%2==0;


        /*        
        // Solution#3 - DP
        if (N<2) return false;

        bool[] f = new bool[N+1];
        f[1] = false;   // Alice would lose
        f[2] = true;    // Alice would win

        for (int i=3;i<=N;i++)
        {
            for (int j=1;j<i;j++)
            {
                if (i%j==0 && f[i-j]==false)
                {
                    f[i] = true;
                    break;
                }
            }
        }
        //displayArray(f);
        return f[N];
        */

        /*
        // Solution#1
        bool A = true;

        while (true)
        {
            int x=N-1;
            while(x>0 && N%x!=0)
            {
                x--;
            }

            if (x==0)   // game over
            {
                break;
            }
            else
            {
                N-=x;
                A = !A; // change player
            }
        }

        return !A;
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

