using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameFramework;
using OthelloModel;

namespace OthelloWindows
{
    public partial class OthelloForm : Form
    {
        private static Othello _game;

        private static IPlay<Othello>[] players =
        {
            new Human(),
            new GreedyComputer(),
        };

        public OthelloForm()
        {
            _game = new Othello();
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
                    Console.WriteLine("\nCongratulations, Player " + _game.GetPlayer() + " (" +
                                      "OX".Substring(_game.GetPlayer() - 1, 1) + "), you won!");
                }
                else if (response.tied)
                {
                    Console.WriteLine(" It's a tie. Everyone wins! *smirk* ");
                }

                var nextPlayer = players[_game.GetPlayer() - 1];
                if (!(nextPlayer is Human)) // Humans move asyncronysly using the form.
                {
                    TurnHandler(nextPlayer.Move(_game));
                }
            }
            else
            {
                Console.WriteLine("You can't put that there. Try somewhere else.\n");
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

                this.Invalidate();
            }
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
            if (players[_game.GetPlayer() - 1] is Human)
            {
                var b = sender as Button;
                TurnHandler((b.Location.X / b.Width, b.Location.Y / b.Height));
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
    }
}