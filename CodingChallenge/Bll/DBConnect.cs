using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CodingChallenge.Bll
{
    public class DBConnect
    {
        public static MySqlConnection conn;

        public static MySqlConnection GetConnection()
        {
            conn = new MySqlConnection();
            string connectionString =
                    @"server=127.0.0.1;" +
                    @"uid=root;" +
                    @"pwd=root;" +
                    @"database=Challenge;";

            conn.ConnectionString = connectionString;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }

        public static void CloseConnection()
        {
            conn.Close();
        }
    }
}
