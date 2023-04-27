using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Page
    {

        Manicure manicure = new Manicure();
        Saloon saloon = new Saloon();
        public AddClientPage()
        {
            InitializeComponent();
            IdAdressCB.ItemsSource = DBEntities.GetContext().Adress.ToList();
            IdGenderCB.ItemsSource = DBEntities.GetContext().Gender.ToList();
            IdStaffCB.ItemsSource = DBEntities.GetContext().Staff.ToList();
            IdTypeManicureCB.ItemsSource = DBEntities.GetContext().TypeManicure.ToList();
        }

        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageFolder.ClientFolder.ListClientPage());
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ManicureAdd();
                SaloonAdd();

                MBClass.InfoMB("");
            }
            catch (DbEntityValidationException ex)
            {
                MBClass.ErrorMB(ex);
            }
            NavigationService.Navigate(new PageFolder.ClientFolder.ListClientPage());
        }

        private void ManicureAdd()
        {
            var manicureAdd = new Manicure()
            {
                IdTypeManicure = Int32.Parse(IdTypeManicureCB.SelectedValue.ToString()),
                PriceManicure = Int32.Parse(PriceManicureCB.Text),
                AddonsForManicure = AddonsForManicureTb.Text,
            };
            DBEntities.GetContext().Manicure.Add(manicureAdd);
            DBEntities.GetContext().SaveChanges();
            manicure.IdManicure = manicureAdd.IdManicure;
        }

        private void SaloonAdd()
        {
            var saloonAdd = new Saloon()
            {
                IdAdress = Int32.Parse(IdAdressCB.SelectedValue.ToString()),
                LastNameClient = LastNameClientTB.Text,
                FirstNameClient = FirstNameClientTB.Text,
                MiddleNameClient = MiddleNameClientTb.Text,
                PhoneNumberClient = PhoneNumberClientTb.Text,
                PhoneNumberSaloon = PhoneNumberSaloonTb.Text,
                IdGender = Int32.Parse(IdGenderCB.SelectedValue.ToString()),
                IdStaff = Int32.Parse(IdStaffCB.SelectedValue.ToString()),
                DateOfVisit = DateTime.Parse(DateOfVisitCB.Text),
                IdManicure = manicure.IdManicure
            };
            DBEntities.GetContext().Saloon.Add(saloonAdd);
            DBEntities.GetContext().SaveChanges();
        }
    }
}

