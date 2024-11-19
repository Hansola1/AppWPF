using Avalonia.Controls;
using GeckoMarket.DataBase;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace GeckoMarket.Views
{
    public partial class BasketPage : Page
    {
        public List<BasketData> basketData { get; set; } = new List<BasketData>();

        public BasketPage()
        {
            InitializeComponent();
            LoadBasketItems();
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
            LoadBasketItemsFromDatabase();
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
                if (UserSession.Visitor == true)
                {
                    MessageBox.Show("Создайте аккаунт!!!");
                    MainFrame.Navigate(new RegistrationPage());
                }
                else
                { 
                    MainFrame.Navigate(new PlaceOrder());
                }
            }
        }
    }
}
