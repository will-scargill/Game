using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Objects;

namespace Game.Managers
{
    static class EM
    {
        public static Monster GetMonster(int floornum)
        {
            Random random = new Random();
            int rarityOfMonster;
            if (floornum < 10) { rarityOfMonster = random.Next((80 - (floornum - 1 * 10)), 100); }
            else { rarityOfMonster = random.Next((80 - (floornum * 10)), (100 - (10 * (floornum - 9)))); }

            List<List<string>> data = DBM.SQLRaw("SELECT * FROM Monsters WHERE rarity >= " + rarityOfMonster, "Monsters");
            int index = random.Next(data.Count);

            // Implement scaling stat code here

            return new Monster(data[index][1],
                Convert.ToInt32(data[index][2]),
                Convert.ToInt32(data[index][3]),
                data[index][4],
                Convert.ToInt32(data[index][5]),
                Convert.ToInt32(data[index][6]),
                Convert.ToInt32(data[index][7]),
                Convert.ToInt32(data[index][8]),
                Convert.ToInt32(data[index][9]),
                data[index][10],
                data[index][11],
                Convert.ToDouble(data[index][12]),
                Convert.ToInt32(data[index][13]));
        }

        public static Boss GetBossMonster(int floornum)
        {
            Random random = new Random();
            int rarityOfMonster;
            if (floornum < 10) { rarityOfMonster = random.Next((80 - (floornum - 1 * 10)), 100); }
            else { rarityOfMonster = random.Next((80 - (floornum * 10)), (100 - (10 * (floornum - 9)))); }

            List<List<string>> data = DBM.SQLRaw("SELECT * FROM Bosses WHERE rarity >= " + rarityOfMonster, "Bosses");
            int index = random.Next(data.Count);

            // Implement scaling stat code here

            return new Boss(data[index][1],
                Convert.ToInt32(data[index][2]),
                Convert.ToInt32(data[index][3]),
                data[index][4],
                Convert.ToInt32(data[index][5]),
                Convert.ToInt32(data[index][6]),
                Convert.ToInt32(data[index][7]),
                Convert.ToInt32(data[index][8]),
                Convert.ToInt32(data[index][9]),
                data[index][10],
                data[index][11],
                Convert.ToDouble(data[index][12]),
                data[index][13],
                Convert.ToInt32(data[index][14]),
                Convert.ToInt32(data[index][15]),
                Convert.ToInt32(data[index][16]));
        }

        public static int CalculatePlayerMeleeDamage(Player player)
        {
            double damage = 0;
            int totalDamage = 0;
            if (player.EquippedWep == null)
            {
                damage = player.Strength;
            }
            else
            {
                if (player.EquippedWep.DamageType == "Physical")
                {
                    damage += player.EquippedWep.Damage;
                    if (player.EquippedWep.WeaponType == "Bludgeoning")
                    {
                        damage += (player.Strength / 2);
                    }
                    else if (player.EquippedWep.WeaponType == "Slashing")
                    {
                        damage += (player.Strength / 2);
                    }
                    else if (player.EquippedWep.WeaponType == "Piercing")
                    {
                        damage += (player.Dexterity / 2);
                    }
                }
                else if (player.EquippedWep.DamageType == "Magical")
                {

                }
            }
            totalDamage = Convert.ToInt32(damage);
            Random random = new Random();
            int crit = random.Next(1, 100);
            if (crit <= player.Luck)
            {
                totalDamage += player.Strength;
                Console.WriteLine("Critical Hit!");
            }
            return totalDamage;
        }

        public static int CalculatePlayerMagicDamage(Player player)
        {
            return 0;
        }

