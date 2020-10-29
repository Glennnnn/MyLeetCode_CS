/*
 * @lc app=leetcode.cn id=381 lang=csharp
 *
 * [381] O(1) 时间插入、删除和获取随机元素 - 允许重复
 */

// @lc code=start
public class RandomizedCollection {

    Dictionary<int, List<int>> myDict;    // key = val, value = idx
    List<int> newList;      // used to get element by index O(1)

    /** Initialize your data structure here. */
    public RandomizedCollection() {
        myDict = new Dictionary<int, List<int>>();
        newList = new List<int>();        
    }
    
    /** Inserts a value to the collection. Returns true if the collection did not already contain the specified element. */
    public bool Insert(int val) {
        bool ans = myDict.ContainsKey(val);
        if (!ans) myDict.Add(val, new List<int>());
        myDict[val].Add(newList.Count);
        newList.Add(val);
        // Console.Write("inserted: {0} ", val);
        // displayList(newList);
        return !ans;
    }
    
    /** Removes a value from the collection. Returns true if the collection contained the specified element. */
    public bool Remove(int val) {
        bool ans = myDict.ContainsKey(val) && myDict[val].Count > 0;
        if (!ans) return false;

        int idxRemove = myDict[val][0];
        myDict[val].RemoveAt(0);

        int idxLast = newList.Count-1;
        newList[idxRemove] = newList[idxLast];
        myDict[newList[idxLast]].Add(idxRemove);
        myDict[newList[idxLast]].Remove(idxLast);
        newList.RemoveAt(idxLast);

        // Console.Write("removed : {0} ", val);
        // displayList(newList);

        return true;
    }
    
    /** Get a random element from the collection. */
    public int GetRandom() {
        int randomIndex = new Random().Next(newList.Count);
        // Console.Write("randomed: {0} ", randomIndex);
        // displayList(newList);
        return newList[randomIndex];
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
 * Your RandomizedCollection object will be instantiated and called as such:
 * RandomizedCollection obj = new RandomizedCollection();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */
// @lc code=end

