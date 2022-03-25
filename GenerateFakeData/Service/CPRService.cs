public class CPRService
{
    public string GenerateCprNumber(string genderName, string dateOfBirth)
        {
            Random rnd = new Random();
            string generatedCprNumber = "";
            generatedCprNumber += dateOfBirth;

            generatedCprNumber += rnd.Next(001, 1000);
            
            if (genderName.Equals("male"))
            {
                //To generate an even number in the range 0-9
                generatedCprNumber += 1 + 2 * rnd.Next(5);
            }
            else
            {
                //To generate an odd number in the range 0-9
                generatedCprNumber += 2 * rnd.Next(5);
            }

            if (ValidateCpr(genderName, generatedCprNumber, dateOfBirth)) {
                return generatedCprNumber;
            }
            else {
                System.Console.WriteLine("Error generating CPR number");
                return null;
            }
        }
        //Validator of CprNumber
        public bool ValidateCpr(string genderName, string cprToTest, string dateOfBirth)
        {
            bool validDateMonth = ValidateCprMonth(cprToTest);

            bool validGender = ValidateCprLastDigit(genderName, cprToTest);

            return cprToTest.StartsWith(dateOfBirth) && (cprToTest.Length == 10) 
                && validDateMonth 
                && validGender;
        }

        private bool ValidateCprMonth(string cprToTest)
        {
            try {
                int firstTwoDigits = Int32.Parse(cprToTest.Substring(0, 2));
                int secondTwoDigits = Int32.Parse(cprToTest.Substring(2, 2));
                int yearDigits = Int32.Parse(cprToTest.Substring(4, 2));
                new DateTime(yearDigits, secondTwoDigits, firstTwoDigits);
                return true;    
            } catch (ArgumentOutOfRangeException) {
                Console.WriteLine("Date range out of bounds.");
                return false;
            }
            
            // // TODO: here we dont check for months that have 28/29/30 days, but..
            // bool validDateMonth = (firstTwoDigits < 32 && secondTwoDigits < 13);
            // return validDateMonth;
        }

        private bool ValidateCprLastDigit(string genderName, string cprToTest) {
            int lastDigit = cprToTest[cprToTest.Length - 1];
            bool validMale = (lastDigit % 2 == 1) && (genderName.Equals("male"));
            bool validFemale = (lastDigit % 2 == 0) && (genderName.Equals("female"));
            return validMale || validFemale;
        }
}