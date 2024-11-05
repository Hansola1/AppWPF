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

namespace GeckoMarket.Views
{
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new LogInPage());
        }
        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new LogInPage());
        }
    }
}
