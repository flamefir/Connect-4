using System.Diagnostics;
using System;
namespace FourInLineGame
{
    public partial class Form1 : Form
    {
        private GameClass game = new();
        private int counter = 0;
        private List<Tuple<RoundButton, string>> roundButtonNameList;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            string button = ((Button)sender).Name;
            int btNumber = Int32.Parse(button.Substring(11));

            game.getButtonValue(btNumber);

            if (game.checkMoveValid())
            {
                makeMoveOnBoard("roundButton" + game.MakeMove());
                changePlayerTurn();
            }
        }

        private void changePlayerTurn()
        {
            game.changePlayerTurn();
            tbRoundsPlayed.Text = (counter += 1).ToString();
            if (game.RedPlayersTurn)
            {
                roundButton43.BackColor = Color.Red;
                roundButton44.BackColor = SystemColors.Control;
            }
            if (!game.RedPlayersTurn)
            {
                roundButton44.BackColor = Color.Yellow;
                roundButton43.BackColor = SystemColors.Control;
            }
        }

        private void makeMoveOnBoard(string moveBt)
        {
            roundButtonNameList = new List<Tuple<RoundButton, string>>
            {
                Tuple.Create(roundButton1, "roundButton1"),
                Tuple.Create(roundButton2, "roundButton2"),
                Tuple.Create(roundButton3, "roundButton3"),
                Tuple.Create(roundButton4, "roundButton4"),
                Tuple.Create(roundButton5, "roundButton5"),
                Tuple.Create(roundButton6, "roundButton6"),
                Tuple.Create(roundButton7, "roundButton7"),
                Tuple.Create(roundButton8, "roundButton8"),
                Tuple.Create(roundButton9, "roundButton9"),
                Tuple.Create(roundButton10, "roundButton10"),
                Tuple.Create(roundButton11, "roundButton11"),
                Tuple.Create(roundButton12, "roundButton12"),
                Tuple.Create(roundButton13, "roundButton13"),
                Tuple.Create(roundButton14, "roundButton14"),
                Tuple.Create(roundButton15, "roundButton15"),
                Tuple.Create(roundButton16, "roundButton16"),
                Tuple.Create(roundButton17, "roundButton17"),
                Tuple.Create(roundButton18, "roundButton18"),
                Tuple.Create(roundButton19, "roundButton19"),
                Tuple.Create(roundButton20, "roundButton20"),
                Tuple.Create(roundButton21, "roundButton21"),
                Tuple.Create(roundButton22, "roundButton22"),
                Tuple.Create(roundButton23, "roundButton23"),
                Tuple.Create(roundButton24, "roundButton24"),
                Tuple.Create(roundButton25, "roundButton25"),
                Tuple.Create(roundButton26, "roundButton26"),
                Tuple.Create(roundButton27, "roundButton27"),
                Tuple.Create(roundButton28, "roundButton28"),
                Tuple.Create(roundButton29, "roundButton29"),
                Tuple.Create(roundButton30, "roundButton30"),
                Tuple.Create(roundButton31, "roundButton31"),
                Tuple.Create(roundButton32, "roundButton32"),
                Tuple.Create(roundButton33, "roundButton33"),
                Tuple.Create(roundButton34, "roundButton34"),
                Tuple.Create(roundButton35, "roundButton35"),
                Tuple.Create(roundButton36, "roundButton36"),
                Tuple.Create(roundButton37, "roundButton37"),
                Tuple.Create(roundButton38, "roundButton38"),
                Tuple.Create(roundButton39, "roundButton39"),
                Tuple.Create(roundButton40, "roundButton40"),
                Tuple.Create(roundButton41, "roundButton41"),
                Tuple.Create(roundButton42, "roundButton42")
            };

            foreach (Tuple<RoundButton, string> tuple in roundButtonNameList)
            {
                if (tuple.Item2 == moveBt)
                {
                    Console.WriteLine(tuple.Item2 + " == " + moveBt);
                    if (game.RedPlayersTurn)
                    {
                        tuple.Item1.BackColor = Color.Red;
                    }
                    if (!game.RedPlayersTurn)
                    {
                        tuple.Item1.BackColor = Color.Yellow;
                    }
                }
            }
        }
    }
}