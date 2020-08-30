/*
 * @lc app=leetcode.cn id=24 lang=csharp
 *
 * [24] 两两交换链表中的节点
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
    public ListNode SwapPairs(ListNode head) {
        const int k = 2;
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

