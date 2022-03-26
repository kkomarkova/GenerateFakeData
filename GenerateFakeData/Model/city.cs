namespace GenerateFakeData.Model
{
   public class City
    {
        public int PostalCode { get; set; }
        public string CityName { get; set; }
        private static Random random = new Random();


        public City() { }
        public City(int PostalCode, string CityName)
        {
            this.PostalCode = PostalCode;
            this.CityName = CityName;
        }
    }
}
