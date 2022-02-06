using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MTLab1.FileReaders;
using MTLab1.StringUtils;

namespace MTLab1.Windows
{
    /// <summary>
    /// Логика взаимодействия для IsInLanguageWindow.xaml
    /// </summary>
    public partial class IsInLanguageWindow : Window
    {
        private char[] alphabet = Array.Empty<char>();
        private string stringToCheck = string.Empty;
        public IsInLanguageWindow()
        {
            InitializeComponent();
        }

        private void OnAlphabetChanged(object sender, TextChangedEventArgs e)
        {
            alphabet = AlphabetTextBox.Text.ToCharArray();
        }

        private void OnStringToCheckChanged(object sender, TextChangedEventArgs e)
        {
            stringToCheck = StringToCheckTextBox.Text;
        }

        private void OnCheckResultsButton(object sender, RoutedEventArgs e)
        {
            bool result = StringUtilsLibrary.IsInLanguage(alphabet, stringToCheck);
            if (result)
            {
                ResultOfCheck.Background = new SolidColorBrush(Colors.GreenYellow);
                ResultOfCheck.Text = "Success! In language!";
            } else
            {
                ResultOfCheck.Background = new SolidColorBrush(Colors.OrangeRed);
                ResultOfCheck.Text = "Failure! Not in language!";
            }
        }

        private void LoadDataFromFile(object sender, RoutedEventArgs e)
        {
            var task1Data = DataLoadersFromFile.LoadDataForTask1();
            AlphabetTextBox.Text = new string (task1Data.Alphabet);
            StringToCheckTextBox.Text = task1Data.StringToCheck;
        }
    }
}
