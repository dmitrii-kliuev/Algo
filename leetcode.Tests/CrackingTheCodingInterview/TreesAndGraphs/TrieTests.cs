using System.Diagnostics;
using Xunit;

namespace Algo.Tests.CrackingTheCodingInterview.TreesAndGraphs
{
    public class TrieTests
    {
        [Fact]
        public void Test()
        {
            // Input keys (use only 'a' 
            // through 'z' and lower case)
            string[] keys = { "the", "a", "there", "answer", "any", "by", "bye", "their" };

            const string present = "Present in trie";
            const string absent = "Not present in trie";

            var trie = new Trie();

            // Construct trie
            int i;
            for (i = 0; i < keys.Length; i++)
                trie.Insert(keys[i]);

            // Search for different keys
            if (trie.Search("the"))
                Debug.WriteLine("the --- " + present);
            else Debug.WriteLine("the --- " + absent);

            if (trie.Search("these"))
                Debug.WriteLine("these --- " + present);
            else Debug.WriteLine("these --- " + absent);

            if (trie.Search("their"))
                Debug.WriteLine("their --- " + present);
            else Debug.WriteLine("their --- " + absent);

            if (trie.Search("thaw"))
                Debug.WriteLine("thaw --- " + present);
            else Debug.WriteLine("thaw --- " + absent);
        }
    }

    public class Trie
    {
        const int ALPHABET_SIZE = 26;
        private readonly TrieNode _root;

        public Trie()
        {
            _root = new TrieNode();
        }

        public void Insert(string key)
        {
            var pCrawl = _root;

            for (var level = 0; level < key.Length; level++)
            {
                var index = key[level] - 'a';
                pCrawl.Children[index] ??= new TrieNode();

                pCrawl = pCrawl.Children[index];
            }

            pCrawl.IsEndOfWord = true;
        }

        public bool Search(string key)
        {
            var pCrawl = _root;

            for (var level = 0; level < key.Length; level++)
            {
                var index = key[level] - 'a';

                if (pCrawl.Children[index] == null)
                {
                    return false;
                }

                pCrawl = pCrawl.Children[index];
            }

            return pCrawl != null && pCrawl.IsEndOfWord;
        }

        private class TrieNode
        {
            public readonly TrieNode[] Children = new TrieNode[ALPHABET_SIZE];

            public bool IsEndOfWord;

            public TrieNode()
            {
                IsEndOfWord = false;
                for (var i = 0; i < ALPHABET_SIZE; i++)
                {
                    Children[i] = null;
                }
            }
        }
    }
}
