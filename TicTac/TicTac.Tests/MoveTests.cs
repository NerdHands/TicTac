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
    public class MoveTests
    {
        private void performMoveWinTest(string jsonData, Tile player = Tile.X)
        {
            Console.WriteLine("Input:\n" + jsonData);
            Assert.IsNotNull(jsonData);
            Assert.AreNotEqual(jsonData, String.Empty);
            Board board = JsonConvert.DeserializeObject<Board>(jsonData);
            int score = board.getState().getScore(player);
            var pivot = Board.Move.selectBestMove(board, player);
            Console.WriteLine("Output:\n" + JsonConvert.SerializeObject(pivot, Formatting.Indented));
            Assert.IsNotNull(pivot, "pivot should not be null");
            board.play(player, pivot.y, pivot.x);
            int newScore = board.getState().getScore(player);
            Assert.AreNotEqual<int>(score, newScore);
            Console.WriteLine("New Board:\n" + board.toJsonString());
            Console.WriteLine("Old Score: " + score + ", New Score: " + newScore);
        }

        [TestMethod]
        public void TestXCanWinTop()
        {
            string jsonData = System.IO.File.ReadAllText("Data/Moves/x-can-win-top.json");
            performMoveWinTest(jsonData);
        }

        [TestMethod]
        public void TestXCanWinLeft()
        {
            string jsonData = System.IO.File.ReadAllText("Data/Moves/x-can-win-left.json");
            performMoveWinTest(jsonData);
        }

        [TestMethod]
        public void TestXCanWinRight()
        {
            string jsonData = System.IO.File.ReadAllText("Data/Moves/x-can-win-right.json");
            performMoveWinTest(jsonData);
        }

        [TestMethod]
        public void TestXCanWinBottom()
        {
            string jsonData = System.IO.File.ReadAllText("Data/Moves/x-can-win-bottom.json");
            performMoveWinTest(jsonData);
        }

        [TestMethod]
        public void TestXCanWinMiddleVert()
        {
            string jsonData = System.IO.File.ReadAllText("Data/Moves/x-can-win-middle-vert.json");
            performMoveWinTest(jsonData);
        }

        [TestMethod]
        public void TestXCanWinMiddleHorz()
        {
            string jsonData = System.IO.File.ReadAllText("Data/Moves/x-can-win-middle-horz.json");
            performMoveWinTest(jsonData);
        }

        [TestMethod]
        public void TestXCanWinLeftDiagonal()
        {
            string jsonData = System.IO.File.ReadAllText("Data/Moves/x-can-win-left-diag.json");
            performMoveWinTest(jsonData);
        }

        [TestMethod]
        public void TestXCanWinRightDiagonal()
        {
            string jsonData = System.IO.File.ReadAllText("Data/Moves/x-can-win-right-diag.json");
            performMoveWinTest(jsonData);
        }
    }
}
