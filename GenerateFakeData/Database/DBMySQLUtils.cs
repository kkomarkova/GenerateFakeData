using MySql.Data.MySqlClient;

namespace GenerateFakeData.Database
{
    public static class DbMySqlUtils
    {
        public static MySqlConnection
                GetDbConnection(string host, int port, string database, string username, string password)
        {
            // Connection String.
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;

            var conn = new MySqlConnection(connString);

            return conn;
        }
    }
}
