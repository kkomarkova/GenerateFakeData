using MySql.Data.MySqlClient;


namespace GenerateFakeData.Database
{
    public static class DbUtils
    {
        public static MySqlConnection GetDbConnection()
        {
            const string host = "ilzyz0heng1bygi8.chr7pe7iynqr.eu-west-1.rds.amazonaws.com";
            const int port = 3306;
            const string database = "sy27b9hvoxzw2vww";
            const string username = "afyc8wdc8jh58a4w";
            const string password = "mre2oikifr6lpty2";

            return DbMySqlUtils.GetDbConnection(host, port, database, username, password);
        }
    }
}
