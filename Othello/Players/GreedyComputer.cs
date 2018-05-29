using System;
using System.Collections.Generic;
using System.Linq;
using GameFramework;

namespace OthelloModel
{
    public class GreedyComputer : IPlay<Othello>
    {
        public (int x, int y) Move(Othello game)
        {
            var options = game.LegalMoves;
            var flips = game.CountFlipsPerLegalMove();
            int index = flips.IndexOf(flips.Max());

            var result = (options[index].Y, options[index].X);

            int tmpind = 0;
            foreach (var point in options)
            {
                Console.WriteLine(point.X + ", " + point.Y + ": " + flips[tmpind++]);
            }
            
            return result;
        }
    }
}