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
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

namespace TestLoveForEublefar
{
    public partial class MainWindow : Window
    {
        public int correctAnswersCount = 0;
        public static string[] questions;
        public int currentQuestionIndex;

        public MainWindow()
        {
            InitializeComponent();
            LoadQuestionsFromFile("D:\\С# и С++\\Приложения WPF\\TestLoveForEublefar\\TestLoveForEublefar\\questionAndanswer.txt");// ("questionAndanswer.txt"); 
            DisplayQuestion();
        }
        private void LoadQuestionsFromFile(string filePath)
        {
            Encoding win1251 = Encoding.GetEncoding("windows-1251");
            questions = File.ReadAllLines(filePath, win1251);
        }

        private void DisplayQuestion()
        {
            if (currentQuestionIndex < questions.Length)
            {
                string[] questionData = questions[currentQuestionIndex].Split('|');
                quest.Text = questionData[0];

                answersPanel.Children.Clear();
                for (int i = 1; i < questionData.Length - 1; i++)
                {
                    RadioButton radioButton = new RadioButton();
                    radioButton.Content = questionData[i];

                    answersPanel.Children.Add(radioButton);
                }
            }
            else
            {
                /*result resultWin = new result();
                this.Close();
                resultWin.Show();*/
                double percentage = correctAnswersCount / questions.Length * 100;
                MessageBox.Show($"Вы ответили правильно на {percentage}% вопросов.");
            }
        }


        private void ok_click(object sender, RoutedEventArgs e)
        {
            RadioButton selectedAnswer = answersPanel.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);

            for (int i = 0; i < questions.Length; i++)
            {
                if (selectedAnswer != null)
                {
                    string selectedAnswerText = selectedAnswer.Content.ToString();
                    string correctAnswerText = questions[currentQuestionIndex].Split('|')[currentQuestionIndex];

                    if (selectedAnswerText == correctAnswerText)
                    {
                        correctAnswersCount++;
                    }
                }
                currentQuestionIndex++;
            }

            progressBar.Value = (double)currentQuestionIndex / questions.Length * 100;
            DisplayQuestion();
        }
    }
}
