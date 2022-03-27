using GenerateFakeData.Model;

namespace GenerateFakeData.Service;

public class CprService
{
    public string GenerateCprNumber(Gender gender, string dateOfBirth)
    {
        Random rnd = new Random();
        string generatedCprNumber = "";
        generatedCprNumber += dateOfBirth;

        generatedCprNumber += rnd.Next(001, 1000).ToString("000");
            
        if (gender == Gender.Male)
        {
            //To generate an even number in the range 0-9
            generatedCprNumber += 1 + 2 * rnd.Next(5);
        }
        else
        {
            //To generate an odd number in the range 0-9
            generatedCprNumber += 2 * rnd.Next(5);
        }

        if (ValidateCpr(gender, generatedCprNumber, dateOfBirth)) {
            return generatedCprNumber;
        }
        else {
            Console.WriteLine("Error generating CPR number");
            return null;
        }
    }
    //Validator of CprNumber
    public bool ValidateCpr(Gender gender, string cprToTest, string dateOfBirth)
    {
        bool validDateMonth = ValidateCprMonth(cprToTest);

        bool validGender = ValidateCprLastDigit(gender, cprToTest);

        return cprToTest.StartsWith(dateOfBirth) && (cprToTest.Length == 10) 
                                                 && validDateMonth 
                                                 && validGender;
    }

    private bool ValidateCprMonth(string cprToTest)
    {
        DateService dateService = new();
        int firstTwoDigits = int.Parse(cprToTest.Substring(0, 2));
        int secondTwoDigits = int.Parse(cprToTest.Substring(2, 2));
        int yearDigits = int.Parse(cprToTest.Substring(4, 2));

        return dateService.IsDateValid(firstTwoDigits, secondTwoDigits, yearDigits);
    }

    private bool ValidateCprLastDigit(Gender gender, string cprToTest) {
        int lastDigit = cprToTest[cprToTest.Length - 1];
        bool validMale = (lastDigit % 2 == 1) && (gender == Gender.Male);
        bool validFemale = (lastDigit % 2 == 0) && (gender == Gender.Female);
        return validMale || validFemale;
    }
}