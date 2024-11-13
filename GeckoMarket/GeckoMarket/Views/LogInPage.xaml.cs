using GeckoMarket.DataBase;
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
                UserSession.IsLoggedIn = true;
                UserSession.CurrentUserLogin = Login_TextBox.Text.Trim();

                MainFrame.Navigate(new CatalogPage());
            }
        }

        public bool validationData()
        {
            DBControll db = new DBControll();

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
            else if(db.dateVerification(Login_TextBox.Text, PasswordBox.Password) == false)
            {
                MessageBox.Show("Неверные данные");
                return false;
            }

            return true;
        }
    }
}
