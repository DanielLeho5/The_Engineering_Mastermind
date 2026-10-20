class IndexedAdder
{
    public long? AddValues(string filename, int columnIdx, int expectedColumns)
    {  
        using StreamReader reader = new StreamReader(filename);
        
        long sum = 0;
        reader.ReadLine();
        string? line;

        while ((line = reader.ReadLine()) != null)
        {
            string[] values = line.Split(['\t', ' '], StringSplitOptions.RemoveEmptyEntries);

            if (values.Length != expectedColumns)
            {
                Console.WriteLine("Invalid File Format");
                return null;
            }

            if (!int.TryParse(values[columnIdx], out int value))
            {
                Console.WriteLine("Invalid Integer Value");
                return null;
            }

            sum += value;
        }

        return sum;
    }
}