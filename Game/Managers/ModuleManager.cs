using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Game.Managers
{
    class MM
    {
        public static List<string> Modules = new List<string>();

        public static void GetModules()
        {
            Modules = new List<string>();
            string[] fileEntries = Directory.GetFiles(@"Modules");
            foreach (string fileName in fileEntries)
            {
                // Here we call Regex.Match.
                Match match = Regex.Match(fileName, @"........(.+)\.[^.]*$",
                    RegexOptions.IgnoreCase);

                // Here we check the Match instance.
                if (match.Success)
                {
                    // Finally, we get the Group value and display it.
                    string key = match.Groups[1].Value;
                    List<List<string>> data = DBM.SQLRaw("SELECT * FROM Modules WHERE name='" + key + "'", "Modules");
                    try
                    {
                        if (data[0][2] == "true")
                        {
                            Modules.Add(key + " - Loaded");
                        }
                        else
                        {
                            Modules.Add(key + " - Not loaded");
                        }
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        DBM.SQLRaw("INSERT INTO Modules (name, loaded) VALUES ('"+ key + "','false')","Modules");
                        Modules.Add(key + " - Not loaded");
                    }
                }
            }
        }

        public static void LoadModule(string module)
        {
            List<List<string>> data = DBM.SQLRaw("SELECT * FROM Modules WHERE name='" + module + "'", "Modules");
            try
            {
                if (data[0][2] == "true") // loaded
                {
                    Console.WriteLine("This module is already loaded");
                }
                else // not loaded
                {
                    string moduleFileName = module + ".json";
                    Dictionary<string, List<List<string>>> moduleData = JsonConvert.DeserializeObject<Dictionary<string, List<List<string>>>>(File.ReadAllText(@"Modules\" + moduleFileName));
                    foreach (KeyValuePair<string, List<List<string>>> entry in moduleData)
                    {
                        switch (entry.Key)
                        {
                            case "weapons":
                                {
                                    foreach (List<string> weapon in entry.Value)
                                    {
                                        DBM.SQLRaw(string.Format("INSERT INTO Weapons (name, weapontype, damagetype, damage, rarity) VALUES ('{0}','{1}','{2}',{3},{4})",
                                        weapon[0].Replace("'", "''"),
                                        weapon[1].Replace("'", "''"),
                                        weapon[2].Replace("'", "''"),
                                        weapon[3].Replace("'", "''"),
                                        weapon[4].Replace("'", "''")), "Weapons");
                                        Console.WriteLine("Added " + weapon[0] + " to database");

                                    }
                                    break;
                                }
                            case "armours":
                                {
                                    foreach (List<string> weapon in entry.Value)
                                    {
                                        DBM.SQLRaw(string.Format("INSERT INTO Armours (name, armourtype, protectiontype, protection, rarity) VALUES ('{0}','{1}','{2}',{3},{4})",
                                        weapon[0].Replace("'", "''"),
                                        weapon[1].Replace("'", "''"),
                                        weapon[2].Replace("'", "''"),
                                        weapon[3].Replace("'", "''"),
                                        weapon[4].Replace("'", "''")), "Armours");
                                        Console.WriteLine("Added " + weapon[0] + " to database");

                                    }
                                    break;
                                }
                            case "items":
                                {
                                    foreach (List<string> weapon in entry.Value)
                                    {
                                        DBM.SQLRaw(string.Format("INSERT INTO Items (name, buffstat, buffvalue, nerfstat, nerfvalue, rarity) VALUES ('{0}','{1}',{2},'{3}',{4},{5})",
                                        weapon[0].Replace("'", "''"),
                                        weapon[1].Replace("'", "''"),
                                        weapon[2].Replace("'", "''"),
                                        weapon[3].Replace("'", "''"),
                                        weapon[4].Replace("'", "''"),
                                        weapon[5].Replace("'", "''")), "Items");
                                        Console.WriteLine("Added " + weapon[0] + " to database");
                                    }                                  
                                    break;
                                }
                            case "consumables":
                                {
                                    foreach (List<string> weapon in entry.Value)
                                    {
                                        DBM.SQLRaw(string.Format("INSERT INTO Consumables (name, type, value, rarity) VALUES ('{0}','{1}',{2},{3})",
                                        weapon[0].Replace("'", "''"),
                                        weapon[1].Replace("'", "''"),
                                        weapon[2].Replace("'", "''"),
                                        weapon[3].Replace("'", "''")), "Weapons");
                                        Console.WriteLine("Added " + weapon[0] + " to database");
                                    }
                                    break;
                                }
                            case "spells":
                                {
                                    foreach (List<string> weapon in entry.Value)
                                    {
                                        DBM.SQLRaw(string.Format("INSERT INTO Spells (name, manacost, magictype, target, damagetype, damage, rarity) VALUES ('{0}',{1},'{2}','{3}','{4}',{5},{6})",
                                        weapon[0].Replace("'", "''"),
                                        weapon[1].Replace("'", "''"),
                                        weapon[2].Replace("'", "''"),
                                        weapon[3].Replace("'", "''"),
                                        weapon[4].Replace("'", "''"),
                                        weapon[5].Replace("'", "''"),
                                        weapon[6].Replace("'", "''")), "Spells");
                                        Console.WriteLine("Added " + weapon[0] + " to database");
                                    }
                                    break;
                                }
                            case "monsters":
                                {
                                    foreach (List<string> weapon in entry.Value)
                                    {
                                        DBM.SQLRaw(string.Format("INSERT INTO Monsters (name, health, mana, magictype, strength, dexterity, constitution, intelligence, luck, weapontype, damagetype, damage, rarity) VALUES ('{0}',{1},{2},'{3}',{4},{5},{6},{7},{8},'{9}','{10}',{11},{12})",
                                        weapon[0].Replace("'", "''"),
                                        weapon[1].Replace("'", "''"),
                                        weapon[2].Replace("'", "''"),
                                        weapon[3].Replace("'", "''"),
                                        weapon[4].Replace("'", "''"),
                                        weapon[5].Replace("'", "''"),
                                        weapon[6].Replace("'", "''"),
                                        weapon[7].Replace("'", "''"),
                                        weapon[8].Replace("'", "''"),
                                        weapon[9].Replace("'", "''"),
                                        weapon[10].Replace("'", "''"),
                                        weapon[11].Replace("'", "''"),
                                        weapon[12].Replace("'", "''")), "Monsters");
                                        Console.WriteLine("Added " + weapon[0] + " to database");
                                    }
                                    break;
                                }
                            case "bosses":
                                {
                                    foreach (List<string> weapon in entry.Value)
                                    {
                                        DBM.SQLRaw(string.Format("INSERT INTO Bosses (name, health, mana, magictype, strength, dexterity, constitution, intelligence, luck, weapontype, damagetype, damage, specialtype, specialvalue, specialcost, rarity) VALUES ('{0}',{1},{2},'{3}',{4},{5},{6},{7},{8},'{9}','{10}',{11},'{12}',{13},{14},{15})",
                                        weapon[0].Replace("'", "''"),
                                        weapon[1].Replace("'", "''"),
                                        weapon[2].Replace("'", "''"),
                                        weapon[3].Replace("'", "''"),
                                        weapon[4].Replace("'", "''"),
                                        weapon[5].Replace("'", "''"),
                                        weapon[6].Replace("'", "''"),
                                        weapon[7].Replace("'", "''"),
                                        weapon[8].Replace("'", "''"),
                                        weapon[9].Replace("'", "''"),
                                        weapon[10].Replace("'", "''"),
                                        weapon[11].Replace("'", "''"),
                                        weapon[12].Replace("'", "''"),
                                        weapon[13].Replace("'", "''"),
                                        weapon[14].Replace("'", "''"),
                                        weapon[15].Replace("'", "''")), "Bosses");
                                        Console.WriteLine("Added " + weapon[0] + " to database");
                                    }
                                    break;
                                }
                        }

                    }
                    DBM.SQLRaw("UPDATE Modules SET loaded='true' WHERE name='" + module + "'", "Modules");
                    Console.WriteLine("Module loaded");
                }
            }
            catch (System.ArgumentOutOfRangeException) // wrong input
            {
                Console.WriteLine("Error - This module does not exist");
            }          
        }

        public static void UnloadModule(string module)
        {
            List<List<string>> data = DBM.SQLRaw("SELECT * FROM Modules WHERE name='" + module + "'", "Modules");
            try
            {
                if (data[0][2] == "false") // not loaded
                {
                    Console.WriteLine("This module is not loaded");
                }
                else // loaded
                {
                    string moduleFileName = module + ".json";
                    Dictionary<string, List<List<string>>> moduleData = JsonConvert.DeserializeObject<Dictionary<string, List<List<string>>>>(File.ReadAllText(@"Modules\" + moduleFileName));
                    foreach (KeyValuePair<string, List<List<string>>> entry in moduleData)
                    {
                        switch (entry.Key)
                        {
                            case "weapons":
                                {
                                    foreach (List<string> weapon in entry.Value)
                                    {
                                        DBM.SQLRaw(string.Format(@"DELETE FROM Weapons WHERE name='{0}'", weapon[0].Replace("'", "''")), "Weapons");
                                        Console.WriteLine("Removed " + weapon[0] + " from database");

                                    }
                                    break;
                                }
                            case "armours":
                                {
                                    foreach (List<string> weapon in entry.Value)
                                    {
                                        DBM.SQLRaw(string.Format(@"DELETE FROM Armours WHERE name='{0}'", weapon[0].Replace("'", "''")), "Armours");
                                        Console.WriteLine("Removed " + weapon[0] + " from database");

                                    }
                                    break;
                                }
                            case "items":
                                {
                                    foreach (List<string> weapon in entry.Value)
                                    {
                                        DBM.SQLRaw(string.Format(@"DELETE FROM Items WHERE name='{0}'", weapon[0].Replace("'", "''")), "Items");
                                        Console.WriteLine("Removed " + weapon[0] + " from database");

                                    }
                                    break;
                                }
                            case "consumables":
                                {
                                    foreach (List<string> weapon in entry.Value)
                                    {
                                        DBM.SQLRaw(string.Format(@"DELETE FROM Consumables WHERE name='{0}'", weapon[0].Replace("'", "''")), "Consumables");
                                        Console.WriteLine("Removed " + weapon[0] + " from database");

                                    }
                                    break;
                                }
                            case "spells":
                                {
                                    foreach (List<string> weapon in entry.Value)
                                    {
                                        DBM.SQLRaw(string.Format(@"DELETE FROM Spells WHERE name='{0}'", weapon[0].Replace("'", "''")), "Spells");
                                        Console.WriteLine("Removed " + weapon[0] + " from database");

                                    }
                                    break;
                                }
                            case "monsters":
                                {
                                    foreach (List<string> weapon in entry.Value)
                                    {
                                        DBM.SQLRaw(string.Format(@"DELETE FROM Monsters WHERE name='{0}'", weapon[0].Replace("'", "''")), "Monsters");
                                        Console.WriteLine("Removed " + weapon[0] + " from database");

                                    }
                                    break;
                                }
                            case "bosses":
                                {
                                    foreach (List<string> weapon in entry.Value)
                                    {
                                        DBM.SQLRaw(string.Format(@"DELETE FROM Bosses WHERE name='{0}'", weapon[0].Replace("'", "''")), "Bosses");
                                        Console.WriteLine("Removed " + weapon[0] + " from database");

                                    }
                                    break;
                                }
                        }

                    }
                    DBM.SQLRaw("UPDATE Modules SET loaded='false' WHERE name='" + module + "'", "Modules");
                    Console.WriteLine("Module unloaded");
                }
            }
            catch (System.ArgumentOutOfRangeException) // wrong input
            {
                Console.WriteLine("Error - This module does not exist");
            }
        }
    }
}
