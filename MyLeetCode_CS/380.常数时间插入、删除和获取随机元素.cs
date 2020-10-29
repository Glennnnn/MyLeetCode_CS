/*
 * @lc app=leetcode.cn id=380 lang=csharp
 *
 * [380] 常数时间插入、删除和获取随机元素
 */

// @lc code=start
public class RandomizedSet {

    Dictionary<int, int> myDict;    // key = val, value = idx
    List<int> newList;      // used to get element by index O(1)
    
    /** Initialize your data structure here. */
    public RandomizedSet() {
        myDict = new Dictionary<int, int>();
        newList = new List<int>();
    }
    
    /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
    public bool Insert(int val) {
        if (myDict.ContainsKey(val))
        {
            return false;
        }
        else
        {
            myDict.Add(val, newList.Count);
            newList.Add(val);
            // Console.Write("inserted: {0} ", val);
            // displayList(newList);
            return true;
        }
    }
    
    /** Removes a value from the set. Returns true if the set contained the specified element. */
    public bool Remove(int val) {
        if (myDict.ContainsKey(val))
        {
            int idxRemove = myDict[val];
            int idxLast = newList.Count-1;
            myDict[newList[idxLast]] = idxRemove;
            myDict.Remove(val);
            newList[idxRemove] = newList[idxLast];
            newList.RemoveAt(idxLast);
            // Console.Write("removed : {0} ", val);
            // displayList(newList);
            return true;
        }
        else
        {
            return false;
        }
    }
    
    /** Get a random element from the set. */
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
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */
// @lc code=end

