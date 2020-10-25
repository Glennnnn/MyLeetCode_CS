/*
 * @lc app=leetcode.cn id=211 lang=csharp
 *
 * [211] 添加与搜索单词 - 数据结构设计
 */

// @lc code=start
public class TrieNode
{
    public char val;
    public TrieNode[] children = new TrieNode[26];
    public bool isEnd = false;

    public TrieNode(char c)
    {
        this.val = c;
    }

    public TrieNode GetTrie(char c)
    {
        int idx = (int)(c-'a');
        return children[idx];
    }

    public void PutTrie(char c)
    {
        int idx = (int)(c-'a');
        children[idx] = new TrieNode(c);
    }
}

public class WordDictionary {

    TrieNode root;
    /** Initialize your data structure here. */
    public WordDictionary() {
        root = new TrieNode('-');
    }
    
    /** Adds a word into the data structure. */
    public void AddWord(string word) {
        TrieNode node  = root;
        foreach(char c in word)
        {
            if (node.GetTrie(c) == null)
                node.PutTrie(c);
            node = node.GetTrie(c);
        }
        node.isEnd = true;
    }
    
    /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
    public bool Search(string word) {
        return search2(word, root);
    }

    private bool search2(string word, TrieNode node)
    {
        if (node == null) 
            return false;

        for (int i=0;i<word.Length;i++)
        {
            if (word[i] == '.')
            {
                string remaining = word.Substring(i+1);
                //Console.WriteLine("continue search {0}", remaining);

                foreach (TrieNode child in node.children)
                {
                    if (search2(remaining, child))
                        return true;
                }
                return false;
            }
            else
            {
                node = node.GetTrie(word[i]);
                if (node == null)
                    return false;
            }
        }
        return node.isEnd;
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */
// @lc code=end

