using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backtracking
{
    class TreeNode
    {
        public int Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public TreeNode Sibling { get; set; }

        public TreeNode(int data)
        {
            this.Data = data;
            this.Left = null;
            this.Right = null;
            this.Sibling = null;
       }
   }

    class Tree
    {
        public TreeNode Root { get; set; }

        public Tree()
        {
        }
        public void FindSiblings(TreeNode node)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(node);
            TreeNode previous = null;
            TreeNode current = null;

            while (q.Count > 0)
            {
                current = q.Dequeue();
                if (current.Left != null)
                {
                    q.Enqueue(current.Left);
                }
                if (current.Right != null)
                {
                    q.Enqueue(current.Right);
                }
                if (previous != null )
                {
                    if (previous.Data < current.Data)
                    {
                        previous.Sibling = current;
                        Console.WriteLine(previous.Data + " : " + previous.Sibling.Data);
                    }                
                 }
                previous = current;
            }
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

    }
}
