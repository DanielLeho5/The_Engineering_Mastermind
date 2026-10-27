public class WordFrequencyCounter : IWordCounter
{
    public SortedDictionary<string, int> CountWords(string fileName)
    {
        SortedDictionary<string, int> words = new SortedDictionary<string, int>();
        WordReaderByChars wordReader = new WordReaderByChars(fileName);

        try
        {
            string? word = wordReader.GetNextWord();

            while (word != null)
            {
                AddWord(words, word);
                word = wordReader.GetNextWord();
            }
        }
        finally
        {
            wordReader.Close();
        }

        return words;
    }

    private void AddWord(SortedDictionary<string, int> words, string word)
    {
        if (words.ContainsKey(word))
        {
            words[word]++;
            return;
        }

        words[word] = 1;
    }
}