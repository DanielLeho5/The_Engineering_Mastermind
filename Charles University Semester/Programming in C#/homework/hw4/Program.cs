class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 3)
        {
            Console.WriteLine("Argument Error");
            return;
        }

        try
        {
            ColumnFinder cf = new ColumnFinder();
            IndexedAdder ia = new IndexedAdder();

            int idx = cf.FindColumn(args[2], args[0]);

            if (idx == -2)
            {
                Console.WriteLine("Invalid File Format");
                return;
            }

            if (idx == -1)
            {
                Console.WriteLine("Non-existent Column Name");
                return;
            }

            long? sum = ia.AddValues(args[0], idx, cf.NumberOfColumns(args[0]));
            if (sum != null)
            {
                File.WriteAllText(args[1], $"{args[2]}\n{new string('-', args[2].Length)}\n{sum}\n");
            }
        }
        catch
        {
            Console.WriteLine("File Error");
        }
    }
}