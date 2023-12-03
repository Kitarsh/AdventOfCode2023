using System.Text;
using System.Text.RegularExpressions;

namespace Domain
{
    public class Schematic
    {
        private string input;
        private string[] lines;
        private List<SchematicNumber> schematicsNumber;

        public Schematic(string input)
        {
            this.input = input;
            this.schematicsNumber = new List<SchematicNumber>();
            AddDotsOnExternal();

            this.lines = this.input.Split("\r\n");
            CreateSchematics();
        }

        public int GetSum()
        {
            return this.schematicsNumber.Where(sn => sn.HasConnectingSymbol).Sum(sn => sn.Value);
        }

        private void CreateSchematics()
        {
            for (var i = 1; i < lines.Length - 1; i++)
            {
                CreateSchematicsForLine(i);
            }
        }

        private void CreateSchematicsForLine(int i)
        {
            var matchNumber = new Regex("\\d+");
            var numberMatches = matchNumber.Matches(lines[i]).ToList();
            var upperLine = lines[i - 1];
            var line = lines[i];
            var lowerLine = lines[i + 1];
            foreach (var numberMatch in numberMatches)
            {
                CreateSchematicNumber(upperLine, line, lowerLine, numberMatch);
            }
        }

        private void CreateSchematicNumber(string upperLine, string line, string lowerLine, Match? numberMatch)
        {
            var numberUpperLine = new string(upperLine.Skip(numberMatch.Index - 1).ToArray());
            var numberLine = new string(line.Skip(numberMatch.Index - 1).ToArray());
            var numberLowerLine = new string(lowerLine.Skip(numberMatch.Index - 1).ToArray());
            this.schematicsNumber.Add(new SchematicNumber(new string[] { numberUpperLine, numberLine, numberLowerLine }));
        }

        private void AddDotsOnExternal()
        {
            this.input = "." + this.input.Replace("\r\n", ".\r\n.") + ".";
            var lineSize = this.input.Split("\r\n")[0].Length;
            var dotLineBuilder = new StringBuilder();
            for (int i = 0; i < lineSize; i++)
            {
                dotLineBuilder.Append('.');
            }
            dotLineBuilder.Append("\r\n");
            var dotLine = dotLineBuilder.ToString();
            this.input = dotLine + this.input + dotLine;
        }
    }
}