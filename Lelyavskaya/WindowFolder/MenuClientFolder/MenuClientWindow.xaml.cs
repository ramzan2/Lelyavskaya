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
using System.Windows.Shapes;
using Lelyavskaya.ClassFolder;

namespace Lelyavskaya.WindowFolder.MenuClientFolder
{
    /// <summary>
    /// Логика взаимодействия для MenuClientWindow.xaml
    /// </summary>
    public partial class MenuClientWindow : Window
    {
        public MenuClientWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new PageFolder.ClientFolder.ListClientPage());
        }

        private void AddZayavkaBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageFolder.ClientFolder.AddClientPage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void ListClientBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageFolder.ClientFolder.ListClientPage());
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void CloseIm_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MBClass.ExitMB();
        }
    }
}
