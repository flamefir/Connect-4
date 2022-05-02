using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;

namespace FourInLineGame
{
    public class Board
    {

        public const int rows = 6;
        public const int cols = 7;
        public string[,] Board2D = new string[rows, cols];
        public int[] ColloumOne = new int[]   { 0, 7,  14, 21, 28, 35};
        public int[] ColloumTwo = new int[]   { 1, 8,  15, 22, 29, 36};
        public int[] ColloumThree = new int[] { 2, 9,  16, 23, 30, 37};
        public int[] ColloumFour = new int[]  { 3, 10, 17, 24, 31, 38};
        public int[] ColloumFive = new int[]  { 4, 11, 18, 25, 32, 39};
        public int[] ColloumSix = new int[]   { 5, 12, 19, 26, 33, 40};
        public int[] ColloumSeven = new int[] { 6, 13, 20, 27, 34, 41};
       
        public void initializeBoard()
        {
            int increment = 0;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    increment += 1;
                    Board2D[r, c] = increment.ToString();
                }
            }
        }

        public void printBoard()
        {
            int increment = 0;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    increment++;
                    if (increment <= 9)
                    {
                        Console.Write($"{Board2D[r, c]}  ");
                    }
                    else
                    {
                        Console.Write($"{Board2D[r, c]} ");
                    }
                }
                Console.Write("\n");
            }
        }
    }
}
