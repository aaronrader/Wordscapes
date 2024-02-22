/*
 * Project:   WordscapesLibrary
 * Author:    Aaron Rader
 * Date:      2024-02-22
 */

namespace WordscapesLibrary
{
  internal class WordsContainer : IWordsContainer
  {
    private const string FileName = "words.txt";

    private List<string> _words;
    public int Length { get { return _words.Count; } }

    public uint MinWordLength { get; set; } = 1;
    public uint MaxWordLength { get; set; } = uint.MaxValue;

    public WordsContainer()
    {
      _words = new List<string>();

      if (!File.Exists(FileName))
        throw new FileNotFoundException($"{FileName} could not be found!");

      _words.AddRange(File.ReadAllLines(FileName));
    }

    public List<string> GetAllWords()
    {
      return _words;
    }

    public List<string> GetByLetterGroup(string groupToFind)
    {
      List<string> results = new List<string>();

      foreach (string word in _words)
      {
        //Check for word length
        if (word.Length < MinWordLength || word.Length > MaxWordLength)
          continue;

        //Copy the word to search so that I can discard letters that have already been
        //searched without changing the original string
        string lettersToSearch = groupToFind;
        bool found = true;

        foreach (char letter in word)
        {
          int index = lettersToSearch.IndexOf(letter);
          if (index == -1)
          {
            found = false;
            break;
          }

          lettersToSearch = lettersToSearch.Remove(index, 1);
        }
        if (found)
          results.Add(word);
      }

      return results;
    }

    public List<string> GetByLetter(char letterToFind)
    {
      List<string> results = new List< string>();

      foreach (string word in _words)
      {
        if (word.Length < MinWordLength || word.Length > MaxWordLength)
          continue;

        if (word.Contains(letterToFind))
          results.Add(word);
      }

      return results;
    }
  }
}
