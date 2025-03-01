using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Knucklebones
{
    public class Field
    {
        public Image ImageElement { get; set; }

        private Dice _DiceOnField;

        public Dice DiceOnField { get { return _DiceOnField; } set { _DiceOnField = value; LoadDiceImage(); } }

        public Field(Image imageElement)
        {
            ImageElement = imageElement;
            _DiceOnField = new Dice(DiceName.None);
            LoadDiceImage();
        }

        public bool IsNone()
        {
            return _DiceOnField.CurrentDice == DiceName.None;
        }

        private void LoadDiceImage()
        {
            ImageElement.Source = new BitmapImage(new Uri(_DiceOnField.GetPath(), UriKind.Absolute));
        }
    }
}
