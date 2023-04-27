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

namespace Lelyavskaya.PageFolder.ClientFolder
{
    /// <summary>
    /// Логика взаимодействия для ListClientPage.xaml
    /// </summary>
    public partial class ListClientPage : Page
    {
   
        public ListClientPage()
        {
            InitializeComponent();
     
            DgClient.ItemsSource = DBEntities.GetContext().Saloon
                .ToList().OrderBy(u => u.IdSaloon);
            
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            if (DgClient.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "пользователя для редактирования");
            }
            else
            {
                NavigationService.Navigate(
                    new EditClientPage(DgClient.SelectedItem as Saloon));
            }
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            Saloon saloon = DgClient.SelectedItem as Saloon;

            if (DgClient.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите пользователя" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QuestionMB("Удалить " +
                    $"читателя {saloon.LastNameClient} " +
                    $"{saloon.FirstNameClient} {saloon.MiddleNameClient}?"))
                {
                    DBEntities.GetContext().Saloon
                        .Remove(DgClient.SelectedItem as Saloon);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InfoMB("Пользователь удален");
                    DgClient.ItemsSource = DBEntities.GetContext()
                        .Saloon.ToList().OrderBy(r => r.LastNameClient);
                    NavigationService.Navigate(new ListClientPage());
                }

            }
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            DgClient.ItemsSource = DBEntities.GetContext()
                .Saloon.Where(u => u.PhoneNumberClient
                .StartsWith(SearchTB.Text))
                .ToList().OrderBy(u => u.PhoneNumberClient);
            //if (DgUser.Items.Count <= 0)
            //{
            //    MBClass.ErrorMB("Данные не найдены");
            //}
        }
    }
}
