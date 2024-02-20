namespace WordscapesLibrary
{
  public interface IWordsContainer
  {
    private static readonly WordsContainer? _container = null;

    public int Length { get; }
    public uint MinWordLength { get; set; }
    public uint MaxWordLength { get; set; }

    //Impliment singleton pattern
    public static IWordsContainer GetWordsContainer()
    {
      if (_container is null)
      {
        return new WordsContainer();
      }

      return _container;
    }

    public List<string> GetAllWords();
    public List<string> GetByWord(string wordToFind);
    public List<string> GetByLetter(char letterToFind);
  }
}
