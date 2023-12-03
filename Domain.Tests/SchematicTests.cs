namespace Domain.Tests
{
    [TestClass]
    public class SchematicTests
    {
        [TestMethod]
        public void MapNumber()
        {
            var lines = new string[]
            {
                "....",
                ".12.",
                "#...",
            };

            var number = new SchematicNumber(lines);
            Assert.AreEqual(12, number.Value);
            Assert.IsTrue(number.HasConnectingSymbol);
        }

        [TestMethod]
        public void GetSumForSampleInput()
        {
            var input = File.ReadAllText("sampleinput.txt");

            var schematic = new Schematic(input);

            Assert.AreEqual(4361, schematic.GetSum());
        }

        [TestMethod]
        public void GetSumForSampleInput2()
        {
            var input = File.ReadAllText("sampleinput2.txt");

            var schematic = new Schematic(input);

            Assert.AreEqual(0, schematic.GetSum());
        }
    }
}