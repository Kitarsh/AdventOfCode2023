namespace Domain
{
    public class DrawGame
    {
        private List<Game> games;

        public DrawGame(string[] lines)
        {
            games = new List<Game>();
            foreach (var line in lines)
            {
                games.Add(new Game(line));
            }
        }

        public int SumGameIdWithLimit(int redCubeLimit, int greenCubeLimit, int blueCubeLimit)
            => games.Where(game => game.RespectLimit(redCubeLimit, greenCubeLimit, blueCubeLimit)).Select(g => g.Id).Sum();

        public int SumPowersOfGames()
            => games.Sum(g => g.Power);
    }
}