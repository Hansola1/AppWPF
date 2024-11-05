using System;
using System.Windows;
using System.Windows.Controls;

namespace GeckoMarket.Views
{
    public partial class LogInPage : Page
    {
        public LogInPage()
        {
            InitializeComponent();
        }

        private void CreatAccount_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RegistrationPage());
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            if (validationData())
            {
                MainFrame.Navigate(new CatalogPage());
            }
        }

        private bool validationData()
        {
            string login = Login_TextBox.Text.Trim();
            string password = PasswordBox.Password.Trim();
            // Trim() - убирает пробелы из строки.

            if (string.IsNullOrEmpty(login))
            {
                Login_TextBox.ToolTip = "Заполните поле!";
                return false; 
            }
            else if (string.IsNullOrEmpty(password))
            {
                PasswordBox.ToolTip = "Заполните поле!";
                return false; 
            }
            return true;
        }
    }
}
