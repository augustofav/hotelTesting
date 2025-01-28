using System;
using System.Data.SQLite;

namespace hotelTesting
{
    internal class Hotel
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public Boolean Disponivel { get; set; }
        public static void EnsureDatabaseSchema(string connectionString)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    CREATE TABLE IF NOT EXISTS Hotels (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nome TEXT NOT NULL,
                        Preco REAL NOT NULL,
                        Disponivel BOOLEAN NOT NULL,
                          
                    );";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        public static void InsertHotel(string connectionString, Hotel hotel)
        {
            try { 
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Hotels (Nome, Preco, Disponivel) VALUES (@Nome, @Preco, @Disponivel);";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", hotel.Nome);
                    command.Parameters.AddWithValue("@Preco", hotel.Preco);
                    command.Parameters.AddWithValue("@Disponivel", hotel.Disponivel);
                    command.ExecuteNonQuery();
                }
            }
        
        }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao inserir hotel: {ex.Message}");
            }
        }
        public static void UpdateHotel(string connectionString, Hotel hotel)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Hotels SET Nome = @Nome, Preco = @Preco, Disponivel = @Disponivel WHERE Id = @Id;";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nome", hotel.Nome);
                        command.Parameters.AddWithValue("@Preco", hotel.Preco);
                        command.Parameters.AddWithValue("@Disponivel", hotel.Disponivel);
                        command.Parameters.AddWithValue("@Id", hotel.Id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar hotel: {ex.Message}");
            }
        }
    
    public static void DeleteHotel(string connectionString, int id)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Hotels WHERE Id = @Id;";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar hotel: {ex.Message}");
            }
        }
    
    public static void ReservingHotel(string connectionString, int id) {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Hotels SET Disponivel = 0 WHERE Id = @Id;";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao reservar hotel: {ex.Message}");
            }
        }
    }
   public static void listAvailableHotels(string connectionString) {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT FROM Hotels WHERE Disponivel = 1;";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(
                        }