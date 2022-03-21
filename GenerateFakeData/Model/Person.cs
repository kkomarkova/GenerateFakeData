using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateFakeData.Model
{
    public class Person
    {
        

        public static int[] starters = new int[] {2, 30, 31, 40, 41, 42, 50, 51, 52, 53, 60, 61, 71, 81, 91, 92, 93,
            342, 344, 345, 346, 347, 348, 349, 356, 357, 359, 362, 365, 366, 389, 398, 431, 441, 462, 466,  468,  472,  474,  476,  478,  485,
            486,  488, 489,  493, 494, 495, 496,  498, 499,  542, 543,  545,  551, 552, 556, 571, 572, 573, 574, 577, 579, 584, 586, 587, 589,
            597, 598, 627, 629, 641, 649, 658, 662, 663, 664, 665, 667, 692, 693, 694, 697, 771, 772, 782, 783, 785, 786, 788, 789, 826, 827,829};
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string CprNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Door { get; set; }
        public string Floor { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }

        public string DoB = DateofBirth();

        private static Random random = new Random();

        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }


        public static string DateofBirth(int startYear = 1900, string outputDateFormat = "ddMMyy")
        {
            DateTime start = new DateTime(startYear, 1, 1);
            //GUID - broader version of numbers, guaranteed to be unique across tables
            //GetHasCode - returns the hash code of Guid
            Random gen = new Random(Guid.NewGuid().GetHashCode());
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range)).ToString(outputDateFormat);
        }

        public void GenerateCprNumber(string DoB, bool isMale)
        {
            Random rnd = new Random();
            CprNumber += DoB;

            CprNumber += rnd.Next(001, 1000);

            if (isMale)
            {
                //To generate an even number in the range 0-9
                CprNumber += 1 + 2 * rnd.Next(5);
            }
            else
            {
                //To generate an odd number in the range 0-9
                CprNumber += 2 * rnd.Next(5);
            }
        }

        public void SetRandomPhoneNumber()
        {
            string Generated = "";
            Random Rnd = new Random();
            int NumberLength = 8;
            //Pick one index from the array, from 0 to the length of the starters
            int StartingSequence = starters[Rnd.Next(0, starters.Length)];
            //How many digits are in one object
            int LengthOfStartingSequence = StartingSequence.ToString().Length;
            Generated += StartingSequence.ToString();
            //Generate random of the digit missing from number length - length of starting sequence (1,2,3)
            for (int i = 0; i < NumberLength - LengthOfStartingSequence; i++)
            {
                Generated += Rnd.Next(0, 10);
            }
            PhoneNumber = Generated;
        }

        public string SetStreet()
        {
            // lets say we want our street names to be at least 6 and at most 16 characters long, so that it makes *some* sense
            int Length = random.Next(6, 17);
            const string Chars = "abcdefghijklmnopqrstuvwxyz";
            string StreetName = new string(Enumerable.Repeat(Chars, Length)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            // returning so that the first letter is capitalized and others are lower case
            return char.ToUpper(StreetName[0]) + StreetName.Substring(1);
        }

        public void SetStreetNumber()
        {
            const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string StreetNumber = random.Next(1, 1000).ToString();
            // optinalfollowed - random if the letter follows number, if 0 letter A-Z follows the number, if 1 only number
            int Optionalfollowed = random.Next(0, 2);

            if (Optionalfollowed == 0)
            {
                StreetNumber += Chars[random.Next(Chars.Length)];
            }
            else if (Optionalfollowed == 1)
            {
                this.StreetNumber = StreetNumber;
            }

            this.StreetNumber = StreetNumber;
        }


        public void setFloor()
        {
            // floor number is either "st" or a number 1-99, so we take random number, if we get 0, we turn that into "st", otherwise just return
            string FloorToReturn;
            int floorNumber = random.Next(0, 100);
            if (floorNumber == 0)
            {
                FloorToReturn = "st";
            }
            else FloorToReturn = floorNumber.ToString();

            this.Floor = FloorToReturn;
        }

        public void setDoor()
        {
            // final string that will be returned
            string DoorToReturn = "";

            // there are three ways we should produce the door number, either "tv" or "42" or "d-14", to randomly determine which to use, introducing a variable
            // 0= just tv th mf, 1= number 1-50, 2= letter optional dash and number 1-999
            int DoorFormatToProduce = random.Next(0, 3);

            // for case 0, we need three different positions of the door, 0=tv, 1=mf, 2=th
            int Position = random.Next(0, 3);

            // for case 1, we need a door number from 1 to 50
            int NumberUntilFifty = random.Next(1, 51);

            // for case 2, we need a random char from the alphabet, optional dash and a door number from 1 to 999
            int NumberUntilThousand = random.Next(1, 1000);
            int HasDash = random.Next(0, 2);
            const string Chars = "abcdefghijklmnopqrstuvwxyz";
            char RandomChar = Chars[random.Next(0, Chars.Length)];

            switch (DoorFormatToProduce)
            {
                case 0:
                    switch (Position)
                    {
                        case 0:
                            DoorToReturn = "tv";
                            break;
                        case 1:
                            DoorToReturn = "mf";
                            break;
                        case 2:
                            DoorToReturn = "th";
                            break;
                    }
                    break;
                case 1:
                    DoorToReturn = NumberUntilFifty.ToString();
                    break;
                case 2:
                    DoorToReturn = HasDash == 1
                        ? RandomChar + "-" + NumberUntilThousand.ToString()
                        : RandomChar + NumberUntilThousand.ToString();
                    break;
            }

            Door = DoorToReturn;
        }
    }
}
