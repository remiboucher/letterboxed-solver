namespace LetterboxedSolver.Initial;

public class WordTree
{
    private class Node
    {
        public Node(char value)
        {
            Value = value;
        }

        public char Value { get; set; }
        public Dictionary<char, Node>? Children { get; set; }
        public bool CanBeEnding { get; set; } = false;
    }

    private Node _root;

    public WordTree() {
        _root = new Node('?');
    }

    public void Add(string word)
    {
        Add(word, _root);
    }

    private void Add(string substring, Node node)
    {
        if (string.IsNullOrEmpty(substring))
        {
            node.CanBeEnding = true;
            return;
        }

        char firstChar = substring[0];

        if (node.Children == null)
        {
            node.Children = new Dictionary<char, Node>() { { firstChar, new Node(firstChar) } };
            Add(substring.Substring(1), node.Children[firstChar]);
        }
        else
        {
            Node? child;

            if (!node.Children.TryGetValue(firstChar, out child))
            {
                node.Children.Add(firstChar, new Node(firstChar));
                Add(substring.Substring(1), node.Children[firstChar]);
            }
            else
            {
                Add(substring.Substring(1), child);
            }
        }
    }

    public (bool wordExists, bool canContinue) Check(string word)
    {
        return Check(word, _root);
    }

    private (bool wordExists, bool canContinue) Check(string substring, Node node)
    {
        if (string.IsNullOrEmpty(substring)) return (node.CanBeEnding, node.Children != null);
        if (node.Children == null) return (false, false);

        char firstChar = substring[0];

        Node? child;

        if (node.Children.TryGetValue(firstChar, out child))
        {
            return Check(substring.Substring(1), child);
        }

        return (false, false);
    }
}