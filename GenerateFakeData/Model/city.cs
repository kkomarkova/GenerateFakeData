using GenerateFakeData.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
