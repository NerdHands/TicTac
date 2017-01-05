using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicTac.Tests
{
    [TestClass]
    public class GameTests
    {
        private void performGameTest(string jsonData, Tile starterPlayer)
        {
            Board board = JsonConvert.DeserializeObject<Board>(jsonData);
            Console.WriteLine("Input:\n" + board.toJsonString());
            Tile player = starterPlayer;
            Tile opponent = starterPlayer == Tile.X ? Tile.O : Tile.X;
            int iteration = 0;
            while (!board.isFull())
            {
                iteration++;
                var currentPlayer = iteration % 2 != 0 ? player : opponent;
                var pivot = Board.Move.selectBestMove(board, currentPlayer);
                board.play(currentPlayer, pivot.y, pivot.x);
                board.getState();
                Console.WriteLine("Play " + iteration + ":\n" + board.toGameString());
            }
            Console.WriteLine("Final State:\n" + JsonConvert.SerializeObject(board.getState()));
        }

        [TestMethod]
        public void TestFull3x3GameFromScratchXStarts()
        {
            string jsonData = System.IO.File.ReadAllText("Data/Board/empty-board.json");
            performGameTest(jsonData, Tile.X);
        }

        [TestMethod]
        public void TestFull6x6GameFromScratchXStarts()
        {
            string jsonData = System.IO.File.ReadAllText("Data/Board/empty-board-6.json");
            performGameTest(jsonData, Tile.X);
        }

        [TestMethod]
        public void TestFull9x9GameFromScratchXStarts()
        {
            string jsonData = System.IO.File.ReadAllText("Data/Board/empty-board-9.json");
            performGameTest(jsonData, Tile.X);
        }

        [TestMethod]
        public void TestFull12x12GameFromScratchXStarts()
        {
            string jsonData = System.IO.File.ReadAllText("Data/Board/empty-board-12.json");
            performGameTest(jsonData, Tile.X);
        }
    }
}
