using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Configuration;
using Npgsql;
using System.Windows;
using Npgsql.Internal;
using System.Windows.Media.Media3D;
using GeckoMarket.Views;
using Avalonia.Styling;

namespace GeckoMarket.DataBase
{
    public class DBControll 
    {
        //private static string connectionString = ConfigurationManager.ConnectionStrings["GeckoMarketDB"].ConnectionString; 
        private static string connectionString = "host=localhost port=5432 dbname=GeckoMarket user=postgres password=root";
        NpgsqlConnection sqlConnection = new NpgsqlConnection(connectionString);

        private void Connection() 
        {
            try
            {
                sqlConnection.Open();
                Console.WriteLine("Succesful connection!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //sqlConnection.Close(); - закрывать соединение с БД в каждом методе.

        public void SetCatalog()
        {
            //Connection();
            sqlConnection.Open();

            NpgsqlCommand command = new NpgsqlCommand(); 
            command.Connection = sqlConnection;
            command.CommandType = CommandType.Text; // тип комманд - передача/получения текстовых запросов.
            command.CommandText = "SELECT * FROM public.\"Catalog\"";

            NpgsqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.HasRows) // содержит ли dataReader 1 или несколько строк. 
            {
                DataTable dataTable = new DataTable(); //представить данные в виде таблицы
                dataTable.Load(dataReader);

                CatalogPage catalogPage = new CatalogPage();
                catalogPage.Catalog_DataGrid.ItemsSource = (System.Collections.IEnumerable)dataTable;
            }
            
            command.Dispose();
            sqlConnection.Close();
        }

    }
}

