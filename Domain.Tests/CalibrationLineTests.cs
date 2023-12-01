namespace Domain.Tests
{
    [TestClass]
    public class CalibrationTests
    {
        [TestMethod]
        [DataRow("1abc2", 12)]
        [DataRow("aaaaoneaaaaa2", 12)]
        [DataRow("eight99fhstbssrplmdlnonecmmqqnklb39nineoneightjz", 88)]
        public void GetFirstAndLastDigit(string input, int expectedResult)
        {
            var line = new CalibrationLine(input);
            int lineNumber = line.GetNumber();

            Assert.AreEqual(expectedResult, lineNumber);
        }

        [TestMethod]
        public void ComputeLinesOfFileStep1()
        {
            var inputFile = "SampleTest.txt";
            var expectedResult = 142;

            var calibration = new Calibration(inputFile);
            int result = calibration.GetTotal();

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ComputeLinesOfFileStep2()
        {
            var inputFile = "SecondSampleText.txt";
            var expectedResult = 281;

            var calibration = new Calibration(inputFile);
            int result = calibration.GetTotal();

            Assert.AreEqual(expectedResult, result);
        }
    }
}