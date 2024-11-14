using GeckoMarket.DataBase;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace GeckoMarket.Views
{
    public partial class BasketPage : Page
    {
        public List<BasketData> basketData { get; set; }

        public BasketPage()
        {
            InitializeComponent();
            basketData = new List<BasketData>();
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
        private void CreatOrder_Click(object sender, RoutedEventArgs e)
        {
            if (UserSession.Visitor == true)
            {
                MessageBox.Show("Создайте аккаунт!!!");
                MainFrame.Navigate(new RegistrationPage());
            }
        }
    }
}
