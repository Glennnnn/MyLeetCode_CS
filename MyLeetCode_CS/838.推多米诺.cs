/*
 * @lc app=leetcode.cn id=838 lang=csharp
 *
 * [838] 推多米诺
 */

// @lc code=start
public class Solution {

    // Solution#1 - O(3n)
    public string PushDominoes(string dominoes) {

        int l = dominoes.Length;
        int i;
        bool falling;

        // R
        int[] R = new int[l];
        falling = false;
        for(i=0;i<l;i++)
        {
            if (dominoes[i] == '.')
            {
                R[i] = falling? R[i-1] + 1: l;
            }
            else if (dominoes[i] == 'R')
            {
                R[i] = 0;
                falling = true;
            }
            else if (dominoes[i] == 'L')
            {
                R[i] = l;
                falling = false;
            }
        }
        // displayArray(R);

        // L
        int[] L = new int[l];
        falling = false;
        for (i=l-1;i>=0;i--)
        {
            if (dominoes[i] == '.')
            {
                L[i] = falling? L[i+1] + 1: l;
            }
            else if (dominoes[i] == 'R')
            {
                L[i] = l;
                falling = false;
            }
            else if (dominoes[i] == 'L')
            {
                L[i] = 0;
                falling = true;
            }            
        }
        // displayArray(L);

        // charArray
        char[] cA = new char[l];
        for (i=0;i<l;i++)
        {
            if (L[i]==R[i]) cA[i] = '.';
            else if (L[i]>R[i]) cA[i] = 'R';
            else if (L[i]<R[i]) cA[i] = 'L';
        }
        // displayArray(cA);

        // ans
        string ans = new string(cA);
        return ans;
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

