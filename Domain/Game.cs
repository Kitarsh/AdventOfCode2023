namespace Domain
{
    public class Game
    {
        private string input;

        public Game(string input)
        {
            this.input = input;
            ParseInput();
            ComputePower();
        }

        public int Id { get; private set; }

        public List<Draw> Draws { get; private set; }

        public int Power { get; set; }

        internal bool RespectLimit(int redCubeLimit, int greenCubeLimit, int blueCubeLimit)
        {
            return Draws.All(draw => draw.RespectLimit(redCubeLimit, greenCubeLimit, blueCubeLimit));
        }

        private void ComputePower()
        {
            var maxGreen = Draws.Select(d => d.Greens).Max();
            var maxRed = Draws.Select(d => d.Reds).Max();
            var maxBlue = Draws.Select(d => d.Blues).Max();
            Power = maxGreen * maxRed * maxBlue;
        }

        private void ParseInput()
        {
            ParseId();
            ParseDraws();
        }

        private void ParseDraws()
        {
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