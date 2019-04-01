using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm
{
    public class GraphTraversal
    {
        public class Graph
        {
            private int vertexNum;    //Vertex number
            private int[] vertexs;    //Vertex array  if input is int
            private int[][] matrix;   //vertex matrix to mark the edge between vertex: 1 - have; 0 - Not have
            public Boolean[][] edgeVisited;
            private Boolean[] vertexVisited;

            private int targetValue = 9;
            public List<int> lstResult = new List<int>();

            public Graph(int vertexNum =9)
            {
                this.vertexNum = vertexNum;

                matrix = new int[vertexNum][];
                for (int i=0; i < vertexNum; i++)
                     matrix[i] = new int[vertexNum];
                
                edgeVisited = new Boolean[vertexNum][];
                for (int i = 0; i < vertexNum; i++)
                    edgeVisited[i] = new Boolean[vertexNum];

                vertexs = new int[vertexNum];
                for (int i = 0; i < vertexNum; i++)
                {
                    vertexs[i] = i;
                }
                vertexVisited = new Boolean[vertexNum];

                //Default Test data:
                //matrix[0][0] = 0; matrix[0][1] = 1; matrix[0][2] = 1;
                //matrix[1][0] = 0; matrix[1][1] = 1; matrix[1][2] = 9;
                //matrix[2][0] = 0; matrix[2][1] = 1; matrix[2][2] = 1;

                BuildVertexs();
                BuildEdges();
            }

            /// <summary>
            /// assum it can start from the (0,0)  or loop to get the first vertex
            /// </summary>
            public void DFS(int vertexIndex = 0)
            {
                vertexVisited[vertexIndex] = true;
                Console.Write((char)vertexs[vertexIndex] + " ");

                int[] next = getConnectedVertex(vertexIndex, matrix);
                if (next.Length == 0)
                    return;
                else
                {

                    for (int i = 0; i < next.Length; i++)
                    {
                        if (!vertexVisited[next[i]])
                            DFS(next[i]);
                    }
                }
            }

            public void BFS(int vertexIndex =0)
            {
                ClearFlag();
                Console.WriteLine();

                Queue<int> q = new Queue<int>();
                if (vertexs.Length > 0)
                    q.Enqueue(vertexIndex);
               
                while(q.Count > 0)
                {
                    int cur = q.Dequeue();
                    
                    Console.Write((char)vertexs[cur] + " ");
                    vertexVisited[cur] = true;

                    int[] next = getConnectedVertex(cur, matrix);
                    if (next.Length > 0)
                    {
                        for(int i=0; i < next.Length; i++)
                        {
                            if (!vertexVisited[next[i]] && !q.Contains(next[i]))
                               q.Enqueue(next[i]);
                        }
                    }
                }
            }

            private int[] getConnectedVertex(int rowIndex, int[][]arr)
            {
                List<int> lst = new List<int>();
                for (int i = 0; i < arr[rowIndex].Length; i++)
                    if (arr[rowIndex][i] == 1)
                        lst.Add(i);

                return lst.ToArray();
            }

            private void BuildVertexs()
            {
                //Console.WriteLine("Please input all vertexs, comma as separation:");
                //var strInput = Console.ReadLine();
                var strInput = "A,B,C,D,E,F,G,H,I";
                string[] elements = strInput.Split(new char[] { ',' });

                if (elements.Length > vertexNum)
                    throw new Exception("Too many vertexs, input is invalid");

                for (int i=0; i < elements.Length; i++)
                {
                    vertexs[i] = Convert.ToChar(elements[i]);
                }
            }

            private void BuildEdges()
            {
                Console.WriteLine("Input edge of starting vertex and end vertex, comma as separation(99 for end):");
                Console.WriteLine("For example: 1,4");
                Console.WriteLine("2,3");
                Console.WriteLine("1,2");
                Console.WriteLine("99");

                var strInput = Console.ReadLine();

                while (strInput != "99")
                {
                    string[] ele = strInput.Split(new char[] { ',' });
                    if (ele.Length == 2)
                    {
                        int start = getIndex(Convert.ToChar(ele[0]));
                        int end = getIndex(Convert.ToChar(ele[1]));

                        matrix[start][end] = 1;
                        matrix[end][start] = 1;
                    }
                    strInput = Console.ReadLine();
                }
            }

            private int getIndex(char ch)
            {
                int index = -1;
                for (int i = 0; i < vertexs.Length; i++)
                {
                    if (vertexs[i] == ch)
                    {
                        index = i; break;
                    }
                }

                return index;
            }

            private void ClearFlag()
            {
                for (int i = 0; i < edgeVisited.GetUpperBound(0); i++)
                    for (int j = 0; j < edgeVisited[i].Length; j++)
                        edgeVisited[i][j] = false;

                for (int i = 0; i < vertexVisited.Length; i++)
                    vertexVisited[i] = false;
           
            }

            /// <summary>
            /// amazon test quiz: find all path to the point 9,  1 means can go, 0 means no way.
            /// </summary>
            /// <param name="rowIndex">matrix row</param>
            /// <param name="colIndex">matrix col</param>
            /// <param name="value">path node number</param>
            /// <param name="vistitedArr">a flag maxtrix to mark visited edge</param>
            public void FindNextVertex(int rowIndex, int colIndex, int value, Boolean[][] vistitedArr)
            {
                vistitedArr[rowIndex][colIndex] = true;

                if (rowIndex - 1 >= 0 && !vistitedArr[rowIndex - 1][colIndex])
                {
                    if (matrix[rowIndex - 1][colIndex] == 1)
                        FindNextVertex(rowIndex - 1, colIndex, value + 1, vistitedArr);
                    else if (matrix[rowIndex - 1][colIndex] == targetValue)
                    {
                        lstResult.Add(value + 1);
                        vistitedArr[rowIndex][colIndex] = false;
                    }
                }

                if (colIndex + 1 <= matrix[rowIndex].Length - 1 && !vistitedArr[rowIndex][colIndex + 1])
                {
                    if (matrix[rowIndex][colIndex + 1] == 1)
                        FindNextVertex(rowIndex, colIndex + 1, value + 1, vistitedArr);
                    else if (matrix[rowIndex][colIndex + 1] == targetValue)
                    {
                        lstResult.Add(value + 1);
                        vistitedArr[rowIndex][colIndex] = false;
                    }
                }

                if (rowIndex + 1 <= matrix.GetUpperBound(0) && !vistitedArr[rowIndex + 1][colIndex])
                {
                    if (matrix[rowIndex + 1][colIndex] == 1)
                        FindNextVertex(rowIndex + 1, colIndex, value + 1, vistitedArr);
                    else if (matrix[rowIndex + 1][colIndex] == targetValue)
                    {
                        lstResult.Add(value + 1);
                        vistitedArr[rowIndex][colIndex] = false;
                    }
                }
           }

            //clockwise print maxtix
            //public List<int> printMatrix(int[][] matrix)
            public List<int> printMatrixClosewise()
            {
                //Initial a matix for testing, you may rebuild this matrix:
                int[][] matrix = new int[4][];
                matrix[0] = new int[4]; matrix[1] = new int[4]; matrix[2] = new int[4]; matrix[3] = new int[4];

                matrix[0][0] = 1; matrix[0][1] = 2; matrix[0][2] = 3; matrix[0][3] = 4;
                matrix[1][0] = 5; matrix[1][1] = 6; matrix[1][2] = 7; matrix[1][3] = 8;
                matrix[2][0] = 9; matrix[2][1] = 10; matrix[2][2] = 11; matrix[2][3] = 12;
                matrix[3][0] = 13; matrix[3][1] = 14; matrix[3][2] = 15; matrix[3][3] = 16;

                int iRow = matrix.GetUpperBound(0);
                int iCol = matrix[0].Length;

                Boolean[][] visited;    // add a visited array to mark the element if the element visited
                visited = new Boolean[iRow+1][];
                for (int i = 0; i <= iRow; i++)
                    visited[i] = new bool[iCol];

                List<int> lstRet = new List<int>();

                int curRow = 0;
                int curCol = 0;
                LoopMatrix(curRow, curCol, matrix, visited, lstRet); //visit the matrix recursive
                return lstRet;
            }

            private void LoopMatrix(int curRow, int curCol, int[][] matrix, Boolean[][]visited, List<int> lstRet)
            {
                int iRow = matrix.GetUpperBound(0);
                int iCol = matrix[0].Length -1;

                visited[curRow][curCol] = true;
                lstRet.Add(matrix[curRow][curCol]);

                //Left and down direction is available(index is in boundary), choose Left direction
                if ((curRow + 1) <= iRow && (curCol + 1) <= iCol && !visited[curRow][curCol + 1] && !visited[curRow+1][curCol])
                    LoopMatrix(curRow, curCol + 1, matrix, visited, lstRet);

                //Down and right direction is available(index is in boundary), choose down direction
                if (curRow +1 <= iRow && curCol-1 >= 0 && (curRow + 1) <= iRow && !visited[curRow + 1][curCol] && !visited[curRow][curCol-1])
                    LoopMatrix(curRow + 1, curCol, matrix, visited, lstRet);
                
                //Right and Up direction is available (index is in boundary) choose right direction
                if(curRow - 1 >= 0 && curCol -1 >= 0 && curCol-1 >= 0  && !visited[curRow][curCol - 1] && !visited[curRow-1][curCol])
                    LoopMatrix(curRow, curCol - 1, matrix, visited, lstRet);
                
                //up and left direction is available(index is in boundary) choose up direction
                if (curRow -1 >= 0 && curCol + 1 <= iCol && (curRow - 1) >=0 && !visited[curRow-1][curCol] && !visited[curRow][curCol+1])
                    LoopMatrix(curRow-1, curCol, matrix, visited, lstRet);

                // only left direction
                if ((curCol + 1) <= iCol && !visited[curRow][curCol + 1])
                    LoopMatrix(curRow, curCol + 1, matrix, visited, lstRet);
                
                //only down direction
                if ((curRow + 1) <= iRow && !visited[curRow + 1][curCol])
                    LoopMatrix(curRow + 1, curCol, matrix, visited, lstRet);
                
                //only right direction
                if (curCol - 1 >= 0 && !visited[curRow][curCol - 1])
                    LoopMatrix(curRow, curCol - 1, matrix, visited, lstRet);
                
                //only up direction
                if (curRow - 1 >= 0 && !visited[curRow - 1][curCol])
                    LoopMatrix(curRow - 1, curCol, matrix, visited, lstRet);
            }
        }
    }
}
