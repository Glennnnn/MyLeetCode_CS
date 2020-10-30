/*
 * @lc app=leetcode.cn id=432 lang=csharp
 *
 * [432] 全 O(1) 的数据结构
 */

// @lc code=start

public class DLLNode {

    public int count;
    public HashSet<string> hs;
    public DLLNode prev, next;

    public DLLNode (int cnt, DLLNode prevNode=null, DLLNode nextNode=null)
    {
        // create node object
        this.count = cnt;
        this.hs = new HashSet<string>();
        // connect to double linked list
        this.prev = prevNode;
        this.next = nextNode;
        if (prevNode != null) prevNode.next = this;
        if (nextNode != null) nextNode.prev = this;
    }    

    public void insertKey (string s)
    {
        hs.Add(s);
    }
    public void removeKey (string s)
    {
        if (!hs.Contains(s)) return;    // do nothing if not exist
        hs.Remove(s);       // O(1) for hashset
        if (hs.Count==0)    // disconnect if empty
        {
            this.prev.next = this.next;
            this.next.prev = this.prev;
            this.prev = null;
            this.next = null;
        }
    }
    public string getFirst()
    {
        return (hs.Count==0) ? "":hs.First();
    }

    public DLLNode getPrevNode()
    {
        int target = this.count-1;
        if (prev.count == target) return prev;
        // create new node if prev node is not immediate prev
        return new DLLNode(target, prev, this);
    }

    public DLLNode getNextNode()
    {
        int target = this.count+1;
        if (next.count == target) return next;
        // create new node if next node is not immediate next
        return new DLLNode(target, this, next);
    }
}

public class AllOne {
    bool display = false;    // debug

    Dictionary<string, DLLNode> myDict;
    DLLNode head, tail;

    /** Initialize your data structure here. */
    public AllOne() {
        myDict = new Dictionary<string, DLLNode>();
        head = new DLLNode(0);
        tail = new DLLNode(0);
        head.next = tail;
        tail.prev = head;
    }
    
    /** Inserts a new key <Key> with value 1. Or increments an existing key by 1. */
    public void Inc(string key) {

        DLLNode currNode = myDict.ContainsKey(key)? myDict[key]: head;
        DLLNode nextNode = currNode.getNextNode();
        // put the key into next node
        nextNode.insertKey(key);
        // update dictionary
        myDict[key] = nextNode;
        // remove the key from current node
        currNode.removeKey(key);    // head node is empty anyways

        if (display)
        {
            Console.WriteLine("Inc: {0}", key);
            displayDictionary(myDict);
            displDLL_Fwd();
            displDLL_Bwd();
        }
    }
    
    /** Decrements an existing key by 1. If Key's value is 1, remove it from the data structure. */
    public void Dec(string key) {
        if (myDict.ContainsKey(key))
        {
            DLLNode currNode = myDict[key];
            DLLNode prevNode = currNode.getPrevNode();

            myDict.Remove(key); // remove from dictionary for now
            if (prevNode != head)   // insertable
            {
                // put the key into prev node
                prevNode.insertKey(key);
                // update dictionary
                myDict.Add(key, prevNode);
            }
            // remove the key from current node
            currNode.removeKey(key);
        }

        if (display)
        {
            Console.WriteLine("Dec: {0}", key);
            displayDictionary(myDict);
            displDLL_Fwd();
            displDLL_Bwd();
        }
    }
    
    /** Returns one of the keys with maximal value. */
    public string GetMaxKey() {
        return tail.prev.getFirst();
    }
    
    /** Returns one of the keys with Minimal value. */
    public string GetMinKey() {
        return head.next.getFirst();
    }

    private void displayDictionary(Dictionary<string, DLLNode> dict)
    {
        string s = "myDict: ";
        foreach (KeyValuePair<string, DLLNode> kvp in dict)
        {
            s += string.Format("[{0}:{1}],", kvp.Key, ((DLLNode)kvp.Value).count);
        }
        Console.WriteLine(s.TrimEnd(','));
    }
    private void displDLL_Fwd()
    {
        string ans = "Forward :";
        DLLNode node = head;
        while (node != null)
        {
            string ss = "";
            foreach (string sss in node.hs)
            {
                ss += sss + ",";
            }
            ans += string.Format("[{0}],", ss.TrimEnd(','));
            node = node.next;
        }
        Console.WriteLine(ans.TrimEnd(','));
    }
    private void displDLL_Bwd()
    {
        string ans = "Backward:";
        DLLNode node = tail;
        while (node != null)
        {
            string ss = "";
            foreach (string sss in node.hs)
            {
                ss += sss + ",";
            }
            ans += string.Format("[{0}],", ss.TrimEnd(','));
            node = node.prev;
        }
        Console.WriteLine(ans.TrimEnd(','));
    }
}



/**
 * Your AllOne object will be instantiated and called as such:
 * AllOne obj = new AllOne();
 * obj.Inc(key);
 * obj.Dec(key);
 * string param_3 = obj.GetMaxKey();
 * string param_4 = obj.GetMinKey();
 */
// @lc code=end

