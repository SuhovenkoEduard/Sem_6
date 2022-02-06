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
    /// Логика взаимодействия для StringChildsWindow.xaml
    /// </summary>
    public partial class StringChildsWindow : Window
    {
        private char[] alphabet = Array.Empty<char>();
        private string stringToCheck = string.Empty;
        private StringChild stringChild = StringChild.Other;
        public StringChildsWindow()
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
        private void OnStringChildsChange(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem? comboBoxItem = StringChildComboBox.SelectedItem as ComboBoxItem;
            TextBlock? textBlock = comboBoxItem?.Content as TextBlock;
            string? selectedStringChild = textBlock?.Text;
            if (selectedStringChild != null && 
                new string[] {"Prefixes", "Suffixes", "Substrings"}.Contains(selectedStringChild))
            {
                ChildsTextBlock.Text = selectedStringChild;
            } else
            {
                if (ChildsTextBlock != null) 
                    ChildsTextBlock.Text = "";
            }

            switch (selectedStringChild)
            {
                case "Prefixes":
                    {
                        stringChild = StringChild.Prefix;
                        break;
                    }
                case "Suffixes":
                    {
                        stringChild = StringChild.Suffix;
                        break;
                    }
                case "Substrings":
                    {
                        stringChild = StringChild.Substring;
                        break;
                    }
                default:
                    {
                        stringChild = StringChild.Other;
                        break;
                    }
            }
        }

        private void OnCheckResultsButton(object sender, RoutedEventArgs e)
        {
            if (stringChild == StringChild.Other)
            {
                MessageBox.Show("You should to select correct string child type!");
                return;
            }

            bool isInLanguage = StringUtilsLibrary.IsInLanguage(alphabet, stringToCheck);
            if (isInLanguage)
            {
                ResultedStringChilds.Items.Clear();
                string[] childs = StringUtilsLibrary.GetAllChilds(stringToCheck, stringChild);
                foreach (string child in childs)
                    ResultedStringChilds.Items.Add(child);
            } else
            {
                MessageBox.Show("Current string is not in language!");
            }
        }

        private void LoadDataFromFile(object sender, RoutedEventArgs e)
        {
            var task2Data = DataLoadersFromFile.LoadDataForTask2();
            AlphabetTextBox.Text = new string(task2Data.Alphabet);
            StringToCheckTextBox.Text = task2Data.StringToCheck;
            StringChildComboBox.SelectedIndex = (int)task2Data.StringChild; 
        }
    }
}
