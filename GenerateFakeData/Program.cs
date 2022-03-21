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
        MainAsync(args).GetAwaiter().GetResult();
    }

    static async Task MainAsync(string[] args)
    {
        Person person = new Person();

        bool result = await person.SetCity();
        person.SetNameAndGender();

        //Only get name and city and postal code
        person.GetData(out string name, out _, out _, out _, out _, out _, out _, out string cityName, out int postalCode);

        if (result)
        {
            //One way of getting data
            Console.WriteLine(person.CityName + " " + person.PostalCode);
            Console.WriteLine(person.FullName);
            //Second way of getting data
            Console.WriteLine(name);
        }
    }
}

