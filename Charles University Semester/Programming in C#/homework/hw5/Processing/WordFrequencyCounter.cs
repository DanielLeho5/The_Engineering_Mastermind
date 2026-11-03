class WordFrequencyCounter : TokenProcessor
{
    
    public WordFrequencyCounter(TokenReader tokenReader): base(tokenReader) {}

    public void CountWords()
    {
        SortedDictionary<string, int> words = [];

        while (tokenReader.ReadToken() is Token token)
        {
            if (token.Type == Token.TokenType.Word) 
            {
                if (words.ContainsKey(token.Word))
                {
                    words[token.Word] = words[token.Word] + 1;
                }
                else
                {
                    words[token.Word] = 1;
                }
            };
        }

        foreach (KeyValuePair<string, int> kvp in words)
        {
            System.Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
}