using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        bool task_5 = true;

        if (!task_5 && args.Length != 1)
        {
            Console.WriteLine("Argument Error");
            return;
        }

        if (task_5 && args.Length != 3)
        {   
            Console.WriteLine("Argument Error");
            return;
        }


        try
        {            
            using StreamReader sr = new StreamReader(args[0]);
            TokenReader tr = new TokenReader(sr);

            // hw 1 - Word Counting, files:
            // /Processing/WordCounter.cs
            // /Readers/*
            // /Tokens/Token.css
            // Program.cs

            //WordCounter wc = new WordCounter(tr);
            //wc.CountWords();

            // hw 2 - Word Frequencies, files:
            // /Processing/WordFrequencyCounter.cs
            // /Readers/*
            // /Tokens/Token.css
            // Program.cs

            //WordFrequencyCounter wfc = new WordFrequencyCounter(tr);
            //wfc.CountWords();

            // hw 3 - Paragraph Word Counting, files:
            // /Processing/ParagraphWordCounter.cs
            // /Readers/*
            // /Tokens/Token.css
            // Program.cs

            //ParagraphWordCounter pwc = new ParagraphWordCounter(tr);
            //pwc.CountWords();

            // hw 4 - To sum or not to sum (different approach, couldn't fit the current structure to it)

            // hw 5 - Text justification, files:

            bool isValid = int.TryParse(args[2], out int lineWidth);

            if (!isValid || lineWidth < 1)
            {
                System.Console.WriteLine("Argument Error");
                return;
            }
              
            using StreamWriter writer = new StreamWriter(args[1]);

            TextJustifier tj = new TextJustifier(tr);
            tj.JustifyText(writer, lineWidth);
        }
        catch (Exception)
        {
            Console.WriteLine("File Error");
        }
    }
}