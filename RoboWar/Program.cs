using System.IO.Pipes;
using RoboWar;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, Robo Warrior!!!");
        var envDimensions = Console.ReadLine()?.Trim().Split(' ').Select(int.Parse).ToArray();
        var positonalParams = Console.ReadLine()?.Trim().Split(' ');
        var commands = Console.ReadLine() ?? String.Empty;


        if ((envDimensions is null || !envDimensions.Any())
            || (positonalParams is null || !positonalParams.Any())
            || commands == String.Empty)
        {
            throw new InvalidDataException("Invalid information provided.");
        }

        try
        {
            var location = new Location(positonalParams);
            Console.WriteLine(location.FollowCommands(envDimensions, commands.ToUpper()));
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }

        Console.ReadLine();
    }
}
