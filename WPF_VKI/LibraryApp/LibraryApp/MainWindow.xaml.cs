using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.ComponentModel;
using System.Windows.Data;

namespace LibraryApp
{
    public partial class MainWindow : Window
    {
        public List<BookData> allBooks;
        public List<BookData> filteredBooks;

        public MainWindow()
        {
            InitializeComponent();
            LoadDataFromFile();

            filteredBooks = allBooks; 
            Information_ListView.ItemsSource = filteredBooks;
        }

        public void LoadDataFromFile()
        {
            allBooks = new List<BookData>();
            string filePath = "D:\\С# и С++ и HTML\\C#\\Приложение WPF по вариантам\\LibraryApp\\LibraryApp\\Books.txt"; 

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] data = line.Split('_');
                    if (data.Length == 4)
                    {
                        BookData book = new BookData
                        {
                            Number = data[0], Title = data[1], Author = data[2], Genre = data[3]
                        };
                        allBooks.Add(book);
                    }
                }
                //Information_ListView.ItemsSource = allBooks;
            }
        }

        private void AddBook_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddBook addBook = new AddBook();
            addBook.Show();
        }

        public void AddBookForForm(BookData newBook)
        {
            allBooks.Add(newBook);

            string filePath = "D:\\С# и С++ и HTML\\C#\\Приложение WPF по вариантам\\LibraryApp\\LibraryApp\\Books.txt";
            string newLine = $"{newBook.Number}_{newBook.Title}_{newBook.Author}_{newBook.Genre}";
            File.AppendAllLines(filePath, new[] { newLine });


            if (SortBook_ComboBox.SelectedItem.ToString() == "Все жанры" || newBook.Genre == SortBook_ComboBox.SelectedItem.ToString())
            {
                filteredBooks.Add(newBook);
            }
            Information_ListView.ItemsSource = filteredBooks;

            this.Show();
        }


        private void DeletBook_Button_Click(object sender, RoutedEventArgs e)
        {
          
            BookData selectedBook = (BookData)Information_ListView.SelectedItem;
            if (selectedBook != null)
            {
                allBooks.Remove(selectedBook);

                /* string filePath = "D:\\С# и С++ и HTML\\C#\\Приложение WPF по вариантам\\LibraryApp\\LibraryApp\\Books.txt";
                 string[] lines = File.ReadAllLines(filePath);

                 List<string> newLines = lines.Where(line => !line.StartsWith(selectedBook.Number + "_")).ToList();
                 File.WriteAllLines(filePath, newLines);
                 */ // ШОБ НЕ ЧИСТИТЬ ФАЙЛ. я устала его восстанавливать... 

                Information_ListView.Items.Refresh();
                Information_ListView.ItemsSource = filteredBooks;
            }
            else
            {
                MessageBox.Show("Выберите книгу для удаления.");
            }       
        }


        public void FindBook_TextBox_TextChanged(object sender, TextChangedEventArgs e) 
        {
            string searchText = FindBook_TextBox.Text.ToLower();
            filteredBooks = allBooks.Where(book => book.Title.ToLower().Contains(searchText) || book.Author.ToLower().Contains(searchText)).ToList(); 
            Information_ListView.ItemsSource = filteredBooks;
        }

        public void SortBook_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedGenre = (string)((ComboBoxItem)SortBook_ComboBox.SelectedItem).Content; 

            if (selectedGenre != "Все жанры")
            { 
                List<BookData> orderFile = new List<BookData>();
                allBooks.ForEach(book =>
                {
                    if (book.Genre == selectedGenre)
                    {
                        orderFile.Add(book);
                    }
                });
                Information_ListView.ItemsSource = orderFile;
            }
            else
            {
                Information_ListView.ItemsSource = allBooks;
            }
        }

    }
}
