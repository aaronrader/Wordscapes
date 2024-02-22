/*
 * Project:   WordscapesLibrary
 * Author:    Aaron Rader
 * Date:      2024-02-22
 */

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
    public List<string> GetByLetterGroup(string groupToFind);
    public List<string> GetByLetter(char letterToFind);
  }
}
