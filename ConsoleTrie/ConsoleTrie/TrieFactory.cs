namespace ConsoleTrie
{
    internal static class TrieFactory
    {
        public static TrieNode MakeWikipediaTrie()
        {
            var trie = new TrieNode();
            trie.Insert("t", null);
            trie.Insert("A", null);
            trie.Insert("i", 11);
            trie.Insert("to", 7);
            trie.Insert("te", null);
            trie.Insert("in", 5);
            trie.Insert("tea", 3);
            trie.Insert("ted", 4);
            trie.Insert("ten", 12);
            trie.Insert("inn", 9);
            return trie;
        }
    }
}