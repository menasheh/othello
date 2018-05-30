using System;
using System.Drawing;
using System.Windows.Forms;
using GameFramework;
using OthelloModel;

namespace OthelloWindows
{
    public partial class OthelloForm : Form
    {
        private static Othello _game;
        
        private static readonly String[] playerNames = { "Black", "White" };

        public OthelloForm()
        {
            _game = new Othello(new Human(), new GreedyComputer());
            InitializeComponent();
            InitializeButtons();
        }

        private void TurnHandler((int x, int y) input)
        {
            (bool placed, bool won, bool tied) response = _game.PlaceToken(input.y, input.x);

            if (response.placed)
            {
                UpdateBoard();

                if (response.won)
                {
                    UpdateStatus(playerNames[_game.GetPlayer() - 1] + " wins!");
                    System.Threading.Thread.Sleep(5000);
                    this.Dispose();
                }
                else if (response.tied)
                {
                    UpdateStatus("It's a tie. Everyone wins! *smirk*");
                    System.Threading.Thread.Sleep(5000);
                    this.Dispose();
                }

                var nextPlayer = _game.Players[_game.GetPlayer() - 1];
                if (nextPlayer is Human)
                {
                    UpdateStatus("Click To Move");
                } else
                {
                    UpdateStatus("Thinking...");
                    TurnHandler(nextPlayer.Move(_game));
                }
            }
            else
            {
                UpdateStatus("Somewhere Else!");
            }

            void UpdateBoard()
            {
                var board = _game.GetBoard();
                var boardHeight = board.GetLength(0);
                var boardWidth = board.GetLength(1);

                for (var i = 0; i < boardHeight; i++)
                {
                    for (var j = 0; j < boardWidth; j++)
                    {
                        buttons[i, j].BackColor = playerColor(board[i, j]);
                    }
                }

                UpdateStatus("");
            }
        }

        private void UpdateStatus(String text)
        {
            int[] scores = _game.GetScores();
            
            pieces.Text = String.Format("Black: {0} White: {1}", scores[0], scores[1]);
            turn.Text = playerNames[_game.GetPlayer() - 1] + "'s Turn";
            if(text!="") instruction.Text = text;

            this.Invalidate();
            this.Update();
        }

        private void InitializeButtons()
        {
            buttons = new Button[8, 8];
            var gameBoard = _game.GetBoard();
            for (int row = 0; row < 8; row++)
            for (int column = 0; column < 8; column++)
            {
                var b = buttons[row, column] = new System.Windows.Forms.Button();

                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;

                this.board.Controls.Add(b, column, row);
                b.Dock = System.Windows.Forms.DockStyle.Fill;
                b.TabIndex = row * 8 + column;

                b.BackColor = playerColor(gameBoard[row, column]);

                b.Click += ButtonClickHandler;
            }
        }

        private void ButtonClickHandler(object sender, EventArgs e)
        {
            if (_game.Players[_game.GetPlayer() - 1] is Human)
            {
                var b = sender as Button;

                Console.WriteLine((b.Location, b.Height, b.Width, (b.Location.X - 5) / b.Width, (b.Location.Y - 5) / b.Height));

                TurnHandler(((b.Location.X - 5) / b.Width, (b.Location.Y - 5) / b.Height));
            }
        }

        private Color playerColor(int player)
        {
            if (player == 1) return Color.Black;
            if (player == 2) return Color.White;
            return System.Drawing.Color.FromArgb(0, 64, 0);
        }

        private void board_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
