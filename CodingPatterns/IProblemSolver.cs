namespace CodingPatterns
{
    public interface IProblemSolverBase
    {
        string Key { get; }
    }

    public interface IProblemSolver<TInput, TOutput> : IProblemSolverBase
    {
        TOutput Solve(TInput input);
    }

}
