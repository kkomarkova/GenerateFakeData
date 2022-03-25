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
        DobService dobGenerator;
        AddressService addressService;
        NameGenderGenerator nameGenderGenerator;
        PhoneNoService phoneNumberGenerator;
        CPRService cprGenerator;

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
            addressService = new AddressService();
            dobGenerator = new DobService();
            nameGenderGenerator = new NameGenderGenerator();
            phoneNumberGenerator = new PhoneNoService();
            cprGenerator = new CPRService();
        }
        public Person()
        {
            addressService = new AddressService();
            dobGenerator = new DobService();
            nameGenderGenerator = new NameGenderGenerator();
            phoneNumberGenerator = new PhoneNoService();
            cprGenerator = new CPRService();
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
      
        public async Task<bool> GenerateWholeAddress()
        {
            bool success = await SetCity();
            if (!success) return false;

            SetFloor();
            SetDoor();
            SetStreet();
            SetStreetNumber();

            return true;
        }

        public string GenerateDateofBirth(int startYear = 1900, string outputDateFormat = "ddMMyy")
        {
            DateOfBirth = dobGenerator.GenerateDateofBirth();
        }

        public void GenerateCprNumber()
        {
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
            PhoneNumber = phoneNumberGenerator.GenerateRandomPhoneNumber();
        }
        public void SetStreet()
        {
            Street = addressService.GenerateStreetName();
        }

        public void SetStreetNumber()
        {
            this.StreetNumber = addressService.GenerateStreetNumber();
        }

        public void SetFloor()
        {
            this.Floor = addressService.GenerateFloor();
        }

        public void SetDoor()
        {
            Door = addressService.GenerateDoor();
        }
        //Reading city and postalcode from Address.sql
        public async Task<bool> SetCity()
        {
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
            nameGenderGenerator.GetRandomPerson(out string firstName, out string lastName, out _);

            FullName = firstName + " " + lastName;
        }
        private void SetGender()
        {
            nameGenderGenerator.GetRandomPerson(out _, out _, out string gender);
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
