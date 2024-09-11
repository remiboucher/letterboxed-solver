using BenchmarkDotNet.Attributes;
using LetterboxedSolver.Initial;

namespace LetterboxedSolver.Benchmarks;

public class InitialBenchmark
{
    private readonly WordChecker _checker;
    private readonly string[] _sides = ["bpa", "ftr", "ecm", "lyn"];

    public InitialBenchmark()
    {
        _checker = new("words_alpha.txt");
    }

    [Benchmark]
    public void InitialWithWordCheckerLoad()
    {
        WordChecker checker = new("words_alpha.txt");
        ISolver solver = new Solver(checker);
        solver.Solve(_sides);
    }

    [Benchmark]
    public void InitialOnlySolver()
    {
        ISolver solver = new Solver(_checker);
        solver.Solve(_sides);
    }
}