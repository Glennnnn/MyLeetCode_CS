/*
 * @lc app=leetcode.cn id=142 lang=csharp
 *
 * [142] 环形链表 II
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public ListNode DetectCycle(ListNode head) {
        ListNode fast = head;
        ListNode slow = head;

        bool moveSlow = true;

        // find first encounter
        while (fast != null)
        {
            fast = fast.next;
            moveSlow = !moveSlow;
            if (moveSlow)
            {
                slow = slow.next;
                if (fast == slow) break;
            }
        }
        // find second encounter
        if (fast != null)
        {
            fast = head;
            while (fast != slow)
            {
                fast = fast.next;
                slow = slow.next;
            }
        }
        return fast;
    }
}
// @lc code=end

