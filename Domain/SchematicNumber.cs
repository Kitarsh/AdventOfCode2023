using System.Text.RegularExpressions;

namespace Domain
{
    public class SchematicNumber
    {
        private string[] lines;

        public SchematicNumber(string[] lines)
        {
            this.lines = lines;
            GetValue();
            var matchSymbols = new Regex("[^\\d.\\s]");
            var startingIndex = Position - 1;
            var endIndex = Position + ValueLength + 1;

            foreach (var line in lines)
            {
                var subline = new string(line.Take(endIndex - startingIndex).ToArray());
                if (matchSymbols.Match(subline).Success)
                {
                    this.HasConnectingSymbol = true;
                }
            }
        }

        public int Value { get; private set; }
        public int ValueLength { get; private set; }
        public int Position { get; private set; }
        public bool HasConnectingSymbol { get; private set; }

        private void GetValue()
        {
            var matchNumber = new Regex("\\d+");
            var middleLine = lines[1];
            var matchValue = matchNumber.Match(middleLine);
            this.Value = Int32.Parse(matchValue.Value);
            this.ValueLength = Value.ToString().Length;
            this.Position = matchValue.Index;
        }
    }
}