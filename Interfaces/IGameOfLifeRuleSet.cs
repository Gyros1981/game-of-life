public interface IGameOfLifeRuleSet<T> {
    T ApplyRule(T cell, Dictionary<(long, long), T> neighbors);
}