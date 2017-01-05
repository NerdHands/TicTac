using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTac
{
    public partial class Board
    {
        public class Pivot
        {
            public int x { get; set; }
            public int y { get; set; }

            public Pivot() { }

            public Pivot (int x, int y)
            {
                this.x = x;
                this.y = y;
            }



            public static List<Pivot> GetPivots(Board board)
            {
                var pivots = new List<Pivot>();
                for (int x = 1; x < board.Count - 1; x++)
                {
                    for (int y = 1; y < board[0].Count - 1; y++)
                    {
                        pivots.Add(new Pivot() { x = x, y = y });
                    }
                }
                return pivots;
            }

            public static List<Pivot> GetEmptyPoints(Board board)
            {
                var pivots = new List<Pivot>();
                for (int row = 0; row < board.Count; row++)
                {
                    for (int col = 0; col < board[0].Count; col++)
                    {
                        if (board[row][col].Equals(Tile.Blank)) pivots.Add(new Pivot() { x = col, y = row });
                    }
                }
                return pivots;
            }
        }
    }
}
