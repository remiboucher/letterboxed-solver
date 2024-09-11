interface ISolver
{
    IEnumerable<(string firstWord, string secondWord)> Solve(string[] sides);
}

interface IWordChecker
{
    (bool exists, bool canContinue) Check(string word);
}