/*
 * @lc app=leetcode.cn id=295 lang=csharp
 *
 * [295] 数据流的中位数
 */

// @lc code=start
public class MedianFinder {
    List<int> data;
    /** initialize your data structure here. */
    public MedianFinder() {
        data = new List<int>();
    }
    // O(logn)
    public void AddNum(int num) {
        int l=0,r=data.Count-1;
        while(l<=r)
        {
            int mid = (l+r)/2;
            if (data[mid]==num)
            {
                l = mid;
                break;
            }
            else if (data[mid]<num)
                l = mid+1;
            else if (data[mid]>num)
                r = mid-1;
        }
        data.Insert(l, num);
        //displayList(data);
    }
    // O(1)
    public double FindMedian() {
        int mid = data.Count/2;
        double ans = (double)data[mid];
        if (data.Count%2==0)
        {
            ans += (double)data[mid-1];
            ans /= 2;
        }
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

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */
// @lc code=end

