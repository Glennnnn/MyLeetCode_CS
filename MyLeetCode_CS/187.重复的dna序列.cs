/*
 * @lc app=leetcode.cn id=187 lang=csharp
 *
 * [187] 重复的DNA序列
 */

// @lc code=start
public class Solution {
    
    /*
    // Solution#1 - look for string in hashset is O(10)
    // Time- O((n-10)*10), Space - O((n-10)*10)
    public IList<string> FindRepeatedDnaSequences(string s) {
        int l = 10; 
        List<string> ans = new List<string>();
        HashSet<string> newHS = new HashSet<string>();
        for(int i=0;i<s.Length-l;i++)
        {
            string ss = s.Substring(i, l);
            if (newHS.Contains(ss)) 
                ans.Add(ss);    // already seen, add to answer
            else 
                newHS.Add(ss);  // never seen, add to hashset
        }
        return ans;
    }
    */


    // Solution#2 - look for ulong in hashset is O(1)
    // Time- O(n-10), Space - O(n-10)
    public IList<string> FindRepeatedDnaSequences(string s) {
        const int L = 10;
        HashSet<string> ans = new HashSet<string>();
        HashSet<ulong> newHS = new HashSet<ulong>();

        int len = s.Length;
        if (len>=L)
        {
            ulong[] nums = new ulong[len];
            for(int i=0;i<len;i++)
            {
                if (s[i]=='A') nums[i] = 0;
                if (s[i]=='C') nums[i] = 1;
                if (s[i]=='G') nums[i] = 2;
                if (s[i]=='T') nums[i] = 3;
            }
            //displayArray(nums);

            ulong bitmask = 0;
            const ulong bit1112 = 3<<(2*L);
            for(int i=0;i<len;i++)
            {
                bitmask <<= 2;
                bitmask |= nums[i];  // append the new bit
                bitmask &= ~bit1112; // reset bit 2L+1 and 2L+2
                //Console.WriteLine("{0}: {1:X}", i, bitmask);

                if (i>=L-1)
                {
                    if (newHS.Contains(bitmask))
                        ans.Add(s.Substring(i-L+1,L));
                    else
                        newHS.Add(bitmask);
                }
            }
        }
        return ans.ToList();
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

