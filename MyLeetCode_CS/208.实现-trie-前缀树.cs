/*
 * @lc app=leetcode.cn id=208 lang=csharp
 *
 * [208] 实现 Trie (前缀树)
 */

// @lc code=start
public class Trie {

    TrieNode root;
    /** Initialize your data structure here. */
    public Trie() {
        root = new TrieNode('-');
    }
    
    /** Inserts a word into the trie. */
    public void Insert(string word) {
        TrieNode node = root;
        foreach (char c in word)
        {
            if (node.GetTrie(c) == null)
                node.PutTrie(c);
            node = node.GetTrie(c);
        }
        node.ending = true;
    }
    
    /** Returns if the word is in the trie. */
    public bool Search(string word) {
        TrieNode node = root;
        foreach (char c in word)
        {
            node = node.GetTrie(c);
            if (node == null)
                return false;
        }
        return node.ending; // see if this is the last char
    }
    
    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string prefix) {
        TrieNode node = root;
        foreach (char c in prefix)
        {
            node = node.GetTrie(c);
            if (node == null)
                return false;
        }
        return true; // not strict need to be the last char
    }
}

public class TrieNode
{
    public char val;
    public TrieNode[] children = new TrieNode[26];
    public bool ending = false;

    public TrieNode(char x)
    {
        val = x;
    }
    public TrieNode GetTrie(char c)
    {
        return children[(int)(c-'a')];
    }
    public void PutTrie(char c)
    {
        children[(int)(c-'a')] = new TrieNode(c);
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */
// @lc code=end

