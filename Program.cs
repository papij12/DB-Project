using Npgsql;
using System;

namespace SqlDatabase
{
    class Program
    {
        static void Main(string[] args)
        {

            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=pwd;Database=rental;");
            conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("Select title From movies", conn);
            NpgsqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Console.WriteLine($"Title: {dataReader[0]}");
            }

            conn.Close();
        }
    }
}
