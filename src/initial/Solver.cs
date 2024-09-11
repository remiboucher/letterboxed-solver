namespace LetterboxedSolver.Initial;

public class Solver : ISolver 
{
    private readonly WordChecker _checker;
    private readonly HashSet<string> firstWordCandidates = new();

    public Solver(WordChecker checker)
    {
        _checker = checker;
    }

    public IEnumerable<(string firstWord, string secondWord)> Solve(string[] sides)
    {
        List<(string, string)> result = new();

        string allLetters = "";

        for (int i = 0; i < 4; i++)
        {
            allLetters += sides[i];

            for (int j = 0; j < 3; j++)
            {
                FindWords(sides[i][j].ToString(), i, sides);
            }
        }

        foreach (var firstWord in firstWordCandidates)
        {
            HashSet<char> firstRemainingLetters = new(allLetters);

            foreach (char c in firstWord)
            {
                firstRemainingLetters.Remove(c);
            }

            foreach (var secondWord in firstWordCandidates)
            {
                if (secondWord[0] != firstWord[^1]) continue;

                HashSet<char> secondRemainingLetters = new(firstRemainingLetters);
                
                foreach (char c2 in secondWord)
                {
                    secondRemainingLetters.Remove(c2);

                    if (secondRemainingLetters.Count == 0) result.Add((firstWord, secondWord));
                }
            }
        }

        return result;
    }

    private void FindWords(string soFar, int currentSideIndex, string[] sides)
    {
        for (int i = 1; i < 4; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int nextSide = (currentSideIndex + i) % 4;
                string word = soFar + sides[nextSide][j];
                (bool wordExists, bool canContinue) = _checker.Check(word);

                if (wordExists)
                {
                    firstWordCandidates.Add(word);
                }

                if (canContinue) FindWords(word, nextSide, sides);
            }
        }
    }
}