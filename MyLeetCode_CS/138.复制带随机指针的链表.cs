/*
 * @lc app=leetcode.cn id=138 lang=csharp
 *
 * [138] 复制带随机指针的链表
 */

// @lc code=start
/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {



    // Solution#2 - Time O(3n), Space O(1)
    public Node CopyRandomList(Node head) {

        if (head == null) return null;
        Node curr;

        // step1. copy a node behind EACH of the original nodes
        // one pass - O(n)
        curr = head;
        while (curr != null)
        {
            Node node = new Node(curr.val);
            node.next = curr.next;
            curr.next = node;
            curr = node.next;
        }

        // step2. all nodes are copied now, assign the random pointers
        // one pass - O(n)        
        curr = head;
        while (curr != null)
        {
            if (curr.random != null)
                curr.next.random = curr.random.next;
            curr = curr.next.next;
        }

        // head.next is the head of the copied list
        // keep a handle before losing it
        Node ans = head.next;
        
        // step3. cut off the links with the original list
        // one pass - O(n)
        curr = head;
        while (curr != null)
        {
            Node tmp = curr.next;
            curr.next = tmp.next;
            if (tmp.next != null)
                tmp.next = tmp.next.next;
            curr = curr.next;
        }

        return ans;

    }

    /*
    // Solution#1 - recursion
    Dictionary<Node, Node> cloned = new Dictionary<Node, Node>();
    public Node CopyRandomList(Node head) {
        if (head == null) return null;
        if (!cloned.ContainsKey(head))
        {
            // has to be added into dictionary first
            Node newNode = new Node(head.val, null, null);
            cloned.Add(head, newNode);
            // update place holders
            newNode.next = CopyRandomList(head.next);
            newNode.random = CopyRandomList(head.random);
        }
        return cloned[head];
    }
    */
}
// @lc code=end

