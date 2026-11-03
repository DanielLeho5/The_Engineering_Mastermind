class ParagraphWordCounter : TokenProcessor
{ 
    public ParagraphWordCounter(TokenReader tokenReader): base(tokenReader) {}

    public void CountWords()
    {
        int count = 0;
        int newLineCount = 0;

        while (tokenReader.ReadToken() is Token token)
        {
            //System.Console.WriteLine(token.Type);
            if (token.Type == Token.TokenType.Word) 
            {
                newLineCount = 0;
                count++;
            }
            else if (token.Type == Token.TokenType.Newline)
            {
                newLineCount++;
                if (newLineCount >= 2)
                {
                    newLineCount = 0;
                    if (count > 0)
                    {          
                        System.Console.WriteLine(count);
                    }
                    count = 0;
                }
            }
        }
        if (count > 0)
        {          
            System.Console.WriteLine(count);
        }
    }
}