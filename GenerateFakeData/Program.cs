using GenerateFakeData.data;
using GenerateFakeData.Model;
using System;
using MySql.Data.MySqlClient;
using GenerateFakeData.Database;


//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//Person Brnak = new Person();
//Console.WriteLine();
//// testing for cycle if bulk test is needed
//for (int i = 0; i < 100; i++)
//{
//}

//NameGenderGenerator nameGender = new NameGenderGenerator();
//if (nameGender.GetRandomPerson(out string firstName, out string lastName, out string gender))
//{
//    Console.WriteLine(firstName + ", " + lastName + ", " + gender);
//}
//else
//{
//    Console.WriteLine("File with person data not found.");
//}
public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Getting Connection ...");
        MySqlConnection conn = DBUtils.GetDBConnection();
        List<city> citylist = new List<city>();


        try
        {
            Console.WriteLine("Openning Connection ...");

            conn.Open();

            //SQL Query to execute
            //selecting from postal code
            string sql = "select * from postal_code";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            //read the data
            while (rdr.Read())
            {
                citylist.Add(new city(Convert.ToInt32(rdr[0]),rdr[1].ToString())); 
            }
            Console.WriteLine(citylist[10].PostalCode + " " + citylist[10].CityName);
            rdr.Close();

            Console.WriteLine("Connection successful!");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }

        Console.Read();
    }
}

