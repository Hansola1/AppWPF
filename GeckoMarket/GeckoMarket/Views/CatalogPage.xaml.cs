using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using GeckoMarket.DataBase;


namespace GeckoMarket.Views
{
    public partial class CatalogPage : Page
    {
        public CatalogPage()
        {
            InitializeComponent();

            DBControll db = new DBControll();
            db.SetCatalog();

            /*List<Animals> animal = new List<Animals>();
            animal.Add(new Animals { Number = 1, Type = "Eublefar", Morph = "Normal het TA", Sex = "Male", Cost = "1000$" });
            Catalog_DataGrid.ItemsSource = animal;*/
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
    }

    /*public class Animals //БД
    {
        public int Number { get; set; }
        public string Type { get; set; }
        public string Morph { get; set; }
        public string Sex { get; set; }
        public string Cost { get; set; }
    }*/
}
