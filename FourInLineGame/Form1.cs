using System.Diagnostics;
using System;
namespace FourInLineGame
{
    public partial class Form1 : Form
    {
        private GameClass game = new();
        private int counter = 0;
        private int redScoreCounter = 0;
        private int yellowScoreCounter = 0;
        private List<RoundButton> roundButtonNameList;

        public Form1()
        {
            InitializeComponent();
            roundButtonNameList = new List<RoundButton>
            {
                roundButton1, roundButton2, roundButton3, roundButton4, roundButton5, roundButton6, roundButton7,
                roundButton8, roundButton9, roundButton10, roundButton11, roundButton12, roundButton13, roundButton14,
                roundButton15, roundButton16, roundButton17, roundButton18, roundButton19, roundButton20, roundButton21, 
                roundButton22, roundButton23, roundButton24, roundButton25, roundButton26, roundButton27, roundButton28,
                roundButton29, roundButton30, roundButton31, roundButton32, roundButton33, roundButton34, roundButton35, 
                roundButton36, roundButton37, roundButton38, roundButton39, roundButton40, roundButton41, roundButton42
            };
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                string button = ((Button)sender).Name;
                int btNumber = Int32.Parse(button.Substring(11));
                game.getButtonValue(btNumber);

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

            string movedButton = game.MakeMove();
            if (movedButton != "")
	        {
                makeMoveOnBoard("roundButton" + movedButton);
                changePlayerTurn();
                game.board.printBoard();
	        }
                if (game.checkMoveValid() && game.winningPlayer == "Red player")
                {
                    DialogResult dialogResult = MessageBox.Show($"Winner is Red player \n\n Want to play again?", "Winner box", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        lbRedPlayerScore.Text = (redScoreCounter += 1).ToString();
                        resetGame();
                    }
                    else
                    {
                        Form1.ActiveForm.Close();
                    }
                }
                else if (game.checkMoveValid() && game.winningPlayer == "Yellow player")
                {
                    DialogResult dialogResult = MessageBox.Show($"Winner is Yellow player \n\n Want to play again?", "Winner box", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        lbYellowPlayerScore.Text = (yellowScoreCounter += 1).ToString();
                        resetGame();
                    }
                    else
                    {
                        Form1.ActiveForm.Close();
                    }
                }
            
        }

        private void resetGame()
        {
            counter = 0;
            tbRoundsPlayed.Text = "0";
            game.board.reset2DBoard();
            resetAllPieces();
            rematch = false;
            game.RedPlayersTurn = true;
        }

        private void changePlayerTurn()
        {
            game.changePlayerTurn();
            tbRoundsPlayed.Text = (counter += 1).ToString();
            if (game.RedPlayersTurn)
            {
                roundButton43.BackColor = Color.Red;
                lbRedPlayerScore.BackColor = Color.Red;
                roundButton44.BackColor = SystemColors.Control;
                lbYellowPlayerScore.BackColor = SystemColors.Control;
            }
            if (!game.RedPlayersTurn)
            {
                roundButton44.BackColor = Color.Yellow;
                lbYellowPlayerScore.BackColor = Color.Yellow;
                roundButton43.BackColor = SystemColors.Control;
                lbRedPlayerScore.BackColor = SystemColors.Control;           
            }
        }


        private void resetAllPieces()
        {
            foreach (RoundButton btItem in roundButtonNameList)
            {
                btItem.BackColor = SystemColors.Control;
            }
        }

        private void makeMoveOnBoard(string moveBt)
        {
            foreach (RoundButton btItem in roundButtonNameList)
            {
                if (btItem.Name == moveBt)
                {
                    Console.WriteLine(btItem.Name + " == " + moveBt);
                    if (game.RedPlayersTurn)
                    {
                        btItem.BackColor = Color.Red;
                    }
                    if (!game.RedPlayersTurn)
                    {
                        btItem.BackColor = Color.Yellow;
                    }
                }
            }
        }
    }
}