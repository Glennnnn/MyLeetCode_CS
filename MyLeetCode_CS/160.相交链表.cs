/*
 * @lc app=leetcode.cn id=160 lang=csharp
 *
 * [160] 相交链表
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
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        
        // Solution#2 - O(n), O(1)
        ListNode nodeA = headA;
        ListNode nodeB = headB;

        while (nodeA != nodeB)
        {
            nodeA = (nodeA == null)? headB:nodeA.next;
            nodeB = (nodeB == null)? headA:nodeB.next;
        }
        return nodeA;

        /*
        // Solution#1 - O(3n), O(2n)
        ListNode node = null;
        Stack<ListNode> listA = new Stack<ListNode>();
        Stack<ListNode> listB = new Stack<ListNode>();

        // O(n)
        node = headA;
        while (node != null)
        {
            listA.Push(node);
            node = node.next;
        }
        
        // O(n)
        node = headB;
        while (node != null)
        {
            listB.Push(node);
            node = node.next;
        }
        
        // O(n)
        node = null;
        while (listA.Count>0 && listB.Count>0 
                && listA.Peek()==listB.Peek())
        {
            node = listA.Pop();
            listB.Pop();
        }
        return node;
        */
    }
}
// @lc code=end