        public static int CalculateMonsterDamage(Monster monster, Player player)
        {
            double damage = 0;
            int totalDamage = 0;

            if (monster.DamageType == "Physical")
            {
                damage += monster.Damage;
                if (monster.WeaponType == "Bludgeoning")
                {
                    damage += (monster.Strength / 2);
                }
                else if (monster.WeaponType == "Slashing")
                {
                    damage += (monster.Strength / 2);
                }
                else if (monster.WeaponType == "Piercing")
                {
                    damage += (monster.Dexterity / 2);
                }
            }
            else if (monster.DamageType == "Magical")
            {
                damage += (monster.Intelligence / 2);
            }

            try
            {
                if (player.ArmourSlotOne.ProtectionType == monster.DamageType)
                {
                    damage -= player.ArmourSlotOne.Protection / 2;
                    //player.ArmourSlotOne.Durability -= 1;
                    // CheckArmourDurability(player, 1); // durability is a trash mechanic
                }
            }
            catch (NullReferenceException)
            {
                // :/
            }

            try
            {
                if (player.ArmourSlotTwo.ProtectionType == monster.DamageType)
                {
                    damage -= player.ArmourSlotTwo.Protection / 2;
                    //player.ArmourSlotTwo.Durability -= 1;
                    // CheckArmourDurability(player, 2); // durability is a trash mechanic
                }
            }
            catch (NullReferenceException)
            {
                // :/
            }

            try
            {
                if (player.ArmourSlotThree.ProtectionType == monster.DamageType)
                {
                    damage -= player.ArmourSlotThree.Protection / 2;
                    //player.ArmourSlotThree.Durability -= 1;
                    // CheckArmourDurability(player, 3); // durability is a trash mechanic
                }
            }
            catch (NullReferenceException)
            {
                // :/
            }


            totalDamage = Convert.ToInt32(damage);
            return totalDamage;
        }

        public static int CalculateBossMonsterDamage(Boss monster, Player player)
        {
            double damage = 0;
            int totalDamage = 0;
            Random random = new Random();
            if (random.Next(100) <= 25 && (monster.CurrentMana - monster.SpecialCost) >= 0) // special attack
            {
                GM.bossUsedSpecial = true;
                return monster.SpecialValue; // gonna redo this later
            }
            else // normal attack
            {
                if (monster.DamageType == "Physical")
                {
                    damage += monster.Damage;
                    if (monster.WeaponType == "Bludgeoning")
                    {
                        damage += (monster.Strength / 2);
                    }
                    else if (monster.WeaponType == "Slashing")
                    {
                        damage += (monster.Strength / 2);
                    }
                    else if (monster.WeaponType == "Piercing")
                    {
                        damage += (monster.Dexterity / 2);
                    }
                }
                else if (monster.DamageType == "Magical")
                {
                    damage += (monster.Intelligence / 2);
                }


                try
                {
                    if (player.ArmourSlotOne.ProtectionType == monster.DamageType)
                    {
                        damage -= player.ArmourSlotOne.Protection / 2;
                        //player.ArmourSlotOne.Durability -= 1;
                        // CheckArmourDurability(player, 1); // durability is a trash mechanic
                    }
                }
                catch (NullReferenceException)
                {
                    // :/
                }

                try
                {
                    if (player.ArmourSlotTwo.ProtectionType == monster.DamageType)
                    {
                        damage -= player.ArmourSlotTwo.Protection / 2;
                        //player.ArmourSlotTwo.Durability -= 1;
                        // CheckArmourDurability(player, 2); // durability is a trash mechanic
                    }
                }
                catch (NullReferenceException)
                {
                    // :/
                }

                try
                {
                    if (player.ArmourSlotThree.ProtectionType == monster.DamageType)
                    {
                        damage -= player.ArmourSlotThree.Protection / 2;
                        //player.ArmourSlotThree.Durability -= 1;
                        // CheckArmourDurability(player, 3); // durability is a trash mechanic
                    }
                }
                catch (NullReferenceException)
                {
                    // :/
                }


                totalDamage = Convert.ToInt32(damage);
                return totalDamage;
            }
            
        }

        /*
        public static bool CheckWeaponDurability(Player player)
        {
            if (player.EquippedWep.Durability == 0)
            {
                player.EquippedWep = null;
                return true;
            }
            else
            {
                return false;
            }
        }
        */

        /*
        public static bool CheckArmourDurability(Player player, int slot)
        {
            switch (slot)
            {
                case 1:
                    if (player.ArmourSlotOne.Durability == 0)
                    {
                        player.ArmourSlotOne = null;
                        DM.Broke("Armour");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 2:
                    if (player.ArmourSlotTwo.Durability == 0)
                    {
                        player.ArmourSlotTwo = null;
                        DM.Broke("Armour");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 3:
                    if (player.ArmourSlotThree.Durability == 0)
                    {
                        player.ArmourSlotThree = null;
                        DM.Broke("Armour");
                        return true;
                    }
                    else
                    {
                        return false;
                    }

            }
            return false;
        }
        */
        public static bool CheckMonsterDeath(Monster monster)
        {
            if (monster.CurrentHealth <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckBossDeath(Boss boss)
        {
            if (boss.CurrentHealth <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckGameOver(Player player)
        {
            if (player.CurrentHealth <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int GetGold(Monster monster)
        {
            return monster.Health / 10;
        }


    }
}
