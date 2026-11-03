public class TextJustifier : TokenProcessor
{
    public TextJustifier(TokenReader tokenReader): base(tokenReader) {}

    public void JustifyText(TextWriter writer, int maxTextWidth)
    {
        if (maxTextWidth <= 0)
        {
            throw new ArgumentOutOfRangeException("Line width must be a positive whole number.");
        }

        writer.NewLine = "\n";

        List<string> words = [];
        int wordsLength = 0;

        bool inputLineHasWord = false;
        bool paragraphHasWords = false;
        bool paragraphBreakPending = false;

        while (tokenReader.ReadToken() is Token token)
        {
            if (token.Type == Token.TokenType.Word)
            {
                string word = token.Word!;

                if (paragraphBreakPending)
                {
                    writer.WriteLine();
                    paragraphBreakPending = false;
                }

                int requiredWidth = wordsLength + words.Count + word.Length;

                if (words.Count > 0 && requiredWidth > maxTextWidth)
                {
                    WriteLine(writer, words, wordsLength, maxTextWidth, isLastLine: false);

                    words = [];
                    wordsLength = 0;
                }

                words.Add(word);
                wordsLength += word.Length;

                inputLineHasWord = true;
                paragraphHasWords = true;
            }
            else if (token.Type == Token.TokenType.Newline)
            {
                if (!inputLineHasWord && paragraphHasWords)
                {
                    WriteLine(writer, words, wordsLength, maxTextWidth, isLastLine: true);

                    words = [];
                    wordsLength = 0;
                    paragraphHasWords = false;
                    paragraphBreakPending = true;
                }

                inputLineHasWord = false;
            }
        }

        if (words.Count > 0)
        {
            WriteLine(
                writer, words, wordsLength,
                maxTextWidth, isLastLine: true);
        }
    }

    private static void WriteLine(
        TextWriter writer,
        List<string> words,
        long wordsLength,
        int maxTextWidth,
        bool isLastLine)
    {
        if (words.Count == 0)
            return;

        int gaps = words.Count - 1;

        if (isLastLine || gaps == 0)
        {
            for (int i = 0; i < words.Count; i++)
            {
                if (i > 0)
                    writer.Write(' ');

                writer.Write(words[i]);
            }
        }
        else
        {
            int totalSpaces = (int)(maxTextWidth - wordsLength);
            int spacesPerGap = totalSpaces / gaps;
            int widerGaps = totalSpaces % gaps;

            for (int i = 0; i < words.Count; i++)
            {
                writer.Write(words[i]);

                if (i < gaps)
                {
                    int spaceCount = spacesPerGap;

                    if (i < widerGaps)
                        spaceCount++;

                    for (int j = 0; j < spaceCount; j++)
                        writer.Write(' ');
                }
            }
        }

        writer.WriteLine();
    }
}