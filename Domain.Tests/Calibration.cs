namespace Domain.Tests;

public class Calibration
{
    private string inputFile;

    public Calibration(string inputFile)
    {
        this.inputFile = inputFile;
    }

    public int GetTotal()
    {
        var lines = File.ReadAllLines(inputFile);

        var calibrationLines = lines.Select(l => new CalibrationLine(l));
        var total = calibrationLines.Select(cl => cl.GetNumber()).Sum();
        return total;
    }
}