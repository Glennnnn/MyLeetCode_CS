/*
 * @lc app=leetcode.cn id=445 lang=csharp
 *
 * [445] 两数相加 II
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
    // solution#2 - stack, not reversing original linked list
    // O(n1) + O(n2) + O(n3) = O(n)
    // O(n3) = O(n)
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        Stack<int> stack1 = ll2stack(l1);
        Stack<int> stack2 = ll2stack(l2);

        Stack<int> stack3 = new Stack<int>();
        int carry = 0;
        while (stack1.Count>0 || stack2.Count>0 || carry>0)
        {
            int a = (stack1.Count>0? stack1.Pop(): 0);
            int b = (stack2.Count>0? stack2.Pop(): 0);
            int newDigit = a + b + carry;
            carry = newDigit/10;
            newDigit %= 10;
            stack3.Push(newDigit);
        }
        return stack2ll(stack3);
    }
    private Stack<int> ll2stack(ListNode node)
    {
        Stack<int> stack = new Stack<int>();
        while (node != null)
        {
            stack.Push(node.val);
            node = node.next;
        }
        return stack;
    }
    private ListNode stack2ll(Stack<int> stack)
    {
        ListNode dummy = new ListNode(-1);
        ListNode node = dummy;
        while (stack.Count>0)
        {
            node.next = new ListNode(stack.Pop());
            node = node.next;
        }
        return dummy.next;
    }    



    /*
    // solution#1 - reverse
    // O(n1+n2+n3) = O(3n)
    // O(n3) = O(n)
    // where n3=max(n1,n2)+1
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        // dispLL(l1);
        // dispLL(l2);
        reverseLL(l1, ref l1);
        reverseLL(l2, ref l2);
        // dispLL(l1);
        // dispLL(l2);
        ListNode dummy = new ListNode(-1);
        ListNode l3 = dummy;
        int carry = 0;
        
        while (l1!=null || l2!=null || carry>0)
        {
            int newNodeVal = carry;
            if (l1!=null)
            {
                newNodeVal += l1.val;
                l1 = l1.next;
            }
            if (l2!=null)
            {
                newNodeVal += l2.val;
                l2 = l2.next;
            }
            carry = newNodeVal/10;
            newNodeVal %= 10;
            l3.next = new ListNode(newNodeVal);
            l3 = l3.next;
        }
        l3 = dummy.next;
        reverseLL(l3, ref l3);
        dummy.next = l3;

        return l3;
    }
    private ListNode reverseLL(ListNode node, ref ListNode head)
    {
        if (node.next != null)
        {
            reverseLL(node.next, ref head).next = node;
            node.next = null;
        }
        else
            head = node;
        return node;
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
    */
}
// @lc code=end

