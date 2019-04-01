using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm
{
    class BreadthTraversal
    {
        //Breadth  traversal
        public List<int> BreadthTreeTraversal(TreeNode node)
        {
            List<int> lst = new List<int>();
            Queue<TreeNode> queue = new Queue<TreeNode>();

            if (node == null) return lst;

            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                TreeNode tmpNode = queue.Dequeue();
                lst.Add(tmpNode.Data);

                if (tmpNode.Left != null) queue.Enqueue(tmpNode.Left);
                if (tmpNode.Right != null) queue.Enqueue(tmpNode.Right);
            }

            return lst;
        }


    }
}
