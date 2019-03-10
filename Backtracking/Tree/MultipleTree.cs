using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm
{
       public class Node
       {
          public int Data { get; set; }
          public Node[] Children { get; set; }
          public Node Right { get; set; }   // for right sibling, not right node.
       
          public Node(int data)
          {
            this.Data = data;
            this.Children = null;
            this.Right = null;
          }
      }

       public class MultipleTree
       {
           public Node Root { get; set; }
           
           public MultipleTree()
           {

           }
           
           //Set node's right value 
           public void SetRightSiblings(Node node)
           {
               Queue<Node> q = new Queue<Node>();
               q.Enqueue(node);
              
               Node previous = null;
               Node current = null;

               while (q.Count > 0)
               {
                   current = q.Dequeue();

                   if (current.Children != null)
                   {
                       for (int i = 0; i < current.Children.Length; i++)
                       {
                           q.Enqueue(current.Children[i]);
                       }
                   }

                   if (previous != null && previous.Data < current.Data)
                   {
                       previous.Right = current;
                       //Console.WriteLine(previous.Data + " : " + previous.Right.Data);
                   }
                   previous = current;
               }
           }

           //Queue traversal
           public void PrintNodeSibling(Node node)
           {
               Queue<Node> q = new Queue<Node>();
               q.Enqueue(node);

               Node current = null;

               while (q.Count > 0)
               {
                   current = q.Dequeue();

                   if (current.Children != null)
                   {
                       for (int i = 0; i < current.Children.Length; i++)
                       {
                           q.Enqueue(current.Children[i]);
                       }
                   }

                   if (current != null && current.Right != null)
                      Console.WriteLine(current.Data + " : " + current.Right.Data);
                   else
                      Console.WriteLine(current.Data + " : Null");
               }

           }

           // recursively tree traversal 
           public void PrintNodeSibling(Node node, bool recursive)
           { 
              if(node != null)
              {
                  if (node.Right != null)
                    Console.WriteLine(node.Data + ":" + node.Right.Data);
                  else
                      Console.WriteLine(node.Data + ": null");

                  if(node.Children != null)
                  {
                      for (int i = 0; i < node.Children.Length; i++)
                          PrintNodeSibling(node.Children[i]);
                  }
             }
          }
           
           /// <summary>
           /// used to contruct a multiple tree
           /// </summary>
           /// <param name="data"></param>
           /// <param name="children"></param>
           public void InsertNode(int data, int[] children)  
           {
               Node node = CreateNode(data, children);
               
               if (Root == null)
               {
                  Root = node;
               }
               else
               {
                   Node current = Root;
                   while (current.Children != null)
                   {
                           Node[] aryNodes = current.Children;

                           for (int i = 0; i < aryNodes.Length - 1; i++)
                           {
                               if (data <= aryNodes[0].Data)
                               {
                                 current = aryNodes[0];
                                 break;
                               }
                               if (data >= aryNodes[aryNodes.Length-1].Data)
                               {
                                  current = aryNodes[aryNodes.Length-1];
                                   break;
                               }
                               if (aryNodes[i].Data <= data && data < aryNodes[i + 1].Data)
                               {
                                   current = aryNodes[i];
                                   break;
                               }
                           }
                   }
                   current.Children = new Node[1];
                   current.Children[0] = node;
               }
           }

           private Node CreateNode(int data, int[] children)
           {
               Node node = new Node(data);
               Array.Sort(children);
               
               if (children != null && children.Length > 0)
               {
                   node.Children = new Node[children.Length];
                   for (int i = 0; i < children.Length; i++)
                   {
                       node.Children[i] = new Node(children[i]);
                   }
               }
               return node;
           }
      }  
}

         
