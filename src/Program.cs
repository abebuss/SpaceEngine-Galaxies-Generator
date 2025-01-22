using System;
using System.Globalization;
using System.IO;

public class Galaxy
{
    public string[] hubbleType = { "E0", "E1", "E2", "E3", "E4", "E5", "E6", "E7", "S0",
    "Sa", "Sb", "Sc", "Sd", "SBa", "SBb", "SBc", "SBd", "Irr"};

    public int galaxiesCount;
    public string galaxiesName;
    public double initialDistance;
    public string filepath;

    public double distanceIncrement;
    public double currentDistance;

    public Galaxy(int galaxiesCount, double initDistance, string filepath, string galaxiesName)
    {
        this.galaxiesCount = galaxiesCount;
        this.initialDistance = initDistance;
        this.filepath = filepath;
        this.galaxiesName = galaxiesName;
    }

    public void Generate()
    {
        Random random = new Random();
        currentDistance = initialDistance;

        distanceIncrement = initialDistance / galaxiesCount;

        using (StreamWriter writer = new StreamWriter(filepath))
        {
            writer.WriteLine("Name,Type,RA,Dec,Dist,AbsMagn,Radius,Quat.w,Quat.x,Quat.y,Quat.z");

            for (int i = 1; i <= galaxiesCount; i++)
            {
                double RA = random.NextDouble() * 360;
                double Dec = random.NextDouble() * 180 - 90;
                double randomChange = random.NextDouble() * distanceIncrement;
                currentDistance += randomChange;

                string hubbleClass = hubbleType[random.Next(hubbleType.Length)];
                int radius = random.Next(1000, 12000);
                float absMagn = (float)(random.Next(-22, -10) + random.NextDouble());
                string quaternion = $"{random.NextDouble()} {random.NextDouble()} {random.NextDouble()} {random.NextDouble()}";

                var quatComponents = quaternion.Split(' ');

                string galaxyEntry = $"{galaxiesName}-{i},{hubbleClass},{RA.ToString("F8", CultureInfo.InvariantCulture)},{Dec.ToString("F8", CultureInfo.InvariantCulture)},{currentDistance.ToString("E", CultureInfo.InvariantCulture)},{absMagn.ToString("F2", CultureInfo.InvariantCulture)},{radius},{quatComponents[0]},{quatComponents[1]},{quatComponents[2]},{quatComponents[3]}";

                writer.WriteLine(galaxyEntry);
                Console.WriteLine($"{galaxiesName}-{i}");
            }
        }
    }

}

public class Init
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Welcome to the Galaxy Catalog Generator!");
        Console.ResetColor();

        Console.WriteLine("\nPlease follow the prompts to set everything up.");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Enter the name for your catalog (e.g., SEVDSOG): ");
        Console.ResetColor();
        string galaxiesName = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Enter the initial distance from the sun (in parsecs): ");
        Console.ResetColor();
        double initDistance = Convert.ToDouble(Console.ReadLine());

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Enter the number of galaxies you want to create: ");
        Console.ResetColor();
        int galaxiesCount = Convert.ToInt32(Console.ReadLine());

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Enter the file path for the galaxy catalog (e.g., yourpath\\SpaceEngine\\addons\\catalogs\\galaxies\\yourfile.csv): ");
        Console.ResetColor();
        string filepath = Console.ReadLine();

        Galaxy galaxyGenerator = new Galaxy(galaxiesCount, initDistance, filepath, galaxiesName);
        galaxyGenerator.Generate();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nFile has been successfully generated at: " + filepath);
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Thank you for using the Galaxy Catalog Generator! Press any key to exit.");
        Console.ResetColor();
        Console.ReadKey();
    }
}

