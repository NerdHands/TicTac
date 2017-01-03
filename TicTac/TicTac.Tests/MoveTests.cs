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
        [TestMethod]
        public void TestXCanWinTop()
        {
            string jsonData = System.IO.File.ReadAllText("Data/Moves/x-can-win-top.json");
            Assert.IsNotNull(jsonData);
            Assert.AreNotEqual(jsonData, String.Empty);
            Board board = JsonConvert.DeserializeObject<Board>(jsonData);
            var pivot = Board.Move.selectBest(board, Tile.X);
            Console.WriteLine(JsonConvert.SerializeObject(pivot, Formatting.Indented));

        }

        [TestMethod]
        public void TestXCanWinLeft()
        {
            string jsonData = System.IO.File.ReadAllText("Data/Moves/x-can-win-left.json");
            Assert.IsNotNull(jsonData);
            Assert.AreNotEqual(jsonData, String.Empty);
            Board board = JsonConvert.DeserializeObject<Board>(jsonData);
            var pivot = Board.Move.selectBest(board, Tile.X);
            Console.WriteLine(JsonConvert.SerializeObject(pivot, Formatting.Indented));

        }

        [TestMethod]
        public void TestXCanWinRight()
        {
            string jsonData = System.IO.File.ReadAllText("Data/Moves/x-can-win-right.json");
            Assert.IsNotNull(jsonData);
            Assert.AreNotEqual(jsonData, String.Empty);
            Board board = JsonConvert.DeserializeObject<Board>(jsonData);
            var pivot = Board.Move.selectBest(board, Tile.X);
            Console.WriteLine(JsonConvert.SerializeObject(pivot, Formatting.Indented));

        }
    }
}
