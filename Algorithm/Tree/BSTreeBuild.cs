using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm
{
   public class TreeNode
    {
        public int Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }


        public TreeNode(int data)
        {
            this.Data = data;
            this.Left = null;
            this.Right = null;
        }
    }

   public class Tree
    {
        public TreeNode Root { get; set; }

        public Tree()
        {
        }

        public void InsertNode(int data)
        {
            if (Root == null)
            {
                Root = new TreeNode(data);
            }
            else
            {
                TreeNode current = Root;
                while (current != null)
                {
                    if (data <= current.Data)
                    {
                        // InsertNode left
                        if (current.Left == null)
                        {
                            current.Left = new TreeNode(data);
                            return;
                        }
                        else
                        {
                            current = current.Left;
                        }
                    }
                    else
                    {
                        // InsertNode right
                        if (current.Right == null)
                        {
                            current.Right = new TreeNode(data);
                            return;
                        }
                        else
                        {
                            current = current.Right;
                        }
                    }
                }
            }
        }

        // Returns true if the given tree is a BST and its  
        //values are >= min and <= max. 
        public bool IsBST(TreeNode node, int min, int max)
        {
            /* an empty tree is BST */
            if (node == null)
            {
                return true;
            }

            /* false if this node violates the min/max constraints */
            if (node.Data < min || node.Data > max)
            {
                return false;
            }

            /* otherwise check the subtrees recursively  
            tightening the min/max constraints */
            // Allow only distinct values  
            return (IsBST(node.Left, min, node.Data - 1) && IsBST(node.Right, node.Data + 1, max));
        }

        // can array represent pre-order BST
        public bool IsArrValidBST(int[] pre, int n)
        {

            Stack<int> stack = new Stack<int>();

            int root = int.MinValue;

            // Traverse given array 
            for (int i = 0; i < n; i++)
            {
                if (pre[i] < root)
                {
                    return false;
                }

                while (stack.Count > 0 && stack.Peek() < pre[i])
                {
                    root = stack.Pop();
                }

                stack.Push(pre[i]);
            }

            return true;
        }

    }



}
