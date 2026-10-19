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
            WordCounter wordCounter = new WordCounter();
            int wordCount = wordCounter.CountWords(args[0]);

            Console.WriteLine(wordCount);
        }
        catch (Exception)
        {
            Console.WriteLine("File Error");
        }
    }
}