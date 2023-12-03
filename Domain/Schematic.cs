using System.Text;
using System.Text.RegularExpressions;

namespace Domain
{
    public class Schematic
    {
        private string input;
        private string[] lines;
        private List<SchematicNumber> schematicsNumber;
        private List<Gear> schematicGears;

        public Schematic(string input)
        {
            this.input = input;
            this.schematicsNumber = new List<SchematicNumber>();
            this.schematicGears = new List<Gear>();
            AddDotsOnExternal();

            this.lines = this.input.Split("\r\n");
            CreateSchematics();
        }

        public int GetSum()
        {
            return this.schematicsNumber.Where(sn => sn.HasConnectingSymbol).Sum(sn => sn.Value);
        }

        public int GetGearSum()
            => schematicGears.Sum(sg => sg.Value);

        private void CreateSchematics()
        {
            for (var i = 1; i < lines.Length - 1; i++)
            {
                CreateSchematicsForLine(i);
                CreateGearForLine(i);
            }
        }

        private void CreateGearForLine(int i)
        {
            var matchNumber = new Regex("[*]");
            var starMatches = matchNumber.Matches(lines[i]).ToList();
            var upperLine = lines[i - 1];
            var line = lines[i];
            var lowerLine = lines[i + 1];
            foreach (var starMatch in starMatches)
            {
                CreateGear(upperLine, line, lowerLine, starMatch);
            }
        }

        private void CreateGear(string upperLine, string line, string lowerLine, Match starMatch)
        {
            var numberUpperLine = new string(upperLine.Skip(starMatch.Index - 3).Take(7).ToArray());
            var numberLine = new string(line.Skip(starMatch.Index - 3).Take(7).ToArray());
            var numberLowerLine = new string(lowerLine.Skip(starMatch.Index - 3).Take(7).ToArray());
            this.schematicGears.Add(new Gear(new string[] { numberUpperLine, numberLine, numberLowerLine }));
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