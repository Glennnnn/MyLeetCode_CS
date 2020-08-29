/*
 * @lc app=leetcode.cn id=23 lang=csharp
 *
 * [23] 合并K个升序链表
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
    public ListNode MergeKLists(ListNode[] lists) {
        ListNode ans = null;
        foreach (ListNode list in lists)
            ans = MergeTwoLists(ans, list);
        return ans;
    }

    private ListNode MergeTwoLists(ListNode l1, ListNode l2) {

        ListNode dummy = new ListNode(-1);
        ListNode ptr = dummy;

        while (true)
        {
            if (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    ptr.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    ptr.next = l2;
                    l2 = l2.next;
                }
                ptr = ptr.next;
                ptr.next = null;
            }
            else
            {
                if (l2 != null) ptr.next = l2;
                if (l1 != null) ptr.next = l1;
                break;
            }
        }

        return dummy.next;
    }

}
// @lc code=end

