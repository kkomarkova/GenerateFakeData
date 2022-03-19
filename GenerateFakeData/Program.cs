using GenerateFakeData.data;
using System;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

NameGenerator haha = new NameGenerator();
Cpr cpr = new Cpr();
Console.WriteLine(haha.generateRandomPhoneNumber());
Console.WriteLine(cpr.generateCprNumber(cpr.DoB,true));
Console.WriteLine(cpr.DoB);
Console.WriteLine(Address.Street());
Console.WriteLine(Address.Number());
Console.WriteLine(Address.Floor());
Console.WriteLine(Address.Door());

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




