// This class parses an input file of the #Life 1.06 style
class Life106Parser
{
    public const string LIFE_106_HEADER = "#Life 1.06";
    public static List<(long, long)> ParseFile(string filePath)
    {
        List<(long, long)> coordinates = new List<(long, long)>();

        string[] lines = validateFileAndContents(filePath);
        if (lines.Length <= 0) {
            return coordinates;
        }

        for (var i = 1; i < lines.Length; i++)
        {
            var line = lines[i];
            
            string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
            {
                Console.WriteLine($"Invalid line: {line}");
                continue;
            }

            if (long.TryParse(parts[0], out long x) && long.TryParse(parts[1], out long y))
            {
                coordinates.Add((x, y));
            }
            else
            {
                Console.WriteLine($"Invalid coordinates: {line}");
            }
        }

        return coordinates;
    }

    private static string[] validateFileAndContents(string filePath) {
        if (!File.Exists(filePath)) {
            Console.WriteLine($"File not found {filePath}");
            return new string[0];
        }

        string[] lines = File.ReadAllLines(filePath);
    
        // Check that the file has contents
        if (lines.Length < 0) {
            Console.WriteLine("Empty file provided");
            return new string[0];
        }

        // Check if the file starts with the correct header
        if (!lines[0].Equals(LIFE_106_HEADER, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Invalid file format. Expected Life 1.06 format.");
            return new string[0];
        }
        return lines;
    }
}
