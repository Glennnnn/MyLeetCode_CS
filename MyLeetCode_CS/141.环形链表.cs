/*
 * @lc app=leetcode.cn id=141 lang=csharp
 *
 * [141] 环形链表
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
    public bool HasCycle(ListNode head) {
        ListNode fast = head;
        ListNode slow = head;

        bool moveSlow = true;

        while (fast != null)
        {
            fast = fast.next;
            moveSlow = !moveSlow;
            if (moveSlow)
            {
                slow = slow.next;
                if (fast == slow) return true;
            }
        }
        return false;
    }
}
// @lc code=end

