using System;
using System.Collections.Generic;
using System.Data;
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

namespace CalculatorAppWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void num_Click(object sender, RoutedEventArgs e)//EventArgs e)
        {
            Button b = (Button)sender;
            if (output.Text == "0")
            {
                output.Clear();
            }
            if (b.Content.ToString() == "C") // clear_Click, content не работает b.Content == "C"
            {
                output.Clear();
            }
            if (output.Text == ".")
            {
                output.Text = Convert.ToDouble(output.Text).ToString();
            }
            else
            {
                output.Text = output.Text + b.Content;
            }
        }

        private void calculator_Click(object sender, EventArgs e)
        {
            Button operat = (Button)sender;
            try
            {
                if (operat.Content.ToString() == "/" || operat.Content.ToString() == "+" || operat.Content.ToString() == "-" || operat.Content.ToString() == "*")
                {
                    output.Text = output.Text + operat.Content;
                }
                if (output.Text == "/0")
                {
                    if (operat.Content.ToString() == "=")
                    {
                        output.Text = "Деление на ноль невозможно";
                    }
                }

                if (operat.Content.ToString() == "=")
                {
                    output.Text = new DataTable().Compute(output.Text, null).ToString();
                }
            }
            catch (DivideByZeroException)
            {
                {
                    output.Text = "Деление на ноль невозможно";
                }
            }
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
           output.Clear();
           output.Text = "0";
        }
    }
}
