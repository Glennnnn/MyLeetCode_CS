/*
 * @lc app=leetcode.cn id=942 lang=csharp
 *
 * [942] 增减字符串匹配
 */

// @lc code=start
public class Solution {
    public int[] DiStringMatch(string S) {

        int N = S.Length;
        int[] A = new int[N+1];
        int l=0, r=N;

        for(int i=0;i<=N;i++)
        {
            if (i==N) A[i]=l;   // whatever is left at this point, l==r 
            else if (S[i]=='I') A[i] = l++;
            else if (S[i]=='D') A[i] = r--;
        }
        return A;
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

