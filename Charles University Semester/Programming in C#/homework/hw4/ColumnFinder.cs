class ColumnFinder
{
    public int FindColumn(string column, string filename)
    {
        using StreamReader reader = new StreamReader(filename);

        string? line = reader.ReadLine();

        if (line == null || line.Split(['\t', ' '],
            StringSplitOptions.RemoveEmptyEntries).Length == 0)
        {
            return -2;
        }

        string[] columnNames = line.Split(['\t', ' '],
            StringSplitOptions.RemoveEmptyEntries);

        return Array.IndexOf(columnNames, column);
    }

    public int NumberOfColumns(string filename)
    {
        using StreamReader reader = new StreamReader(filename);
        string[] columnNames = reader.ReadLine().Split(['\t', ' '], StringSplitOptions.RemoveEmptyEntries);
        return columnNames.Length;
    }
}