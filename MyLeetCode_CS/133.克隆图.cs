/*
 * @lc app=leetcode.cn id=133 lang=csharp
 *
 * [133] 克隆图
 */

// @lc code=start
/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;
    
    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }
    
    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {

    List<Node> cloned = new List<Node>();
    public Node CloneGraph(Node node) {
        if (node == null) return null;
        
        Node clone = new Node(node.val);
        cloned.Add(clone);
        foreach (Node nb in node.neighbors) 
        {
            clone.neighbors.Add(findNode(nb));
        }
        return clone;
    }

    private Node findNode(Node targetNode)
    {
        foreach(Node node in cloned)
        {
            if (node.val == targetNode.val)
            {
                return node;
            }
        }
        return CloneGraph(targetNode);
    }
}
// @lc code=end

