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

        public static string Street()
        {
            // lets say we want our street names to be at least 6 and at most 16 characters long, so that it makes *some* sense
            int length = random.Next(6, 17);
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            string streetName = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            // returning so that the first letter is capitalized and others are lower case
            return char.ToUpper(streetName[0]) + streetName.Substring(1);
        }

        public static string Number()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string Number = random.Next(1, 1000).ToString();
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
        

        public static string Floor()
        {
            // floor number is either "st" or a number 1-99, so we take random number, if we get 0, we turn that into "st", otherwise just return
            string floorToReturn;
            int floorNumber = random.Next(0, 100);
            if (floorNumber == 0)
            {
                floorToReturn = "st";
            }
            else floorToReturn = floorNumber.ToString();

            return floorToReturn;
        }

        public static string Door()
        {
            // final string that will be returned
            string doorToReturn = "";

            // there are three ways we should produce the door number, either "tv" or "42" or "d-14", to randomly determine which to use, introducing a variable
            // 0= just tv th mf, 1= number 1-50, 2= letter optional dash and number 1-999
            int doorFormatToProduce = random.Next(0, 3);

            // for case 0, we need three different positions of the door, 0=tv, 1=mf, 2=th
            int position = random.Next(0, 3);

            // for case 1, we need a door number from 1 to 50
            int numberUntilFifty = random.Next(1, 51);

            // for case 2, we need a random char from the alphabet, optional dash and a door number from 1 to 999
            int numberUntilThousand = random.Next(1, 1000);
            int hasDash = random.Next(0, 2);
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            char randomChar = chars[random.Next(0, chars.Length)];

            switch (doorFormatToProduce)
            {
                case 0:
                    switch (position)
                    {
                        case 0:
                            doorToReturn = "tv";
                            break;
                        case 1:
                            doorToReturn = "mf";
                            break;
                        case 2:
                            doorToReturn = "th";
                            break;
                    }
                    break;
                case 1:
                    doorToReturn = numberUntilFifty.ToString();
                    break;
                case 2:
                    doorToReturn = hasDash == 1
                        ? randomChar + "-" + numberUntilThousand.ToString()
                        : randomChar + numberUntilThousand.ToString();
                    break;
            }

            return doorToReturn;
        }
    }
}
