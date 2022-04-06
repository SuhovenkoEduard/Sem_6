using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BLL;
using Bll.Repository;
using Bll.Services;

namespace UI
{
    public partial class Window1 : Window
    {
        private readonly IService _service;

        public Window1(IService service)
        {
            InitializeComponent();
            _service = service;
        }
        public Window1()
        {
            InitializeComponent();
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

        private void ButtonLeft_Click(object sender, RoutedEventArgs e)
        {
            ShowWindowByType();
            
        }

        private void ShowWindowByType()
        {
            /*switch (TypeService().ToString())
            {
                case "Bll.Services.AddressService":
                    var param1 = _service as AddressService;
                    var win1 = new MainWindow(param1);
                    win1.Show();
                    Close();
                    break;
                case "Bll.Services.CourseService":
                    var param2 = _service as CourseService;
                    var win2 = new MainWindow(param2);
                    win2.Show();
                    break;
                case "Bll.Services.StudInfoService":
                    var param3 = _service as StudInfoService;
                    var win3 = new MainWindow(param3);
                    win3.Show();
                    break;
            }*/
        }

        private void ButtonReadAll(object sender, RoutedEventArgs e)
        {
            var data = _service.GetData();
            ShowTable(data);
        }

        private void ShowTable(List<IModel> data)
        {
            if (TypeService() == typeof(AddressService))
            {
                addressData.Visibility = Visibility.Visible;
                add_pnl.Visibility = Visibility.Hidden;
                update_pnl.Visibility = Visibility.Hidden;
                find_pnl.Visibility = Visibility.Hidden;
                addressData.ItemsSource = data;
            }
            if (TypeService() == typeof(StudInfoService))
            {
                studInfoData.Visibility = Visibility.Visible;
                studInfoData.ItemsSource = data;
            }
            if (TypeService() == typeof(CourseService))
            {
                courseData.Visibility = Visibility.Visible;
                courseData.ItemsSource = data;
            }
        }

        private Type TypeService()
        {
            return _service.GetType();
        }

        private void ButtonCreate(object sender, RoutedEventArgs e)
        {

            if (TypeService() == typeof(AddressService))
            {
                var custom = _service as AddressService;
                custom.Add(new AddressDTO()
                {
                    Id = Convert.ToInt32(dto_Id.Text),
                    ExistAddress = dto_Address.Text,
                });
                
            }
            
            MessageBox.Show($"Объект был добавлен!");
        }

        private void ButtonDisplayCreate(object sender, RoutedEventArgs e)
        {
            add_pnl.Visibility = Visibility.Visible;
            
            addressData.Visibility = Visibility.Hidden;
            update_pnl.Visibility = Visibility.Hidden;
            find_pnl.Visibility = Visibility.Hidden;
        }

        private void ButtonDelete(object sender, RoutedEventArgs e)
        {
            if (TypeService() == typeof(AddressService))
            {
                var custom = _service as AddressService;
                AddressDTO dto = (AddressDTO)addressData.SelectedItem;
                if (dto != null)
                {
                    custom.Delete(dto);
                }
                
            }

            ButtonReadAll(sender, e);
            MessageBox.Show($"Объект был удален!");
        }

        private void ButtonDisplayUpdate(object sender, RoutedEventArgs e)
        {
            update_pnl.Visibility = Visibility.Visible;
            
            addressData.Visibility = Visibility.Hidden;
            add_pnl.Visibility = Visibility.Hidden;
            
            
            
            
            if (TypeService() == typeof(AddressService))
            {
                AddressDTO dto = (AddressDTO)addressData.SelectedItem;

                if (dto == null) return;
                dto_Id_Update.Text = Convert.ToString(dto.Id);
                dto_Address_Update.Text = dto.ExistAddress;
            }
            
            
        }

        private void ButtonDisplayFind(object sender, RoutedEventArgs e)
        {
            find_pnl.Visibility = Visibility.Visible;
            
            update_pnl.Visibility = Visibility.Hidden;
            addressData.Visibility = Visibility.Hidden;
            add_pnl.Visibility = Visibility.Hidden;
            
        }

        private void ButtonUpdate(object sender, RoutedEventArgs e)
        {
            if (TypeService() == typeof(AddressService))
            {
                var custom = _service as AddressService;
                AddressDTO dto = new AddressDTO()
                {
                    Id = Convert.ToInt32(dto_Id_Update.Text),
                    ExistAddress = dto_Address_Update.Text,
                };
                if (dto != null)
                {
                    custom.Update(dto);
                }
            }

            ButtonReadAll(sender, e);
            MessageBox.Show($"Объект был обновлен!");
        }

        private void ButtonFind(object sender, RoutedEventArgs e)
        {
            if (TypeService() == typeof(AddressService))
            {
                var custom = _service as AddressService;
                AddressDTO dto = new AddressDTO()
                {
                    Id = Convert.ToInt32(dto_Id_Find.Text),
                    ExistAddress = dto_Address_Find.Text,
                };
                if (dto != null)
                {
                    var items = custom.Find(dto);
                    addressData.ItemsSource = items;
                    addressData.Visibility = Visibility.Visible;
                    find_pnl.Visibility = Visibility.Hidden;
                }
            }

            
            MessageBox.Show($"Объект был найден!");
        }
    }
}
