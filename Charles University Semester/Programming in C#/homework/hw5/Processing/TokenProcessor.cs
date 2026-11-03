public abstract class TokenProcessor
{
    protected readonly TokenReader tokenReader;

    protected TokenProcessor(TokenReader tokenReader)
    {
        this.tokenReader = tokenReader ?? throw new ArgumentNullException("Token reader must not be null!");
    }
}