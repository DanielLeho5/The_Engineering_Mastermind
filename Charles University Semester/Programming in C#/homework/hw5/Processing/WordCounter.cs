class WordCounter : TokenProcessor
{
    
    public WordCounter(TokenReader tokenReader): base(tokenReader) {}

    public void CountWords()
    {
        int count = 0;

        while (tokenReader.ReadToken() is Token token)
        {
            if (token.Type == Token.TokenType.Word) 
            {
                count++;
            };
        }

        System.Console.WriteLine(count);
    }
}