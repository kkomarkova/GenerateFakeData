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
    }

    static async Task MainAsync(string[] args)
    {
        Person person = new Person();

        bool result = await person.GenerateAllInfo();
        if (result)
        {
            Console.WriteLine($"Randomly generated person data:\nFull name: {person.FullName}\nGender: {person.Gender}" +
                $"\nDate of birth: {person.DateOfBirth}\nCPR number: {person.CprNumber}\n" +
                $"Address: {person.Street} {person.StreetNumber}, fl. {person.Floor}, {person.Door}\n{person.PostalCode} {person.CityName}" +
                $"\nPhone number: {person.PhoneNumber}");
        }
        else
        {
            Console.WriteLine("Generation unsuccessful");
        }
    }

    // functionality method stubs
    public string Cpr()
    {
        return null;
    }
    public string FullNameAndGender()
    {
        return null;
    }
    public string FullNameGenderAndDob()
    {
        return null;
    }
    public string CprFullNameGender()
    {
        return null;
    }
    public string CprFullNameGenderAndDob()
    {
        return null;
    }
    public string Address()
    {
        return null;
    }
    public string PhoneNumber()
    {
        return null;
    }
    public string AllInfo()
    {
        return null;
    }
    public string AllInfoInBulk()
    {
        return null;
    }

}

