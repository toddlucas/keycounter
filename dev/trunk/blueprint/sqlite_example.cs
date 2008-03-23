using System;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a connection and a command
            using (DbConnection cnn = new SQLiteConnection("Data Source=test.db3"))
            using (DbCommand cmd = cnn.CreateCommand())
            {
                // Open the connection. If the database doesn't exist,
                // it will be created automatically
                cnn.Open();
                // Create a table in the database
                cmd.CommandText = "CREATE TABLE FOO (ID INTEGER PRIMARY KEY, MYVALUE VARCHAR(50))";
                cmd.ExecuteNonQuery();

                // Create a parameterized insert command
                cmd.CommandText = "INSERT INTO FOO (MYVALUE) VALUES(?)";
                cmd.Parameters.Add(cmd.CreateParameter());

                // Insert 10 rows into the database
                for (int n = 0; n < 10; n++)
                {
                    cmd.Parameters[0].Value = "Value " + n.ToString();
                    cmd.ExecuteNonQuery();
                }
                // Now read them back
                cmd.CommandText = "SELECT * FROM FOO";
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("ID = {0}, MYVALUE = {1}", reader[0], reader[1]));
                    }
                }
            }
            Console.ReadKey();
        }
    }
}