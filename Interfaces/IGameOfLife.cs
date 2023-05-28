// Define a generic game of life such that cell type is T (generic. bool or int or char?)
public interface IGameOfLife<T> {
    // Sets the state of a specific cell to some initial value
    void SetCellState(long row, long column, T cellState); 
    
    // Returns the state of a cell
    T GetCellState(long row, long column); 

    // Main function in game of life. This calculates the next generation
    void nextGeneration();

    void print();

    Dictionary<(long, long), T> GetLiveCells();
}
