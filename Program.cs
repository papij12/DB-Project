using Npgsql;
using System;

namespace SqlDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection_path = "Server = 127.0.0.1; User Id = postgres; Password = pwd; Database = rental;";
            Console.WriteLine("Enter the the movie_Id for your movie");
            string movie_id = Console.ReadLine();
            NpgsqlConnection conn = new NpgsqlConnection(connection_path);
            conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("Select title From movies Where movie_id = @movie_id", conn);
            cmd.Parameters.AddWithValue("@movie_id", int.Parse(movie_id));
            NpgsqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Console.WriteLine($"Title: {dataReader[0]}");
            }

            conn.Close();
        }
    }
}
