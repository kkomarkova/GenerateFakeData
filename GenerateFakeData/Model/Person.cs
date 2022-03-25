using GenerateFakeData.Database;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace GenerateFakeData.Model
{
    public class Person
    {        
        int[] starters = new int[] {2, 30, 31, 40, 41, 42, 50, 51, 52, 53, 60, 61, 71, 81, 91, 92, 93,
            342, 344, 345, 346, 347, 348, 349, 356, 357, 359, 362, 365, 366, 389, 398, 431, 441, 462, 466,  468,  472,  474,  476,  478,  485,
            486,  488, 489,  493, 494, 495, 496,  498, 499,  542, 543,  545,  551, 552, 556, 571, 572, 573, 574, 577, 579, 584, 586, 587, 589,
            597, 598, 627, 629, 641, 649, 658, 662, 663, 664, 665, 667, 692, 693, 694, 697, 771, 772, 782, 783, 785, 786, 788, 789, 826, 827,829};
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string CprNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Door { get; set; }
        public string Floor { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string CityName { get; set; }
        public int PostalCode { get; set; }
        public string DateOfBirth { get; set; }

        private static Random random = new Random();

        public Person(string fullName, string gender, string cprNumber, string phoneNumber, string door, 
            string floor, string street, string streetNumber, string cityName, int postalCode, string dateOfBirth)
        {
            FullName = fullName;
            Gender = gender;
            CprNumber = cprNumber;
            PhoneNumber = phoneNumber;
            Door = door;
            Floor = floor;
            Street = street;
            StreetNumber = streetNumber;
            CityName = cityName;
            PostalCode = postalCode;
            DateOfBirth = dateOfBirth;
        }
        public Person()
        {
        }

        public async Task<bool> GenerateAllInfo()
        {
            try
            {
                SetNameAndGender();
                DateOfBirth = GenerateDateofBirth();
                GenerateCprNumber(Gender == "male");
                SetRandomPhoneNumber();
                await SetCity();
                SetFloor();
                SetDoor();
                SetStreet();
                SetStreetNumber();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }            
        }
        public string GenerateDateofBirth(int startYear = 1900, string outputDateFormat = "ddMMyy")
        {
            DateTime start = new DateTime(startYear, 1, 1);
            //GUID - broader version of numbers, guaranteed to be unique across tables
            //GetHasCode - returns the hash code of Guid
            Random gen = new Random(Guid.NewGuid().GetHashCode());
            int range = (DateTime.Today - start).Days;
            DateOfBirth = start.AddDays(gen.Next(range)).ToString(outputDateFormat);
            return DateOfBirth;
        
        }

        public void GenerateCprNumber(bool isMale)
        {
            Random rnd = new Random();
            string generatedCprNumber = "";
            if(DateOfBirth == null)
            {
                DateOfBirth = GenerateDateofBirth();
            }
            generatedCprNumber += DateOfBirth;

            generatedCprNumber += rnd.Next(001, 1000);

            if (isMale)
            {
                //To generate an even number in the range 0-9
                generatedCprNumber += 1 + 2 * rnd.Next(5);
            }
            else
            {
                //To generate an odd number in the range 0-9
                generatedCprNumber += 2 * rnd.Next(5);
            }
            CprNumber = generatedCprNumber;
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

        private static bool ValidateCprMonth(string cprToTest)
        {
            int firstTwoDigits = Int32.Parse(cprToTest.Substring(0, 2));
            int secondTwoDigits = Int32.Parse(cprToTest.Substring(2, 2));
            // TODO: here we dont check for months that have 28/29/30 days, but..
            bool validDateMonth = (firstTwoDigits < 32 && secondTwoDigits < 13);
            return validDateMonth;
        }

        private bool ValidateCprLastDigit(string genderName, string cprToTest) {
            int lastDigit = cprToTest[cprToTest.Length - 1];
            bool validMale = (lastDigit % 2 == 1) && (genderName.Equals("male"));
            bool validFemale = (lastDigit % 2 == 0) && (genderName.Equals("female"));
            return validMale || validFemale;
        }

        public void SetRandomPhoneNumber()
        {
            string Generated = "";
            Random Rnd = new Random();
            int NumberLength = 8;
            //Pick one index from the array, from 0 to the length of the starters
            int StartingSequence = starters[Rnd.Next(0, starters.Length)];
            //How many digits are in one object
            int LengthOfStartingSequence = StartingSequence.ToString().Length;
            Generated += StartingSequence.ToString();
            //Generate random of the digit missing from number length - length of starting sequence (1,2,3)
            for (int i = 0; i < NumberLength - LengthOfStartingSequence; i++)
            {
                Generated += Rnd.Next(0, 10);
            }
            ValidatePhoneNumber(Generated);
            PhoneNumber = Generated;
        }
        //Validator of Phone number
        public bool ValidatePhoneNumber(string numberToTest)
        {
            return starters.Any(x => numberToTest.StartsWith(x.ToString())) && (numberToTest.Length == 8);
        }
        public string SetStreet()
        {
            // lets say we want our street names to be at least 6 and at most 16 characters long, so that it makes *some* sense
            int Length = random.Next(6, 17);
            const string Chars = "abcdefghijklmnopqrstuvwxyz";
            string StreetName = new string(Enumerable.Repeat(Chars, Length)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            // returning so that the first letter is capitalized and others are lower case
            Street = char.ToUpper(StreetName[0]) + StreetName.Substring(1);
            return Street;
        }

        public void SetStreetNumber()
        {
            const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string StreetNumber = random.Next(1, 1000).ToString();
            // optinalfollowed - random if the letter follows number, if 0 letter A-Z follows the number, if 1 only number
            int Optionalfollowed = random.Next(0, 2);

            if (Optionalfollowed == 0)
            {
                StreetNumber += Chars[random.Next(Chars.Length)];
            }
            else if (Optionalfollowed == 1)
            {
                this.StreetNumber = StreetNumber;
            }

            this.StreetNumber = StreetNumber;
        }

        public void SetFloor()
        {
            // floor number is either "st" or a number 1-99, so we take random number, if we get 0, we turn that into "st", otherwise just return
            string FloorToReturn;
            int floorNumber = random.Next(0, 100);
            if (floorNumber == 0)
            {
                FloorToReturn = "st";
            }
            else FloorToReturn = floorNumber.ToString();

            this.Floor = FloorToReturn;
        }

        public void SetDoor()
        {
            // final string that will be returned
            string DoorToReturn = "";

            // there are three ways we should produce the door number, either "tv" or "42" or "d-14", to randomly determine which to use, introducing a variable
            // 0= just tv th mf, 1= number 1-50, 2= letter optional dash and number 1-999
            int DoorFormatToProduce = random.Next(0, 3);

            // for case 0, we need three different positions of the door, 0=tv, 1=mf, 2=th
            int Position = random.Next(0, 3);

            // for case 1, we need a door number from 1 to 50
            int NumberUntilFifty = random.Next(1, 51);

            // for case 2, we need a random char from the alphabet, optional dash and a door number from 1 to 999
            int NumberUntilThousand = random.Next(1, 1000);
            int HasDash = random.Next(0, 2);
            const string Chars = "abcdefghijklmnopqrstuvwxyz";
            char RandomChar = Chars[random.Next(0, Chars.Length)];

            switch (DoorFormatToProduce)
            {
                case 0:
                    switch (Position)
                    {
                        case 0:
                            DoorToReturn = "tv";
                            break;
                        case 1:
                            DoorToReturn = "mf";
                            break;
                        case 2:
                            DoorToReturn = "th";
                            break;
                    }
                    break;
                case 1:
                    DoorToReturn = NumberUntilFifty.ToString();
                    break;
                case 2:
                    DoorToReturn = HasDash == 1
                        ? RandomChar + "-" + NumberUntilThousand.ToString()
                        : RandomChar + NumberUntilThousand.ToString();
                    break;
            }

            Door = DoorToReturn;
        }
        //Reading city and postalcode from Address.sql
        public async Task<bool> SetCity()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            List<City> citylist = new List<City>();

            try
            {
                conn.Open();

                //SQL Query to execute
                //selecting from postal code
                string sql = "select * from postal_code";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                DbDataReader rdr = await cmd.ExecuteReaderAsync();

                //read the data + create a list of the cities read from the database
                while (rdr.Read())
                {
                    citylist.Add(new City(Convert.ToInt32(rdr[0]), rdr[1].ToString()));
                }
                rdr.Close();

                //Random city number from the list
                int index = random.Next(0, citylist.Count);

                //Updating object's variables with the random city's information
                CityName = citylist[index].CityName;
                PostalCode = citylist[index].PostalCode;

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public void SetNameAndGender()
        {
            NameGenderGenerator nameGenderGenerator = new();
            nameGenderGenerator.GetRandomPerson(out string firstName, out string lastName, out string gender);
            FullName = firstName + " " + lastName;
            Gender = gender;
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
            // GenerateCprNumber();
            return null;
        }
        public string CprFullNameGenderAndDob()
        {
            // GenerateCprNumber();
            return null;
        }
        public string Address()
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
}
