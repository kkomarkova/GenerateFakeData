using System.Data.Common;
using GenerateFakeData.Database;
using GenerateFakeData.Model;
using MySql.Data.MySqlClient;

namespace GenerateFakeData.Service;

class AddressService
{
    Random random = new();
    List<City> cityList;
    public string GenerateStreetName()
    {
        // lets say we want our street names to be at least 6 and at most 16 characters long, so that it makes *some* sense
        int length = random.Next(6, 17);
        const string chars = "abcdefghijklmnopqrstuvwxyz";
        string streetName = new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());

        // returning so that the first letter is capitalized and others are lower case
        string street = char.ToUpper(streetName[0]) + streetName.Substring(1);
        return street;
    }
    public string GenerateStreetNumber()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string streetNumber = random.Next(1, 1000).ToString();
        // optionalFollowed - random if the letter follows number, if 0 letter A-Z follows the number, if 1 only number
        int optionalFollowed = random.Next(0, 2);

        if (optionalFollowed == 0)
        {
            streetNumber += chars[random.Next(chars.Length)];
        }

        else if (optionalFollowed == 1)
        {
            return streetNumber;
        }

        return streetNumber;
    }
    public string GenerateFloor()
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
    public string GenerateDoor()
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
    //Reading city and postalcode from Address.sql
    public async Task<(bool IsSuccess, string cityName, int postalCode)> GenerateCity()
    {
        //So that the DB isn't continuously spammed
        if(cityList != null)
        {
            //Random city number from the list
            int index = random.Next(0, cityList.Count);

            return (true, cityList[index].CityName, cityList[index].PostalCode);
        }

        MySqlConnection conn = DbUtils.GetDbConnection();
        cityList = new List<City>();

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
                cityList.Add(new City(Convert.ToInt32(rdr[0]), rdr[1].ToString()));
            }
            rdr.Close();

            //Random city number from the list
            int index = random.Next(0, cityList.Count);

            return (true, cityList[index].CityName, cityList[index].PostalCode);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return (false, null, 0);
        }
    }
}