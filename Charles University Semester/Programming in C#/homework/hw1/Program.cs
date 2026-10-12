using System.IO;
class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            System.Console.WriteLine("Argument Error");
            return;
        }

        string fileName = args[0];

        if (!File.Exists(fileName))
        {
            System.Console.WriteLine("File Error");
            return;
        }

        int wordCount = 0;
        
        foreach (string line in File.ReadLines(fileName))
        {
            char prev = ' ';
            for (int i = 0; i < line.Length; i++)
            {
                if (!char.IsWhiteSpace(line[i]) && char.IsWhiteSpace(prev))
                {
                    wordCount++;
                    //System.Console.Write("!");
                }
                //System.Console.Write(line[i]);
                prev = line[i];
            }
        }
        
        
        System.Console.WriteLine(wordCount);
    }
}