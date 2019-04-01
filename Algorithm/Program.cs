using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm
{
    class Program
    {
       
        static void Main(string[] args)
        {
            //Array Sort Test
            #region ArrayTest
            var arrsort = new ArraySort(); 
            var arr = arrsort.BubbleSort(new int[]{2,3,98,10,23,45,4,6 });
            arr = arrsort.QuickSort(arr, arr.GetLowerBound(0), arr.GetUpperBound(0));
            arr = arrsort.SelectSort(arr);
            #endregion

            //Graph Test
            #region Graph Test
            GraphTraversal.Graph graph = new GraphTraversal.Graph();
            graph.DFS();
            graph.BFS();

            graph.FindNextVertex(0, 0, 0, graph.edgeVisited);
            var ret1 = graph.lstResult;
            
            //dijkstra algrithm
            GraphShortPath diPath = new GraphShortPath();
            int[] retArr= diPath.Dijkstra();

            //Floyd algrithm
            GraphShortPath floydPath = new GraphShortPath();
            int[][] retAll = floydPath.Floyd();
            #endregion

            //Tree test
            #region Tree Test  
            Tree t = new Tree();
            t.InsertNode(9);
            t.InsertNode(8);
            t.InsertNode(10);
            t.InsertNode(12);
            t.InsertNode(2);
            t.InsertNode(3);
            t.InsertNode(4);
            t.InsertNode(5);
            t.InsertNode(6);
            t.InsertNode(7);
            t.InsertNode(1);

            t.IsBST(t.Root, int.MinValue,int.MaxValue);

            List<int> lstRet = new List<int>();
         
            var recTraversal = new RecTraversal();
            recTraversal.PreOrderTreeRecursive(t.Root, lstRet);

            lstRet.Clear();
            recTraversal.InOrderTreeRecursive(t.Root, lstRet);

            lstRet.Clear();
            recTraversal.PostOrderTreeRecursive(t.Root, lstRet);

            var stackTraversal = new StackTraversal();
            lstRet = stackTraversal.PreOrderTreeStack(t.Root);

            lstRet = stackTraversal.InOrderTreeStack(t.Root);

            lstRet = stackTraversal.PostOrderTreeStack(t.Root);

            lstRet = new BreadthTraversal().BreadthTreeTraversal(t.Root);

            var treeOper = new TreeOperations();
            treeOper.SumEachPath(t.Root, 0, lstRet);

            int max = treeOper.MaxHeightOfTree(t.Root);

            int totalNodes = treeOper.TotalNodes(t.Root);

            int totalLeaves = treeOper.TotalLeaves(t.Root);


            var projectionTreeView = new ProjectionTree();
            lstRet.Clear();
            lstRet = projectionTreeView.LeftViewNodeTraversal(t.Root, lstRet);

            lstRet.Clear();
            lstRet = projectionTreeView.RightViewNodeTraversal(t.Root, lstRet);

            var lst = projectionTreeView.TopViewNodeTraversal(t.Root);
            foreach(var e in lst)
            {
                //Console.Write(e.Node.Data + " ");
            }
            #endregion

            //Test case:  Tree -> MultipleTree
            #region multiple nodes tree 
            MultipleTree tree = new MultipleTree();
            int data = 10;
            int[] ary = new int[6]{1,10,20,30,50,60};
            tree.InsertNode(data, ary);

            data = 5;
            ary = new int[3] { 7, 8, 9 };
            tree.InsertNode(data, ary);

            data = 55;
            ary = new int[4] { 100, 200, 300,400 };
            tree.InsertNode(data, ary);

            tree.SetRightSiblings(tree.Root);
            tree.PrintNodeSibling(tree.Root);

            Console.Read();
            #endregion

            //Test case: BackTracning ->  Recursion 
            #region Recursive & backtracking
            Backtracking.ListAll(50,30, 0);
            Console.Read();
           
            //Test case:  Practice -> BestPlan 
            Feature[] features = new Feature[11];
            features[0] =new Feature("Email");
            features[1] =new Feature("Sharepoint");
            features[2] =new Feature("OneDrive");
            features[3] =new Feature("Lync");
            features[4] =new Feature("Skype");
            features[5] =new Feature("Word");
            features[6] =new Feature("Excel");
            features[7] =new Feature("Powerpoint");
            features[8] =new Feature("Access");
            features[9] =new Feature("Support");
            features[10] = new Feature("Warranty");
            
            List<Plan> plans = new List<Plan>();
            var tmp = new List<Feature>();
            tmp.Add(features[1]); tmp.Add(features[2]);tmp.Add(features[3]);
            plans.Add(new Plan("Plan0", 400, tmp));

            tmp.Clear(); tmp.Add(features[1]); 
            plans.Add(new Plan("Plan1", 100, tmp));
            
            tmp.Clear(); tmp.Add(features[3]); 
            plans.Add(new Plan("Plan2", 100, tmp));

            tmp.Clear(); tmp.Add(features[3]); tmp.Add(features[9]);
            plans.Add(new Plan("Plan3", 100, tmp));

            tmp.Clear(); tmp.Add(features[2]); tmp.Add(features[8]);
            plans.Add(new Plan("Plan4", 100,tmp));

            tmp.Clear(); tmp.Add(features[2]); tmp.Add(features[3]); tmp.Add(features[7]);
            plans.Add(new Plan("Plan5", 800, tmp));

            tmp.Clear(); tmp.Add(features[1]); tmp.Add(features[3]); tmp.Add(features[7]);
            plans.Add(new Plan("Plan6", 1800, tmp));
       
            List<Feature> selectedFeatures = new List<Feature>();
            selectedFeatures.Add(features[1]);
            selectedFeatures.Add(features[2]);
            selectedFeatures.Add(features[3]);

            var p = new PlanSearch(plans, selectedFeatures);  //plan research
            var ret = p.GetLowCostPlan();

            double cost = 0.0;
            Console.WriteLine();
            foreach (var el in ret)
            {
                cost = cost + el.Cost;
                Console.Write(el.Name + " ");
            }
            Console.Write(" The best plans price: " + cost.ToString());
            Console.WriteLine();
            Console.WriteLine("Done!");
            Console.Read();
            #endregion
        }
    }
}
