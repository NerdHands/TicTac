namespace TicTac
{
    public enum Tile
    {
        Oinvalid = 50,
        Xinvalid = 30,
        Blank = 0,
        X = 3,
        O = 5
    }

    public static class TileExtensions
    {
        public static string toTileString(this Tile tile)
        {
            string ret = "";
            if (tile == Tile.Blank) return "-";
            else if (tile == Tile.X) return "x";
            else if (tile == Tile.O) return "o";
            else if (tile == Tile.Xinvalid) return "X";
            else if (tile == Tile.Oinvalid) return "O";
            return "-";
        }
    }
}