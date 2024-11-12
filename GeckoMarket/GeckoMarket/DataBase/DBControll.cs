using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using Npgsql;
using System.Windows;
using Npgsql.Internal;
using GeckoMarket.Views;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GeckoMarket.DataBase
{
    public class DBControll
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["GeckoMarket"].ConnectionString; 
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

        public List<CatalogData> GetCatalogData()
        {
            List<CatalogData> catalogDataList = new List<CatalogData>();
            Connection();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM public.\"Catalog\"", sqlConnection);
            NpgsqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                CatalogData catalogData = new CatalogData(dataReader["CatalogID"].ToString(), dataReader["TypeReptile"].ToString(),
                    dataReader["SexReptile"].ToString(), dataReader["MorphReptile"].ToString(),Convert.ToInt32(dataReader["CostReptile"])
                );
                catalogDataList.Add(catalogData);
            }    
            sqlConnection.Close(); 

            return catalogDataList;
        }

        public void AddUsers(string login, string password, string email)
        {
            Connection();

            RegistrationPage registrationPage = new RegistrationPage();

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = sqlConnection;

            command.CommandText = "INSERT INTO public.\"Users\" (\"login\", \"password\", \"email\") VALUES (@login, @password, @email)";
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@email", email);

            command.ExecuteNonQuery(); // Выполнить команду
           
            sqlConnection.Close();
        }

        public bool UserExists(string login)
        {
            Connection();

            try
            {
                NpgsqlCommand command = new NpgsqlCommand("SELECT COUNT(*) FROM public.\"Users\" WHERE \"login\" = @login", sqlConnection);
                command.Parameters.AddWithValue("@login", login);

                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0; // Если найден хотя бы один пользователь, возвращаем true
                
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public bool dateVerification(string login, string password)
        {
            Connection();

            try
            {
                NpgsqlCommand command = new NpgsqlCommand("SELECT COUNT(*) FROM public.\"Users\" WHERE \"login\" = @login AND \"password\" = @password", sqlConnection);
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);

                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0; 

            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}