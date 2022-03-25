namespace GenerateFakeData.Model
{
    public class Person
    {        
        public string FullName { get; set; }
        // TODO: change to Enum
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
                GenerateDateofBirth();
                GenerateCprNumber();
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
        public void GenerateDateofBirth(int startYear = 1900, string outputDateFormat = "ddMMyy")
        {
            DobService dobGenerator = new();
            DateOfBirth = dobGenerator.GenerateDateofBirth();
        }

        public void GenerateCprNumber()
        {
            CPRService cprGenerator = new CPRService();
            // do we generate missing info or throw an error? 
            if(Gender == null) {
                SetGender();
            }
            if(DateOfBirth == null)
            {
                GenerateDateofBirth();
            }
            var generatedCprNumber = cprGenerator.GenerateCprNumber(Gender, DateOfBirth);
            CprNumber = generatedCprNumber;
        }

        public void SetRandomPhoneNumber()
        {
            PhoneNoService phoneNumberGenerator = new();
            PhoneNumber = phoneNumberGenerator.GenerateRandomPhoneNumber();
        }
        public void SetStreet()
        {
            AddressService addressService = new();
            Street = addressService.GenerateStreetName();
        }

        public void SetStreetNumber()
        {
            AddressService addressService = new();
            this.StreetNumber = addressService.GenerateStreetNumber();
        }

        public void SetFloor()
        {
            AddressService addressService = new();
            this.Floor = addressService.GenerateFloor();
        }

        public void SetDoor()
        {
            AddressService addressService = new();
            Door = addressService.GenerateDoor();
        }
        //Reading city and postalcode from Address.sql
        public async Task<bool> SetCity()
        {
            AddressService addressService = new();
            var generatedInformation = await addressService.GenerateCity();
            if(generatedInformation.IsSuccess){
                CityName = generatedInformation.cityName;
                PostalCode = generatedInformation.postalCode;
            }

            return generatedInformation.IsSuccess;
        }

        public void SetNameAndGender()
        {
            SetName();
            SetGender();
        }
        private void SetName()
        {
            NameGenderGenerator nameGenderGenerator = new();
            nameGenderGenerator.GetRandomPerson(out string firstName, out string lastName, out string gender);
            FullName = firstName + " " + lastName;
        }
        private void SetGender()
        {
            NameGenderGenerator nameGenderGenerator = new();
            nameGenderGenerator.GetRandomPerson(out string firstName, out string lastName, out string gender);
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
