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
using Bll;
using Bll.Repository;
using Bll.Services;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AddressService _addressService;
        private CourseService _courseService;
        private StudInfoService _studInfoService;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(AddressService addressService, CourseService courseService, StudInfoService studInfoService)
        {
            InitializeComponent();
            _addressService = addressService;
            _courseService = courseService;
            _studInfoService = studInfoService;
        }
        public MainWindow(AddressService addressService)
        {
            InitializeComponent();
            _addressService = addressService;
        }
        public MainWindow(CourseService courseService)
        {
            InitializeComponent();
            _courseService = courseService;
        }
        public MainWindow(StudInfoService studInfoService)
        {
            InitializeComponent();
            _studInfoService = studInfoService;
        }
        

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FirstTableClick(object sender, RoutedEventArgs e)
        {
            var optionsWindow = new Window1(_addressService);
            optionsWindow.Show();

            Close();
        }

        private void SecondTableClick(object sender, RoutedEventArgs e)
        {
            var optionsWindow = new Window1(_studInfoService);
            optionsWindow.Show();

            Close();
        }

        private void ThirdTableClick(object sender, RoutedEventArgs e)
        {
            var optionsWindow = new Window1(_courseService);
            optionsWindow.Show();

            Close();
        }
    }
}
