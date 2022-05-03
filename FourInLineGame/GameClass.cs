using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FourInLineGame
{
    public class GameClass
    {
        private Board board = new();
        private int temp_btNumber;
        public bool validMove = false;
        public bool RedPlayersTurn = true;
        //                                               N          NE         E        SE
        private int[,] directionSteps = new int[,] { { 0, -1 }, { 1, -1 }, { 1, 0 }, { 1, 1 } };


        public GameClass()
        {
            board.initializeBoard();
            board.printBoard();    
        }

        public void getButtonValue(int btNumber)
        {
            temp_btNumber = btNumber;
        }

        /*
         This function will check is a move is valid
         1. Checks like, is there space in the coloum?
         2. Checks like, do we have a winner move?
         */
        public bool checkMoveValid()
        {
            try
            {
                checkForWinningMove();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "This is not a legal move, try again");
                return false;
            }
        }

        public void changePlayerTurn()
        {
            RedPlayersTurn = RedPlayersTurn == true ? false : true;
        }

        private bool checkForWinningMove()
        {
            //// outer loop loops over those direction-steps N, NE, E, SE:
            foreach (var direction in directionSteps)
            {

            }
            return true;
        }

        
        // The last space in the colloum is the target.
        // We fill the colloums from the bottom up. 
        public string MakeMove()
        {
            string toReturn = "";
            for (int r = 0; r < Board.rows; r++)
            {
                for (int c = 0; c < Board.cols; c++)
                {
                    
                    if (board.Board2D[r, c] == temp_btNumber.ToString())
                    {
                        for (int i = 5; i >= 0; i--)
                        {
                            if (board.Board2D[i, c] != "X " && toReturn == "")
                            {
                                toReturn = board.Board2D[i, c];
                                board.Board2D[i, c] = "X ";
                                return toReturn;
                            }
                        }
                    }
                }
            }
            board.printBoard();
            return toReturn;
        }
    }
}
