using System.Collections.Generic;
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

            var words = trie.GetWords();
            foreach (var word in words)
            {
                Debug.WriteLine(word);
            }

            Debug.WriteLine("-------th-------");
            foreach (var word in trie.SearchSuggestions("th", 20))
            {
                Debug.WriteLine(word);
            }

            Debug.WriteLine("-------a-------");
            foreach (var word in trie.SearchSuggestions("a", 20))
            {
                Debug.WriteLine(word);
            }

            Debug.WriteLine("-------b-------");
            foreach (var word in trie.SearchSuggestions("b", 20))
            {
                Debug.WriteLine(word);
            }

        }
    }

    public class Trie
    {
        private const int ALPHABET_SIZE = 26;
        private readonly TrieNode _root;

        public Trie()
        {
            _root = new TrieNode();
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

        public void Insert(string key)
        {
            var node = _root;

            for (var level = 0; level < key.Length; level++)
            {
                var index = key[level] - 'a';
                node.Children[index] ??= new TrieNode();

                node = node.Children[index];
            }

            node.IsEndOfWord = true;
        }

        public bool Search(string key)
        {
            var node = _root;

            for (var level = 0; level < key.Length; level++)
            {
                var index = key[level] - 'a';

                if (node.Children[index] == null)
                {
                    return false;
                }

                node = node.Children[index];
            }

            return node != null && node.IsEndOfWord;
        }

        public IEnumerable<string> GetWords(int quantity = 0)
        {
            const string str = "";
            var words = new List<string>();
            GetWords(_root, str, words, quantity);

            return words;
        }

        void GetWords(TrieNode node, string str, ICollection<string> words, int quantity = 0)
        {
            if (quantity != 0 && words.Count == quantity) return;

            if (node.IsEndOfWord)
            {
                words.Add(str);
            }

            for (var i = 0; i < ALPHABET_SIZE; i++)
            {
                if (node.Children[i] != null)
                {
                    var newStr = str + (char)(i + 'a');
                    GetWords(node.Children[i], newStr, words, quantity);
                }
            }
        }

        public IEnumerable<string> SearchSuggestions(string start, int quantity = 0)
        {
            var suggestions = new List<string>();
            if (start == null) return suggestions;

            var node = _root;

            for (var level = 0; level < start.Length; level++)
            {
                var index = start[level] - 'a';

                if (node.Children[index] != null)
                {
                    node = node.Children[index];
                }
            }

            GetWords(node, start, suggestions, quantity);

            return suggestions;
        }
    }
}
