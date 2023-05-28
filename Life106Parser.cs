using System;
using System.Collections.Generic;
using System.IO;

class Life106Parser
{
    public static List<(long, long)> ParseFile(string filePath)
    {
        List<(long, long)> coordinates = new List<(long, long)>();

        string[] lines = File.ReadAllLines(filePath);

        // Check that the file has contents
        if (lines.Length < 0) {
            Console.WriteLine("Empty file provided");
            return coordinates;
        }

        // Check if the file starts with the correct header
        if (!lines[0].Equals("#Life 1.06", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Invalid file format. Expected Life 1.06 format.");
            // Potentially throw an error here?
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
}
