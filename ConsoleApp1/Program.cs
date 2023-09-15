using System;
using System.Data.SQLite;
using System.IO;

class Program
{
    static void Main()
    {
        string imagePath = "image1.jpg"; // Путь к изображению

        byte[] imageBytes = File.ReadAllBytes(imagePath); // Чтение изображения в виде массива байтов

        
        string connectionString = "Data Source=DB.db;Version=3";

        
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open(); 

            
            using (SQLiteCommand command = connection.CreateCommand())
            {
                
                command.CommandText = "INSERT INTO cars (image) VALUES (@imageData)";

                
                command.Parameters.AddWithValue("@imageData", imageBytes);

                
                command.ExecuteNonQuery();
            }

            connection.Close(); 
        }

        Console.WriteLine("Изображение добавлено в базу данных.");
    }
}