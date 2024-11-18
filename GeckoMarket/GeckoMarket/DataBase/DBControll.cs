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

            while (dataReader.Read()) // Проверяем, есть ли данные
            {
                CatalogData catalogData = new CatalogData(Convert.ToInt32(dataReader["CatalogID"]), dataReader["TypeReptile"].ToString(),
                    dataReader["SexReptile"].ToString(), dataReader["MorphReptile"].ToString(),Convert.ToInt32(dataReader["CostReptile"])
                );
                // каталог айди на самом деле айди товара, переименовать надо
                catalogDataList.Add(catalogData);
            }    
            sqlConnection.Close(); 

            return catalogDataList;
        }

        public void AddUsers(string nickname, string login, string password, string email)
        {
            Connection();

            RegistrationPage registrationPage = new RegistrationPage();

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = sqlConnection;

            command.CommandText = "INSERT INTO public.\"Users\" (\"nickname\", \"login\", \"password\", \"email\") VALUES (@nickname, @login, @password, @email)";
            command.Parameters.AddWithValue("@nickname", nickname); //берем значениe из бд и в строку :)
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

        public bool dateVerification(string login, string password) //отметить здесь что я вошла в аккаунта
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

        public UsersData GetUserData(string login)
        {
            Connection();

            UsersData userData = null;

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = sqlConnection;

            command.CommandText = "SELECT \"nickname\", \"password\", \"email\" FROM public.\"Users\" WHERE \"login\" = @login";
            command.Parameters.AddWithValue("@login", login);

            NpgsqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                userData = new UsersData()
                {
                    nickname = reader["nickname"].ToString(),
                    password = reader["password"].ToString(),
                    email = reader["email"].ToString(),
                };
            }

            sqlConnection.Close();
            return userData;
        }

        public void DeleteUsers(int? UserID)
        {
            Connection();

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = sqlConnection;

            command.CommandText = "DELETE FROM public.\"Users\" WHERE \"UserID\" = @UserID";
            command.Parameters.AddWithValue("@UserID", UserID); 
            command.ExecuteNonQuery(); 

            sqlConnection.Close();
        }

        public int? GetCurrentUserID(string login)
        {
            Connection();

            try
            {
                using (NpgsqlCommand command = new NpgsqlCommand()) 
                {
                    command.Connection = sqlConnection;
                    command.CommandText = "SELECT \"UserID\" FROM public.\"Users\" WHERE \"login\" = @login";
                    command.Parameters.AddWithValue("@login", login);

                    using (NpgsqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            return dataReader.GetInt32(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении UserID: {ex.Message}");
            }
            finally
            {
                sqlConnection.Close();
            }

            return null;
        }
    }
}