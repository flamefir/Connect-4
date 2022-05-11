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
        public Board board = new();
        private int temp_btNumber;
        public bool validMove = false;
        public bool RedPlayersTurn = true;

        private const string RedPlayer = "R ";
        private const string YellowPlayer = "Y ";
        public string winningPlayer = "";

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
         This function will return true if a winner is found.
         */
        public bool checkMoveValid()
        {
            return checkForWinningMove();
        }

        public void changePlayerTurn()
        {
            RedPlayersTurn = RedPlayersTurn == true ? false : true;
        }

        private bool checkForWinningMove()
        {
            try
            {
                if (helperCheckHorizontal() == "Red wins" || helperCheckVertical() == "Red wins" || helperCheckUpRightDiagonal() == "Red wins" || helperCheckUpLeftDiagonal() == "Red wins")
                    {
                    winningPlayer = "Red player";
                    return true;
                }
                else if (helperCheckHorizontal() == "Yellow wins" || helperCheckVertical() == "Yellow wins"|| helperCheckUpRightDiagonal() == "Yellow wins" || helperCheckUpLeftDiagonal() == "Yellow wins")
                {
                    winningPlayer = "Yellow player";
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        private string helperCheckHorizontal()
        {
            for (int c = 0; c < 7; c++)
            {
                int RedWinnerCount = 1;
                int YellowWinnerCount = 1;
                for (int r = 0; r < 5; r++)
                {
                    if ((board.Board2D[r, c] == RedPlayer) && (board.Board2D[r + 1, c] == RedPlayer))
                    {
                        RedWinnerCount++;
                        if (RedWinnerCount >= 4)
                        {
                            return "Red wins";
                        }
                    }
                    else if ((board.Board2D[r, c] == YellowPlayer) && (board.Board2D[r + 1, c] == YellowPlayer))
                    {
                        YellowWinnerCount++;
                        if (YellowWinnerCount >= 4)
                        {
                            return "Yellow wins";
                        }
                    }
                    else
                    {
                        RedWinnerCount = 1;
                        YellowWinnerCount = 1;
                    }
                }
            }
            return "no winner";
        }

        private string helperCheckVertical()
        { 
            for (int r = 0; r < 6; r++)
            {
                int RedWinnerCount = 1;
                int YellowWinnerCount = 1;
                for (int c = 0; c < 6; c++)
                {
                    if ((board.Board2D[r, c] == RedPlayer) && (board.Board2D[r, c + 1] == RedPlayer))
                    {
                        RedWinnerCount++;
                        if (RedWinnerCount >= 4)
                        {
                            return "Red wins";
                        }
                    }
                    else if ((board.Board2D[r, c] == YellowPlayer) && (board.Board2D[r, c + 1] == YellowPlayer))
                    {
                        YellowWinnerCount++;
                        if (YellowWinnerCount >= 4)
                        {
                            return "Yellow wins";
                        }
                    }
                    else
                    {
                        RedWinnerCount = 1;
                        YellowWinnerCount = 1;
                    }
                }
            }
            return "no winner";
        }
        
        private string helperCheckUpRightDiagonal()
        {
            //first we check up and right diagonal
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    int RedWinner = 1;
                    int YellowWinner = 1;
                    for (int i = 0; i + row < 5 && col - i >= 0; i++)
                    {
                        if ((board.Board2D[col, row] == RedPlayer) && (board.Board2D[col - i, row + i] == RedPlayer))
                        {
                            RedWinner++;
                            if (RedWinner > 4)
                            {
                                return "Red wins";
                            }
                        }
                        else if ((board.Board2D[col, row] == YellowPlayer) && (board.Board2D[col - i, row + i] == YellowPlayer))
                        {
                            YellowWinner++;
                            if (YellowWinner > 4)
                            {
                                return "Yellow wins";
                            }
                        }
                        else
                        {
                            RedWinner = 1;
                            YellowWinner = 1;
                        }
                    }
                }
            }
            return "no winner";
        }

        public string helperCheckUpLeftDiagonal()
        {
            //second we check up and left diagonal
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 6; col++)
                {
                    int RedWinner = 1;
                    int YellowWinner = 1;
                    for (int i = 0; i + row < 5 && col + i < 6; i++)
                    {
                        if ((board.Board2D[col, row] == RedPlayer) && (board.Board2D[col + i, row + i] == RedPlayer))
                        {
                            RedWinner++;
                            if (RedWinner > 4)
                            {
                                return "Red wins";
                            }
                        }
                        else if ((board.Board2D[col, row] == YellowPlayer) && (board.Board2D[col + i, row + i] == YellowPlayer))
                        {
                            YellowWinner++;
                            if (YellowWinner > 4)
                            {
                                return "Yellow wins";
                            }
                        }
                        else
                        {
                            RedWinner = 1;
                            YellowWinner = 1;
                        }
                    }
                }
            }
            return "no winner";
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
                            if (board.Board2D[i, c] != "R " && board.Board2D[i, c] != "Y " && toReturn == "")
                            {
                                toReturn = board.Board2D[i, c];

                                if (RedPlayersTurn)
                                    if(!(c < 2 && i < 2))
                                        board.Board2D[i, c] = RedPlayer ; 
                                    else
                                        board.Board2D[i, c] = RedPlayer;
                                else
                                    if (!(c < 2 && i < 2))
                                        board.Board2D[i, c] = YellowPlayer;
                                    else
                                        board.Board2D[i, c] = YellowPlayer;

                                return toReturn;
                            }
                        }
                    }
                }
            }
            return toReturn;
        }
    }
}
