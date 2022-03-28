using Newtonsoft.Json;

namespace GenerateFakeData.Model
{
    public class NameGenderGenerator
    {
        private List<Person> persons;

        public NameGenderGenerator()
        {
            persons = GetDataFromJsonFile(Properties.Resources.person_names);
        }

        public List<Person> GetDataFromJsonFile(string pathToFile)
        {
            try
            {
                return File.Exists(pathToFile) 
                    ? JsonConvert.DeserializeObject<Persons>(pathToFile)?.persons 
                    : null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public bool GetRandomPerson(out string firstName, out string lastName, out Gender gender)
        {
            firstName = string.Empty;
            lastName = string.Empty;
            gender = Gender.Uninitialized;

            if (persons == null) return false;

            //Mixing the names up for more randomness
            Random random = new Random();
            int member = random.Next(0, persons.Count);
            firstName = persons[member].Name;
            gender = persons[member].Gender.Equals("male") ? Gender.Male : Gender.Female;
            member = random.Next(0, persons.Count);
            lastName = persons[member].Surname;

            return true;
        }

        private partial class Persons
        {
            public List<Person> persons { get; set; }
        }

        public partial class Person
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Gender { get; set; }
        }
    }
}
