/*
 * @lc app=leetcode.cn id=206 lang=csharp
 *
 * [206] 反转链表
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
    
    // Solution#1 - Recursion
    ListNode newHead = null;
    public ListNode ReverseList(ListNode head) {
        if (head != null) recursion(head);
        return newHead;
    }
    private ListNode recursion(ListNode node)
    {
        if (node.next == null)
            newHead = node;
        else
        {
            recursion(node.next).next = node;
            node.next = null;
        }
        //dispLL(newHead);
        return node;
    }

    /*
    // Solution#2 - Loop & stack
    public ListNode ReverseList(ListNode head) {

        Stack<ListNode> stack = new Stack<ListNode>();
        
        ListNode node = head;
        while (node != null)
        {
            stack.Push(node);
            node = node.next;
        }
        
        ListNode dummy = new ListNode(-1);
        node = dummy;       // head
        while (stack.Count>0)
        {
            node.next = stack.Pop();
            node = node.next;
        }
        node.next = null;   // tail

        return dummy.next;
    }
    */

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

