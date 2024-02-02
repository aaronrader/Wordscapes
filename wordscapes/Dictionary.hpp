#pragma once
#include <vector>
#include <string>

class Dictionary {
  std::vector<std::string> words_;
  constexpr static unsigned MIN_WORD_LENGTH = 3;
  constexpr static unsigned MAX_WORD_LENGTH = std::numeric_limits<unsigned>::max();
  
public:
  void add(std::string const&) noexcept;
  [[nodiscard]] std::vector<std::string> get_by_word(std::string const&, unsigned const& wordLength = MAX_WORD_LENGTH) const noexcept;
  [[nodiscard]] std::vector<std::string> get_by_letter(char const&, unsigned const& wordLength = MAX_WORD_LENGTH) const noexcept;
  [[nodiscard]] std::vector<std::string> get_all_words() const noexcept { return words_; }

  [[nodiscard]] constexpr size_t size() const noexcept { return words_.size(); }
};
