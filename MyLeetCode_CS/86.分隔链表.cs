/*
 * @lc app=leetcode.cn id=86 lang=csharp
 *
 * [86] 分隔链表
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
    public ListNode Partition(ListNode head, int x) {

        ListNode dummy1 = new ListNode(0);
        ListNode dummy2 = new ListNode(x);

        dummy1.next = head;
        ListNode prev1 = dummy1;
        ListNode curr1 = head;
        ListNode prev2 = dummy2;
        
        while (curr1 != null)
        {
            // append to list2
            if (curr1.val >= x) 
            {
                prev1.next = null;
                prev2.next = curr1;
                curr1 = curr1.next;
                prev2 = prev2.next;
                prev2.next = null;
            }
            // stay in list1
            else    
            {
                prev1.next = curr1;
                prev1 = prev1.next;
                curr1 = curr1.next;
            }            
        }
        // dispLL(dummy1);
        // dispLL(dummy2);

        // connect the two lists
        prev1.next = dummy2.next;
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

