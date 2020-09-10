/*
 * @lc app=leetcode.cn id=234 lang=csharp
 *
 * [234] 回文链表
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

    // Solution#2
    ListNode fowardNode;
    public bool IsPalindrome(ListNode head) {
        fowardNode = head;
        return check(fowardNode);
    }
    private bool check(ListNode backwardNode)
    {
        if (backwardNode == null) return true;
        bool result = check(backwardNode.next) 
            && (fowardNode.val==backwardNode.val);
        fowardNode = fowardNode.next;
        return result;
    }

    /*
    // Solution#1
    ListNode firstHalf, secondHalf;
    public bool IsPalindrome(ListNode head) {
        // Solution#1 - O(n), O(1)

        // two pointers - find mid node
        bool moveSlow = false;
        ListNode p1 = head, p2 = head;

        while (p1 != null)
        {
            p1 = p1.next;
            if (moveSlow) p2 = p2.next;
            moveSlow = !moveSlow;
        }
        // Console.WriteLine("moveSlow={0}", moveSlow);
        // dispLL(head);
        // dispLL(p2);

        // reverse the second half
        firstHalf = head;   // may contain an extra node in case of even # of nodes
        if (p2!=null) reverse(p2);
        // dispLL(firstHalf);
        // dispLL(secondHalf);        

        // compare firstHalf and secondHalf
        p1 = firstHalf;
        p2 = secondHalf;
        while (p2 != null)
        {
            if (p1.val == p2.val)
            {
                p2=p2.next;
                p1=p1.next;
            }
            else
                return false;
        }
        return true;
    }

    private ListNode reverse(ListNode node)
    {
        if (node.next == null)
        {
            secondHalf = node;
        }
        else
        {
            reverse(node.next).next = node;
            node.next = null;
        }
        return node;
    }

    private void dispLL(ListNode head, string title = "")
    {
        string s = "";

        if (!string.IsNullOrEmpty(title))
            s = title + ": ";
        while (head != null)
        {
            s += string.Format("{0}->", head.val);
            head = head.next;
        }
        s += "null";

        Console.WriteLine(s);
    }
    */
}
// @lc code=end

