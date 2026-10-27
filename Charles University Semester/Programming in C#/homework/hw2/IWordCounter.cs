public interface IWordCounter
{
    public SortedDictionary<string, int> CountWords(string fileName);
}