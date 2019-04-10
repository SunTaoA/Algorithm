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
        //pre-order: root node is at the beginning of array, the first node greater than root is the right tree start
        //all elments behind first node should be greater than the root node (recursive this step)
        public bool IsArrValidPreOrderBST(int[] pre)
        {
            if (pre.Length == 0) return false;
            if (pre.Length == 1) return true;

            int root = pre[0];
            int rightIndex = 0;
            for(int i=0; i <= pre.Length-1; i++)
            {
                if (pre[i] > root)
                {
                    rightIndex = i;
                    break;
                }
            }
           
            for(int i = rightIndex; i <= pre.Length -1; i++)
            {
                if (pre[i] < root)
                    return false;
            }

            bool bLeft = true;
            if (rightIndex -1 > 0)
            { 
              int[] leftArr = new int[rightIndex-1];
              Array.Copy(pre, 1, leftArr, 0, rightIndex-1);
              bLeft = IsArrValidPreOrderBST(leftArr); 
            }

            bool bRight = true;
            if (pre.Length - rightIndex > 0)
            { 
                int[] rightArr = new int[pre.Length - rightIndex];
                Array.Copy(pre, rightIndex, rightArr, 0, pre.Length - rightIndex);
                bRight = IsArrValidPreOrderBST(rightArr);
            }
            return bLeft && bRight;
        }

        //can array represent post-order BST
        // post-order: the root number is at end of array.  search the array the last number less than the root number
        // is the start of left tree. all left tree nodes number less than root.
        // recursive the steps
        public bool IsArrValidPostOrderBST(int[] pre)
        {
            if (pre.Length == 0) return false;
            if (pre.Length == 1) return true;

            int end = pre[pre.Length - 1];
            int left = 0;
            for(int i= pre.Length -1; i>=0; i--)
            {
                if (pre[i] < end)
                {
                    left = i;
                    break;
                }
            }

            for(int i=0; i < left; i++)
            {
                if (pre[i] >= end)
                    return false;
            }

            int[] leftArr = new int[left + 1];
            Array.Copy(pre, leftArr, left + 1);

            bool bRight = true;
            int[] rightArr = new int[pre.Length - left - 1];
            if ((pre.Length - left - 1) > 0)
            { 
                Array.Copy(pre, left + 1, rightArr, 0, pre.Length - left - 1);
                bRight = IsArrValidPostOrderBST(rightArr);
            }

            return IsArrValidPostOrderBST(leftArr) && bRight;
        }

        // Convert BST tree as sorted bi-linked list
        public TreeNode head;
        public TreeNode pre;
        public bool bCreated = false;
        public TreeNode ConvertToSortedList(TreeNode pRootOfTree)
        {
            if (pRootOfTree.Left != null)
                ConvertToSortedList(pRootOfTree.Left);

            if (!bCreated)
            {
                pre = pRootOfTree;
                head = pre;
                pre.Left = null;
                bCreated = true;
            }
            else
            {
                pre.Right = pRootOfTree;
                pRootOfTree.Left = pre;

                pre = pRootOfTree;
            }

            if (pRootOfTree.Right != null)
                ConvertToSortedList(pRootOfTree.Right);

            return head;
        }
    }

}
