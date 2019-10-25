using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Game.Managers
{
    static class DBM
    {
        private static SQLiteConnection dbConn;
        private static SQLiteCommand command;
        private static SQLiteDataReader reader;
        private static string sql;

        public static void SQLInitialise()
        {
            dbConn = new SQLiteConnection("Data Source=database.db;Version=3;"); /// Assign it to a db connnection
            dbConn.Open(); /// Open the database
            sql = "SELECT count(*) FROM sqlite_master WHERE type='table'";
            command = new SQLiteCommand(sql, dbConn); /// Use sql command on database
            reader = command.ExecuteReader(); /// Setup reader
            while (reader.Read())
            {
                if (Convert.ToInt16(reader[0]) == 0)
                {
                    sql = "CREATE TABLE 'Weapons' ( 'id' INTEGER PRIMARY KEY AUTOINCREMENT, 'name' TEXT, 'durability' INT, 'weapontype' TEXT, 'damagetype' TEXT, 'damage' REAL, 'rarity' INT )";
                    command = new SQLiteCommand(sql, dbConn); /// Use sql command on database
                    reader = command.ExecuteReader(); /// Setup reader
                    sql = "CREATE TABLE 'Consumables' ( 'id' INTEGER PRIMARY KEY AUTOINCREMENT, 'name' TEXT, 'type' TEXT, 'value' REAL, 'rarity' INT )";
                    command = new SQLiteCommand(sql, dbConn); /// Use sql command on database
                    reader = command.ExecuteReader(); /// Setup reader
                    sql = "CREATE TABLE 'Armours' ( 'id' INTEGER PRIMARY KEY AUTOINCREMENT, 'name' TEXT, 'durability' INT, 'armourtype' TEXT, 'protectiontype' TEXT, 'protection' REAL, 'rarity' INT )";
                    command = new SQLiteCommand(sql, dbConn); /// Use sql command on database
                    reader = command.ExecuteReader(); /// Setup reader
                }
            }
        }

        public static List<List<string>> SQLGetTableData(string tableName)
        {
            string sql = "SELECT * FROM " + tableName; /// Setup sql command
            command = new SQLiteCommand(sql, dbConn); /// assign command to var
            reader = command.ExecuteReader(); /// Setup reader
            List<List<string>> data = new List<List<string>>(); /// Create list of string lists
            switch (tableName) /// Depending on table name
            {
                case "servers":
                    while (reader.Read())
                        data.Add(new List<string> { reader["id"].ToString(), reader["name"].ToString(), reader["ip"].ToString(), reader["port"].ToString() });
                    break;
            }
            reader.Close();
            return data;
        }

        public static List<List<string>> SQLRaw(string rawCom, string tableName)
        {
            string sql = rawCom; /// Setup sql command
            command = new SQLiteCommand(sql, dbConn); /// assign command to var
            reader = command.ExecuteReader(); /// Setup reader
            List<List<string>> data = new List<List<string>>(); /// Create list of string lists
            switch (tableName) /// Depending on table name
            {
                case "Weapons":
                    while (reader.Read())
                        data.Add(new List<string> { reader["id"].ToString(), reader["name"].ToString(), reader["durability"].ToString(), reader["weapontype"].ToString(), reader["damagetype"].ToString(), reader["damage"].ToString(), reader["durability"].ToString() });
                    break;
            }
            reader.Close();
            return data;
        }
    }
}
