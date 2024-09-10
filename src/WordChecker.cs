namespace LetterboxedSolver;

public class WordChecker
{
    private readonly WordTree _wordTree;
    public WordChecker(string wordFilePath)
    {
        _wordTree = new();

        using (FileStream fs = new(wordFilePath, FileMode.Open))
        using (StreamReader sr = new(fs))
        {
            var word = sr.ReadLine();
            while (word != null)
            {
                _wordTree.Add(word);
                word = sr.ReadLine();
            }
        }
    }

    public (bool exists, bool canContinue) Check(string word)
    {
        return _wordTree.Check(word);
    }
}