/*
 * @lc app=leetcode.cn id=460 lang=csharp
 *
 * [460] LFU缓存
 */

// @lc code=start

public class DLLNode {

    public int count;   //# of access
    public int key;
    public int value;
    public DLLNode next, prev;
    public DLLNode (int key, int value, DLLNode prevNode=null, DLLNode nextNode=null)
    {
        // create node object
        this.count = 1;
        this.key = key;
        this.value = value;
        // connect to linked list
        this.next = nextNode;
        this.prev = prevNode;        
        if (prevNode != null) prevNode.next = this;
        if (nextNode != null) nextNode.prev = this;
    }
    
    public void moveBack()
    {
        while(this.count >= this.next.count)
        {
            // keep moving backwards by swapping
            DLLNode nextNode = this.next;

            this.prev.next = nextNode;
            nextNode.prev = this.prev;
            nextNode.next.prev = this;
            this.next = nextNode.next;
            this.prev = nextNode;
            nextNode.next = this;
        }
    }
    public void delete()
    {
        this.prev.next = this.next;
        this.next.prev = this.prev;
        this.prev = null;
        this.next = null;
    }
}


/*
Use a double linked list to store values
head = least frequent, tail = most frequent
each node contains 2 properties
1) access count
2) value
*/

public class LFUCache {
    bool display = false;    // debug

    Dictionary<int, DLLNode> myDict;
    DLLNode head, tail;
    int capacityDLL;    // remaining spot

    public LFUCache(int capacity) {
        this.myDict = new Dictionary<int, DLLNode>();
        this.head = new DLLNode(-1, -1, null, null);
        this.tail = new DLLNode(-1, -1, null, null);
        head.count = -1;
        tail.count = Int32.MaxValue;
        head.next = tail;
        tail.prev = head;
        this.capacityDLL = capacity;
    }
    
    public int Get(int key) {
        
        int ans = -1;
        if (myDict.ContainsKey(key))
        {
            DLLNode currNode = myDict[key];
            ans = currNode.value;
            currNode.count ++;
            currNode.moveBack();
        }
        if (display)
        {
            Console.WriteLine("Get {0} returns {1}", key, ans);
            displayDictionary(myDict);
            displDLL_Fwd();
            displDLL_Bwd();
        }
        return ans;
    }
    
    public void Put(int key, int value) {
        if (myDict.ContainsKey(key))
        {
            DLLNode currNode = myDict[key];
            currNode.value = value; // update value
            currNode.count ++;
            currNode.moveBack();
        }
        else
        {
            if (capacityDLL==0)
            {
                // invalidate the first node
                DLLNode nodeLFU = head.next;

                if (nodeLFU == tail)
                    return; // original capacity==0
                else
                {
                    if (display)
                    {
                        Console.WriteLine("remove node [{0},{1}]", nodeLFU.count, nodeLFU.value);
                    }
                    nodeLFU.delete();
                    myDict.Remove(nodeLFU.key);
                    capacityDLL++;
                }
            }

            DLLNode newNode = new DLLNode(key, value, head, head.next);
            newNode.moveBack();
            capacityDLL--;
            myDict.Add(key, newNode);
        }
        if (display)
        {
            Console.WriteLine("Put: {0}, {1}", key, value);
            displayDictionary(myDict);
            displDLL_Fwd();
            displDLL_Bwd();
        }
    }

    private void displayDictionary(Dictionary<int, DLLNode> dict)
    {
        string s = "myDict: ";
        foreach (KeyValuePair<int, DLLNode> kvp in dict)
        {
            DLLNode node = (DLLNode)kvp.Value; 
            s += string.Format("[key={0}: count={1}, value={2}],", kvp.Key, node.count, node.value);
        }
        Console.WriteLine(s.TrimEnd(','));
    }
    private void displDLL_Fwd()
    {
        string ans = "Forward :";
        DLLNode node = head;
        while (node != null)
        {
            ans += string.Format("[{0},{1}],", node.count, node.value);
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
            ans += string.Format("[{0},{1}],", node.count, node.value);
            node = node.prev;
        }
        Console.WriteLine(ans.TrimEnd(','));
    }    
    
}

/**
 * Your LFUCache object will be instantiated and called as such:
 * LFUCache obj = new LFUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
// @lc code=end

