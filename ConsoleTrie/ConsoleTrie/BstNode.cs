using System;

namespace ConsoleTrie
{
    /// <summary>
    /// A binary search tree node
    /// </summary>
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

        /// <summary>
        /// Traverse the tree in-order, writing its keys to the console.
        /// </summary>
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

        /// <summary>
        /// Verify if the tree is a BST.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="minKey"></param>
        /// <param name="maxKey"></param>
        /// <returns></returns>
        public bool IsBst(BstNode node = null, int minKey = int.MinValue, int maxKey = int.MaxValue)
        {
            node ??= this;
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

        /// <summary>
        /// Insert a key into the tree.
        /// </summary>
        /// <param name="key"></param>
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

        /// <summary>
        /// Delete a key from the tree.
        /// </summary>
        /// <param name="key"></param>
        public void Delete(int key)
        {
            if (Key == key)
            {
                // leaf node, remove node
                if (!Left.Key.HasValue && !Right.Key.HasValue)
                {
                    Key = null;
                    Left = null;
                    Right = null;
                    return;
                }

                // only one child node, replace this node by its child
                if (Left.Key.HasValue && !Right.Key.HasValue) // left child
                {
                    Key = Left.Key;
                    Left = Left.Left;
                    Right = Left.Right;
                }
                else if (!Left.Key.HasValue) // right child
                {
                    Key = Right.Key;
                    Left = Right.Left;
                    Right = Right.Right;
                }

                // two child nodes
                // get in-order predecessor (right subtree's left-most child)
                var pred = Right;
                while (pred.Key.HasValue && pred.Left.Key.HasValue)
                {
                    pred = pred.Left;
                }

                Key = pred.Key;
                if (pred.Right.Key.HasValue) // replace by its child 
                {
                    pred.Key = pred.Right.Key;
                    pred.Left = pred.Right.Left;
                    pred.Right = pred.Right.Right;
                }
                else // remove 
                {
                    pred.Key = null;
                    pred.Left = null;
                    pred.Right = null;
                }
            }
            else
            {
                if (Key > key)
                {
                    Left?.Delete(key);
                }
                else
                {
                    Right?.Delete(key);
                }
            }
        }

        /// <summary>
        /// Lookup a key in the tree.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Lookup(int key)
        {
            if (Key == key)
            {
                return true;
            }

            return (Left?.Lookup(key) ?? false) || (Right?.Lookup(key) ?? false);
        }
    }
}