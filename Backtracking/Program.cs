using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backtracking
{
    class Program
    {
        /// <summary>
        /// A simple example backtracking algorithem
        /// Give you the nubmer from 1,2,3... to 30.  
        /// List all the combination the nubmer sum equals to 50
        /// For example:  30, 20
        ///               30, 19,1
        ///               ...
        ///               
        /// </summary>
        
        static void Main(string[] args)
        {
            //Recursive function test:
            var x = new RecurFun();
            Console.WriteLine(x.Fact(5));
            Console.Read();
           
            // ary search
            int[] arry = new int[] { 1, 2, 5, 3, 10, 8, 7, 5, 12 };
            int target = 10;
            FindCombination(arry, target, 0, 0);
            Console.Read();
            return;
            
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
            return;
            
            for (int i = 0; i < 100; i++)
                selected[i] = false;

            //ListAll(50,30, 0);
            //Console.WriteLine("TotalNumber:" + totalNum);
            //Console.Read();
            //return;

            //Construct test case:
            Feature [] features = new Feature[11];
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

            Tree binaryTree = new Tree();
            binaryTree.InsertNode(8);
            binaryTree.InsertNode(4);
            binaryTree.InsertNode(2);
            binaryTree.InsertNode(6);
            binaryTree.InsertNode(1);
            binaryTree.InsertNode(3);
            binaryTree.InsertNode(5);
            binaryTree.InsertNode(7);
            binaryTree.InsertNode(12);
            binaryTree.InsertNode(10);
            binaryTree.InsertNode(14);
            binaryTree.InsertNode(9);
            binaryTree.InsertNode(11);
            binaryTree.InsertNode(13);
            binaryTree.InsertNode(15);

            //Console.WriteLine("\n Find All Siblings... ");
            //binaryTree.FindSiblings(binaryTree.Root);
        }

        static bool[] selected = new bool[100];  //hard code arry to track the number selected for sum, set to true if selected, other false.
        static int totalNum = 0;
        // find sum(sequence number) equals to a target number
        static string ListAll(int endNum, int targetSum, int curSum)
        {

            for (int i = endNum; i >= 1; i--)
            {
                totalNum = totalNum + 1;
                selected[i] = true;
                int sum = curSum + i;

                if (sum < targetSum)
                {
                    ListAll(i - 1, targetSum, sum);
                    selected[i] = false;
                }
                else if (sum == targetSum)
                {
                    for (int j = 30; j >=1; j--)
                    {
                        if (selected[j] == true)
                            Console.Write(j + " ");
                    }
                    selected[i] = false;
                    //Console.Read();
                    Console.WriteLine();
                }
                else if (sum > targetSum)
                {
                    selected[i] = false;
                    //break;
                }
            }
            
            return "Done";
        }

        /// <summary>
        /// find sum(n elements in the ary) equals to a target number 
        /// BackTracking
        /// </summary>
        /// <param name="ary">array input</param>
        /// <param name="target">target sum int</param>
        /// <param name="start">from which index to add</param>
        /// <param name="sum">current sum</param>
        /// Test code:
        /// int[] arry = new int[] { 1, 2, 5, 3, 10, 8, 7, 5, 12 };
        /// int target = 10;
        /// FindCombination(arry, target, 0, 0);
        /// Console.Read();
        /// return;
        /// Expected results: 1,2,7
        ///                   2,5,3
        ///                   2,3,5
        static List<int> lstTrack = new List<int>();
        static void FindCombination(int[] ary, int target, int start, int sum)
        {
            for (int i = start; i < ary.Length; i++)
            {
                if (lstTrack.Count > 3) break;
               
                lstTrack.Add(i);
                if ((sum + ary[i]) == target)
                {
                   if (lstTrack.Count == 3)
                    {
                        foreach (int temp in lstTrack)
                        {
                            Console.Write(ary[temp] + " ");
                        }
                        Console.WriteLine();
                    }
                    lstTrack.Remove(i);
                }
                else
                {
                    FindCombination(ary, target, i+1, sum + ary[i]);
                    lstTrack.Remove(i);
                }
            }
        }
    }
}
