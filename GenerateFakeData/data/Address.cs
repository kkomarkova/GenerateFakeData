using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateFakeData.data
{
    public class Address
    {
        private static Random random = new Random();

        public static string Street(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string Number()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string Number = random.Next(1, 999).ToString();
            // optinalfollowed - random if the letter follows number, if 0 letter A-Z follows the number, if 1 only number
            int optionalfollowed = random.Next(0, 2);

            if (optionalfollowed == 0)
            {
                Number += chars[random.Next(chars.Length)];
            }
            else if (optionalfollowed == 1)
            {
                return Number;
            }
            return Number;
        }

    }
}
