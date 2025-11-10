using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB
{
    public class DBHelper
    {
        private const string dataBaseFile = "Students.db";


        // SQLite - SQLite....

        public static SQLiteConnection dbGetConnection()
        {
            if (!File.Exists(dataBaseFile)) //if file do not exist we create it, otherwise we do nothing
            {
                SQLiteConnection.CreateFile(dataBaseFile);
                using var conection = new SQLiteConnection($"Data Source={dataBaseFile};Version=3;"); // joining Students.db with version 3
                conection.Open();

                // commands = string data
                // CREATE TABLE {name} ({COLUMS name DATA TYPE)
                string createTable = "CREATE TABLE students (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT, age INTEGER)";
                using var command = new SQLiteCommand(createTable, conection); // creating command (discribing command first, then connection)
                command.ExecuteNonQuery();
            }
            return new SQLiteConnection($"Data Source={dataBaseFile};Version=3;");
        }
    }
}
