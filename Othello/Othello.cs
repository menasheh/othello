using System;
using System.Collections.Generic;
using System.Text;
using GameFramework;

namespace OthelloModel
{
    public class Othello : Playable
    {
        private const int BoardHeight = 8;
        private const int BoardWidth = 8;

        private int[,] _board;
        private int _turn;
        private int[] _score = new int[2];

        public List<Point> LegalMoves { get; private set; }

        private static readonly int[,] directions = {{0, 1}, {1, 1}, {1, 0}, {1, -1}};

        public Othello()
        {
            _board = new int[BoardHeight, BoardWidth];
            _board[3, 3] = 1;
            _board[3, 4] = 2;
            _board[4, 3] = 2;
            _board[4, 4] = 1;
            _score[0] = _score[1] = 2;
        }

        public int[,] GetBoard() => _board;
        public int GetPlayer() => _turn + 1;
        public int[] GetScores() => _score;

        public (bool placed, bool won, bool tied) PlaceToken(int x, int y)
        {
            (bool placed, bool won, bool tied) result = (ActuallyPlaceToken(x, y), false, false);

            if (result.placed)
            {
                result.won = SwitchPlayerCheckGameOver();

                if (result.won)
                {
                    if (_score[_turn] == _score[1 - _turn])
                    {
                        result.won = false;
                        result.tied = true;
                    }

                    if (_score[_turn] < _score[1 - _turn])
                    {
                        _turn = 1 - _turn;
                    }
                }
            }

            return result;
        }

        private bool SwitchPlayerCheckGameOver()
        {
            SwitchTurn();
            if (LegalMoves.Count == 0) SwitchTurn();
            if (LegalMoves.Count == 0) return true;

            return false;
        }

        private void SwitchTurn()
        {
            _turn = 1 - _turn;
            LegalMoves = GetLegalMoves();
        }

        private List<Point> GetLegalMoves()
        {
            var legalMoves = new List<Point>();
            for (int i = 0; i < BoardHeight; i++)
            {
                for (int j = 0; j < BoardWidth; j++)
                {
                    if (_board[i, j] == 0 && IsLegalMove(i, j))
                    {
                        legalMoves.Add(new Point(i, j));
                    }
                }
            }

            return legalMoves;
        }

        private bool IsLegalMove(int x, int y)
        {
            int myToken = GetPlayer();
            int enemyToken = (1 - _turn) + 1;

            for (int i = 0; i < directions.GetLength(0); i++)
            {
                for (int j = -1; j < 2; j += 2)
                {
                    int xCursor = x + directions[i, 0] * j;
                    int yCursor = y + directions[i, 1] * j;

                    int flippable = 0;

                    while (InBounds(xCursor, yCursor) && _board[xCursor, yCursor] == enemyToken)
                    {
                        xCursor += directions[i, 0] * j;
                        yCursor += directions[i, 1] * j;
                        flippable++;
                    }

                    if (InBounds(xCursor, yCursor) && _board[xCursor, yCursor] == myToken && flippable > 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool ActuallyPlaceToken(int x, int y)
        {
            if (!GetLegalMoves().Contains(new Point(x, y)))
            {
                return false;
            }

            int myToken = GetPlayer();
            int enemyToken = (1 - _turn) + 1;
            _board[x, y] = myToken;
            _score[_turn] += 1;

            for (int i = 0; i < directions.GetLength(0); i++)
            {
                for (int j = -1; j < 2; j += 2)
                {
                    int xCursor = x + directions[i, 0] * j;
                    int yCursor = y + directions[i, 1] * j;

                    int flippable = 0;

                    while (InBounds(xCursor, yCursor) && _board[xCursor, yCursor] == enemyToken)
                    {
                        xCursor += directions[i, 0] * j;
                        yCursor += directions[i, 1] * j;
                        flippable++;
                    }

                    if (InBounds(xCursor, yCursor) && _board[xCursor, yCursor] == myToken)
                    {
                        while (flippable-- > 0)
                        {
                            xCursor -= directions[i, 0] * j;
                            yCursor -= directions[i, 1] * j;

                            _board[xCursor, yCursor] = myToken;
                            _score[_turn] += 1;
                            _score[1 - _turn] -= 1;
                        }
                    }
                }
            }

            return true;
        }

        private bool InBounds(int x, int y)
        {
            return x >= 0 && x < BoardHeight && y >= 0 && y < BoardWidth;
        }

        public List<int> CountFlipsPerLegalMove()
        {
            var flipsPerLegalMove = new List<int>(LegalMoves.Count);
            foreach (var move in LegalMoves)
            {
                flipsPerLegalMove.Add(FlipsIfMove(move.X, move.Y));
            }

            return flipsPerLegalMove;
        }

        private int FlipsIfMove(int x, int y)
        {
            int flips = 0;
            int myToken = GetPlayer();
            int enemyToken = (1 - _turn) + 1;

            for (int i = 0; i < directions.GetLength(0); i++)
            {
                for (int j = -1; j < 2; j += 2)
                {
                    int xCursor = x + directions[i, 0] * j;
                    int yCursor = y + directions[i, 1] * j;

                    int flippable = 0;

                    while (InBounds(xCursor, yCursor) && _board[xCursor, yCursor] == enemyToken)
                    {
                        xCursor += directions[i, 0] * j;
                        yCursor += directions[i, 1] * j;
                        flippable++;
                    }

                    if (InBounds(xCursor, yCursor) && _board[xCursor, yCursor] == myToken)
                    {
                        flips += flippable;
                    }
                }
            }

            return flips;
        }

    }
}