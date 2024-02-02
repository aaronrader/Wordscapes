#include <iostream>
#include <vector>
#include <fstream>

#include "Dictionary.hpp"

using namespace std;

int main(int argc, char* argv[]) {
  Dictionary dict;

  cout << "Wordscapes Word Search" << endl;
  cout << "Please wait while the dictionary loads...";
  ifstream ifs("C:\\Custom Programs\\words.txt");
  while (ifs) {
    string word;
    getline(ifs, word);
    dict.add(word);
  }
  cout << " done!\n" << endl;
  
  cout.imbue(locale(""));
  cout << "Choose from the following options" << endl;
  cout << "\t1 - List all words in the dictionary (" << dict.size() << ")" << endl;
  cout << "\t2 - Find all words containing a specific word or group of letters" << endl;
  cout << "\t3 - Find all words containing a specific letter" << endl;
  cout << "\t0 - Exit" << endl;

  vector<string> wordList;

  bool exitFlag = false;
  while (!exitFlag) {
    cout << "Choice: ";
    int choice;
    cin >> choice;
    switch (choice) {
    case 1:
    {
      wordList = dict.get_all_words();
      exitFlag = true;
      break;
    }
    case 2:
    {
      cout << "Enter a word or group of letters to search for: ";
      string word;
      cin >> word;
      cout << "What length of word are you looking for? ";
      unsigned length;
      cin >> length;
      wordList = dict.get_by_word(word, length);
      exitFlag = true;
      break;
    }
    case 3:
    {
      cout << "Enter a letter to search for: ";
      char letter;
      cin >> letter;
      wordList = dict.get_by_letter(letter);
      exitFlag = true;
      break;
    }
    case 0: {
      cout << "\nThank you for using Wordscapes Word Search!";
      return EXIT_SUCCESS;
    }
    default:
      cout << "Invalid choice entered." << endl;
    }
  }

  cout << endl;
  for (string const& word : wordList) {
    cout << word << endl;
  }
  cout << endl << "Thank you for using Wordscapes Word Search!";
}