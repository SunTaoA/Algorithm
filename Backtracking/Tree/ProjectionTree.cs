using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm
{
    class ProjectionTree
    {

        // all most left view nodes
        int MaxLevel = -1;
        public List<int> LeftViewNodeTraversal(TreeNode node, List<int> lst, int level = 0)
        {

            if (node != null && level > MaxLevel)
            {
                lst.Add(node.Data);
                MaxLevel = level;
            }

            if (node.Left != null)
                LeftViewNodeTraversal(node.Left, lst, level + 1);
            if (node.Right != null)
                LeftViewNodeTraversal(node.Right, lst, level + 1);

            return lst;
        }

        //all most right view nodes
        int rightMaxLevel = -1;
        public List<int> RightViewNodeTraversal(TreeNode node, List<int> lst, int level = 0)
        {
            if (node != null && level > rightMaxLevel)
            {
                lst.Add(node.Data);
                rightMaxLevel = level;
            }

            if (node.Right != null)
                RightViewNodeTraversal(node.Right, lst, level + 1);
            if (node.Left != null)
                RightViewNodeTraversal(node.Left, lst, level + 1);

            return lst;
        }

        //top view nodes
        public class NodeLoc
        {
            public TreeNode Node;
            public int Location;
            public NodeLoc(TreeNode node, int loc)
            {
                Node = node;
                Location = loc;
            }
        }

        public List<NodeLoc> TopViewNodeTraversal(TreeNode node)
        {
            List<NodeLoc> lst = new List<NodeLoc>();
            TreeNode cur = node;

            Queue<NodeLoc> q = new Queue<NodeLoc>();
            if (node != null) q.Enqueue(new NodeLoc(node, 0));

            while (q.Count > 0)
            {
                NodeLoc n = q.Dequeue();
                if (!lst.Any(x => x.Location == n.Location))   //already existing;
                    lst.Add(n);

                if (n.Node.Left != null)
                    q.Enqueue(new NodeLoc(n.Node.Left, n.Location - 1));

                if (n.Node.Right != null)
                    q.Enqueue(new NodeLoc(n.Node.Right, n.Location + 1));
            }

            lst.Sort((x, y) => { return x.Location.CompareTo(y.Location); });
            return lst;
        }

    }
}
