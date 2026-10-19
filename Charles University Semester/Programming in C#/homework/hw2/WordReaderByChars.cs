public class WordReaderByChars(string fileName)
{
    private StreamReader reader = new StreamReader(fileName);
    // the reader remains between function calls, as long as the instance of this object exists

    public string? GetNextWord()
    {
        string word = "";
        int value = reader.Read();

        // when there are more characters to read (StreamReader.Read() doesn't return -1)
        // and when the read character is a whitespace
        while (value != -1 && IsWhitespace(value)) 
        { 
            // we just simply read the next character (so skipping the whitespaces at the beginning)
            value = reader.Read();
        }
        
        // StremReader.Read() returns -1 if there are no more characters to read from the file
        if (value == -1)
        {
            // we return null to indicate that there are no more words in the file
            return null;
        }

        // when there are more characters to read (StreamReader.Read() doesn't return -1)
        // and when the read character is NOT a whitespace
        while (value != -1 && !IsWhitespace(value))
        {
            word += (char)value; // we concat the word with our current character
            value = reader.Read(); // and move on to the next character
        }

        // we return the word since the second loop has ended
        // meaning it's either a whitespace next
        // or it's the end of the file
        return word;
    }

    private static bool IsWhitespace(int value)
    {
        return value == ' ' || value == '\t' ||
            value == '\n' || value == '\r';
    }

    public void Close()
    {
        reader.Close();
    }
}