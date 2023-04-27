using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для EditOrderPage.xaml
    /// </summary>
    public partial class EditOrderPage : Page
    {
        Manicure manicure = new Manicure();
        public EditOrderPage(Manicure manicure)
        {
            InitializeComponent();
            DataContext = manicure;
            IdTypeManicureCB.
                ItemsSource = DBEntities.GetContext().
                TypeManicure.ToList();

        }

   

        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListOrderPage());
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

        private void EditManicureBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectedFileName == "")
                {
                    manicure = DBEntities.GetContext().Manicure.FirstOrDefault(r => r.IdManicure == manicure.IdManicure);
                    manicure.IdTypeManicure = Int32.Parse(IdTypeManicureCB.SelectedValue.ToString());
                    manicure.PriceManicure = Int32.Parse(PriceManicureTB.Text);
                    manicure.AddonsForManicure = AddonsForManicureTB.Text;
                    DBEntities.GetContext().SaveChanges();
                }
                else
                {
                    manicure = DBEntities.GetContext().Manicure.FirstOrDefault(r => r.IdManicure == manicure.IdManicure);
                    manicure.IdTypeManicure = Int32.Parse(IdTypeManicureCB.SelectedValue.ToString());
                    manicure.PriceManicure = Int32.Parse(PriceManicureTB.Text);
                    manicure.AddonsForManicure = AddonsForManicureTB.Text;
                    manicure.PhotoManicure = ImageClass.ConvertImageToByteArray(selectedFileName);
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InfoMB("Информацию о работе измененна");
                }

            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex.Message);
            }
            NavigationService.Navigate(new ListOrderPage());
        }
    }
}
