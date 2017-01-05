using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTac
{
    public partial class Board
    {
        public class State
        {
            public int size { get; set; }
            public int xWinCount { get; set; }
            public int oWinCount { get; set; }
            public State() { }

            public State(Board board)
            {
                this.size = board.Count;
            }

            public int getScore(Tile tile)
            {
                if (tile == Tile.X) return xWinCount;
                else if (tile == Tile.O) return oWinCount;
                else return 0;
            }

            public static State calcScore(Board board, State state = null)
            {
                if (state == null) state = new State(board);
                var pivots = Pivot.GetPivots(board);
                int xScore = state.xWinCount;
                int oScore = state.oWinCount;
                pivots.ForEach(pivot =>
                {
                    Tile left = calcLeft(ref board, pivot);
                    if (left == Tile.X) state.xWinCount++;
                    else if (left == Tile.O) state.oWinCount++;

                    Tile right = calcRight(ref board, pivot);
                    if (right == Tile.X) state.xWinCount++;
                    else if (right == Tile.O) state.oWinCount++;

                    Tile top = calcTop(ref board, pivot);
                    if (top == Tile.X) state.xWinCount++;
                    else if (top == Tile.O) state.oWinCount++;

                    Tile bottom = calcBottom(ref board, pivot);
                    if (bottom == Tile.X) state.xWinCount++;
                    else if (bottom == Tile.O) state.oWinCount++;

                    Tile vertMiddle = calcVerticalMiddle(ref board, pivot);
                    if (vertMiddle == Tile.X) state.xWinCount++;
                    else if (vertMiddle == Tile.O) state.oWinCount++;

                    Tile horzMiddle = calcHorizontalMiddle(ref board, pivot);
                    if (horzMiddle == Tile.X) state.xWinCount++;
                    else if (horzMiddle == Tile.O) state.oWinCount++;

                    Tile diagLeft = calcLeftDiagonal(ref board, pivot);
                    if (diagLeft == Tile.X) state.xWinCount++;
                    else if (diagLeft == Tile.O) state.oWinCount++;

                    Tile diagRight = calcRightDiagonal(ref board, pivot);
                    if (diagRight == Tile.X) state.xWinCount++;
                    else if (diagRight == Tile.O) state.oWinCount++;
                });
                if (state.xWinCount > xScore || state.oWinCount > oScore)
                {
                    //Console.WriteLine(board.toGameString());
                }
                return state;
            }

            public static bool checkWin(Board board, Pivot pivot, Tile player)
            {
                var blankTile = board[pivot.y][pivot.x];
                int score = board.getState().getScore(player);
                board.play(player, pivot.y, pivot.x); //mark the tile with the player

                var ret = board.getState().getScore(player) > score;
                board.play(blankTile, pivot.y, pivot.x); //restore tile to its original state
                return ret;
            }

            private static Tile calcLeft(ref Board board, Pivot pivot)
            {
                int x = pivot.x;
                int y = pivot.y;
                Tile a = board[y - 1][x - 1];
                Tile b = board[y][x - 1];
                Tile c = board[y + 1][x - 1];

                int prod = (int)a * (int)b * (int)c;
                if (prod == Game.XWON)
                {
                    board[y - 1][x - 1] = board[y][x - 1] = board[y + 1][x - 1] = Tile.Xinvalid;
                    return Tile.X;
                }
                else if (prod == Game.OWON)
                {
                    board[y - 1][x - 1] = board[y][x - 1] = board[y + 1][x - 1] = Tile.Oinvalid;
                    return Tile.O;
                }
                else return Tile.Blank;
            }

            private static Tile calcRight(ref Board board, Pivot pivot)
            {
                int x = pivot.x, y = pivot.y;
                Tile a = board[y - 1][x + 1];
                Tile b = board[y][x + 1];
                Tile c = board[y + 1][x + 1];

                int prod = (int)a * (int)b * (int)c;
                if (prod == Game.XWON)
                {
                    board[y - 1][x + 1] = board[y][x + 1] = board[y + 1][x + 1] = Tile.Xinvalid;
                    return Tile.X;
                }
                else if (prod == Game.OWON)
                {
                    board[y - 1][x + 1] = board[y][x + 1] = board[y + 1][x + 1] = Tile.Oinvalid;
                    return Tile.O;
                }
                else return Tile.Blank;
            }

            private static Tile calcTop(ref Board board, Pivot pivot)
            {
                int x = pivot.x, y = pivot.y;
                Tile a = board[y - 1][x - 1];
                Tile b = board[y - 1][x];
                Tile c = board[y - 1][x + 1];

                int prod = (int)a * (int)b * (int)c;
                if (prod == Game.XWON)
                {
                    board[y - 1][x - 1] = board[y - 1][x] = board[y - 1][x + 1] = Tile.Xinvalid;
                    return Tile.X;
                }
                else if (prod == Game.OWON)
                {
                    board[y - 1][x - 1] = board[y - 1][x] = board[y - 1][x + 1] = Tile.Oinvalid;
                    return Tile.O;
                }
                else return Tile.Blank;
            }

            private static Tile calcBottom(ref Board board, Pivot pivot)
            {
                int x = pivot.x, y = pivot.y;
                Tile a = board[y + 1][x - 1];
                Tile b = board[y + 1][x];
                Tile c = board[y + 1][x + 1];

                int prod = (int)a * (int)b * (int)c;
                if (prod == Game.XWON)
                {
                    board[y + 1][x - 1] = board[y + 1][x] = board[y + 1][x + 1] = Tile.Xinvalid;
                    return Tile.X;
                }
                else if (prod == Game.OWON)
                {
                    board[y + 1][x - 1] = board[y + 1][x] = board[y + 1][x + 1] = Tile.Oinvalid;
                    return Tile.O;
                }
                else return Tile.Blank;
            }

            private static Tile calcHorizontalMiddle(ref Board board, Pivot pivot)
            {
                int x = pivot.x, y = pivot.y;
                Tile a = board[y][x - 1];
                Tile b = board[y][x];
                Tile c = board[y][x + 1];

                int prod = (int)a * (int)b * (int)c;
                if (prod == Game.XWON)
                {
                    board[y][x - 1] = board[y][x] = board[y][x + 1] = Tile.Xinvalid;
                    return Tile.X;
                }
                else if (prod == Game.OWON)
                {
                    board[y][x - 1] = board[y][x] = board[y][x + 1] = Tile.Oinvalid;
                    return Tile.O;
                }
                else return Tile.Blank;
            }

            private static Tile calcVerticalMiddle(ref Board board, Pivot pivot)
            {
                int x = pivot.x, y = pivot.y;
                Tile a = board[y - 1][x];
                Tile b = board[y][x];
                Tile c = board[y + 1][x];

                int prod = (int)a * (int)b * (int)c;
                if (prod == Game.XWON)
                {
                    board[y - 1][x] = board[y][x] = board[y + 1][x] = Tile.Xinvalid;
                    return Tile.X;
                }
                else if (prod == Game.OWON)
                {
                    board[y - 1][x] = board[y][x] = board[y + 1][x] = Tile.Oinvalid;
                    return Tile.O;
                }
                else return Tile.Blank;
            }

            private static Tile calcLeftDiagonal(ref Board board, Pivot pivot)
            {
                int x = pivot.x, y = pivot.y;
                Tile a = board[y - 1][x - 1];
                Tile b = board[y][x];
                Tile c = board[y + 1][x + 1];

                int prod = (int)a * (int)b * (int)c;
                if (prod == Game.XWON)
                {
                    board[y - 1][x - 1] = board[y][x] = board[y + 1][x + 1] = Tile.Xinvalid;
                    return Tile.X;
                }
                else if (prod == Game.OWON)
                {
                    board[y - 1][x - 1] = board[y][x] = board[y + 1][x + 1] = Tile.Oinvalid;
                    return Tile.O;
                }
                else return Tile.Blank;
            }

            private static Tile calcRightDiagonal(ref Board board, Pivot pivot)
            {
                int x = pivot.x, y = pivot.y;
                Tile a = board[y - 1][x + 1];
                Tile b = board[y][x];
                Tile c = board[y + 1][x - 1];

                int prod = (int)a * (int)b * (int)c;
                if (prod == Game.XWON)
                {
                    board[y - 1][x + 1] = board[y][x] = board[y + 1][x - 1] = Tile.Xinvalid;
                    return Tile.X;
                }
                else if (prod == Game.OWON)
                {
                    board[y - 1][x + 1] = board[y][x] = board[y + 1][x - 1] = Tile.Oinvalid;
                    return Tile.O;
                }
                else return Tile.Blank;
            }
        }
    }
}
