using System;

namespace ConsoleTrie
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            BstTests();
            TrieTests();
        }

        static void TrieTests()
        {
            var trie = TrieFactory.MakeWikipediaTrie();
            trie.Traverse();
            Console.WriteLine();
            Console.WriteLine($"Looking up value of 'tea': {trie.Lookup("tea")}");
            Console.WriteLine($"Looking up value of 'i': {trie.Lookup("i")}");
            Console.WriteLine($"Looking up value of 'teapot': {trie.Lookup("teapot")?.ToString() ?? "null"}");
        }

        static void BstTests()
        {
            var bst = BstFactory.MakeWikipediaBst();
            Console.WriteLine($"IsBst: {bst.IsBst()}");
            bst.Traverse();
            Console.WriteLine();
            for (int i = 1; i <= 15; i++)
            {
                Console.WriteLine($"Lookup {i}: {bst.Lookup(i)}");
            }

            Console.WriteLine("Delete 6..");
            bst.Delete(6);
            Console.WriteLine($"IsBst: {bst.IsBst()}");
            Console.WriteLine("Delete 8..");
            bst.Delete(8);
            Console.WriteLine($"IsBst: {bst.IsBst()}");
            Console.WriteLine("Delete 3..");
            bst.Delete(3);
            Console.WriteLine($"IsBst: {bst.IsBst()}");
            Console.WriteLine("Delete 42..");
            bst.Delete(42);
            Console.WriteLine($"IsBst: {bst.IsBst()}");
            bst.Traverse();
            Console.WriteLine();
        }
    }
}