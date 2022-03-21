using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace GenerateFakeData.Database
{
    public class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "ilzyz0heng1bygi8.chr7pe7iynqr.eu-west-1.rds.amazonaws.com";
            int port = 3306;
            string database = "sy27b9hvoxzw2vww";
            string username = "afyc8wdc8jh58a4w";
            string password = "mre2oikifr6lpty2";

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}
