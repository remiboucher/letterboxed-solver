# letterboxed-solver

A solver for the [NYT game Letter Boxed](https://www.nytimes.com/puzzles/letter-boxed) for educational purposes. Will contain a few experiments and benchmarks to test performance improvements.

Word list from https://www.mit.edu/~ecprice/wordlist.100000

# Performance experiments

I'm using the excellent [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet) to measure performance.

## Initial implementation

| Method                     | Mean      | Error     | StdDev    |
|--------------------------- |----------:|----------:|----------:|
| InitialWithWordCheckerLoad | 918.64 ms | 12.737 ms | 11.914 ms |
| InitialOnlySolver          |  59.26 ms |  0.450 ms |  0.399 ms |