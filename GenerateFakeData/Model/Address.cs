
namespace GenerateFakeData.Model
{
    public class Address
    {

        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string Floor { get; set; }
        public string Door { get; set; }
        public City City { get; set; }
        public Address()
        {
            City = new City();
        }
        public Address(string street, string streetNumber, string floor, string door, City city)
        {
            Street = street;
            StreetNumber = streetNumber;
            Floor = floor;
            Door = door;
            City = city;
        }
    }
}
