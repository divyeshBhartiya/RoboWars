namespace RoboWar.Test
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void TestScanrio_Valid()
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
        public void TestScanrio_Invalid()
        {
            var positonalParams = new string[] { };
            var envDimensions = new string[] { };
            var commands = string.Empty;

            Assert.ThrowsException<InvalidDataException>(() => Program.Main(new string[] { }));
        }
    }
}

