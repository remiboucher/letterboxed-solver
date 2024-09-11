using LetterboxedSolver.Initial;

public class WordTreeTests
{
    private readonly WordTree _wordTree;

    public WordTreeTests()
    {
        _wordTree = new WordTree();
    }

    [Fact]
    public void TestName()
    {
        // Given
        var words = File.ReadAllLines("test_words.txt");

        foreach (var word in words)
        {
            _wordTree.Add(word);
        }
    
        foreach (var word in words)
        {
            (bool wordExists, bool canContinue) = _wordTree.Check(word);
            Assert.True(wordExists);
            
            if (word == "ask")
            {
                Assert.True(canContinue);
            }
            else
            {
                Assert.False(canContinue);
            }
        }

        Assert.False(_wordTree.Check("asky").wordExists);
        Assert.False(_wordTree.Check("askedy").wordExists);
    }
}