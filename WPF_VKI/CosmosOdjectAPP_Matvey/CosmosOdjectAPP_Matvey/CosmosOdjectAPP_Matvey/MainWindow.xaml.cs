using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.ComponentModel;
using System.Windows.Data;

namespace CosmosOdjectAPP_Matvey
{
    public partial class MainWindow : Window
    {
        public List<StarData> allStar;
        public List<StarData> filteredStar;

        public MainWindow()
        {
            InitializeComponent();
            LoadDataFromFile();

            filteredStar = allStar;
            Information_ListView.ItemsSource = filteredStar;
        }
        public void LoadDataFromFile()
        {
            allStar = new List<StarData>();
            string filePath = "D:\\С# и С++ и HTML\\CosmosOdjectAPP_Matvey\\CosmosOdjectAPP_Matvey\\CosmosOdjectAPP_Matvey\\CosmoObject.txt";

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] data = line.Split('_');
                    if (data.Length == 4)
                    {
                        StarData star = new StarData
                        {
                            NumStar = data[0],
                            NameStar = data[1],
                            Distance = data[2],
                            TypeStar = data[3]
                        };
                        allStar.Add(star);
                    }
                }
            }
        }

        private void AddStar_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddStar addStar = new AddStar();
            addStar.Show();
        }

        public void AddStarForForm(StarData newStar)
        {
            allStar.Add(newStar);

            string filePath = "D:\\С# и С++ и HTML\\CosmosOdjectAPP_Matvey\\CosmosOdjectAPP_Matvey\\CosmosOdjectAPP_Matvey\\CosmoObject.txt";
            string newLine = $"{newStar.NumStar}_{newStar.NameStar}_{newStar.Distance}_{newStar.TypeStar}";
            File.AppendAllLines(filePath, new[] { newLine });

            if (SortStar_ComboBox.SelectedItem.ToString() == "Все типы звезд" || newStar.TypeStar == SortStar_ComboBox.SelectedItem.ToString())
            {
                filteredStar.Add(newStar);
            }
            Information_ListView.ItemsSource = filteredStar;

            this.Show();
        }

        private void DeletStar_Button_Click(object sender, RoutedEventArgs e)
        {

            StarData selectedStar = (StarData)Information_ListView.SelectedItem;
            if (selectedStar != null)
            {
                allStar.Remove(selectedStar);

                string filePath = "D:\\С# и С++ и HTML\\CosmosOdjectAPP_Matvey\\CosmosOdjectAPP_Matvey\\CosmosOdjectAPP_Matvey\\CosmoObject.txt";
                 string[] lines = File.ReadAllLines(filePath);

                 List<string> newLines = lines.Where(line => !line.StartsWith(selectedStar.NumStar + "_")).ToList();
                 File.WriteAllLines(filePath, newLines);
                 

                Information_ListView.Items.Refresh();
                Information_ListView.ItemsSource = filteredStar;
            }
            else
            {
                MessageBox.Show("Выберите звезду для удаления.");
            }
        }

        public void FindStar_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = FindStar_TextBox.Text.ToLower();
            filteredStar = allStar.Where(star => star.NameStar.ToLower().Contains(searchText) || star.TypeStar.ToLower().Contains(searchText)).ToList();
            Information_ListView.ItemsSource = filteredStar;
        }

        public void SortStar_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedType = (string)((ComboBoxItem)SortStar_ComboBox.SelectedItem).Content;

            if (selectedType != "Все типы звезд")
            {
                List<StarData> orderFile = new List<StarData>();
                allStar.ForEach(star =>
                {
                    if (star.TypeStar == selectedType)
                    {
                        orderFile.Add(star);
                    }
                });
                Information_ListView.ItemsSource = orderFile;
            }
            else
            {
                Information_ListView.ItemsSource = allStar;
            }
        }
    }
}
