/*
 * @lc app=leetcode.cn id=146 lang=csharp
 *
 * [146] LRU缓存机制
 */

// @lc code=start

public class DLLNode
{
    public int val;
    public int key;
    public DLLNode prev;
    public DLLNode next;
    public DLLNode(int k, int x)
    {
        key = k;
        val = x;
        prev = null;
        next = null;
    }
}

public class LRUCache {

    int cap;
    Dictionary<int, DLLNode> myDic;
    DLLNode head, tail;

    public LRUCache(int capacity) {
        this.cap = capacity;
        this.myDic = new Dictionary<int, DLLNode>();
        this.head = null;
        this.tail = null;
    }
    
    public int Get(int key) {

        int ans = -1;
        if (myDic.ContainsKey(key))
        {
            ans = RemoveNode(key);
            AppendNode(key, ans);
        }
        // dispDLL(head);
        // displayDictionary(myDic);
        return ans;
    }
    
    public void Put(int key, int value) {
        if (myDic.ContainsKey(key))
            RemoveNode(key);
        else if (myDic.Count == cap)
            RemoveNode(head.key);
        AppendNode(key, value);
        //dispDLL(head);
        //displayDictionary(myDic);
    }

    // fetch the value, then remove it from dll and dictionary
    // return: value of corresponding key
    private int RemoveNode(int key)
    {
        DLLNode target = myDic[key];
        int ans = target.val;

		if (target.prev == null) head = target.next;
		else target.prev.next = target.next;
		if (target.next == null) tail = target.prev;
		else target.next.prev = target.prev;
		target = null;

        myDic.Remove(key);  //remove from hash table as well
        return ans;
    }

    // create a node and add it into dll and dictionary
    // return: the new node
    private DLLNode AppendNode(int key, int val)
    {
        DLLNode newNode = new DLLNode(key, val);

        if (tail == null)   // empty list
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.next = newNode;
            newNode.prev = tail;
            tail = newNode;
        }

        myDic.Add(key, newNode);
        return newNode;
    }

    private void displayDictionary(Dictionary<int, DLLNode> dict)
    {
        string s = "";
        foreach (KeyValuePair<int, DLLNode> kvp in dict)
        {
			s += string.Format("[{0}:{1}],", kvp.Key, kvp.Value.val);
        }
        Console.WriteLine(s.TrimEnd(','));
    }
    private void dispDLL(DLLNode head)
    {
        string s = "";
        while (head != null)
        {
            s += string.Format("{0} <=> ", head.val);
            head = head.next;
        }
        Console.WriteLine(s + "null");
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
// @lc code=end

