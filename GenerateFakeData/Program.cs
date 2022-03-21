using GenerateFakeData.data;
using GenerateFakeData.Model;
using System;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Person Brnak = new Person();
Console.WriteLine();
// testing for cycle if bulk test is needed
for (int i = 0; i < 100; i++)
{
}

NameGenderGenerator nameGender = new NameGenderGenerator();
if (nameGender.GetRandomPerson(out string firstName, out string lastName, out string gender))
{
    Console.WriteLine(firstName + ", " + lastName + ", " + gender);
}
else
{
    Console.WriteLine("File with person data not found.");
}