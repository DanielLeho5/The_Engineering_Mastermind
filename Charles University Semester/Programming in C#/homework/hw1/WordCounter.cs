public class WordCounter
{
    public int CountWords(string fileName)
    {
        int wordCount = 0;
        WordReaderByChars wordReader = new WordReaderByChars(fileName);

        try
        {
            string? word = wordReader.GetNextWord();

            while (word != null)
            {
                wordCount++;
                word = wordReader.GetNextWord();
            }
        }
        finally
        {
            wordReader.Close();
        }

        return wordCount;
    }
}