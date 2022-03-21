using Newtonsoft.Json;

namespace GenerateFakeData.data
{
    public class NameGenderGenerator
    {
        private List<Person> persons;

        public NameGenderGenerator()
        {
            try
            {
                string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"data\person-names.json");
                string[] personNames = File.ReadAllLines(path);
                persons = JsonConvert.DeserializeObject<Persons>(string.Join("", personNames)).persons;
            }
            catch
            {
            }
            
        }

        public bool GetRandomPerson(out string firstName, out string lastName, out string gender)
        {
            firstName = string.Empty;
            lastName = string.Empty;
            gender = string.Empty;

            if(persons == null) return false;

            //Mixing the names up for more randomness
            Random random = new Random();
            int member = random.Next(0, persons.Count);
            firstName = persons[member].name;
            gender = persons[member].gender;
            member = random.Next(0, persons.Count);
            lastName = persons[member].surname;

            return true;
        }

        private partial class Persons
        {
            public List<Person> persons { get; set; }
        }

        private partial class Person
        {
            public string name { get; set; }
            public string surname { get; set; }
            public string gender { get; set; }
        }
    }
}
