using MTLab1.ErrorWindows;
using MTLab1.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MTLab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string selectedTaskName = string.Empty;
        private Dictionary<string, string> taskDescriptions = new()
        {
            { "Task1 (IsInLanguage)", "Program checking that the language with input alphabet contains the input string." },
            { "Task2 (StringChilds)", "Program show all prefixes/suffixes/substrings of the input string, wich is belongs to the input language." },
            { "Task3 (TwoStrings)", "Program show the information about sequence in text, that sequence can be a suffix, a prefix or a substring of the text, or text may not contain the sequence.  " }
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TaskSelector.SelectedItem != null)
            {
                ComboBoxItem? comboBoxItem = TaskSelector.SelectedItem as ComboBoxItem;
                if (comboBoxItem?.Content is TextBlock textBlock)
                {
                    selectedTaskName = textBlock.Text;
                    TaskDescription.Text = $"Description of task: [{selectedTaskName}]: {taskDescriptions[selectedTaskName]}";
                }
            }
        }

        private void OnStartButton(object sender, RoutedEventArgs e)
        {
            Window? childWindow = null;
            switch (selectedTaskName)
            {
                case "Task1 (IsInLanguage)":
                    {
                        childWindow = new IsInLanguageWindow();
                        break;
                    }
                case "Task2 (StringChilds)":
                    {
                        childWindow = new StringChildsWindow();
                        break;
                    }
                case "Task3 (TwoStrings)":
                    {
                        childWindow = new TwoStringsWindow();
                        break;
                    }
                default:
                    {
                        ErrorWindow.ShowDialog("You need to choose the right task!");
                        break;
                    }
            }
            childWindow?.ShowDialog();
        }
    }
}
