/*
 * @lc app=leetcode.cn id=237 lang=csharp
 *
 * [237] 删除链表中的节点
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
    public void DeleteNode(ListNode node) {
        /*
        // Solution#1 - O(n), O(1)
        while (node.next != null)
        {
            node.val = node.next.val;   // overwrite current node value with value of next node
            if (node.next.next == null) 
                node.next = null;   // drop the last node
            else
                node = node.next;   // keep moving forward
        }
        */

        // Solution#2 - O(1), O(1)
        node.val = node.next.val;   // overwrite current node value with value of next node
        node.next = node.next.next; // skip the next node
    }
}
// @lc code=end

