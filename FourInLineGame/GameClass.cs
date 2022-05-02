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
                checkForSpaceInColoum();
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

        private bool checkForSpaceInColoum()
        {
            return true;
        }

        private bool checkForWinningMove()
        {
            return true;
        }

        
        // The last space in the colloum is the target.
        // We fill the colloums from the bottom up. 
        public string MakeMove()
        {
            string toReturn = "";
            int increment = 0;
            for (int r = 0; r < Board.rows; r++)
            {
                for (int c = 0; c < Board.cols; c++)
                {
                    increment++;
                    if (board.Board2D[r, c] == temp_btNumber.ToString())
                    {
                        for (int i = (Board.rows - 1); i >= 0; i--)
                        {
                            if (!(board.Board2D[i, c] == "X") || !(board.Board2D[i, c] == "X "))
                            {
                                toReturn = board.Board2D[i, c];

                                if (increment <= 9)
                                {
                                    board.Board2D[i, c] = "X";
                                }
                                else
                                {
                                    board.Board2D[i, c] = "X ";
                                }
                                break;
                            }
                            else
                            {
                                toReturn = board.Board2D[i-1, c];

                                if (increment <= 9)
                                {
                                    board.Board2D[i-1, c] = "X";
                                }
                                else
                                {
                                    board.Board2D[i-1, c] = "X ";
                                }
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
