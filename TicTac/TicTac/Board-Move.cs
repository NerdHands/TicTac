using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTac
{
    public partial class Board
    {
        public class Move
        {
            public static Pivot selectBestMove(Board board, Tile player)
            {
                if (board.Count < 3) throw new Exception("Board should be of Size 3 or more");
                if (board.FirstOrDefault().Count < 3) throw new Exception("Board should be of Size 3 or more");
                int max = 0;
                Pivot bestPivot = null;

                for (int row = 0; row <= board.Count - 3; row++)
                {
                    for (int col = 0; col <= board.FirstOrDefault().Count - 3; col++)
                    {
                        int localMax;
                        Pivot localBestPivot = selectBest(board.getBoard(new Pivot(col, row), 3), player, out localMax);
                        if (localBestPivot != null)
                        {
                            localBestPivot.x += col;
                            localBestPivot.y += row;
                        }
                        if (localMax == Game.PLAYERWON) return localBestPivot;
                        else if (localMax > max)
                        {
                            max = localMax;
                            bestPivot = localBestPivot;
                        }
                    }
                }

                return bestPivot;
            }

            private static Pivot selectBest(Board board, Tile player, out int max)
            {
                max = 0;
                Pivot bestPivot = null;
                for (int row = 0; row < board.Count; row++)
                {
                    for (int col = 0; col < board.FirstOrDefault().Count; col++)
                    {
                        if (board[row][col] == Tile.Blank)
                        {
                            //board[row][col] = player;
                            int fitnessValue = getFitness(board, new Pivot() { x = col, y = row }, player); //stopped working here before push
                            //board[row][col] = Tile.Blank;
                            if (fitnessValue > max)
                            {
                                max = fitnessValue;
                                bestPivot = new Pivot() { x = col, y = row };
                            }
                        }
                    }
                }
                if (bestPivot == null)
                {
                    var pivots = Pivot.GetEmptyPoints(board);
                    if (pivots.Count > 0) bestPivot = pivots[new System.Random().Next(pivots.Count)];
                }
                return bestPivot;
            }

            public static int getFitness(Board board, Pivot pivot, Tile player)
            {
                var opponent = player == Tile.X ? Tile.O : Tile.X;
                if (State.checkWin(board, pivot, player)) return Game.PLAYERWON;
                if (State.checkWin(board, pivot, opponent)) return Game.OPPONENTWON;
                
                //for (int row = 0; row < board.Count; row++)
                //{
                //    for (int col = 0; col < board.FirstOrDefault().Count; col++)
                //    {
                //        if (board[row][col] == Tile.Blank)
                //        {
                //            int value = -getFitness(board, new Pivot()
                //            {
                //                x = row,
                //                y = col
                //            }, opponent);
                //            if (value > max)
                //            {
                //                max = value;
                //                return max;
                //            }
                //        }
                //    }
                //}
                return Game.RANDOMPLAY;
            }
        }
    }
}
