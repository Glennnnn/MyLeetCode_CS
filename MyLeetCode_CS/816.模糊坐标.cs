/*
 * @lc app=leetcode.cn id=816 lang=csharp
 *
 * [816] 模糊坐标
 */

// @lc code=start
public class Solution {
    
    public IList<string> AmbiguousCoordinates(string S) 
    {
        int l = S.Length;
        HashSet<string> hs = new HashSet<string>();

        for (int i=1;i<l-2;i++)
        {
            List<string> num1Cdds = validNums(S.Substring(1, i));
            List<string> num2Cdds = validNums(S.Substring(i+1, l-1-i-1));

            foreach(string n1 in num1Cdds)
            {
                foreach (string n2 in num2Cdds)
                {
                    hs.Add(string.Format("({0}, {1})", n1, n2));
                }
            }
        }

        return hs.ToList();
    }

    private List<string> validNums (string s)
    {
        List<string> ans = new List<string>();
        string s2, s3;

        // integer
        s3 = Int32.Parse(s).ToString();
        if (s == s3) ans.Add(s);
        // decimals
        for (int i=0;i<s.Length-1;i++)
        {
            s2 = s.Substring(0,i+1) + "." + s.Substring(i+1);
            s3 = Double.Parse(s2).ToString("F99").TrimEnd('0');
            if (s2 == s3) ans.Add(s2);
        }        
        // Console.Write("{0} => ", s);
        // displayList(ans);
        return ans;
    }
    private void displayList<T>(List<T> list)
    {
        string s = "";
        foreach (T element in list)
        {
            s += element.ToString() + ',';
        }
        s = string.Format("[{0}]", s.TrimEnd(','));
        Console.WriteLine(s);
    }    
}
// @lc code=end

