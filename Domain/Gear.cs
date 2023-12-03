using System.Text.RegularExpressions;

namespace Domain
{
    public class Gear
    {
        private string[] lines;
        private List<int> numbers;

        public Gear(string[] lines)
        {
            this.lines = lines;
            this.numbers = new List<int>();
            GetStar();
            GetAdjacentNumber();
        }

        public int Value
        {
            get
            {
                return numbers.Count == 2 ? numbers[0] * numbers[1] : 0;
            }
        }

        public int StarIndex { get; private set; }

        private void GetAdjacentNumber()
        {
            foreach (var line in lines)
            {
                var matchNumber = new Regex("\\d+");
                var matches = matchNumber.Matches(line).ToList();
                foreach (var match in matches)
                {
                    if (match.Success
                        &&
                        (
                            (StarIndex - 1 <= match.Index && match.Index <= StarIndex + 1)
                            ||
                            (StarIndex - 1 <= match.Index + match.Length - 1 && match.Index + match.Length - 1 <= StarIndex + 1)
                        ))
                    {
                        numbers.Add(Int32.Parse(match.Value));
                    }
                }
            }
        }

        private void GetStar()
        {
            var matchStar = new Regex("[*]");
            var middleLine = lines[1];
            var matchedStar = matchStar.Match(middleLine);
            this.StarIndex = matchedStar.Index;
        }
    }
}