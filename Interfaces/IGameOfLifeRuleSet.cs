// Simple interface for game of life rule set
public interface IGameOfLifeRuleSet<T> {
    
    // Given a value of a cell and a dictionary of all neighbors and their values, returns what the new value of the cell shoudld be
    T ApplyRule(T cell, Dictionary<(long, long), T> neighbors);
}