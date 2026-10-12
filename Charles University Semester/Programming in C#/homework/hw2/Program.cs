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

        SortedDictionary<string, int> words = new SortedDictionary<string, int>();
        
        foreach (string line in File.ReadLines(fileName))
        {
            string currentWord = "";

            for (int i = 0; i < line.Length; i++)
            {
                if (!char.IsWhiteSpace(line[i]))
                {
                    currentWord += line[i];
                }
                else if (currentWord.Length > 0)
                {
                    if (words.ContainsKey(currentWord))
                    {
                        words[currentWord]++;
                    }
                    else
                    {
                        words[currentWord] = 1;
                    }

                    currentWord = "";
                }
            }
            
            if (currentWord.Length > 0)
            {
                if (words.ContainsKey(currentWord))
                {
                    words[currentWord]++;
                }
                else
                {
                    words[currentWord] = 1;
                }
            }
        }
        
        
        for (int i = 0; i < words.Count; i++)
        {
            System.Console.WriteLine($"{words.ElementAt(i).Key}: {words.ElementAt(i).Value}");
        }

        /*
        Dictionary<string, int> ads = new Dictionary<string, int>();
        ads["hello"] = 1;
        System.Console.WriteLine(ads.ElementAt(0));
        System.Console.WriteLine(ads.Count);*/
    }
}