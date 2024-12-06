using System.Windows;
using System.Windows.Controls;
using GeckoMarket.DataBase;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace GeckoMarket.Views
{
    public partial class PlaceOrder : Page
    {
        private BasketData selectedItem;
        public PlaceOrder(BasketData selectedItem)
        {
            InitializeComponent();
            this.selectedItem = selectedItem;
        }

        private void cancel_click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new BasketPage());
        }

        private void confirm_click(object sender, RoutedEventArgs e)
        {
            if (validationData() != false)
            {
                //var selectedItem = basket.Basket_DataGrid.SelectedItem as BasketData; // всегда null?!

                if (selectedItem != null)
                {
                    placeAnOrder(selectedItem);
                    MessageBox.Show("Заказ успешно оформлен!");

                    MainFrame.Navigate(new BasketPage());
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

        private bool validationData()
        {
            string card = card_TextBox.Text.Trim();
            string dataCard = dataCard_TextBox.Text.Trim(); 
            string CVC = CVC_TextBox.Text.Trim();
            string address = address_TextBox.Text.Trim();

            if(card.Length < 16 || string.IsNullOrWhiteSpace(card_TextBox.Text)) // карты стандартно 16 символов имеют
            {
                MessageBox.Show("Введите счет корректно");
                return false;
            }
            if (CVC.Length > 3 || string.IsNullOrWhiteSpace(CVC_TextBox.Text))
            {
                MessageBox.Show("Введите CVC корректно");
                return false ;
            }
            if (dataCard.Length < 10 || string.IsNullOrWhiteSpace(dataCard_TextBox.Text))
            {
                MessageBox.Show("Введите срок действия карты корректно");
                return false;
            }
            if(string.IsNullOrWhiteSpace(address_TextBox.Text))
            {
                MessageBox.Show("Введите адрес карты корректно");
                return false;
            }
            return true;
        }

        public void placeAnOrder(BasketData selectedItem)
        {
            DBControll db = new DBControll();

            int? BasketID = db.GetBasketID(selectedItem.CatalogID);
            //int? OrderID = db.GetOrderID(selectedItem.CatalogID);

            string loginCurrentUser = UserSession.CurrentUserLogin;
            int? CurrentUserId = db.GetCurrentUserID(loginCurrentUser);

            db.AddToOrder(CurrentUserId, selectedItem.TypeReptile, selectedItem.SexReptile, selectedItem.MorphReptile, selectedItem.CostReptile); //BasketID.Value);
            db.DeleteOrder(selectedItem.CatalogID, BasketID.Value); //Value штоб не мучатся из-за инт?
        }
    }
}
