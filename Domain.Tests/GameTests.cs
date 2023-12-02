namespace Domain.Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void ParseAGame()
        {
            var input = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";

            var game = new Game(input);
            Assert.AreEqual(1, game.Id);
            Assert.AreEqual(3, game.Draws.Count());

            var firstDraw = game.Draws[0];
            Assert.AreEqual(3, firstDraw.Blues);
            Assert.AreEqual(4, firstDraw.Reds);
            Assert.AreEqual(0, firstDraw.Greens);

            var secondDraw = game.Draws[1];
            Assert.AreEqual(6, secondDraw.Blues);
            Assert.AreEqual(1, secondDraw.Reds);
            Assert.AreEqual(2, secondDraw.Greens);

            var thirdDraw = game.Draws[2];
            Assert.AreEqual(0, thirdDraw.Blues);
            Assert.AreEqual(0, thirdDraw.Reds);
            Assert.AreEqual(2, thirdDraw.Greens);
        }

        [TestMethod]
        public void GetGamesWithCubeLimit()
        {
            var lines = File.ReadAllLines("SampleInput.txt");
            var drawGame = new DrawGame(lines);

            var redCubeLimit = 12;
            var greenCubeLimit = 13;
            var blueCubeLimit = 14;

            int result = drawGame.SumGameIdWithLimit(redCubeLimit, greenCubeLimit, blueCubeLimit);

            Assert.AreEqual(8, result);
        }
    }
}