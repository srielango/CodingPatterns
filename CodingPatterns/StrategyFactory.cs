namespace CodingPatterns
{
    public class StrategyFactory : IStrategyFactory
    {
        private readonly Dictionary<string, IProblemSolverBase> _strategies;

        public StrategyFactory(IEnumerable<IProblemSolverBase> strategies)
        {
            _strategies = strategies.ToDictionary(s => s.Key, s => s);
        }

        public IProblemSolver<TInput, TOutput> GetStrategy<TInput, TOutput>(string key)
        {
            if (_strategies.TryGetValue(key, out var strategy))
            {
                return (IProblemSolver<TInput, TOutput>)strategy;
            }

            throw new KeyNotFoundException($"No strategy found with key '{key}'");
        }
    }
}
