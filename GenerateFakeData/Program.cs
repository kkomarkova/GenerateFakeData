using GenerateFakeData.data;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

GenerateFakeData.data.NameGenerator haha = new NameGenerator();
GenerateFakeData.data.Cpr cpr = new Cpr();
System.Console.WriteLine(haha.generateRandomPhoneNumber());
System.Console.WriteLine(cpr.generateCprNumber(cpr.DoB,true));
System.Console.WriteLine(cpr.DoB);
System.Console.WriteLine(Address.Street(7));
System.Console.WriteLine(Address.Number());

NameGenderGenerator nameGender = new NameGenderGenerator();
if (nameGender.GetRandomPerson(out string firstName, out string lastName, out string gender))
{
    Console.WriteLine(firstName + ", " + lastName + ", " + gender);
}
else
{
    Console.WriteLine("File with person data not found.");
}




