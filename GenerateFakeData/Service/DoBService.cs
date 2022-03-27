namespace GenerateFakeData.Service;

public class DobService
{
    public string GenerateDateofBirth(string outputDateFormat = "ddMMyy")
    {
        DateTime start = new DateTime(1900, 1, 1);
        DateService dateService = new();
        Random gen = new Random();
        int range = (DateTime.Today - start).Days;
        string dateOfBirth = start.AddDays(gen.Next(range)).ToString(outputDateFormat);
        if (dateService.IsDateValid(
                int.Parse(dateOfBirth.Substring(0, 2)),
                int.Parse(dateOfBirth.Substring(2, 2)),
                int.Parse(dateOfBirth.Substring(4, 2))
            )) {
            return dateOfBirth;
        }
        else return null;
    }
}