using System.Windows;
using System.Windows.Controls;
using GeckoMarket.DataBase;

namespace GeckoMarket.Views
{
    public partial class BasketPage : Page
    {
        public List<BasketData> basketData { get; set; } = new List<BasketData>();

        public BasketPage()
        {
            InitializeComponent();
            LoadBasketItems();
            SetUsersNameLabel();
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
        private void Out_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.CloseProgramm();
        }

        public void LoadBasketItems()
        {
            if (UserSession.IsLoggedIn == false)
            {
                MessageBox.Show("Создайте аккаунт!!!");
                MainFrame.Navigate(new RegistrationPage());
            }
            else
            {
                LoadBasketItemsFromDatabase();
            }
        }

        private void LoadBasketItemsFromDatabase()
        {
            DBControll db = new DBControll();

            string loginCurrentUser = UserSession.CurrentUserLogin;
            int? CurrentUserId = db.GetCurrentUserID(loginCurrentUser);

            basketData = db.GetBasketItems(CurrentUserId); 
            Basket_DataGrid.ItemsSource = basketData;
        }

        private void CreatOrder_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = Basket_DataGrid.SelectedItem as BasketData;
            if (selectedItem != null)
            {
                if (UserSession.IsLoggedIn == false)
                {
                    MessageBox.Show("Создайте аккаунт!!!");
                    MainFrame.Navigate(new RegistrationPage());
                }
                else
                {
                    MainFrame.Navigate(new PlaceOrder(selectedItem));
                }
            }
            else
            {
                MessageBox.Show("Выберите товар!");
            }
        }

        public void SetUsersNameLabel()
        {
            DBControll db = new DBControll();

            if (UserSession.IsLoggedIn)
            {
                string loginCurrentUser = UserSession.CurrentUserLogin;
                var userData = db.GetUserData(loginCurrentUser);

                if (userData != null)
                {
                    UsersName_TextBlock.Text = userData.nickname;
                }
            }
        }
    }
}
