
using System.Text;


public class TokenReader
{
    private readonly TextReader reader;

    public TokenReader(TextReader reader)
    {
        this.reader = reader ?? throw new ArgumentNullException("Reader must not be null!");
    }

    private bool IsWhiteSpace(char character)
    {
        if (character == ' ' || character == '\n' || character == '\t' || character == '\r')
        {
            return true;
        }
        return false;
    }

    public Token? ReadToken()
    {
        while (reader.Peek() == ' ')
        {
            reader.Read();
        }

        int next = reader.Peek();

        if (next == -1)
        {
            return null;
        }

        switch (next)
        {
            case '\n':
                reader.Read();
                return new Token(Token.TokenType.Newline);
            
            case '\t':
                reader.Read();
                return new Token(Token.TokenType.Tab);

            case '\r':
                reader.Read();
                return new Token(Token.TokenType.CarriageReturn);
        }

        var word = new StringBuilder();

        while (reader.Peek() != -1)
        {
            char character = (char)reader.Peek();

            if (IsWhiteSpace(character))
            {
                break;
            }

            word.Append((char)reader.Read());
        }

        return new Token(Token.TokenType.Word, word: word.ToString());
    }
}
