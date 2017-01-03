using System;
using Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicTac.Tests {
    [TestClass]
    public class BoardTests {

        [TestMethod]
        public void TestThatWidthAndHeightAreSame() {
            var board = new Board(3);
            Assert.AreEqual(board.Count, board[0].Count);
        }

        [TestMethod]
        public void TestBoardIsEmpty()
        {
            string jsonData = System.IO.File.ReadAllText("Data/empty-board.json");
            Assert.IsNotNull(jsonData);
            Assert.AreNotEqual(jsonData, String.Empty);
            Board board = JsonConvert.DeserializeObject<Board>(jsonData);
            Assert.IsTrue(board.isEmpty());
            Assert.IsTrue(board.isValid());
            Assert.AreEqual(board.getState().xWinCount, 0);
            Assert.AreEqual(board.getState().oWinCount, 0);
        }

        [TestMethod]
        public void TestXWinsRight()
        {
            string jsonData = System.IO.File.ReadAllText("Data/x-right-win.json");
            Assert.IsNotNull(jsonData);
            Assert.AreNotEqual(jsonData, String.Empty);
            Board board = JsonConvert.DeserializeObject<Board>(jsonData);
            Assert.IsTrue(board.isValid());
            var state = board.getState();
            Assert.AreEqual(state.xWinCount, 1);
            Assert.AreEqual(state.oWinCount, 0);
        }

        [TestMethod]
        public void TestXWinsLeft()
        {
            string jsonData = System.IO.File.ReadAllText("Data/x-left-win.json");
            Assert.IsNotNull(jsonData);
            Assert.AreNotEqual(jsonData, String.Empty);
            Board board = JsonConvert.DeserializeObject<Board>(jsonData);
            Assert.IsTrue(board.isValid());
            var state = board.getState();
            Assert.AreEqual(state.xWinCount, 1);
            Assert.AreEqual(state.oWinCount, 0);
        }

        [TestMethod]
        public void TestXWinsBottom()
        {
            string jsonData = System.IO.File.ReadAllText("Data/x-bottom-win.json");
            Assert.IsNotNull(jsonData);
            Assert.AreNotEqual(jsonData, String.Empty);
            Board board = JsonConvert.DeserializeObject<Board>(jsonData);
            Assert.IsTrue(board.isValid());
            var state = board.getState();
            Assert.AreEqual(state.xWinCount, 1);
            Assert.AreEqual(state.oWinCount, 0);
        }

        [TestMethod]
        public void TestXWinsTop()
        {
            string jsonData = System.IO.File.ReadAllText("Data/x-top-win.json");
            Assert.IsNotNull(jsonData);
            Assert.AreNotEqual(jsonData, String.Empty);
            Board board = JsonConvert.DeserializeObject<Board>(jsonData);
            Assert.IsTrue(board.isValid());
            var state = board.getState();
            Assert.AreEqual(state.xWinCount, 1);
            Assert.AreEqual(state.oWinCount, 0);
        }

        [TestMethod]
        public void TestXWinsLeftDiagonal()
        {
            string jsonData = System.IO.File.ReadAllText("Data/x-left-diagonal-win.json");
            Assert.IsNotNull(jsonData);
            Assert.AreNotEqual(jsonData, String.Empty);
            Board board = JsonConvert.DeserializeObject<Board>(jsonData);
            Assert.IsTrue(board.isValid());
            var state = board.getState();
            Assert.AreEqual(state.xWinCount, 1);
            Assert.AreEqual(state.oWinCount, 0);
        }

        [TestMethod]
        public void TestXWinsRightDiagonal()
        {
            string jsonData = System.IO.File.ReadAllText("Data/x-right-diagonal-win.json");
            Assert.IsNotNull(jsonData);
            Assert.AreNotEqual(jsonData, String.Empty);
            Board board = JsonConvert.DeserializeObject<Board>(jsonData);
            Assert.IsTrue(board.isValid());
            var state = board.getState();
            Assert.AreEqual(state.xWinCount, 1);
            Assert.AreEqual(state.oWinCount, 0);
        }

        [TestMethod]
        public void TestXWinsMiddleVertical()
        {
            string jsonData = System.IO.File.ReadAllText("Data/x-middle-vertical-win.json");
            Assert.IsNotNull(jsonData);
            Assert.AreNotEqual(jsonData, String.Empty);
            Board board = JsonConvert.DeserializeObject<Board>(jsonData);
            Assert.IsTrue(board.isValid());
            var state = board.getState();
            Assert.AreEqual(state.xWinCount, 1);
            Assert.AreEqual(state.oWinCount, 0);
        }

        [TestMethod]
        public void TestXWinsMiddleHorizontal()
        {
            string jsonData = System.IO.File.ReadAllText("Data/x-middle-horizontal-win.json");
            Assert.IsNotNull(jsonData);
            Assert.AreNotEqual(jsonData, String.Empty);
            Board board = JsonConvert.DeserializeObject<Board>(jsonData);
            Assert.IsTrue(board.isValid());
            var state = board.getState();
            Assert.AreEqual(state.xWinCount, 1);
            Assert.AreEqual(state.oWinCount, 0);
        }

        [TestMethod]
        public void TestOWinsRight()
        {
            //Arrange
            string jsonData = System.IO.File.ReadAllText("Data/o-right-win.json");
            var board = JsonConvert.DeserializeObject<Board>(jsonData);
            var state = board.getState();

            //Assert
            Assert.AreEqual(state.xWinCount, 0);
            Assert.AreEqual(state.oWinCount, 1);
        }

        [TestMethod]
        public void TestOWinsLeft() {
            //Arrange
            string jsonData = System.IO.File.ReadAllText("Data/o-left-win.json");
            var board = JsonConvert.DeserializeObject<Board>(jsonData);
            var state = board.getState();

            //Assert
            Assert.AreEqual(state.xWinCount, 0);
            Assert.AreEqual(state.oWinCount, 1);
        }

        [TestMethod]
        public void TestOWinsTop() {
            //Arrange
            string jsonData = System.IO.File.ReadAllText("Data/o-top-win.json");
            var board = JsonConvert.DeserializeObject<Board>(jsonData);
            var state = board.getState();

            //Assert
            Assert.AreEqual(state.xWinCount, 0);
            Assert.AreEqual(state.oWinCount, 1);
        }

        [TestMethod]
        public void TestOWinsBottom() {
            //Arrange
            string jsonData = System.IO.File.ReadAllText("Data/o-bottom-win.json");
            var board = JsonConvert.DeserializeObject<Board>(jsonData);
            var state = board.getState();

            //Assert
            Assert.AreEqual(state.xWinCount, 0);
            Assert.AreEqual(state.oWinCount, 1);
        }

        [TestMethod]
        public void TestOWinsMidH() {
            //Arrange
            string jsonData = System.IO.File.ReadAllText("Data/o-mid-h-win.json");
            var board = JsonConvert.DeserializeObject<Board>(jsonData);
            var state = board.getState();

            //Assert
            Assert.AreEqual(state.xWinCount, 0);
            Assert.AreEqual(state.oWinCount, 1);
        }

        [TestMethod]
        public void TestOWinsMidV() {
            //Arrange
            string jsonData = System.IO.File.ReadAllText("Data/o-mid-v-win.json");
            var board = JsonConvert.DeserializeObject<Board>(jsonData);
            var state = board.getState();

            //Assert
            Assert.AreEqual(state.xWinCount, 0);
            Assert.AreEqual(state.oWinCount, 1);
        }

        [TestMethod]
        public void TestOWinsDiagonalRight() {
            //Arrange
            string jsonData = System.IO.File.ReadAllText("Data/o-diag-r-win.json");
            var board = JsonConvert.DeserializeObject<Board>(jsonData);
            var state = board.getState();

            //Assert
            Assert.AreEqual(state.xWinCount, 0);
            Assert.AreEqual(state.oWinCount, 1);
        }

        [TestMethod]
        public void TestOWinsDiagonalLeft() {
            //Arrange
            string jsonData = System.IO.File.ReadAllText("Data/o-diag-l-win.json");
            var board = JsonConvert.DeserializeObject<Board>(jsonData);
            var state = board.getState();

            //Assert
            Assert.AreEqual(state.xWinCount, 0);
            Assert.AreEqual(state.oWinCount, 1);
        }
    }
}