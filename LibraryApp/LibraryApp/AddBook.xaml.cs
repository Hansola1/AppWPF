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
    public partial class AddBook : Window
    {
        MainWindow mainWindow = new MainWindow();
        public AddBook()
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
            string numBook = NumBook_TextBox.Text;
            string nameBook = NameBook_TextBox.Text;
            string author = Author_TextBox.Text;
            string genre = Genre_TextBox.Text;

            BookData newBook = new BookData
            {    
                Number = numBook,
                Title = nameBook,
                Author = author,
                Genre = genre
            };
            this.Hide();
            mainWindow.AddBookForForm(newBook);
           // mainWindow.Show();
        }
    }    
}
