using System;
using GameFramework;
using OthelloModel;

namespace ConsoleOthello
{
    class ConsoleOthello
    {
        private static Othello _game = new Othello();

        private static IPlay<Othello>[] players =
        {
            new Human(),
            new GreedyComputer(), 
        };

        static void Main(string[] args)
        {
            (int x, int y) input = (-1, -1);
            (bool placed, bool won, bool tied) response = (true, false, false);

            do
            {
                WriteBoard();
                Console.WriteLine();

                if (!response.placed) Console.WriteLine("You can't put that there. Try somewhere else.\n");

                input = players[_game.GetPlayer() - 1].Move(_game);

                response = _game.PlaceToken(input.y, input.x);
                input = (-1, -1);

                Console.Clear();
            } while (!(response.won || response.tied));

            WriteBoard();
            if (response.won)
            {
                Console.WriteLine("\nCongratulations, Player " + _game.GetPlayer() + " (" + "OX".Substring(_game.GetPlayer() - 1, 1) + "), you won!");
            }
            else
            {
                Console.WriteLine(" It's a tie. Everyone wins! *smirk* ");
            }

            Console.WriteLine("\nPress Enter to Exit.  That makes perfect sense, right?");
            Console.ReadLine();
        }

        private static void WriteBoard()
        {
            var board = _game.GetBoard();
            var boardHeight = board.GetLength(0);
            var boardWidth = board.GetLength(1);

            const string labels = "ABCDEFGH";
            int labelIndex = 0;

            Console.WriteLine("   A   B   C   D   E   F   G   H"); // FIX - not scalable
            Console.WriteLine("--- --- --- --- --- --- --- --- ---");
            for (var i = 0; i < boardHeight; i++)
            {
                for (var j = 0; j < boardWidth; j++)
                {
                    int cell = board[i, j];
                    Console.Write(" | ");
                    Console.Write(" OX".Substring(cell, 1));
                }

                Console.Write(" | ");
                Console.WriteLine(labels.Substring(labelIndex++, 1));
                Console.WriteLine(new String('-', 3 + (boardWidth * 4)));
            }

            WriteScore();
        }

        private static void WriteScore()
        {
            int[] scores = _game.GetScores();
            Console.WriteLine("O: " + scores[0]);
            Console.WriteLine("X: " + scores[1]);
        }
    }
}