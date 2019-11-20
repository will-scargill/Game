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
                    sql = "CREATE TABLE 'Weapons' ( 'id' INTEGER PRIMARY KEY AUTOINCREMENT, 'name' TEXT, 'weapontype' TEXT, 'damagetype' TEXT, 'damage' REAL, 'rarity' INT )";
                    command = new SQLiteCommand(sql, dbConn); /// Use sql command on database
                    reader = command.ExecuteReader(); /// Setup reader
                    sql = "CREATE TABLE 'Consumables' ( 'id' INTEGER PRIMARY KEY AUTOINCREMENT, 'name' TEXT, 'type' TEXT, 'value' REAL, 'rarity' INT )";
                    command = new SQLiteCommand(sql, dbConn); /// Use sql command on database
                    reader = command.ExecuteReader(); /// Setup reader
                    sql = "CREATE TABLE 'Armours' ( 'id' INTEGER PRIMARY KEY AUTOINCREMENT, 'name' TEXT, 'armourtype' TEXT, 'protectiontype' TEXT, 'protection' REAL, 'rarity' INT )";
                    command = new SQLiteCommand(sql, dbConn); /// Use sql command on database
                    reader = command.ExecuteReader(); /// Setup reader
                    sql = "CREATE TABLE 'Monsters' ( 'id' INTEGER PRIMARY KEY AUTOINCREMENT, 'name' TEXT, 'health' INT, 'mana' INT, 'magictype' TEXT, 'strength' INT, 'dexterity' INT, 'constitution' INT, 'intelligence' INT, 'luck' INT, 'weapontype' TEXT, 'damagetype' TEXT, 'damage' REAL, 'rarity' INT )";
                    command = new SQLiteCommand(sql, dbConn); /// Use sql command on database
                    reader = command.ExecuteReader(); /// Setup reader
                    sql = "CREATE TABLE 'Bosses' ( 'id' INTEGER PRIMARY KEY AUTOINCREMENT, 'name' TEXT, 'health' INT, 'mana' INT, 'magictype' TEXT, 'strength' INT, 'dexterity' INT, 'constitution' INT, 'intelligence' INT, 'luck' INT, 'weapontype' TEXT, 'damagetype' TEXT, 'damage' REAL, 'specialtype' TEXT, 'specialvalue' INT, 'specialcost' INT, 'rarity' INT )";
                    command = new SQLiteCommand(sql, dbConn); /// Use sql command on database
                    reader = command.ExecuteReader(); /// Setup reader
                    sql = "CREATE TABLE 'Items' ( 'id' INTEGER PRIMARY KEY AUTOINCREMENT, 'name' TEXT, 'buffstat' TEXT, 'buffvalue' INT, 'nerfstat' TEXT, 'nerfvalue' INT, 'rarity' INT)";
                    command = new SQLiteCommand(sql, dbConn); /// Use sql command on database
                    reader = command.ExecuteReader(); /// Setup reader
                    sql = "CREATE TABLE 'Spells' ( 'id' INTEGER PRIMARY KEY AUTOINCREMENT, 'name' TEXT, 'manacost' INT, 'magictype' TEXT, 'target' TEXT, 'damagetype' TEXT, 'damage' REAL, 'rarity' INT)";
                    command = new SQLiteCommand(sql, dbConn); /// Use sql command on database
                    reader = command.ExecuteReader(); /// Setup reader
                    sql = "CREATE TABLE 'Modules' ( 'id' INTEGER PRIMARY KEY AUTOINCREMENT, 'name' TEXT, 'loaded' INT)";
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
                        data.Add(new List<string> { reader["id"].ToString(), reader["name"].ToString(), reader["weapontype"].ToString(), reader["damagetype"].ToString(), reader["damage"].ToString(), reader["rarity"].ToString() });
                    break;
                case "Armours":
                    while (reader.Read())
                        data.Add(new List<string> { reader["id"].ToString(), reader["name"].ToString(), reader["armourtype"].ToString(), reader["protectiontype"].ToString(), reader["protection"].ToString(), reader["rarity"].ToString() });
                    break;
                case "Monsters":
                    while (reader.Read())
                        data.Add(new List<string> { reader["id"].ToString(), reader["name"].ToString(), reader["health"].ToString(), reader["mana"].ToString(), reader["magictype"].ToString(), reader["strength"].ToString(), reader["dexterity"].ToString(), reader["constitution"].ToString(), reader["intelligence"].ToString(), reader["luck"].ToString(), reader["weapontype"].ToString(), reader["damagetype"].ToString(), reader["damage"].ToString(),  reader["rarity"].ToString() });
                    break;
                case "Bosses":
                    while (reader.Read())
                        data.Add(new List<string> { reader["id"].ToString(), reader["name"].ToString(), reader["health"].ToString(), reader["mana"].ToString(), reader["magictype"].ToString(), reader["strength"].ToString(), reader["dexterity"].ToString(), reader["constitution"].ToString(), reader["intelligence"].ToString(), reader["luck"].ToString(), reader["weapontype"].ToString(), reader["damagetype"].ToString(), reader["damage"].ToString(), reader["specialtype"].ToString(), reader["specialvalue"].ToString(), reader["specialcost"].ToString(), reader["rarity"].ToString() });
                    break;
                case "Consumables":
                    while (reader.Read())
                        data.Add(new List<string> { reader["id"].ToString(), reader["name"].ToString(), reader["type"].ToString(), reader["value"].ToString(), reader["rarity"].ToString() });
                    break;
                case "Items":
                    while (reader.Read())
                        data.Add(new List<string> { reader["id"].ToString(), reader["name"].ToString(), reader["buffstat"].ToString(), reader["buffvalue"].ToString(), reader["nerfstat"].ToString(), reader["nerfvalue"].ToString(), reader["rarity"].ToString() });
                    break;
                case "Modules":
                    while (reader.Read())
                        data.Add(new List<string> { reader["id"].ToString(), reader["name"].ToString(), reader["loaded"].ToString() });
                    break;
            }
            reader.Close();
            return data;
        }
    }
}
