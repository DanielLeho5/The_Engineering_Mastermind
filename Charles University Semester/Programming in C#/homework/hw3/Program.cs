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
            ParagraphWordCounter wordCounter = new ParagraphWordCounter();
            List<int> words = wordCounter.CountWords(args[0]);

            foreach (var item in words)
            {
                System.Console.WriteLine(item);
            }
        }
        catch (Exception)
        {
            Console.WriteLine("File Error");
        }
    }
}