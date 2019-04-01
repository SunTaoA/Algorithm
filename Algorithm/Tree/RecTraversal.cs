using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm
{
    class RecTraversal
    {
        // pre-order travesal
        public List<int> PreOrderTreeRecursive(TreeNode node, List<int> lst)
        {
            if (node == null)
                return lst;

            lst.Add(node.Data);
            PreOrderTreeRecursive(node.Left, lst);
            PreOrderTreeRecursive(node.Right, lst);

            return lst;
        }

        // in-order traversal
        public List<int> InOrderTreeRecursive(TreeNode node, List<int> lst)
        {
            if (node == null)
                return lst;


            InOrderTreeRecursive(node.Left, lst);
            lst.Add(node.Data);
            InOrderTreeRecursive(node.Right, lst);

            return lst;
        }

        //post-order traversal
        public List<int> PostOrderTreeRecursive(TreeNode node, List<int> lst)
        {
            if (node == null)
                return lst;

            PostOrderTreeRecursive(node.Left, lst);
            PostOrderTreeRecursive(node.Right, lst);
            lst.Add(node.Data);

            return lst;
        }

    }
}
