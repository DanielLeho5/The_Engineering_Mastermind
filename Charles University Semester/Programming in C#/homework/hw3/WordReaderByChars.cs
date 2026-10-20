public class ParagraphLineReader
{
    private readonly StreamReader reader;

    public ParagraphLineReader(string fileName)
    {
        reader = new StreamReader(fileName);
    }

    public string? ReadLine()
    {
        return reader.ReadLine();
    }

    public void Close()
    {
        reader.Close();
    }
}