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
        public Address Address { get; set; }
        public string DateOfBirth { get; set; }

        DobService dobGenerator;
        AddressService addressService;
        NameGenderGenerator nameGenderGenerator;
        PhoneNoService phoneNumberGenerator;
        CprService cprGenerator;
        
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
                await SetAddress();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public void GenerateDateOfBirth(int startYear = 1900, string outputDateFormat = "ddMMyy")
        {
            DateOfBirth = dobGenerator.GenerateDateOfBirth();
        }

        public void GenerateCprNumber()
        {
            if (Gender == Gender.Uninitialized)
            {
                Random random = new();
                var randomGenderInt = random.Next(1, 2);
                Gender = (Gender) randomGenderInt;
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

        public async Task<bool> SetAddress()
        {
            Address = await addressService.GenerateAddress();
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