/*
 * @lc app=leetcode.cn id=203 lang=csharp
 *
 * [203] 移除链表元素
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
    /*
    // Solution#1
    public ListNode RemoveElements(ListNode head, int val) {
        ListNode prev = null;
        ListNode curr = head;

        while (curr != null)
        {
            if (curr.val == val)
            {
                if (curr==head)
                {
                    prev = head;
                    head = head.next;
                }
                else
                {
                    prev.next = curr.next;
                    curr.next = null;
                }
            }
            else
            {
                prev = curr;
            }
            curr = prev.next;            
        }
        return head;
    }
    */

    // Solution#2
    public ListNode RemoveElements(ListNode head, int val) {
        if (head == null) return null;
        head.next = RemoveElements(head.next, val);
        if (head.val != val) return head;
        else return head.next;
    }
}
// @lc code=end

