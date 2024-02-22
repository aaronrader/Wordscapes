/*
 * Project:   WordscapesGUI
 * Author:    Aaron Rader
 * Date:      2024-02-22
 */

using System.IO;
using System.Windows;
using System.Windows.Controls;
using WordscapesLibrary;

namespace WordscapesGUI
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    readonly IWordsContainer container;

    public MainWindow()
    {
      InitializeComponent();
      try
      {
        container = IWordsContainer.GetWordsContainer();
      }
      catch (FileNotFoundException ex)
      {
        MessageBox.Show(ex.Message, "File not Found", MessageBoxButton.OK, MessageBoxImage.Error);
        Application.Current.Shutdown();
        return;
      }
    }

    private void minLengthSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
      minLengthAmount.Content = e.NewValue.ToString();
      if (maxLengthSlider is not null && minLengthSlider.Value > maxLengthSlider.Value)
      {
        maxLengthSlider.Value = minLengthSlider.Value;
      }
    }

    private void maxLengthSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
      maxLengthAmount.Content = e.NewValue.ToString();
      if (minLengthSlider is not null && maxLengthSlider.Value < minLengthSlider.Value)
      {
        minLengthSlider.Value = maxLengthSlider.Value;
      }
    }

    private void searchField_TextChanged(object sender, TextChangedEventArgs e)
    {
      if (minLengthSlider is null || maxLengthSlider is null)
        return;

      if (searchField.Text.Length > 1)
      {
        minLengthSlider.IsEnabled = true;
        maxLengthSlider.IsEnabled = true;
        minLengthSlider.Maximum = searchField.Text.Length;
        maxLengthSlider.Maximum = searchField.Text.Length;
      }
      else
      {
        minLengthSlider.IsEnabled = false;
        maxLengthSlider.IsEnabled = false;
        minLengthSlider.Maximum = 1;
        maxLengthSlider.Maximum = 1;
      }
    }

    private void searchButton_Click(object sender, RoutedEventArgs e)
    {
      //Set up container
      container.MaxWordLength = (uint)maxLengthSlider.Value;
      container.MinWordLength = (uint)minLengthSlider.Value;

      //Retrieve the results
      List<string> results = container.GetByLetterGroup(searchField.Text.ToLower());

      string data = string.Empty;
      foreach (string result in results)
      {
        data += result + "\n";
      }

      resultsBox.Text = data;
    }
  }
}