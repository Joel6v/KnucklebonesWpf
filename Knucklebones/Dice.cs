using System;
using System.Collections.Generic;
using System.IO;
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

        public Dice()
        {
            CurrentDice = (DiceName)new Random().Next(1, 7);
        }

        public string GetPath()
        {
            return MainWindow.PathAbsolut + PathAbsolutDice + PathsRelative[(int)CurrentDice];
        }

        public int GetValue()
        {
            return (int)CurrentDice;
        }

        public static bool CheckFilesExist()
        {
            for (int i = 0; i < PathsRelative.Count; i++) 
            {
                if(!File.Exists(MainWindow.PathAbsolut + PathAbsolutDice + PathsRelative[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public const string PathAbsolutDice = @"\Images\Dice\";

        private static List<string> PathsRelative = new List<string>() { "Empty_Dice.png", "One_Dice.png",
        "Two_Dice.png", "Three_Dice.png", "Four_Dice.png", "Five_Dice.png", "Six_Dice.png"};
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
