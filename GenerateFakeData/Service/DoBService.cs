public class DobService
{
    public string GenerateDateofBirth(int startYear = 1900, string outputDateFormat = "ddMMyy")
        {
            DateTime start = new DateTime(startYear, 1, 1);
            DateService dateService = new();
            //GUID - broader version of numbers, guaranteed to be unique across tables
            //GetHasCode - returns the hash code of Guid
            Random gen = new Random(Guid.NewGuid().GetHashCode());
            int range = (DateTime.Today - start).Days;
            string dateOfBirth = start.AddDays(gen.Next(range)).ToString(outputDateFormat);
            if (dateService.IsDateValid(
                Int32.Parse(dateOfBirth.Substring(0, 2)),
                Int32.Parse(dateOfBirth.Substring(2, 2)),
                Int32.Parse(dateOfBirth.Substring(4, 2))
            )) {
                return dateOfBirth;
            }
            else return null;
        }
}