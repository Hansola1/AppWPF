using GeckoMarket.DataBase;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input; // для KeyEventArgs e

namespace GeckoMarket.Views
{
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();
            LoadInformationUser();
        }
        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProfilePage());
        }
        private void CatalogButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CatalogPage());
        }
        private void BasketButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new BasketPage());
        }
        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new OrdersPage());
        }
        private void ProfileCancel_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProfilePage());
        }

        private void DeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            DBControll db = new DBControll();

            if (UserSession.IsLoggedIn)
            {
                string loginCurrentUser = UserSession.CurrentUserLogin;
                int? UserIDtoDelete = db.GetCurrentUserID(loginCurrentUser);

                if (UserIDtoDelete.HasValue) // если оно не null
                {
                    db.DeleteUsers(UserIDtoDelete.Value);
                    MainFrame.Navigate(new RegistrationPage());
                }
                else
                {
                    MessageBox.Show("Пользователь не найден.");
                }
            }
            else
            {
                MessageBox.Show("Сначала создайте аккаунта ;)");
            }
        }

        private void LoadInformationUser()
        {
            DBControll db = new DBControll();

            if (UserSession.IsLoggedIn)
            {
                string loginCurrentUser = UserSession.CurrentUserLogin;
                var userData = db.GetUserData(loginCurrentUser);

                if (userData != null)
                {
                    Name_TextBox.Text = userData.nickname;
                    SetUsersNameLabel(userData.nickname);

                    Login_TextBox.Text = loginCurrentUser;
                    Password_TextBox.Text = userData.password;
                    Email_TextBox.Text = userData.email;
                }
            }
        }

        private void Out_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.CloseProgramm();
        }

        private void SetUsersNameLabel(string nameCurrent)
        {
            UsersName_TextBlock.Text = nameCurrent;
        }

        private void editName_Click(object sender, RoutedEventArgs e)
        {
            Name_TextBox.IsReadOnly = false;
            Name_TextBox.Focus();
        }
        private void Name_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) 
            {
                string nickname = Name_TextBox.Text;

                DBControll db = new DBControll();

                string loginCurrentUser = UserSession.CurrentUserLogin;
                int? currentUserId = db.GetCurrentUserID(loginCurrentUser);

                db.EditNameUsers(nickname, currentUserId);

                Name_TextBox.IsReadOnly = true;
            }
        }

        private void editPassword_Click(object sender, RoutedEventArgs e)
        {
            Password_TextBox.IsReadOnly = false;
            Password_TextBox.Focus();
        }
        private void Password_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string nickname = Password_TextBox.Text;

                DBControll db = new DBControll();

                string loginCurrentUser = UserSession.CurrentUserLogin;
                int? currentUserId = db.GetCurrentUserID(loginCurrentUser);

                db.EditPasswordUsers(nickname, currentUserId);

                Password_TextBox.IsReadOnly = true;
            }
        }
    }
}
