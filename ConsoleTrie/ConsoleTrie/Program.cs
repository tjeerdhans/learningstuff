using System;
using System.ComponentModel;

namespace ConsoleTrie
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var bst = new BstNode();

            var rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                var nextKey = rnd.Next(1, 1001);
                bst.Insert(nextKey);
            }

            Console.WriteLine($"IsBst: {bst.IsBst(bst, int.MinValue, int.MaxValue)}"); 
            bst.Traverse();
            // bst.Insert(8);
            // bst.Insert(3);
            // bst.Insert(10);
            // bst.Insert(1);
            // bst.Insert(6);
            // bst.Insert(14);
            // bst.Insert(4);
            // bst.Insert(7);
            // bst.Insert(13);
        }
    }

    public class BstNode
    {
        public int? Key;
        public BstNode Left;
        public BstNode Right;

        public BstNode()
        {
            Key = null;
        }

        public BstNode(int key)
        {
            Key = key;
            Left = new BstNode();
            Right = new BstNode();
        }

        public void Traverse()
        {
            if (!Key.HasValue)
            {
                return;
            }

            Left.Traverse();
            Console.Write($"{Key} ");
            Right.Traverse();
        }

        public bool IsBst(BstNode node, int minKey, int maxKey)
        {
            if (!node.Key.HasValue)
            {
                return true;
            }

            if (node.Key < minKey || node.Key > maxKey)
            {
                Console.WriteLine($"False at node {node.Key}");
                return false;
            }

            return IsBst(node.Left, minKey, node.Key.Value - 1) && IsBst(node.Right, node.Key.Value + 1, maxKey);
        }

        public void Insert(int key)
        {
            if (!Key.HasValue)
            {
                Key = key;
                Left = new BstNode();
                Right = new BstNode();
                return;
            }

            if (Key == key)
            {
                return;
            }

            if (Key > key)
            {
                Left.Insert(key);
                return;
            }

            Right.Insert(key);
        }

        public void Delete(int key)
        {
            if (!Left.Key.HasValue && !Right.Key.HasValue)
            {
                Key = null;
                return;
            }

            if (!Left.Key.HasValue || !Right.Key.HasValue)
            {
                
            }
        }

        public bool Lookup(int key)
        {
            return true;
        }
    }
}