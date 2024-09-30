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
            Parent maleParent = CreateParent(
              EnigmaMale_ComboBox.SelectedItem?.ToString() ?? "Не выбрано",
              WhiteYellowMale_ComboBox.SelectedItem?.ToString() ?? "Не выбрано",
              MackSnowMale_ComboBox.SelectedItem?.ToString() ?? "Не выбрано", "Не выбрано", "Не выбрано", "Не выбрано"
              );


          Parent femaleParent = CreateParent(
                EnigmaFemale_ComboBox.SelectedItem?.ToString() ?? "Не выбрано",
                WhiteYellowFemale_ComboBox.SelectedItem?.ToString() ?? "Не выбрано",
                MackSnowFemale_ComboBox.SelectedItem?.ToString() ?? "Не выбрано", "Не выбрано", "Не выбрано", "Не выбрано"
                );


            List<Result> results = CalculateGenotype.Calculate(maleParent, femaleParent);
            printResult(results);
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

        private Parent CreateParent(string dominant1, string dominant2, string coDominant1, string coDominant2, string recessive1, string recessive2)
        {
            List<Gen> gens = new List<Gen>();
            List<bool> hetStatus = new List<bool>();

            if (dominant1 != "Не выбрано")
            { AddGen(gens, hetStatus, dominant1, Gen.TypeGenEnum.Dominant); }
            if (dominant2 != "Не выбрано")
            { AddGen(gens, hetStatus, dominant2, Gen.TypeGenEnum.Dominant);  }
            if (coDominant1 != "Не выбрано")
            { AddGen(gens, hetStatus, coDominant1, Gen.TypeGenEnum.CoDominant);  }
            if (coDominant1 != "Не выбрано")
            { AddGen(gens, hetStatus, coDominant1, Gen.TypeGenEnum.CoDominant); }
            if (coDominant2 != "Не выбрано")
            { AddGen(gens, hetStatus, coDominant2, Gen.TypeGenEnum.CoDominant); }
            if (recessive1 != "Не выбрано")
            { AddGen(gens, hetStatus, recessive1, Gen.TypeGenEnum.Recessive); }
            if (recessive2 != "Не выбрано")
            { AddGen(gens, hetStatus, recessive2, Gen.TypeGenEnum.Recessive); }
          
            return new Parent(gens, hetStatus);
        }

        private void AddGen(List<Gen> gens, List<bool> hetStatus, string name, Gen.TypeGenEnum type)
        {
            if (!string.IsNullOrEmpty(name))
            {
                gens.Add(new Gen(name, type));
                hetStatus.Add(false);
            }
        }
    }
}