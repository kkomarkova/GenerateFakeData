using GenerateFakeData.Model;


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

        //ShowAllFunctionality();
    }

    static async Task MainAsync(string[] args)
    {
        ShowAllFunctionality();

        //Person person = new Person();

        //bool result = await person.GenerateAllInfo();
        //if (result)
        //{
        //    Console.WriteLine($"Randomly generated person data:\nFull name: {person.FullName}\nGender: {person.Gender}" +
        //        $"\nDate of birth: {person.DateOfBirth}\nCPR number: {person.CprNumber}\n" +
        //        $"Address: {person.Street} {person.StreetNumber}, fl. {person.Floor}, {person.Door}\n{person.PostalCode} {person.CityName}" +
        //        $"\nPhone number: {person.PhoneNumber}");
        //}
        //else
        //{
        //    Console.WriteLine("Generation unsuccessful");
        //}
    }

    public static async void ShowAllFunctionality()
    {
        Person person = new();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Functionality 1: generate CPR: ");
        Console.ForegroundColor = ConsoleColor.White;
        person.SetNameAndGender();
        person.GenerateCprNumber();
        Console.WriteLine(person.CprNumber);
        Console.WriteLine("");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Functionality 2: generate full name and gender: ");
        Console.ForegroundColor = ConsoleColor.White;
        person.SetNameAndGender();
        Console.WriteLine("Name: " + person.FullName + ", gender: " + person.Gender);
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Functionality 3: generate full name, gender and DoB: ");
        Console.ForegroundColor = ConsoleColor.White;
        person.SetNameAndGender();
        person.GenerateDateofBirth();
        Console.WriteLine("Name: " + person.FullName + ", gender: " + person.Gender + ", DoB in ddMMyy format: " + person.DateOfBirth);
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Functionality 4: generate CPR, full name and gender: ");
        Console.ForegroundColor = ConsoleColor.White;
        person.SetNameAndGender();
        person.GenerateCprNumber();
        Console.WriteLine("CPR: " + person.CprNumber + ", name: " + person.FullName + ", gender: " + person.Gender);
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Functionality 5: generate CPR, full name, gender and DoB: ");
        Console.ForegroundColor = ConsoleColor.White;
        person.SetNameAndGender();
        person.GenerateDateofBirth();
        person.GenerateCprNumber();
        Console.WriteLine("CPR: " + person.CprNumber + ", name: " + person.FullName + ", gender: " + person.Gender + ", DoB in ddMMyy format: " + person.DateOfBirth);
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Functionality 6: generate an address: ");
        Console.ForegroundColor = ConsoleColor.White;
        await person.GenerateWholeAddress();
        Console.WriteLine($"Address: {person.Street} {person.StreetNumber}, fl. {person.Floor}, {person.Door}, {person.PostalCode} {person.CityName}");
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Functionality 7: generate phone number: ");
        Console.ForegroundColor = ConsoleColor.White;
        person.SetRandomPhoneNumber();
        Console.WriteLine("Phone number is:" + person.PhoneNumber);
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Functionality 8: generate all info for one person: ");
        Console.ForegroundColor = ConsoleColor.White;
        await person.GenerateAllInfo();
        Console.WriteLine($"Randomly generated person data:\nFull name: {person.FullName}\nGender: {person.Gender}" +
                $"\nDate of birth: {person.DateOfBirth}\nCPR number: {person.CprNumber}\n" +
                $"Address: {person.Street} {person.StreetNumber}, fl. {person.Floor}, {person.Door}, {person.PostalCode} {person.CityName}" +
                $"\nPhone number: {person.PhoneNumber}");
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Functionality 9: generate all info for bulk: ");
        Console.ForegroundColor = ConsoleColor.White;

        for(int i = 0; i < 50; i++)
        {
            await person.GenerateAllInfo();
            Console.WriteLine($"Full name: {person.FullName}\nGender: {person.Gender}" +
                $"\nDate of birth: {person.DateOfBirth}\nCPR number: {person.CprNumber}\n" +
                $"Address: {person.Street} {person.StreetNumber}, fl. {person.Floor}, {person.Door}, {person.PostalCode} {person.CityName}" +
                $"\nPhone number: {person.PhoneNumber}");
            Console.WriteLine();
        }

        Console.WriteLine();
    }

}

