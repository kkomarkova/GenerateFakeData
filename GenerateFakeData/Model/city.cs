namespace GenerateFakeData.Model
{
   public class City
    {
        public int PostalCode { get; set; }
        public string CityName { get; set; }
        public City() { }
        public City(int postalCode, string cityName)
        {
            this.PostalCode = postalCode;
            this.CityName = cityName;
        }
    }
}
