/*
 * @lc app=leetcode.cn id=19 lang=csharp
 *
 * [19] 删除链表的倒数第N个节点
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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {

        ListNode ptr1=head, ptr2=head;

        int count = 0;
        while (ptr1 != null)
        {
            ptr1 = ptr1.next;
            count ++;

            // ptr2 has to lag ptr1 by (n+1) 
            // in order to skip nth last node
            if (count > n+1)
                ptr2 = ptr2.next;
        }
        
        // Console.WriteLine("count={0}", count);
        // dispLL(head);
        // dispLL(ptr2);

        if (count > n) ptr2.next = ptr2.next.next;
        else if (count == n) head = head.next;
        else Console.WriteLine("Invalid input");

        return head;






        /*
        // solution#1
        Queue<ListNode> queue = new Queue<ListNode>();
        ListNode currNodePtr = head;

        dispLL(head);

        Console.Write("Enqueue: ");
        while (currNodePtr!=null)
        {
            Console.Write("{0} ", currNodePtr.val);
            queue.Enqueue(currNodePtr);
            currNodePtr = currNodePtr.next;
        }
        Console.WriteLine();

        ListNode dummy =new ListNode(-1);
        currNodePtr = dummy;

        Console.Write("Dequeue: ");
        while (queue.Count>0)
        {
            ListNode node = queue.Dequeue();

            if (queue.Count == n-1)
            {
                Console.Write("{0}*", node.val);
                node.next = null;
            }
            else
            {
                Console.Write("{0} ", node.val);
                currNodePtr.next = node;
                currNodePtr = node;
                currNodePtr.next = null;
            }
        }
        Console.WriteLine();

        head = dummy.next;
        dispLL(head);

        return head;
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

