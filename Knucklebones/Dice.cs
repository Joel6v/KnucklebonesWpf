using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knucklebones
{
    public class Dice
    {
        public DiceName CurrentDice { get; set; }

        public Dice(DiceName currentDice)
        {
            CurrentDice = currentDice;
        }

        public Dice(int currentDice) //range from 0 to 6
        {
            CurrentDice = (DiceName)currentDice;
        }

        public string GetPath()
        {
            return @"F:\Schule\IMST23_4\M322\Knucklebones\" + PathsRelative[(int)CurrentDice];
        }

        public int GetValue()
        {
            return (int)CurrentDice;
        }

        private static List<string> PathsRelative = new List<string>() { "\\Images\\Dice\\Empty_Dice.png", "\\Images\\Dice\\One_Dice.png",
        "\\Images\\Dice\\Two_Dice.png", "\\Images\\Dice\\Three_Dice.png", "\\Images\\Dice\\Four_Dice.png", "\\Images\\Dice\\Five_Dice.png", "\\Images\\Dice\\Six_Dice.png"};
    }

    public enum DiceName
    {
        None,
        One,
        Two,
        Three,
        Four,
        Five,
        Six
    }
}
