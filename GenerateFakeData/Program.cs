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




