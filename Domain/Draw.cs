namespace Domain
{
    public class Draw
    {
        private string drawInput;

        public Draw(string drawInput)
        {
            this.drawInput = drawInput;
            ParseInput();
        }

        public int Blues { get; set; }

        public int Reds { get; set; }

        public int Greens { get; set; }

        internal bool RespectLimit(int redCubeLimit, int greenCubeLimit, int blueCubeLimit)
        {
            return Reds <= redCubeLimit && Greens <= greenCubeLimit && Blues <= blueCubeLimit;
        }

        private void ParseInput()
        {
            var oneColorDrawList = drawInput.Split(", ");
            foreach (var oneColor in oneColorDrawList)
            {
                var cubeSplit = oneColor.Split(' ');
                var number = Int32.Parse(cubeSplit[0]);
                var color = cubeSplit[1];

                switch (color)
                {
                    case "blue": Blues = number; break;
                    case "red": Reds = number; break;
                    case "green": Greens = number; break;
                }
            }
        }
    }
}