class Program
{
    private const string FILE_OUTPUT = "output.life";
    private const int NUM_GENERATOINS = 10;

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

        // Add all live cells to our implementation
        foreach (var coordinate in coordinates)
        {
            game.SetCellState(coordinate.Item1, coordinate.Item2, true);
        }

        // Run 10 generations
        for (var i = 0; i < NUM_GENERATOINS; i++) {
            game.nextGeneration();
            game.print(-20, 10, -20, 10);
        }

        // Export the current state to a file
        WriteToFile(game.GetLiveCells());
    }

    static void WriteToFile(Dictionary<(long, long), bool> liveCells) {
        using (StreamWriter writer = new StreamWriter(FILE_OUTPUT))
        {
            writer.WriteLine(Life106Parser.LIFE_106_HEADER);
            // Write the coordinates to the file
            foreach (var (coordinate, value) in liveCells)
            {
                writer.WriteLine($"{coordinate.Item1} {coordinate.Item2}");
            }
        }
    }
}
