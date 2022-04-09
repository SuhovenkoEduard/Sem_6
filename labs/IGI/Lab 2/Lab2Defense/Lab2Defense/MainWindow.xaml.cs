using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Lab2Defense;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        MainRect = new Rectangle(0, 0);
        // height
        var heightBinding = new Binding("Height") {Source = MainRect};
        HeightTextBox.SetBinding(TextBox.TextProperty, heightBinding);
        // width
        var widthBinding = new Binding("Width") {Source = MainRect};
        WidthTextBox.SetBinding(TextBox.TextProperty, widthBinding);

        // button's styles
        // CalculateButton.Height = 50;
        // CalculateButton.Width = 150;
        // AboutButton.Height = 50;
        // AboutButton.Width = 150;
    }

    private Rectangle MainRect { get; }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        PerimeterTextBlock.Text = MainRect.Perimeter.ToString(CultureInfo.InvariantCulture);
        AreaTextBlock.Text = MainRect.Area.ToString(CultureInfo.InvariantCulture);
    }

    private void AboutButton_OnClick(object sender, RoutedEventArgs e)
    {
        var aboutWindow = new FlowDocumentAbout();
        aboutWindow.ShowDialog();
    }
}