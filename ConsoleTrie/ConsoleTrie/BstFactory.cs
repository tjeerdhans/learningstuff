using System;

namespace ConsoleTrie
{
    internal static class BstFactory
    {
        /// <summary>
        /// The example tree at https://en.wikipedia.org/wiki/Binary_search_tree#/media/File:Binary_search_tree.svg
        /// </summary>
        /// <returns></returns>
        public static BstNode MakeWikipediaBst()
        {
            var bst = new BstNode(8);
            bst.Insert(3);
            bst.Insert(10);
            bst.Insert(1);
            bst.Insert(6);
            bst.Insert(14);
            bst.Insert(4);
            bst.Insert(7);
            bst.Insert(13);
            return bst;
        }

        /// <summary>
        /// Construct a tree of max 100 nodes randomly taken from 1-1000
        /// </summary>
        /// <returns></returns>
        private static BstNode MakeRandomBst()
        {
            var bst = new BstNode();
            var rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                var nextKey = rnd.Next(1, 1001);
                bst.Insert(nextKey);
            }

            return bst;
        }
    }
}