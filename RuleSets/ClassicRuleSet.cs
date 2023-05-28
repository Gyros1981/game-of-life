public class ClassicRuleSet : IGameOfLifeRuleSet<bool>
{
    public bool ApplyRule(bool cell, Dictionary<(long, long), bool> neighbors)
    {
        // Count Live neighbors
        int count = 0;
        foreach (var neighbor in neighbors) {
            if (neighbor.Value) {
                count++;
            }
        }
        if (cell && count >=2 && count <=3 ) {
            return true;
        }

        if (!cell && count == 3) {
            return true;
        }

        return false;
    }
}