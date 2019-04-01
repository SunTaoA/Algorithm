using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm
{
    //test case at:  http://wiki.jikexueyuan.com/project/easy-learn-algorithm/dijkstra.html
    public class GraphShortPath
   {
        private int vertexNum = 6;    // vertex number;
        private int[] vertexs;        //vertex array;
        private int[][] eMatrix;      // edge matrix weight;
        private bool[] visited;       // vertex visited flag;

        public GraphShortPath()
        {
            visited = new bool[vertexNum];
            vertexs = new int[vertexNum];

            for (int i = 0; i < vertexNum; i++)
               vertexs[i] = i;

            eMatrix = new int[vertexNum][];
            for (int i = 0; i < vertexNum; i++)
            {
              eMatrix[i] = new int[vertexNum];
            }

            //initial eMatrix
            for (int i = 0; i <= eMatrix.GetUpperBound(0); i++)
                for (int j = 0; j < eMatrix[i].Length; j++)
                    if (i == j)
                        eMatrix[i][j] = 0;
                    else
                        eMatrix[i][j] = int.MaxValue;

            //construct a test case
            eMatrix[0][1] = 1; eMatrix[0][2] = 12;
            eMatrix[1][2] = 9; eMatrix[1][3] = 3;
            eMatrix[2][4] = 5;
            eMatrix[3][2] = 4; eMatrix[3][4] = 13; eMatrix[3][5] = 15;
            eMatrix[4][5] = 4;
        }

        // Dijsktra algrithm  Dijkstra
        public int[] Dijkstra()
        {
            int[] dis = new int[vertexNum];
            for (int i = 0; i < vertexNum; i++)
                dis[i] = eMatrix[0][i];


            int startRow = 0;
            int startCol = 1;
            visited[0] = true;
            int value = 0;

            int time = 0;
            while (time < vertexNum)
            {
                for (int j = 0; j < vertexNum; j++)
                {
                    if (eMatrix[startRow][startCol] >= eMatrix[startRow][j] && !visited[j] && j != startRow)
                    {
                        startCol = j;
                        value = eMatrix[startRow][j];
                    }
                }


                if (dis[startCol] > dis[startRow] + value)
                    dis[startCol] = dis[startRow] + value;

                visited[startCol] = true;
                startRow = startCol;
                startCol = 0;

                time = time + 1;
            }

            return dis;                                    
        }

        // Folyd algrithm
        public int[][] Floyd()
        {
            for (int k = 0; k <= eMatrix.GetUpperBound(0); k++)
                for (int i = 0; i <= eMatrix.GetUpperBound(0); i++)
                    for (int j = 0; j <= eMatrix.GetUpperBound(0); j++)
                    {
                        if (eMatrix[i][k] == int.MaxValue || eMatrix[k][j] == int.MaxValue) continue;
                        if (eMatrix[i][j] > eMatrix[i][k] + eMatrix[k][j])
                            eMatrix[i][j] = eMatrix[i][k] + eMatrix[k][j];
                    }

            return eMatrix;
        }
   }
}
