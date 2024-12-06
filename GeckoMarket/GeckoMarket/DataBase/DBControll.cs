using System.Configuration;
using Npgsql;
using System.Windows;
using Npgsql.Internal;
using GeckoMarket.Views;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
                    dataReader["SexReptile"].ToString(), dataReader["MorphReptile"].ToString(), Convert.ToInt32(dataReader["CostReptile"])
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

        public void AddToBasket(int catalogID, int? userID, string typeReptile, string sexReptile, string morphReptile, int costReptile)
        {
            Connection();

            using (NpgsqlCommand command = new NpgsqlCommand())
            {
                command.Connection = sqlConnection;
                command.CommandText = "INSERT INTO public.\"Basket\" (\"CatalogID\", \"UsersID\", \"TypeReptile\", \"SexReptile\", \"MorphReptile\", \"CostReptile\") VALUES (@catalogID, @userID, @typeReptile, @sexReptile, @morphReptile, @costReptile)";
                command.Parameters.AddWithValue("@catalogID", catalogID);
                command.Parameters.AddWithValue("@userID", userID);
                command.Parameters.AddWithValue("@typeReptile", typeReptile);
                command.Parameters.AddWithValue("@sexReptile", sexReptile);
                command.Parameters.AddWithValue("@morphReptile", morphReptile);
                command.Parameters.AddWithValue("@costReptile", costReptile);

                command.ExecuteNonQuery();
            }
        }

        public List<BasketData> GetBasketItems(int? userID)
        {
            List<BasketData> items = new List<BasketData>();

            Connection();

            using (NpgsqlCommand command = new NpgsqlCommand("SELECT \"CatalogID\", \"TypeReptile\", \"SexReptile\", \"MorphReptile\", \"CostReptile\" FROM public.\"Basket\" WHERE \"UsersID\" = @userID", sqlConnection))
            {
                command.Parameters.AddWithValue("@userID", userID);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new BasketData(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetInt32(4)
                        ));
                    }
                }
                
            }
            return items;
        }

        public void DeleteOrder(int catalogID, int basketID)
        {
            Connection();

            using (var transaction = sqlConnection.BeginTransaction())
            {
                // Использую транзакцию чтоб удалить все записи из Basket, которые ссылаются на Catalog.
                // Чтоб не случилось, што я удалила связанную запись в одной таблц, а в другой осталось. Либо да все снесем, либо нет ничего!

                // а иначе ошибка Npgsql.PostgresException: "23503: UPDATE или DELETE в таблице "Catalog" нарушает ограничение внешнего ключа ...

                try
                {
                    using (var basketCommand = new NpgsqlCommand("DELETE FROM public.\"Basket\" WHERE \"CatalogID\" = @CatalogID", sqlConnection, transaction))
                    {
                        basketCommand.Parameters.AddWithValue("@CatalogID", catalogID);
                        basketCommand.ExecuteNonQuery();
                    }

                    using (var catalogCommand = new NpgsqlCommand("DELETE FROM public.\"Catalog\" WHERE \"CatalogID\" = @CatalogID", sqlConnection, transaction))
                    {
                        catalogCommand.Parameters.AddWithValue("@CatalogID", catalogID);
                        catalogCommand.ExecuteNonQuery();
                    }

                    transaction.Commit(); // Подтверждаем транзакцию
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // Откатываем транзакцию в случае ошибки
                    MessageBox.Show($"Ошибка при удалении заказа: {ex.Message}");
                }
            }
        }

        public int? GetBasketID(int catalogID)
        {
            Connection();

            try
            {
                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = sqlConnection;
                    command.CommandText = "SELECT \"ID\" FROM public.\"Basket\" WHERE \"CatalogID\" = @catalogID";
                    command.Parameters.AddWithValue("@catalogID", catalogID);

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
                MessageBox.Show($"Ошибка при получении ID: {ex.Message}");
            }
            finally
            {
                sqlConnection.Close();
            }

            return null;
        }

        public void EditNameUsers(string nickname, int? UserID) 
        {
            Connection();

            using (var transaction = sqlConnection.BeginTransaction())
            {
                try
                {
                    using (var basketCommand = new NpgsqlCommand("UPDATE public.\"Users\" SET \"nickname\" = @nickname WHERE \"UserID\" = @UserID", sqlConnection, transaction))
                    {
                        basketCommand.Parameters.AddWithValue("@nickname", nickname);
                        basketCommand.Parameters.AddWithValue("@UserID", UserID);
                        basketCommand.ExecuteNonQuery();
                    }

                    transaction.Commit(); 
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); 
                    MessageBox.Show($"Ошибка при  изменении имени: {ex.Message}");
                }
            }
        }

        public void EditPasswordUsers(string password, int? UserID)
        {
            Connection();

            using (var transaction = sqlConnection.BeginTransaction())
            {
                try
                {
                    using (var basketCommand = new NpgsqlCommand("UPDATE public.\"Users\" SET \"password\" = @password WHERE \"UserID\" = @UserID", sqlConnection, transaction))
                    {
                        basketCommand.Parameters.AddWithValue("@password", password);
                        basketCommand.Parameters.AddWithValue("@UserID", UserID);
                        basketCommand.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Ошибка при  изменении пароля: {ex.Message}");
                }
            }
        }

        public List<OrderData> GetOrdersItems(int? userID)
        {
            List<OrderData> items = new List<OrderData>();

            Connection();

            using (NpgsqlCommand command = new NpgsqlCommand("SELECT \"OrderID\", \"UsersID\", \"TypeReptile\", \"SexReptile\", \"MorphReptile\", \"CostReptile\" FROM public.\"Orders\" WHERE \"UsersID\" = @userID", sqlConnection))
            {
                command.Parameters.AddWithValue("@userID", userID);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new OrderData(
                            reader.GetInt32(0),
                            reader.GetInt32(1), //UsersID
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetInt32(5)
                        ));
                    }
                }

            }
            return items;
        }

        public void AddToOrder(int? userID, string typeReptile, string sexReptile, string morphReptile, int costReptile)
        {
            Connection();

            using (NpgsqlCommand command = new NpgsqlCommand())
            {
                command.Connection = sqlConnection;
                command.CommandText = "INSERT INTO public.\"Orders\" (\"UsersID\", \"TypeReptile\", \"SexReptile\", \"MorphReptile\", \"CostReptile\") VALUES (@userID, @typeReptile, @sexReptile, @morphReptile, @costReptile)";
                //command.Parameters.AddWithValue("@catalogID", catalogID); больше не храним айди товара из каталога, поскольку он удаляется вместе с товаром

                command.Parameters.AddWithValue("@userID", userID);
                command.Parameters.AddWithValue("@typeReptile", typeReptile);
                command.Parameters.AddWithValue("@sexReptile", sexReptile);
                command.Parameters.AddWithValue("@morphReptile", morphReptile);
                command.Parameters.AddWithValue("@costReptile", costReptile);

                command.ExecuteNonQuery();
            }
        }
    }
}