using System;
using System.Collections.Generic;
using System.IO;

namespace QueensAttack
{
    class Program
    {





        // Complete the queensAttack function below.
        // n: number of rows and columns
        // - n: an integer, the number of rows and columns in the board 
        // k: an integer, the number of obstacles on the board 
        // r_q: integer, the row number of the queen's position 
        // c_q: integer, the column number of the queen's position 
        // obstacles: a two dimensional array of integers where each element is an array of integers, the row and column of an obstacle
        static int queensAttack(int n, int k, int r_q, int c_q, Dictionary<string, bool> obstacleDict)
        {


            // Do UP
            int totalSquaresCanBeAttacked = CountSquaresThatCanBeAttacked(c_q, r_q+1, 0, 1, n, n, obstacleDict);

            // UP-RIGHT
            totalSquaresCanBeAttacked += CountSquaresThatCanBeAttacked(c_q+1, r_q+1, 1, 1, n, n, obstacleDict);

            // RIGHT
            totalSquaresCanBeAttacked += CountSquaresThatCanBeAttacked(c_q+1, r_q, 1, 0, n, n, obstacleDict);

            // DOWN-RIGHT
            totalSquaresCanBeAttacked += CountSquaresThatCanBeAttacked(c_q+1, r_q-1, 1, -1, n, n, obstacleDict);

            // DOWN
            totalSquaresCanBeAttacked += CountSquaresThatCanBeAttacked(c_q, r_q-1, 0, -1, n, n, obstacleDict);

            // DOWN-LEFT
            totalSquaresCanBeAttacked += CountSquaresThatCanBeAttacked(c_q-1, r_q-1, -1, -1, n, n, obstacleDict);

            // LEFT
            totalSquaresCanBeAttacked += CountSquaresThatCanBeAttacked(c_q-1, r_q, -1, 0, n, n, obstacleDict);

            // UP-LEFT
            totalSquaresCanBeAttacked += CountSquaresThatCanBeAttacked(c_q-1, r_q+1, -1, 1, n, n, obstacleDict);

            return totalSquaresCanBeAttacked;
        }


        private static int CountSquaresThatCanBeAttacked(int startX, int startY, int deltaX, int deltaY, int maxColumns, int maxRows, Dictionary<string, bool> obstacleDict)
        {
            var x = startX;
            var y = startY;
            int squaresThatCanBeAttacked = 0;

            while (
                (x>0 && x <= maxColumns) && 
                (y>0 && y <= maxRows)
                )
            {
                string key = y + " " + x;
                if (!obstacleDict.TryGetValue(key, out bool _))
                {
                    squaresThatCanBeAttacked++;
                    x+=deltaX;
                    y+=deltaY;
                }
                else
                    break;
            }

            return squaresThatCanBeAttacked;
        }



        //private static bool HaveObstacle(int row, int column, int[][] obstacles)
        //{
        //    for (int i=0; i<obstacles.Length;i++)
        //    {
        //        if (obstacles[i][0] == row && obstacles[i][1] == column)
        //            return true;
        //    }

        //    return false;
        //}


        //static void Main(string[] args)
        //{


        //    int result = queensAttack(n, k, r_q, c_q, obstacles);
        //}


        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] nk = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nk[0]);

            int k = Convert.ToInt32(nk[1]);

            string[] r_qC_q = Console.ReadLine().Split(' ');

            int r_q = Convert.ToInt32(r_qC_q[0]);

            int c_q = Convert.ToInt32(r_qC_q[1]);

            int[][] obstacles = new int[k][];

            for (int i = 0; i < k; i++)
            {
                obstacles[i] = Array.ConvertAll(Console.ReadLine().Split(' '), obstaclesTemp => Convert.ToInt32(obstaclesTemp));
            }

            var obstacleDict = new Dictionary<string, bool>();
            
            // Create Dictionary out of obstacles
            for (int i=0; i<obstacles.Length; i++)
            {
                string key = obstacles[i][0] + " " + obstacles[i][1];
                obstacleDict[key] = true;
            }


            int result = queensAttack(n, k, r_q, c_q, obstacleDict);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
