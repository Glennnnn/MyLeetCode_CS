/*
 * @lc app=leetcode.cn id=92 lang=csharp
 *
 * [92] 反转链表 II
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode ReverseBetween(ListNode head, int m, int n) {


        Stack<ListNode> stack = new Stack<ListNode>();

        ListNode dummy1 = new ListNode(-1);
        dummy1.next = head;
        ListNode prev1 = dummy1;
        ListNode node = head;

        for (int i=1;i<=n;i++)
        {
            if (i<m)    // move pointers forward
            {
                prev1 = node;
                node = node.next;
            }
            else
            {
                // cut the part <m with the following part
                if (i==m)  prev1.next = null;
                stack.Push(node);
                node = node.next;
            }
        }
                
        // pop nodes in stack
        // construct new list in reversed order
        ListNode dummy2 = new ListNode(-1);
        ListNode node2 = dummy2;
        while (stack.Count>0)
        {
            node2.next = stack.Pop();
            node2 = node2.next;
            node2.next = null;  // cut off existing links
        }
        
        // insert dummy2 into dummy1
        prev1.next = dummy2.next;
        node2.next = node;

        return dummy1.next;
    }
    private void dispLL(ListNode head)
    {
        string s = "";

        while (head != null)
        {
            s += string.Format("{0}->", head.val);
            head = head.next;
        }
        s += "null";

        Console.WriteLine(s);
    }    
}
// @lc code=end

