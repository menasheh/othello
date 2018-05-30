using System;
using System.Collections.Generic;
using System.Linq;
using GameFramework;

namespace OthelloModel
{
    public class ForesightAI : IPlay<Othello>
    {
        private int _steps = 0;
        private int _stepsAhead;
        
        private List<OptionNode> gameStates;

        public ForesightAI(int stepsAhead)
        {
            _stepsAhead = stepsAhead;
        }

        private class OptionNode
        {
            public OptionNode Parent { get; }
            public (int x, int y) Move { get; }
            private int[,] _resultingBoard;
            int _turnsPlayed;

            OptionNode(OptionNode parent, (int x, int y) move, int[,] resultingBoardState)
            {
                Parent = parent;
                Move = move;

                _resultingBoard = resultingBoardState;
                
                _turnsPlayed = Othello.TurnsPlayed(_resultingBoard);
            }
        }

        public (int x, int y) Move(Othello game)
        {
            while (_steps - Othello.TurnsPlayed(game.GetBoard()) < _stepsAhead)
            {

            }

            var options = game.LegalMoves;
            var flips = game.CountFlipsPerLegalMove();
            int index = flips.IndexOf(flips.Max());
            var result = (options[index].Y, options[index].X);

            int tmpind = 0;
            foreach (var point in options)
            {
                Console.WriteLine(point.X + ", " + point.Y + ": " + flips[tmpind++]);
            }

            System.Threading.Thread.Sleep(1000);
            return result;
        }
    }
}