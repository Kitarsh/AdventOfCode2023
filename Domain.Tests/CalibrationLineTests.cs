namespace Domain.Tests
{
    [TestClass]
    public class CalibrationTests
    {
        [TestMethod]
        public void GetFirstAndLastDigit()
        {
            var input = "1abc2";
            var expectedResult = 12;

            var line = new CalibrationLine(input);
            int lineNumber = line.GetNumber();

            Assert.AreEqual(expectedResult, lineNumber);
        }

        [TestMethod]
        public void ComputeLinesOfFile()
        {
            var inputFile = "SampleTest.txt";
            var expectedResult = 142;

            var calibration = new Calibration(inputFile);
            int result = calibration.GetTotal();

            Assert.AreEqual(expectedResult, result);
        }
    }
}