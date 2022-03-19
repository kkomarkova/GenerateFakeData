using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateFakeData.data
{
    public class Cpr
    {
        public string cprNumber { get; set; }
        public string DoB = DateofBirth();

        public static string DateofBirth(int startYear = 1900, string outputDateFormat = "ddMMyy")
        {
            DateTime start = new DateTime(startYear, 1, 1);
            //GUID - broader version of numbers, guaranteed to be unique across tables
            //GetHasCode - returns the hash code of Guid
            Random gen = new Random(Guid.NewGuid().GetHashCode());
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range)).ToString(outputDateFormat);
        }

        public string generateCprNumber(string DoB, bool isMale)
        {
            string cpr = "";
            Random rnd = new Random();
            cpr += DoB;

            cpr += rnd.Next(001, 1000);

            if (isMale)
            {
                //To generate an even number in the range 0-9
                cpr += 1 + 2 * rnd.Next(5);
            }
            else
            {
                //To generate an odd number in the range 0-9
                cpr += 2 * rnd.Next(5);
            }
            return cpr;
        }
        
    }
}
