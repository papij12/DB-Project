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
            //querry displaying details about movies given the movie_id
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("Select title, movie_id, price From movies Where movie_id = @movie_id", conn);
                
                    cmd.Parameters.AddWithValue("@movie_id", int.Parse(movie_id));
                    NpgsqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Console.WriteLine($"movie {dataReader["movie_id"]} has title\"{dataReader["title"]}\"and price : {dataReader["price"]}");
                    }

            conn.Close();

            // querry for displaying all actors starring in a movie 
            conn.Open();
         
            Console.WriteLine("\n first and last name of actors that played in all the movies");
            Console.WriteLine("--------------------------------------------------------------");

            NpgsqlCommand cmd2 = new NpgsqlCommand("Select  first_name,last_name From actors Join starring On starring.actor_id = actors.actor_id", conn);
            NpgsqlDataReader dataReader1 = cmd2.ExecuteReader();
            while (dataReader1.Read())
            {
                Console.WriteLine($" first name: {dataReader1["first_name"]}\"\tlast name : {dataReader1["last_name"]}");
            }

            conn.Close();
            // query for displaying all the copies of the movie 
            conn.Open();
            Console.WriteLine("\n list of all the copies of the movie");
            Console.WriteLine("--------------------------------------");

            NpgsqlCommand cmd3 = new NpgsqlCommand("Select copy_id, title From copies Join movies On movies.movie_id = copies.movie_id", conn);
            NpgsqlDataReader dataReader2 = cmd3.ExecuteReader();
            while (dataReader2.Read())
            {
                Console.WriteLine($"copy_id : {dataReader2["copy_id"]}\"\t title : {dataReader2["title"]}");
            }
            conn.Close();


        }
    }
}