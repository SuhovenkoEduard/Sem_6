using MTLab1.FileReaders;
using MTLab1.StringUtils;
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

namespace MTLab1.Windows
{
    /// <summary>
    /// Логика взаимодействия для TwoStringsWindow.xaml
    /// </summary>
    public partial class TwoStringsWindow : Window
    {
        private char[] alphabet = Array.Empty<char>();
        private string text = string.Empty;
        private string sequence = string.Empty;
        
        public TwoStringsWindow()
        {
            InitializeComponent();
        }

        private void OnAlphabetChanged(object sender, TextChangedEventArgs e)
        {
            alphabet = AlphabetTextBox.Text.ToCharArray();
        }
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            text = TextTextbox.Text;
        }
        private void OnSequenceChanged(object sender, TextChangedEventArgs e)
        {
            sequence = SequenceTextBox.Text;
        }
        private void OnCheckResultsButton(object sender, RoutedEventArgs e)
        {
            bool isInLanguageText = StringUtilsLibrary.IsInLanguage(alphabet, text); 
            bool isInLanguageSequence = StringUtilsLibrary.IsInLanguage(alphabet, sequence);
            if (!isInLanguageText)
            {
                MessageBox.Show("The text is not in a language!");
                return;
            }
            if (!isInLanguageSequence)
            {
                MessageBox.Show("The sequence is not in a language!");
                return;
            }

            ResultsOfCheck.Items.Clear();
            StringChild[] typesOfSequence = StringUtilsLibrary.InvestigateText(text, sequence);
            foreach (StringChild type in typesOfSequence)
            {
                ResultsOfCheck.Items.Add(type.ToString());
            }
        }

        private void LoadDataFromFile(object sender, RoutedEventArgs e)
        {
            var task3Data = DataLoadersFromFile.LoadDataForTask3();
            AlphabetTextBox.Text = new string(task3Data.Alphabet);
            TextTextbox.Text = task3Data.Text;
            SequenceTextBox.Text = task3Data.Sequence;
        }
    }
}
