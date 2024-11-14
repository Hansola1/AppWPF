using GeckoMarket.DataBase;
using System.Windows;
using System.Windows.Controls;

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
                    Login_TextBox.Text = loginCurrentUser;
                    Password_TextBox.Text = userData.password;
                    Email_TextBox.Text = userData.email;
                }
            }
        }
    }
}
