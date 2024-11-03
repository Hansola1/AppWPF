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

namespace TestLoveForEublefar
{
    /// <summary>
    /// Логика взаимодействия для result.xaml
    /// </summary>
    public partial class result : Window
    {
        public result()
        {
            InitializeComponent();
        }

       /* void answ()
        {
            double percentage = (double)MainWindow.correctAnswersCount / MainWindow.questions.Length * 100;
            for (int i = 1; i <= 2;)
           {
                answerr.Text += percentage;
                i++;
            }
            // MessageBox.Show($"Вы ответили правильно на {percentage}% вопросов.");
        }

        private void res_click(object sender, RoutedEventArgs e)
        {
            answ();
        } */
    }
}
