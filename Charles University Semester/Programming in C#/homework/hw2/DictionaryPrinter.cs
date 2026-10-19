class DictionaryPrinter
{
    public void Print(SortedDictionary<string, int> dict)
    {
        foreach (KeyValuePair<string, int> kvp in dict)
        {
            System.Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
}