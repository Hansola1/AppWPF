using GeckoMarket.DataBase;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace GeckoMarket.Views
{
    public partial class PlaceOrder : Page
    {
        public PlaceOrder()
        {
            InitializeComponent();
        }

        private void cancel_click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new BasketPage());
        }

        private void confirm_click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(card_TextBox.Text))
            {
                BasketPage basket = new BasketPage();
                var selectedItem = basket.Basket_DataGrid.SelectedItem as BasketData; // разобраться почему всегда нулевой,хотя выбрали же

                if (selectedItem != null)
                {
                    placeAnOrder(selectedItem);
                    MessageBox.Show("Заказ успешно оформлен!");
                }
                else
                {
                    MessageBox.Show("Выберете товар!");
                }
            }
            else
            {
                MessageBox.Show("Введите данные карты...");
            }
        }

        public void placeAnOrder(BasketData selectedItem)
        {
            DBControll db = new DBControll();
            int? BasketID = db.GetBasketID(selectedItem.CatalogID);
    
            db.DeleteOrder(selectedItem.CatalogID, BasketID.Value); //Value штоб не мучатся из-за инт?
        }
    }
}
