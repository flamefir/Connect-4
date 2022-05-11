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

        public void reset2DBoard()
        {
            initializeBoard();
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
