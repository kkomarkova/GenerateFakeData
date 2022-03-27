using System.Data.Common;
using GenerateFakeData.Database;
using GenerateFakeData.Model;
using MySql.Data.MySqlClient;

namespace GenerateFakeData.Service;

class AddressService
{
    Random random = new();
    List<City> citylist;
    public string GenerateStreetName()
    {
        // lets say we want our street names to be at least 6 and at most 16 characters long, so that it makes *some* sense
        int Length = random.Next(6, 17);
        const string Chars = "abcdefghijklmnopqrstuvwxyz";
        string StreetName = new string(Enumerable.Repeat(Chars, Length)
            .Select(s => s[random.Next(s.Length)]).ToArray());

        // returning so that the first letter is capitalized and others are lower case
        string street = char.ToUpper(StreetName[0]) + StreetName.Substring(1);
        return street;
    }
    public string GenerateStreetNumber()
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
            return StreetNumber;
        }

        return StreetNumber;
    }
    public string GenerateFloor()
    {
        // floor number is either "st" or a number 1-99, so we take random number, if we get 0, we turn that into "st", otherwise just return
        string FloorToReturn;
        int floorNumber = random.Next(0, 100);
        if (floorNumber == 0)
        {
            FloorToReturn = "st";
        }
        else FloorToReturn = floorNumber.ToString();

        return FloorToReturn;
    }
    public string GenerateDoor()
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

        return DoorToReturn;
    }
    //Reading city and postalcode from Address.sql
    public async Task<(bool IsSuccess, string cityName, int postalCode)> GenerateCity()
    {
        //So that the DB isn't continuously spammed
        if(citylist != null)
        {
            //Random city number from the list
            int index = random.Next(0, citylist.Count);

            return (true, citylist[index].CityName, citylist[index].PostalCode);
        }

        MySqlConnection conn = DBUtils.GetDBConnection();
        citylist = new List<City>();

        try
        {
            conn.Open();

            //SQL Query to execute
            //selecting from postal code
            string sql = "select * from postal_code";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            DbDataReader rdr = await cmd.ExecuteReaderAsync();

            //read the data + create a list of the cities read from the database
            while (rdr.Read())
            {
                citylist.Add(new City(Convert.ToInt32(rdr[0]), rdr[1].ToString()));
            }
            rdr.Close();

            //Random city number from the list
            int index = random.Next(0, citylist.Count);

            return (true, citylist[index].CityName, citylist[index].PostalCode);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return (false, null, 0);
        }
    }
}