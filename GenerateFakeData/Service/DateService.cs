namespace GenerateFakeData.Service;

public class DateService
{
    public bool IsDateValid(int days, int months, int year) {
        try {
            new DateTime(year, months, days);
            if (year > DateTime.Now.Year) return false;
            return true;    
        } catch (ArgumentOutOfRangeException e) {
            Console.WriteLine("Date range out of bounds." + e.Message);
            return false;
        }
    }
}