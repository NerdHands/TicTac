using System.Collections.Generic;
using System.Linq;

namespace TicTac
{
    public partial class Board: List<Row>
    {
        private State state { get; set; }
        public Board()
        {

        }
        public Board(int size)
        {
            for (int i = 0; i < size; i++)
            {
                this.Add(new Row(size));
            }
            
        }

        public State getState()
        {
            if (state == null) this.state = new State(this);
            state = State.calcScore(this, state);
            return state;
        } 
        
        public bool isEmpty()
        {
            return this.All(row => row.isEmpty());
        }

        public bool isFull()
        {
            return this.All(row => row.isFull());
        }

        public bool isValid()
        {
            return this.Select(row => row.Count).Distinct().Count() == 1 && this.Count >= 3;
        }

        public State play(Tile tile, int row, int column)
        {
            var state = new Board.State(this);
            this[row][column] = tile;
            return this.getState();
        }

        public Board getBoard(Pivot pivot, int size = 3)
        {
            Board ret = new Board();
            if (pivot.y + size > this.Count) throw new System.Exception("New Sub-Board Rows cannot be out of bounds of Parent Board");
            if (pivot.x + size > this.FirstOrDefault().Count) throw new System.Exception("New Sub-Board Columns cannot be out of bounds of Parent Board");
            for (int y = pivot.y; y < size + pivot.y; y++)
            {
                Row row = new Row();
                for (int x = pivot.x; x < size + pivot.x; x++)
                {
                    row.Add((Tile)((int)this[y][x] + 0)); //make sure a copy and not a reference is passed into the new board
                }
                ret.Add(row);
            }
            return ret;
        }

        public string toJsonString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("[\n");
            int count = 0;
            this.ForEach(row =>
            {
                sb.Append(row.toJsonString());
                count++;
                if (count < this.Count) sb.Append(",\n");
            });
            sb.Append("\n]");
            return sb.ToString();
        }

        public string toGameString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("[\n");
            int count = 0;
            this.ForEach(row =>
            {
                sb.Append(row.toGameString());
                count++;
                if (count < this.Count) sb.Append(",\n");
            });
            sb.Append("\n]");
            return sb.ToString();
        }
    }
}
