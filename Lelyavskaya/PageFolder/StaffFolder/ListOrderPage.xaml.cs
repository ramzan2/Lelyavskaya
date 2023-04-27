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
using Lelyavskaya.ClassFolder;
using Lelyavskaya.DataFolder;
using Lelyavskaya.PageFolder.ClientFolder;

namespace Lelyavskaya.PageFolder.StaffFolder
{
    /// <summary>
    /// Логика взаимодействия для ListOrderPage.xaml
    /// </summary>
    public partial class ListOrderPage : Page
    {
        public ListOrderPage()
        {
            InitializeComponent();
            //DgUser.ItemsSource = DBEntities.GetContext().Manicure
            //.ToList().OrderBy(u => u.IdManicure);
            DgUser.ItemsSource = DBEntities.GetContext().Manicure
                .ToList().OrderBy(u => u.IdManicure);
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            Saloon saloon = DgUser.SelectedItem as Saloon;

            if (DgUser.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите маникюр" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QuestionMB("Удалить " +
                    $"маникюр {saloon.LastNameClient} " +
                    $"{saloon.FirstNameClient} {saloon.MiddleNameClient}?"))
                {
                    DBEntities.GetContext().Saloon
                        .Remove(DgUser.SelectedItem as Saloon);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InfoMB("Маникюр удален");
                    DgUser.ItemsSource = DBEntities.GetContext()
                        .Saloon.ToList().OrderBy(r => r.LastNameClient);
                    NavigationService.Navigate(new ListOrderPage());
                }

            }
        }

        //private void EditMI_Click(object sender, RoutedEventArgs e)
        //{
        //    if (DgUser.SelectedItem == null)
        //    {
        //        MBClass.ErrorMB("Выберите " +
        //            "маникюра для редактирования");
        //    }
        //    else
        //    {
        //        NavigationService.Navigate(
        //            new EditOrderPage(DgUser.SelectedItem as Manicure));
        //    }
        //}

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            DgUser.ItemsSource = DBEntities.GetContext()
                .Saloon.Where(u => u.DateOfVisit.ToString()
                .StartsWith(SearchTB.Text))
                .ToList().OrderBy(u => u.DateOfVisit);
        }
    }
}
