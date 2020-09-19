/*
 * @lc app=leetcode.cn id=1054 lang=csharp
 *
 * [1054] 距离相等的条形码
 */

// @lc code=start
public class Solution {
    public int[] RearrangeBarcodes(int[] barcodes) {
        
        Dictionary<int,int> myDic = new Dictionary<int, int>();
        foreach(int num in barcodes)
        {
            // update dictionary
            if (myDic.ContainsKey(num))
                myDic[num]++;
            else
                myDic.Add(num,1);
        }
        //displayDictionary(myDic);
        // sort dictionary by value
        List<KeyValuePair<int, int>> myList = myDic.ToList();
        myList.Sort((pair1,pair2) => pair2.Value.CompareTo(pair1.Value));
        
        int keyIdx = 0;
        int count = 0;

        int len = barcodes.Length;
        for(int i=0;i<len;i+=2)
        {
            barcodes[i] = myList[keyIdx].Key;
            // Console.Write("[{0},{1}] ", i, barcodes[i]);
            count ++;
            // move to next number if all used
            if (count == myList[keyIdx].Value)
            {
                keyIdx ++;
                count=0;
            }
            // restart for odd number
            if (len%2==1 && i==len-1) i=-1;
            if (len%2==0 && i==len-2) i=-1;
        }
        // Console.WriteLine();
        // displayArray(barcodes);

        return barcodes;
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

