/*
 * @lc app=leetcode.cn id=454 lang=csharp
 *
 * [454] 四数相加 II
 */

// @lc code=start
public class Solution {
    public int FourSumCount(int[] A, int[] B, int[] C, int[] D) {
        Dictionary<int, int> myDic = new Dictionary<int, int>();

        for (int i=0;i<A.Length;i++)
        {
            for (int j=0;j<B.Length;j++)
            {
                int key = A[i]+B[j];
                if (myDic.ContainsKey(key))
                    myDic[key] ++;
                else
                    myDic.Add(key, 1);
            }
        }
        
        //displayDictionary(myDic);

        int ans = 0;
        for (int k=0;k<C.Length;k++)
        {
            for (int l=0;l<D.Length;l++)
            {
                int key = -(C[k]+D[l]);
                if (myDic.ContainsKey(key))
                    ans += myDic[key];
            }
        }
        return ans;
    }
    private void displayDictionary<T>(Dictionary<T, T> dict)
    {
        string s = "";
        foreach (KeyValuePair<T,T> kvp in dict)
        {
			s += string.Format("[{0}:{1}],", kvp.Key, kvp.Value);
        }
        Console.WriteLine(s.TrimEnd(','));
    }    
}
// @lc code=end

