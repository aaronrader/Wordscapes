#include "Dictionary.hpp"

#include <algorithm>

void Dictionary::add(std::string const& word) noexcept {
  if (word.length() >= MIN_WORD_LENGTH && word.length() <= MAX_WORD_LENGTH)
    words_.emplace_back(word);
}

std::vector<std::string> Dictionary::get_by_word(std::string const& wordToSearch, unsigned const& wordLength) const noexcept {
  std::vector<std::string> words;
  for (std::string const& word : words_) {
    if (word.length() != wordLength)
      continue;

    std::string lettersToSearch = wordToSearch;
    bool found = true;
    for (char const& letter : word) {
      std::string::size_type pos;
      if ((pos = lettersToSearch.find_first_of(letter)) == std::string::npos) {
        found = false;
        break;
      }

      lettersToSearch.erase(pos, 1);
    }
    if (found)
      words.push_back(word);
  }
  return words;
}

std::vector<std::string> Dictionary::get_by_letter(char const& letter, unsigned const& wordLength) const noexcept {
  std::vector<std::string> words;
  for (const std::string& word : words_) {
    if (word.length() > wordLength)
      continue;
    
    if (word.find_first_of(letter) != std::string::npos)
      words.push_back(word);
  }
  return words;
}
