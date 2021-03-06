﻿using Npgsql;
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
            Console.Clear();
            //querry displaying details about movies given the movie_id
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("Select title, movie_id, price From movies Where movie_id = @movie_id", conn);
                
                    cmd.Parameters.AddWithValue("@movie_id", int.Parse(movie_id));
                    NpgsqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Console.WriteLine($"movie {dataReader["movie_id"]}\" has title : {dataReader["title"]}\" It costs : {dataReader["price"]}");
                    }

            conn.Close();

            // querry for displaying  actors starring in a movie which the user has provided the movie-id
            conn.Open();
         
            Console.WriteLine("\n first and last name of actors that played in the movie");
            Console.WriteLine("--------------------------------------------------------------");

            NpgsqlCommand cmd2 = new NpgsqlCommand("Select title,first_name,last_name From movies m Join starring s On m.movie_id = s.movie_id Join actors a On s.actor_id = a.actor_id Where m.movie_id = @movie_id", conn);
            cmd2.Parameters.AddWithValue("@movie_id", int.Parse(movie_id));
            NpgsqlDataReader dataReader1 = cmd2.ExecuteReader();
            while (dataReader1.Read())
            {
                Console.WriteLine($"title : {dataReader1["title"]}\" actor first name : {dataReader1["first_name"]}\" actor last name : {dataReader1["last_name"]}");
            }

            conn.Close();
            //query for displaying all the copies of the movie which id was provided bythe user 

           conn.Open();
            Console.WriteLine("\n list of all the copies of the movie");
            Console.WriteLine("--------------------------------------");

            NpgsqlCommand cmd3 = new NpgsqlCommand("Select title, copy_id From copies Join movies On movies.movie_id = copies.movie_id Where movies.movie_id = @movie_id", conn);
            cmd3.Parameters.AddWithValue("@movie_id", int.Parse(movie_id));
            NpgsqlDataReader dataReader2 = cmd3.ExecuteReader();
            while (dataReader2.Read())
            {
                Console.WriteLine($"title : {dataReader2["title"]}\" copy-id :{dataReader2["copy_id"]}");
            }
            conn.Close();
            // querry to display availability of the copies and names of the clients 
            //conn.Open();
            //Console.WriteLine("availability of the copies and names of the clients");
            //Console.WriteLine("---------------------------------------------------");
            //NpgsqlCommand cmd4 = new NpgsqlCommand("Select available,first_name,last_name From copies Join rentals On rentals.copy_id = copies.copy_id Join clients On clients.client_id = rentals.client_id", conn);
            //NpgsqlDataReader dataReader3 = cmd4.ExecuteReader();
            //while (dataReader3.Read())
            //{
            //    Console.WriteLine($"available : {dataReader3["available"]}\"\t rentend by : {dataReader3["first_name"]}\" {dataReader3["last_name"]}");
            //}
            //conn.Close();
            ////querry to insert new movies
            //conn.Open();
            //Console.WriteLine("Enter the title of the movie");
            //string title = Console.ReadLine();
            //Console.WriteLine("Enter the age restriction of the movie");
            //int age = int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter year of production");
            //int year = int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter price of the movie");
            //int price = int.Parse(Console.ReadLine());
            //NpgsqlCommand cmd5 = new NpgsqlCommand("INSERT INTO movies(movie_id, title, year, age_restriction, price) VALUES(@id, @title, @year, @age, @price)", conn);
            //cmd5.Parameters.AddWithValue("@id", 120);
            //cmd5.Parameters.AddWithValue("@title", title);
            //cmd5.Parameters.AddWithValue("@year", year);
            //cmd5.Parameters.AddWithValue("@age", age);
            //cmd5.Parameters.AddWithValue("@price", price);
            //cmd5.ExecuteNonQuery();

            //conn.Close();

        }
    }
}