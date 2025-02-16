﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    //ERROR -1: Enums, to be better organized, they should start with Capital letter and all the other words
    //starting with capital as well... For example: WeaponType.
    public enum weapontype
    {
        Sword,
        Polearm,
        Claymore,
        Catalyst,
        Bow,
        None
    }

    public class Weapon
    {
        // Name,Type,Rarity,BaseAttack
        public string Name { get; set; }
        public weapontype Type { get; set; }
        public int Rarity { get; set; }
        public int BaseAttack { get; set; }

        public string Image { get; set; }
        public string SecondaryStat { get; set; }
        public string Passive { get; set; }

        /// <summary>
        /// The Comparator function to check for name
        /// </summary>
        /// <param name="left">Left side Weapon</param>
        /// <param name="right">Right side Weapon</param>
        /// <returns> -1 (or any other negative value) for "less than", 0 for "equals", or 1 (or any other positive value) for "greater than"</returns>
        public static int CompareByName(Weapon left, Weapon right)
        {
            return left.Name.CompareTo(right.Name);
        }
        public static int CompareByType(Weapon left, Weapon right)
        {
            return left.Type.CompareTo(right.Type);
        }
        public static int CompareByRarity(Weapon left, Weapon right)
        {
            return left.Rarity.CompareTo(right.Rarity);
        }
        public static int CompareByBaseAttack(Weapon left, Weapon right)
        {
            return left.BaseAttack.CompareTo(right.BaseAttack);
        }
        // TODO: add sort for each property:
        // CompareByType
        // CompareByRarity
        // CompareByBaseAttack

        /// <summary>
        /// The Weapon string with all the properties
        /// </summary>
        /// <returns>The Weapon formated string</returns>

        public static bool TryParse(string rawData, out Weapon weapon)
        {
            string[] values = rawData.Split(',');
            weapon = new Weapon();

            // NOTE using int.TryParse is ok too then they don't need the exception.
            if (values.Length == 7)
            {
                try
                {
                    weapon.Name = values[0];
                    weapon.Type = Enum.Parse<weapontype>(values[1]);
                    weapon.Image = values[2];
                    weapon.Rarity = int.Parse(values[3]);
                    weapon.BaseAttack = int.Parse(values[4]);
                    weapon.SecondaryStat = values[5];
                    weapon.Passive = values[6];
                    return true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Unable to parse");
                    return false;
                }
            }
            return false;
        }
        public override string ToString()
        {
            // TODO: construct a comma seperated value string
            // Name,Type,Rarity,BaseAttack
            string message = $@"{Name}, {Type}, {Rarity}, {BaseAttack}, {Image}, {SecondaryStat}, {Passive}";
            return message;
        }
    }
}
