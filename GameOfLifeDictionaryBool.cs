public class GameOfLifeDictionaryBool : IGameOfLife<bool>
{
    private Dictionary<(long, long), bool> _liveCells;
    private Dictionary<(long, long), bool> _nextGen;
    private HashSet<(long, long)> _processedCells;
    private IGameOfLifeRuleSet<bool> _ruleSet;

    public GameOfLifeDictionaryBool() {
        _liveCells = new Dictionary<(long, long), bool>();
        _nextGen = new Dictionary<(long, long), bool>();
        _processedCells = new HashSet<(long, long)>();
        _ruleSet = new ClassicRuleSet();
    }

    public void SetCellState(long row, long column, bool cellState) 
    {
        _liveCells[(row, column)] = cellState;
    }

    public bool GetCellState(long row, long column)
    {
        return _liveCells.ContainsKey((row, column)) ? true : false;
    }


    public void nextGeneration()
    {
        // First ensure that our _nextGen and _processedCells are cleared out
        _nextGen.Clear();
        _processedCells.Clear();
        
        // When processing next generation we need to go over the list of live cells
        foreach (var (key, value) in _liveCells) {
            
            // Get all neighbors and apply rules
            var neighbors = GetNeighbors(key.Item1, key.Item2);
            ApplyRule(key.Item1, key.Item2, value, neighbors);

            foreach (var (neighborKey, neighborValue) in neighbors) {
                // We need to only apply rules to neighbors of live cells we haven't processed yet
                if (!neighborValue && !_processedCells.Contains(neighborKey)) {
                    ApplyRule(neighborKey.Item1, neighborKey.Item2, neighborValue, GetNeighbors(neighborKey.Item1, neighborKey.Item2));
                    _processedCells.Add((neighborKey.Item1, neighborKey.Item2));
                }
            }
        }
        
        _liveCells = new Dictionary<(long, long), bool>(_nextGen);
    }

    public void print(long minX, long maxX, long minY, long maxY) {
        string gridString = "";

        gridString += "   ";
        for (long x = minX; x <= maxX; x++)
        {
            gridString += $"{x,3}";
        }
        gridString += "\n";

        for (long y = minY; y <= maxY; y++)
        {
            gridString += $"{y,3}";
            for (long x = minX; x <= maxX; x++)
            {
                if (_liveCells.ContainsKey((x, y)))
                {
                    gridString += " O ";
                }
                else
                {
                    gridString += " . ";
                }
            }
            gridString += "\n";
        }

        Console.WriteLine(gridString);
    }

    public Dictionary<(long, long), bool> GetLiveCells() 
    {
        return _liveCells;
    }

    private Dictionary<(long, long), bool> GetNeighbors(long row, long column)
    {
        var neighbors = new Dictionary<(long, long), bool>();

        // TODO: This logic doesn't work at edges of board
        for (var i = -1; i <= 1; i++)
        {
            for (var j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0)
                {
                    continue;
                }
                var neighborRow = GetWrapAroundCoordinate(row, i);
                var neighborColumn = GetWrapAroundCoordinate(column, j);

                neighbors[(neighborRow, neighborColumn)] = GetCellState(neighborRow, neighborColumn);
            }
        }

        return neighbors;
    }

    private void ApplyRule(long row, long column, bool cell, Dictionary<(long, long), bool> neighbors)
    {
        if (_ruleSet.ApplyRule(cell, neighbors)) {
            _nextGen[(row, column)] = true;
        }
    }

    private long GetWrapAroundCoordinate(long coord, int displacement) {

        if (coord == long.MaxValue && displacement == 1) {
            return long.MinValue;
        } else if (coord == long.MinValue && displacement == -1) {
            return long.MaxValue;
        } else {
            return coord + displacement;
        }     
    }
}
