using GenerateFakeData.Service;

namespace GenerateFakeData.Model
{
    public enum Gender { Uninitialized = 0, Male = 1, Female = 2 }
    public class Person
    {
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public string CprNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Door { get; set; }
        public string Floor { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string CityName { get; set; }
        public int PostalCode { get; set; }
        public string DateOfBirth { get; set; }

        DobService dobGenerator;
        AddressService addressService;
        NameGenderGenerator nameGenderGenerator;
        PhoneNoService phoneNumberGenerator;
        CprService cprGenerator;

        public Person(string fullName, Gender gender, string cprNumber, string phoneNumber, string door,
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
            cprGenerator = new CprService();
        }
        public Person()
        {
            addressService = new AddressService();
            dobGenerator = new DobService();
            nameGenderGenerator = new NameGenderGenerator();
            phoneNumberGenerator = new PhoneNoService();
            cprGenerator = new CprService();
        }

        public async Task<bool> GenerateAllInfo()
        {
            try
            {
                SetNameAndGender();
                GenerateDateOfBirth();
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

        public void GenerateDateOfBirth(int startYear = 1900, string outputDateFormat = "ddMMyy")
        {
            DateOfBirth = dobGenerator.GenerateDateOfBirth();
        }

        public void GenerateCprNumber()
        {
            // do we generate missing info or throw an error? answer Marek: we throw error as I unified the setName and setGender to one method
            if (Gender == Gender.Uninitialized)
            {
                throw new Exception("Gender is not generated, generate it first");
            }
            if (DateOfBirth == null)
            {
                GenerateDateOfBirth();
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
            if (!generatedInformation.IsSuccess) return false;
            CityName = generatedInformation.cityName;
            PostalCode = generatedInformation.postalCode;

            return true;
        }

        public void SetNameAndGender()
        {
            nameGenderGenerator.GetRandomPerson(out string firstName, out string lastName, out Gender gender);

            FullName = firstName + " " + lastName;
            Gender = gender;
        }
    }
}