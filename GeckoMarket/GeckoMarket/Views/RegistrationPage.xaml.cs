using GeckoMarket.DataBase;
using System.Windows;
using System.Windows.Controls;

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
        private void visitor_Click(object sender, RoutedEventArgs e)
        {
            UserSession.Visitor = true;
            MainFrame.Navigate(new CatalogPage());
        }

        private bool validationData()
        {
            DBControll db = new DBControll();

            string nickname = Name_TextBox.Text.Trim();
            string login = Login_TextBox.Text.Trim();
            string email = Email_TextBox.Text.Trim();
            string password = PasswordBox.Password.Trim();
            string passwordDuplicate = PasswordBoxDuplicate.Password.Trim();
            // Trim() - убирает пробелы из строки.

            if (string.IsNullOrEmpty(login) || login.Length < 5)
            {
                return false;
            }
            else if(string.IsNullOrEmpty(email) && !email.Contains('@'))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(password) || password.Length < 5)
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
            db.AddUsers(Name_TextBox.Text, Login_TextBox.Text, PasswordBox.Password, Email_TextBox.Text);       
        }
    }
}
