public readonly struct Token
{
    public enum TokenType
    {
        Word, Newline, Tab, CarriageReturn
    }
    public TokenType Type { get; }
    public string? Word { get; }

    public Token(TokenType type, string? word = null)
    {
        if (type == TokenType.Word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                throw new ArgumentException("A word token must contain a valid non-null string!");
            }
                
        }
        else if (word != null)
        {
            throw new ArgumentException("Only word-type tokens can contain text!");
        }

        Type = type;
        Word = word;
    }
}