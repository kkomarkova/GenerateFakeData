using GenerateFakeData.Model;
using MySql.Data.MySqlClient;

namespace GenerateFakeData.Database;

public class FetchAddressInformation
{
    private MySqlConnection conn;

    public FetchAddressInformation()
    {
        conn = DbUtils.GetDbConnection();
    }

    public async Task<(bool success, List<City>)> FetchCityInformation()
    {
        try
        {
            var cityList = new List<City>();
            conn.Open();

            //SQL Query to execute
            //selecting from postal code
            const string sql = "select * from postal_code";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var rdr = await cmd.ExecuteReaderAsync();

            //read the data + create a list of the cities read from the database
            while (await rdr.ReadAsync())
            {
                cityList.Add(new City(Convert.ToInt32(rdr[0]), rdr[1].ToString()));
            }
            await rdr.CloseAsync();

            await conn.CloseAsync();
            return (true, cityList);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return (false, null);
        }
    }
}