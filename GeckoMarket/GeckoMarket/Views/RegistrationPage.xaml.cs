using GeckoMarket.DataBase;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
            if(validationData())
            {
                CreatUser();
                MainFrame.Navigate(new LogInPage());
            }
        }
        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new LogInPage());
        }

        private bool validationData()
        {
            DBControll db = new DBControll();

            string login = Login_TextBox.Text.Trim();
            string email = Email_TextBox.Text.Trim();
            string password = PasswordBox.Password.Trim();
            string passwordDuplicate = PasswordBoxDuplicate.Password.Trim();
            // Trim() - убирает пробелы из строки.

            if (string.IsNullOrEmpty(login) || login.Length < 3)
            {
                return false;
            }
            else if(string.IsNullOrEmpty(email))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(password) || password.Length < 3)
            {
                return false;
            }
            else if (string.IsNullOrEmpty(passwordDuplicate) || password != passwordDuplicate)
            {
                return false;
            }
            else if (db.UserExists(Login_TextBox.Text) == true)
            {
                MessageBox.Show("Такой аккаунт существует");
                return false;
            }
            return true;
        }

        private void CreatUser()
        {
            DBControll db = new DBControll();
            db.AddUsers(Login_TextBox.Text, PasswordBox.Password, Email_TextBox.Text);       
        }
    }
}
