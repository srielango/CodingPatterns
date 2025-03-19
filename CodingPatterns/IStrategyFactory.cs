namespace CodingPatterns
{
    public interface IStrategyFactory
    {
        IProblemSolver<TInput, TOutput> GetStrategy<TInput, TOutput>(string key);
    }
}
