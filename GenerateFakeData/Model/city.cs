using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateFakeData.Model
{
   public class city
    {
        public int PostalCode { get; set; }
        public string CityName { get; set; }
        public int V { get; }

        public city(int PostalCode, string CityName)
        {
            this.PostalCode = PostalCode;
            this.CityName = CityName;
        }

    
    }
}
