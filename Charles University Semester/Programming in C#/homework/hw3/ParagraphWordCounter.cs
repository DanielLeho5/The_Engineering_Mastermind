public class ParagraphWordCounter
{
    public List<int> CountWords(string fileName)
    {
        List<int> paragraphCounts = [];
        var lineReader = new ParagraphLineReader(fileName);
        int currentParagraphCount = 0;

        try
        {
            string? line;

            while ((line = lineReader.ReadLine()) != null)
            {
                int wordsOnCurrentLine = line.Split([' ', '\t'], StringSplitOptions.RemoveEmptyEntries).Length;

                if (wordsOnCurrentLine == 0)
                {
                    if (currentParagraphCount > 0)
                    {
                        paragraphCounts.Add(currentParagraphCount);
                        currentParagraphCount = 0;
                    }
                }
                else
                {
                    currentParagraphCount += wordsOnCurrentLine;
                }
            }

            if (currentParagraphCount > 0)
                paragraphCounts.Add(currentParagraphCount);
        }
        finally
        {
            lineReader.Close();
        }

        return paragraphCounts;
    }

}