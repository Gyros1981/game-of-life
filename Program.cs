class Program
{
    static void Main(string[] args)
    {
        // We are accepting a file to read in coordinates from args
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide a file path as a command-line argument.");
            return;
        }

        string filePath = args[0];
        var coordinates = Life106Parser.ParseFile(filePath);
   
        if (coordinates.Count <= 0) {
            Console.WriteLine("Received bad file or file with no coordinates");
            return;
        }

        // Start our game with dictionary
        IGameOfLife<bool> game = new GameOfLifeDictionaryBool();

        // Process the file contents
        foreach (var coordinate in coordinates)
        {
            game.SetCellState(coordinate.Item1, coordinate.Item2, true);
        }

        for (var i = 0; i < 11; i++) {
            game.nextGeneration();
            game.print();
        }

        WriteToFile(game.GetLiveCells());
    }

    static void WriteToFile(Dictionary<(long, long), bool> liveCells) {
        string filePath = "output.life";
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("#Life 1.06");
            // Write the coordinates to the file
            foreach (var (coordinate, value) in liveCells)
            {
                writer.WriteLine($"{coordinate.Item1} {coordinate.Item2}");
            }
        }
    }
}
