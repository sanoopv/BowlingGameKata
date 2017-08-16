using BowlingGameKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGameTests
{
    /// <summary>
    /// Summary description for BowlingGameTest
    /// </summary>
    [TestClass]
    public class BowlingGameTest
    {
        private Game game;
        public BowlingGameTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestGutterGame()
        {
            game = new Game();
            RollMultiple(20, 0);
            const int EXPECTED = 0;
            Assert.AreEqual(EXPECTED, game.Score());

        }
        [TestMethod]
        public void TestAllOnesGame()
        {
            game = new Game();
            RollMultiple(20, 1);
            const int EXPECTED = 20;
            Assert.AreEqual(EXPECTED, game.Score());
        }

        [TestMethod]
        public void TestOneSpare()
        {
            game = new Game();
            RollSpare();
            game.Roll(3);
            RollMultiple(17, 0);
            const int EXPECTED = 16;
            Assert.AreEqual(EXPECTED, game.Score());
        }

        [TestMethod]
        public void TestOneStrike()
        {
            game = new Game();
            RollStrike();
            game.Roll(3);
            game.Roll(4);
            RollMultiple(16, 0);
            const int EXPECTED = 24;
            Assert.AreEqual(EXPECTED, game.Score());
        }

        [TestMethod]
        public void TestPerfectGame()
        {
            game = new Game();
            RollMultiple(12,10);
            const int EXPECTED = 300;
            Assert.AreEqual(EXPECTED,game.Score());
        }

        public void RollMultiple(int times, int pins)
        {
            for (var i = 0; i < times; i++)
            {
                game.Roll(pins);
            }
        }

        public void RollStrike()
        {
            game.Roll(10);
        }
        public void RollSpare()
        {
            game.Roll(5);
            game.Roll(5);
        }

    }
}
