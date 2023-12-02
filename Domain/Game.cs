namespace Domain
{
    public class Game
    {
        private string input;

        public Game(string input)
        {
            this.input = input;
            ParseInput();
        }

        public int Id { get; private set; }
        public List<Draw> Draws { get; private set; }

        internal bool RespectLimit(int redCubeLimit, int greenCubeLimit, int blueCubeLimit)
        {
            return Draws.All(draw => draw.RespectLimit(redCubeLimit, greenCubeLimit, blueCubeLimit));
        }

        private void ParseInput()
        {
            ParseId();

            var inputAfterColon = input.Split(": ")[1];
            var drawsInputs = inputAfterColon.Split("; ");
            this.Draws = new List<Draw>();
            foreach (var drawInput in drawsInputs)
            {
                Draws.Add(new Draw(drawInput));
            }
        }

        private void ParseId()
        {
            var inputWithoutGame = new string(input.Skip(5).ToArray());
            var gameIdStr = inputWithoutGame.Split(':')[0];
            Id = Int32.Parse(gameIdStr);
        }
    }
}