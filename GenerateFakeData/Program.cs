using GenerateFakeData.Model;

public class Program
{
    static void Main(string[] args)
    {
        MainAsync(args).GetAwaiter().GetResult();
    }

    static async Task MainAsync(string[] args)
    {
        ShowAllFunctionality();
    }

    public static async void ShowAllFunctionality()
    {
        Random random = new Random();
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
        person.GenerateDateOfBirth();
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
        person.GenerateDateOfBirth();
        person.GenerateCprNumber();
        Console.WriteLine("CPR: " + person.CprNumber + ", name: " + person.FullName + ", gender: " + person.Gender + ", DoB in ddMMyy format: " + person.DateOfBirth);
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Functionality 6: generate an address: ");
        Console.ForegroundColor = ConsoleColor.White;
        await person.SetAddress();
        Console.WriteLine($"Address: {person.Address.Street} {person.Address.StreetNumber}, fl. {person.Address.Floor}, {person.Address.Door}, {person.Address.City.PostalCode} {person.Address.City.CityName}");
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
                $"Address: {person.Address.Street} {person.Address.StreetNumber}, fl. {person.Address.Floor}, {person.Address.Door}, {person.Address.City.PostalCode} {person.Address.City.CityName}" +
                $"\nPhone number: {person.PhoneNumber}");
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Functionality 9: generate all info for bulk: ");
        Console.ForegroundColor = ConsoleColor.White;

        // TODO: added this so that we can randomize the number of generated people 2-100, for now the upper boundary is 10 for testing purposes, change later
        //int numberOfPeopleToGenerate = random.Next(2, 101);
        int numberOfPeopleToGenerate = 100;
        Console.WriteLine("Generating info for " + numberOfPeopleToGenerate + " people: ");
        for(int i = 1; i < numberOfPeopleToGenerate+1; i++)
        {
            Console.WriteLine("Person " + i + ": ");
            await person.GenerateAllInfo();
            Console.WriteLine($"Full name: {person.FullName}\nGender: {person.Gender}" +
                $"\nDate of birth: {person.DateOfBirth}\nCPR number: {person.CprNumber}\n" +
                $"Address: {person.Address.Street} {person.Address.StreetNumber}, fl. {person.Address.Floor}, {person.Address.Door}, {person.Address.City.PostalCode} {person.Address.City.CityName}" +
                $"\nPhone number: {person.PhoneNumber}");
            Console.WriteLine();
        }

        Console.WriteLine();
    }

}

