public class DateService
{
    public Boolean IsDateValid(int days, int months, int year) {
        try {
            new DateTime(year, months, days);
            return true;    
        } catch (ArgumentOutOfRangeException e) {
            Console.WriteLine("Date range out of bounds." + e.Message);
            return false;
        }
    }
}