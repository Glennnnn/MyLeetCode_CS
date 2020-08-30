/*
 * @lc app=leetcode.cn id=25 lang=csharp
 *
 * [25] K 个一组翻转链表
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
    public ListNode ReverseKGroup(ListNode head, int k) {
        //const int k = 2;  // given
        Stack<ListNode> stack = new Stack<ListNode>();
        ListNode dummy = new ListNode(-1);
        ListNode ptr1 = dummy;
        ListNode ptr2 = head;
        
        while (ptr2 != null)
        {
            // push nodes into stack of size k
            stack.Push(ptr2);
            ptr2 = ptr2.next;

            // once stack is full
            // pop all nodes and append to new linked list
            if (stack.Count == k)
            {
                while (stack.Count > 0)
                {
                    ptr1.next = stack.Pop();
                    ptr1 = ptr1.next;
                    ptr1.next = null;   // cut existing link
                }
                // dispLL(dummy.next);
            }
        }

        // for any remaining nodes in stack
        // just find the bottom one without changing their order
        while (stack.Count>0)
        {
            ptr1.next = stack.Pop();
        }

        head = dummy.next;
        return head;
    }
}
// @lc code=end

