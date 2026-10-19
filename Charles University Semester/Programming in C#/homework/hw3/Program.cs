public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Argument Error");
            return;
        }

        try
        {
            WordFrequencyCounter wordCounter = new WordFrequencyCounter();
            SortedDictionary<string, int> words = wordCounter.CountWords(args[0]);

            DictionaryPrinter dp = new DictionaryPrinter();
            dp.Print(words);
        }
        catch (Exception)
        {
            Console.WriteLine("File Error");
        }
    }
}