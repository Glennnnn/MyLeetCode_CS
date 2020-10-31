/*
 * @lc app=leetcode.cn id=817 lang=csharp
 *
 * [817] 链表组件
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
    public int NumComponents(ListNode head, int[] G) {
        HashSet<int> newSet = new HashSet<int>(G);

        int ans = 0;
        bool connecting = false;

        ListNode node = head;

        while (node != null)
        {
            if (newSet.Contains(node.val))
            {
                connecting = true;
            }
            else if (connecting) // break now
            {
                ans ++;
                connecting = false;
            }
            node = node.next;
        }

        if (connecting) ans ++;
        return ans;
    }
}
// @lc code=end

