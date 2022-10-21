namespace RoboWar.Test;

[TestClass]
public class RoboWarTest
{
    [TestMethod]
    public void TestScanrio_12N_LMLMLMLMM()
    {
        var positonalParams = "1 2 N".Split(' ');
        var envDimensions = "5 5".Split(' ').Select(int.Parse).ToArray();
        var commands = "LMLMLMLMM";
        var location = new Location(positonalParams);
        
        var actualOutput = location.FollowCommands(envDimensions, commands.ToUpper()); ;
        var expectedOutput = "1 3 N";

        Assert.AreEqual(expectedOutput, actualOutput);
    }

    [TestMethod]
    public void TestScanrio_33E_MRRMMRMRRM()
    {
        var positonalParams = "3 3 E".Split(' ');
        var envDimensions = "5 5".Split(' ').Select(int.Parse).ToArray();
        var commands = "MMRMMRMRRM";
        var location = new Location(positonalParams);

        var actualOutput = location.FollowCommands(envDimensions, commands.ToUpper()); ;
        var expectedOutput = "5 1 E";

        Assert.AreEqual(expectedOutput, actualOutput);
    }

    [TestMethod]
    public void TestScanrio_InvalidDataException()
    {
        var positonalParams = new string[] { };
        Assert.ThrowsException<InvalidDataException>(() => new Location(positonalParams));
    }
}
