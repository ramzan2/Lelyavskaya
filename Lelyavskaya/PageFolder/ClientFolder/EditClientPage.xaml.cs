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

namespace Lelyavskaya.PageFolder.ClientFolder
{
    /// <summary>
    /// Логика взаимодействия для EditClientPage.xaml
    /// </summary>
    public partial class EditClientPage : Page
    {

        Saloon saloon = new Saloon();
        Manicure manicure = new Manicure();
        public EditClientPage(Saloon saloon)
        {
            InitializeComponent();
            DataContext = saloon;
            this.saloon = saloon;
            IdAdressCB.ItemsSource = DBEntities.GetContext().Adress.ToList();
            IdGenderCB.ItemsSource = DBEntities.GetContext().Gender.ToList();
            IdStaffCB.ItemsSource = DBEntities.GetContext().Staff.ToList();
            IdTypeManicureCB.ItemsSource = DBEntities.GetContext().TypeManicure.ToList();
            DateOfVisitCB.SelectedDate = saloon.DateOfVisit;
        }

        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListClientPage());
        }

      

        private void EditManicureClient()
        {
            try
            {
                manicure = DBEntities.GetContext().Manicure.FirstOrDefault(r => r.IdManicure == saloon.IdManicure);
                manicure.IdTypeManicure = Int32.Parse(IdTypeManicureCB.SelectedValue.ToString());
                manicure.PriceManicure = Int32.Parse(PriceManicureCB.Text);
                manicure.AddonsForManicure = AddonsForManicureTb.Text;
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Информация о клиенте измененна");
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex.Message);
            }
        }

        private void EditSaloon()
        {
            try
            {
                
                    saloon = DBEntities.GetContext().Saloon.FirstOrDefault(r => r.IdSaloon == saloon.IdSaloon);
                    saloon.IdAdress = Int32.Parse(IdAdressCB.SelectedValue.ToString());
                    saloon.LastNameClient = LastNameClientTB.Text;
                    saloon.FirstNameClient = FirstNameClientTB.Text;
                    saloon.MiddleNameClient = MiddleNameClientTb.Text;
                    saloon.PhoneNumberClient = PhoneNumberClientTb.Text;
                    saloon.PhoneNumberSaloon = PhoneNumberSaloonTb.Text;
                    saloon.IdGender = Int32.Parse(IdGenderCB.SelectedValue.ToString());
                    saloon.IdStaff = Int32.Parse(IdStaffCB.SelectedValue.ToString());
                    saloon.DateOfVisit = DateTime.Parse(DateOfVisitCB.Text);
                    saloon.IdManicure = manicure.IdManicure;
                    DBEntities.GetContext().SaveChanges();             
                    MBClass.InfoMB("Клиент изменен");

                NavigationService.Navigate(new ListClientPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex.Message);
            }
        }

        private void EditClientBtn_Click(object sender, RoutedEventArgs e)
        {
            EditManicureClient();
            EditSaloon();
        }
    }
}
