using Newtonsoft.Json;

namespace GenerateFakeData.Model
{
    public class NameGenderGenerator
    {
        private List<Person> persons;

        public NameGenderGenerator()
        {
            try
            {
                var jsonFile = Properties.Resources.person_names;
                persons = JsonConvert.DeserializeObject<Persons>(jsonFile)?.persons;
            }
            catch
            {
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
            if(persons[member].Gender.Equals("male")) {
                gender = Gender.Male;
            } else gender = Gender.Female;
            member = random.Next(0, persons.Count);
            lastName = persons[member].Surname;

            return true;
        }

        private partial class Persons
        {
            public List<Person> persons { get; set; }
        }

        private partial class Person
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Gender { get; set; }
        }
    }
}
