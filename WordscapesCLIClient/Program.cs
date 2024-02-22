using WordscapesLibrary;

namespace WordscapesCLIClient
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Aaron Rader - Wordscapes CLI Client - 2024\n");

      IWordsContainer words = IWordsContainer.GetWordsContainer();

      Console.WriteLine($"There are {words.Length} words in the database.");

      //Set up an arbitrary 6 length word to test
      words.MaxWordLength = 20;

      string letterGroup;
      do
      {
        Console.Write("Please enter a group of letters to search for: ");
        letterGroup = Console.ReadLine() ?? "";

        if (letterGroup.Length == 0)
          Console.WriteLine("Please enter a word that isn't empty.");

      } while (letterGroup.Length == 0);

      List<string> results = words.GetByLetterGroup(letterGroup);
      Console.WriteLine("Here is your list of words:");
      foreach(string result in results)
      {
        Console.WriteLine(result);
      }
    }
  }
}
