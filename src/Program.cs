using BenchmarkDotNet.Running;
using LetterboxedSolver.Benchmarks;

namespace LetterboxedSolver;

class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<InitialBenchmark>();
    }
}