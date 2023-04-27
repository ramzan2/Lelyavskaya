using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
using Lelyavskaya.ClassFolder;
using Lelyavskaya.DataFolder;
using Microsoft.Win32;

namespace Lelyavskaya.PageFolder.StaffFolder
{
    /// <summary>
    /// Логика взаимодействия для AddOrderPage.xaml
    /// </summary>
    public partial class AddOrderPage : Page
    {
        Manicure manicure = new Manicure();
        public AddOrderPage()
        {
            InitializeComponent();
            IdTypeManicureCB.ItemsSource = DBEntities.GetContext().TypeManicure.ToList();

        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PriceManicureTB.Text))
            {
                MBClass.ErrorMB("Укажите цену");
                PriceManicureTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(AddonsForManicureTB.Text))
            {
                MBClass.ErrorMB("Укажите доп. услуги");
                AddonsForManicureTB.Focus();
            }
            else if (IdTypeManicureCB.SelectedIndex == -1)
            {
                MBClass.ErrorMB("Выберите тиа маникюра");
                IdTypeManicureCB.Focus();
            }
            else
            {
                try
                {
                    DBEntities.GetContext().Manicure.Add(new Manicure()
                    {
                        IdTypeManicure = Int32.Parse(IdTypeManicureCB.SelectedValue.ToString()),
                        PriceManicure = Int32.Parse(PriceManicureTB.Text),
                        AddonsForManicure = AddonsForManicureTB.Text,
                        PhotoManicure = ImageClass.ConvertImageToByteArray(selectedFileName)
                    });
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InfoMB("Маникюр успешно добавлен");
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                    throw;
                }
                NavigationService.Navigate(new ListOrderPage());
            }
        }

        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        string selectedFileName = "";
        private void AddPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            AddPhoto();
        }
        private void AddPhoto()
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.InitialDirectory = "";
                op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                    "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                    "Portable Network Graphic (*.png)|*.png";

                if (op.ShowDialog() == true)
                {
                    selectedFileName = op.FileName;
                    manicure.PhotoManicure = ImageClass.ConvertImageToByteArray(selectedFileName);
                    PhotoIm.Source = ImageClass.ConvertByteArrayToImage(manicure.PhotoManicure);
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
