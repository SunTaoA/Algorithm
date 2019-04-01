using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm
{
    class TreeOperations
    {
        //Calcalate the most depth in a tree
        public int MaxHeightOfTree(TreeNode node)
        {
            if (node == null)
                return 0;
            else if (node.Left == null && node.Right == null)
                return 1;
            else
                return 1 + Math.Max(MaxHeightOfTree(node.Left), MaxHeightOfTree(node.Right));
        }

        //calcalte total nodes
        public int TotalNodes(TreeNode node)
        {
            if (node == null)
                return 0;
            else if (node.Left == null && node.Right == null)
                return 0;
            else
                return (1 + TotalNodes(node.Left) + TotalNodes(node.Right));
        }

        //calculate total leaves
        public int TotalLeaves(TreeNode node)
        {
            if (node == null)
                return 0;
            else if (node.Left == null && node.Right == null)
                return 1;
            else
                return (TotalLeaves(node.Left) + TotalLeaves(node.Right));
        }

        //calculate each path from root to leaf sum
        public List<int> SumEachPath(TreeNode node, int sum, List<int> lst)
        {

            if (node != null)
                sum = sum + node.Data;

            if (node.Left == null && node.Right == null)
            {
                lst.Add(sum);
                return lst;
            }

            if (node.Left != null)
                SumEachPath(node.Left, sum, lst);

            if (node.Right != null)
                SumEachPath(node.Right, sum, lst);

            return lst;
        }
    }
}
