using System.Diagnostics;

namespace LetterboxedSolver;

class Program
{
    static void Main(string[] args)
    {
        Stopwatch sw = Stopwatch.StartNew();
        WordChecker checker = new("res/words_alpha.txt");
        Solver solver = new(checker);

        Console.WriteLine($"Will try to solve {string.Join(' ', args)}...");

        var answer = solver.Solve(args);
        sw.Stop();
        var elapsed = sw.ElapsedMilliseconds;

        if (answer.Count() > 0)
        {
            foreach (var result in answer)
            {
                Console.WriteLine($"{result.firstWord} - {result.secondWord}");
            }
        }
        else
        {
            Console.WriteLine("Could not find a two-word answer for this puzzle");
        }
        
        Console.WriteLine($"Execution time: {elapsed} ms.");
    }
}