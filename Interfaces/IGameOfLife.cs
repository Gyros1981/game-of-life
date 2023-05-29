// Define a generic game of life such that cell type is T (generic. bool or int or char for example)
public interface IGameOfLife<T> {
    // Sets the state of a specific cell to some initial value
    void SetCellState(long row, long column, T cellState); 
    
    // Returns the state of a cell
    T GetCellState(long row, long column); 

    // Given all living cells calculates the next generation for a specific board state
    void nextGeneration();

    // Prints a subsection of the entire board to console
    void print(long minX, long maxX, long minY, long maxY);

    // Returns a dictionary of live cells (from coordinates to T)
    Dictionary<(long, long), T> GetLiveCells();
}
