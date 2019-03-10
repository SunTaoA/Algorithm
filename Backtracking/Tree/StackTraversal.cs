using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm
{
    class StackTraversal
    {
        // pre-order with stack
        public List<int> PreOrderTreeStack(TreeNode node)
        {
            List<int> lst = new List<int>();

            if (node == null) return lst;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(node);

            while (stack.Count > 0)
            {
                TreeNode tmpNode = stack.Pop();
                lst.Add(tmpNode.Data);

                if (tmpNode.Right != null)
                    stack.Push(tmpNode.Right);
                if (tmpNode.Left != null)
                    stack.Push(tmpNode.Left);

            }

            return lst;
        }

        // In-order with stack
        public List<int> InOrderTreeStack(TreeNode node)
        {
            List<int> lst = new List<int>();

            if (node == null) return lst;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode curr = node;


            while (curr != null || stack.Count > 0)
            {
                while (curr != null)
                {
                    stack.Push(curr);
                    curr = curr.Left;

                }

                var tmpNode = stack.Pop();
                lst.Add(tmpNode.Data);

                if (tmpNode.Right != null)
                    curr = tmpNode.Right;
            }

            return lst;
        }

        //Post-order with stack
        public List<int> PostOrderTreeStack(TreeNode node)
        {

            List<int> lst = new List<int>();

            if (node == null) return lst;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(node);

            while (stack.Count > 0)
            {
                TreeNode tmpNode = stack.Pop();
                lst.Add(tmpNode.Data);

                if (tmpNode.Left != null)
                    stack.Push(tmpNode.Left);

                if (tmpNode.Right != null)
                    stack.Push(tmpNode.Right);

            }

            lst.Reverse();
            return lst;
        }

    }
}
