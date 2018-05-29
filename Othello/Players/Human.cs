using System;
using GameFramework;

namespace OthelloModel
{
    public class Human : IPlay<Othello>
    {
        public (int x, int y) Move(Othello game)
        {
            (int x, int y) result = (-1, -1);
            int[,] board = game.GetBoard();
            int player = game.GetPlayer();

            Console.WriteLine("Player " + player + " (" + "OX".Substring(player - 1, 1) +
                              "):\nPress a letter to choose a column:");
            while (result.x < 0 || result.x >= board.GetLength(1))
            {
                result.x = (int)Console.ReadKey().Key - 65;
            }

            Console.WriteLine("\nAnd another letter to choose a row:");
            while (result.y < 0 || result.y >= board.GetLength(1))
            {
                result.y = (int)Console.ReadKey().Key - 65;
            }

            return result;
        }
    }
}