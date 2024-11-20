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
        private void Out_ButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.CloseProgramm();
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
            var selectedItem = Catalog_DataGrid.SelectedItem as CatalogData; //забираем выбранный элемент мы же в чек бокс отметили))))))
                                                                             //as СatalogData приводим к типу
            if (UserSession.Visitor == true)
            {
                MessageBox.Show("Создайте аккаунт!!!");
                MainFrame.Navigate(new RegistrationPage());
            }
            else
            {
                if (selectedItem != null)
                {
                    AddItemToBasket(selectedItem);

                    BasketPage basket = new BasketPage();
                    basket.LoadBasketItems();
                }
                else
                {
                    MessageBox.Show("Выберите товар для добавления в корзину!");
                }
            }
        }

        private void AddItemToBasket(CatalogData selectedItem)
        {
            BasketPage basketPage = new BasketPage();

            var basketItem = new BasketData(selectedItem.CatalogID, selectedItem.TypeReptile, selectedItem.SexReptile, selectedItem.MorphReptile, selectedItem.CostReptile);

            if (!IsItemInBasket(selectedItem)) 
            {
                SaveBasketItemToDatabase(basketItem);
                basketPage.LoadBasketItems();
            }
            else
            {
                MessageBox.Show("Этот товар уже есть в вашей корзине."); 
            }
        }

        private bool IsItemInBasket(CatalogData selectedItem)
        {
            DBControll db = new DBControll();

            string loginCurrentUser = UserSession.CurrentUserLogin;
            int? currentUserId = db.GetCurrentUserID(loginCurrentUser);

            List<BasketData> currentBasketItems = db.GetBasketItems(currentUserId);

            foreach (var item in currentBasketItems)
            {
                if (item.CatalogID == selectedItem.CatalogID)
                {
                    return true;
                }
            }
            return false; 
        }

        private void SaveBasketItemToDatabase(BasketData basketItem)
        {
            DBControll db = new DBControll();

            string loginCurrentUser = UserSession.CurrentUserLogin;
            int? сurrentUserId = db.GetCurrentUserID(loginCurrentUser);

            db.AddToBasket(basketItem.CatalogID, сurrentUserId, basketItem.TypeReptile, basketItem.SexReptile, basketItem.MorphReptile, basketItem.CostReptile);
        }
    }
}
