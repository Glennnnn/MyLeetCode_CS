/*
 * @lc app=leetcode.cn id=328 lang=csharp
 *
 * [328] 奇偶链表
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode OddEvenList(ListNode head) {

        // Solution#1 clean - O(n), O(1)
        if (head == null) return null;

        ListNode odd = head;
        ListNode even = head.next;
        ListNode headEven = even;
        
        // even is always one step faster
        while(even != null && even.next != null)
        {
            odd.next = even.next;
            even.next = odd.next.next;
            odd = odd.next;
            even = even.next;
        }
        odd.next = headEven;    // connect the two lists
        return head;


        /*
        // Solution#1 - O(n), O(1)
        if (head == null) return null;

        ListNode odd = head;
        ListNode even = head.next;
        ListNode dummyO = new ListNode(-1, odd);
        ListNode dummyE = new ListNode(-2, even);
        // dispLL(dummyO);
        // dispLL(dummyE);
        
        while(even != null && even.next != null) // even is always 1 step faster
        {
            odd.next = even.next;
            even.next = odd.next.next;
            odd = odd.next;
            even = even.next;
            // dispLL(dummyO);
            // dispLL(dummyE);
        }
        odd.next = dummyE.next; // connect the two lists
        //dispLL(dummyO);
        return dummyO.next;
        */
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

