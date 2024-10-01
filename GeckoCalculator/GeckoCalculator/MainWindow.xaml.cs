using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GeckoCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void apply_click(object sender, RoutedEventArgs e)
        {
           
            //List<Result> results = CalculateGenotype.Calculate(maleParent, femaleParent);
            //printResult(results);
        }


        private void printResult(List<Result> results)
        {
            string resultString = "Результаты:n";
            foreach (Result result in results)
            {
                resultString += $" - {result.Number}. {result.Probability}% - {result.Morph}n";
            }
            MessageBox.Show(resultString);
        }
    }
}