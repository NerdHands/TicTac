using System.Collections.Generic;
using System.Linq;

namespace TicTac
{
    public class Row: List<Tile>
    {
        public Row()
        {

        }

        public Row(int size)
        {
            for (int i = 0; i < size; i++)
            {
                this.Add(Tile.Blank);
            }
        }

        public bool isEmpty()
        {
            return this.All((tile) => tile == Tile.Blank);
        }

        public bool isFull()
        {
            return this.All((tile) => tile != Tile.Blank);
        }

        public string toJsonString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("[");
            int count = 0;
            this.ForEach(tile =>
            {
                sb.Append((int)tile);
                count++;
                if (count < this.Count) sb.Append(",");
            });
            sb.Append("]");
            return sb.ToString();
        }

        public string toGameString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("[");
            int count = 0;
            this.ForEach(tile =>
            {
                sb.Append(tile.toTileString());
                count++;
                if (count < this.Count) sb.Append(", ");
            });
            sb.Append("]");
            return sb.ToString();
        }
    }
}