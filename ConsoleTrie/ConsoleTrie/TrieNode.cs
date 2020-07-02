using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleTrie
{
    public class TrieNode
    {
        public string Key;
        public int? Value;
        public int Level;

        public SortedDictionary<string, TrieNode> Children;

        public TrieNode()
        {
            Key = string.Empty;
            Value = 0;
            Level = 0;
            Children = new SortedDictionary<string, TrieNode>();
        }

        public TrieNode(string key, int? value, int level)
        {
            Key = key;
            Value = value;
            Level = level;
            Children = new SortedDictionary<string, TrieNode>();
        }

        public TrieNode(char key, int? value, int level) : this(new string(key, 1), value, level)
        {
        }

        public TrieNode(IEnumerable<char> key, int? value, int level) : this(new string(key.ToArray()), value, level)
        {
        }

        public void Insert(string key, int? value)
        {
            if (Key == key)
            {
                Value = value;
                return;
            }

            var prefix = Children.Keys.FirstOrDefault(key.StartsWith);
            TrieNode node;
            if (prefix == null)
            {
                prefix = new string(key.Take(Level + 1).ToArray());
                node = new TrieNode(key.Take(Level + 1), value, Level + 1);
                Children.Add(prefix, node);
            }
            else
            {
                node = Children[prefix];
            }

            node.Insert(key, value);
        }

        public void Delete(string key)
        {
            if (Children.ContainsKey(key))
            {
                var childMatch = Children[key];
                if (!childMatch.Children.Any())
                {
                    Children.Remove(key); // remove the match
                }
                else
                {
                    childMatch.Value = null; // there's descendant keys, just set the value to null
                }

                return;
            }

            var prefix = Children.Keys.FirstOrDefault(key.StartsWith);
            if (prefix == null)
            {
                return; // nothing to be done, the key isn't in the trie.
            }

            Children[prefix].Delete(key);
        }

        public int? Lookup(string key)
        {
            if (Key == key)
            {
                return Value;
            }

            var prefix = Children.Keys.FirstOrDefault(key.StartsWith);
            if (prefix == null)
            {
                return null;
            }

            return Children[prefix].Lookup(key);
        }

        public void Traverse(bool onlyKeysWithValues = true)
        {
            if (!onlyKeysWithValues)
            {
                Console.Write($"{Key} ");
            }
            else if (Value.HasValue)
            {
                Console.Write($"{Key} ");
            }

            foreach (var (_, node) in Children)
            {
                node.Traverse(onlyKeysWithValues);
            }
        }
    }
}