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
using System.Windows.Shapes;

namespace CosmosOdjectAPP_Matvey
{
    public partial class AddStar : Window
    {
        MainWindow mainWindow = new MainWindow();
        public AddStar()
        {
            InitializeComponent();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            mainWindow.Show();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string numStar = NumStar_TextBox.Text;
            string nameStar = NameStar_TextBox.Text;
            string distance = Distance_TextBox.Text;
            string typeStar = TypeStar_TextBox.Text;

            StarData newStar = new StarData
            {
                NumStar = numStar,
                NameStar = nameStar,
                Distance = distance,
                TypeStar = typeStar
            };
            this.Hide();
            mainWindow.AddStarForForm(newStar);
        }
    }
}
