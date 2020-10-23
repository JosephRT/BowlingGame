using System.CodeDom;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Namespace_1;

namespace BowlingGameTests
{
    [TestClass]
    public class GameTests
    {
        private Namespace_1.Class1 game;

        [TestInitialize]
        public void Initialize()
        {
            game = new Class1();
        }

        [TestMethod]
        public void TestGutterGame()
        {
            for (var i = 0; i < 20; i++)
                game.Roll(0);

            Assert.AreEqual(0, game.Score());
        }

        [TestMethod]
        public void TestAllOnes()
        {
            for (var i = 0; i < 20; i++)
                game.Roll(1);

            Assert.AreEqual(20, game.Score());
        }

        [TestMethod]
        public void TestOneSpare()
        {
            game.Roll(5);
            game.Roll(5);
            game.Roll(3);

            for (var i = 0; i < 17; i++)
                game.Roll(0);

            Assert.AreEqual(16, game.Score());
        }

        [TestMethod]
        public void PerfectGame()
        {
            for (var currentRoll = 0; currentRoll < 12; currentRoll++)
            {
                game.Roll(10);
            }

            Assert.AreEqual(300, game.Score());
        }

        [TestMethod]
        public void AllGutterBallsExceptStrikesOnLastFrame()
        {
            for (var currentFrame = 0; currentFrame < 10; currentFrame++)
            {
                var isNotLastFrame = currentFrame < 9;

                if (isNotLastFrame)
                {
                    game.Roll(0);
                    game.Roll(0);
                }
                else
                {
                    game.Roll(10);
                    game.Roll(10);
                    game.Roll(10);
                }
            }

            Assert.AreEqual(30, game.Score());
        }

        [TestMethod]
        public void StrikeThenSpareThenGutters()
        {
            game.Roll(10);
            game.Roll(5);
            game.Roll(5);

            Assert.AreEqual(30, game.Score());
        }

        [TestMethod]
        public void SpareThenStrikeThenGutters()
        {
            game.Roll(5);
            game.Roll(5);
            game.Roll(10);

            Assert.AreEqual(30, game.Score());
        }
    }
}
