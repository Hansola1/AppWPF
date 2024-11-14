using System;
using System.Windows;
using System.Windows.Controls;
using GeckoMarket.DataBase;

namespace GeckoMarket.Views
{
    public partial class CatalogPage : Page
    {
        public CatalogPage()
        {
            InitializeComponent();
            LoadCatalogDataAsync();
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

        private async void LoadCatalogDataAsync()
        {
            DBControll db = new DBControll();
            List<CatalogData> catalogDatas = await Task.Run(() => db.GetCatalogData());

            Dispatcher.Invoke(() =>
            {
                Catalog_DataGrid.ItemsSource = catalogDatas;
            });
        }

        private void AddInBasket_Click(object sender, RoutedEventArgs e)
        {
            BasketPage basketPage = new BasketPage();

            if (UserSession.Visitor == true)
            {
                MessageBox.Show("Создайте аккаунт!!!");
                MainFrame.Navigate(new RegistrationPage());
            }
            else
            {
                
            }
        }
    }
}
