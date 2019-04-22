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
            
            // List test
            #region List Test Cases
            ListNode pHead1 = new ListNode(1);
            pHead1.next = new ListNode(3);
            pHead1.next.next = new ListNode(5);

            var kNode = new ListOperation().FindKthToTail(pHead1, 1);
            var rev = new ListOperation().ReverseList(null);

            ListNode pHead2 = new ListNode(2);
            pHead2.next = new ListNode(4);
            pHead2.next.next = new ListNode(6);

             var lstTmp = new ListOperation().Merge(pHead1, pHead2);
            #endregion

            //Array Sort Test
            #region ArrayTest
            var arrsort = new ArraySort(); 
            var arr = arrsort.BubbleSort(new int[]{2,3,98,10,23,45,4,6 });
            arr = arrsort.QuickSort(arr, arr.GetLowerBound(0), arr.GetUpperBound(0));
            arr = arrsort.SelectSort(arr);
            arr = arrsort.MergeSort(new int[] { 2, 3, 18, 10, 20, 15, 4, 6 });

            ArrayOper.IsPopOrder(new int[] { 1, 2, 3, 4, 5 }, new int[] { 4, 5, 3, 2, 1 });

            var retNum = ArrayOper.MoreThanHalfNum(new int[] { 1, 2, 3, 2, 4, 2, 5, 2, 3 });

            ArrayOper.PrintMinNumber(new int[] { 2, 3, 4, 5, 1 });

            var urglyNum = ArrayOper.GetUglyNumber(10);
            var firstChar = ArrayOper.FirstNotRepeatingChar("google");
            var reverseNum = ArrayOper.InversePairs(new int[] { 1, 2, 3, 4, 5, 6, 7, 0 });

            int[] num1 = new int[1];
            int[] num2 = new int[1];
            ArrayOper.FindTwoNumbersAppearOnce(new int[] { 1, 1, 2, 2, 3, 4, 5, 5, 4, 3, 6, 7 }, num1, num2);
            
            #endregion
            //String practice
             
            
            //Graph Test
            #region Graph Test
            GraphTraversal.Graph graph = new GraphTraversal.Graph();
            var retList = graph.printMatrixClosewise();

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
          
            //t.ConvertToSortedList(t.Root);
            
            //var x = t.head.Data;

            //another invalid test cases
            Tree bst = new Tree();
            bst.Root = new TreeNode(10);
            bst.Root.Left = new TreeNode(5);
            bst.Root.Right = new TreeNode(12);
            bst.Root.Left.Left = new TreeNode(6);
            bst.Root.Left.Right = new TreeNode(7);

            bool isBST = bst.IsBST(bst.Root, int.MinValue, int.MaxValue);
            var secTreeOperBst = new TreeOperations().IsBST(bst.Root);

            int[] testData = new int[]{ 10, 6, 11, 12, 7 };
            //int[] testData = new int[] { 10, 12, 14,17,18 };
            var bRet = t.IsArrValidPreOrderBST(testData);

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

            var totalRet = treeOper.FindPath(bst, 22);

            int max = treeOper.MaxHeightOfTree(t.Root);

            int totalNodes = treeOper.TotalNodes(t.Root);

            int totalLeaves = treeOper.TotalLeaves(t.Root);

            Tree B = new Tree();
            B.InsertNode(1);
            B.InsertNode(2);
            B.InsertNode(3);
            B.InsertNode(4);
            B.InsertNode(5);
            B.InsertNode(6);
            B.InsertNode(7);

            var bIncluded = treeOper.IsATreeIncludeBTree(t.Root, B.Root);

            var bTreeOperBst = treeOper.IsBST(B.Root);
            treeOper.AllDepth(B.Root, 0);
            var lstOperRet = treeOper.lstDepth;
            var isbalanceBST = treeOper.IsBalancedBST(B.Root);

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
