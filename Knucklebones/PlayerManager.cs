using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Knucklebones
{
    public class PlayerManager
    {
        public bool PlayerLeft { get; private set; }

        public Image ContainerLeft { get; set; }
        public Image BtnRollLeft { get; set; }

        public Image ContainerRight { get; set; }
        public Image BtnRollRight { get; set; }

        public PlayerManager(Image containerLeft, Image btnRollLeft, Image containerRight, Image btnRollRight)
        {
            PlayerLeft = false;

            ContainerLeft = containerLeft;
            BtnRollLeft = btnRollLeft;

            ContainerRight = containerRight;
            BtnRollRight = btnRollRight;

            ContainerLeft.Source = new BitmapImage(new Uri(new Dice(DiceName.None).GetPath(), UriKind.Absolute));
            ChangeToOtherPlayer(); //change PlayerLeft = true
        }

        public void Win()
        {
            BtnRollLeft.Source = new BitmapImage(new Uri(Button.RedButton, UriKind.Absolute));
            BtnRollRight.Source = new BitmapImage(new Uri(Button.RedButton, UriKind.Absolute));

            ContainerLeft.Source = new BitmapImage(new Uri(new Dice(DiceName.None).GetPath(), UriKind.Absolute));
            ContainerRight.Source = new BitmapImage(new Uri(new Dice(DiceName.None).GetPath(), UriKind.Absolute));
        }

        public void ChangeToOtherPlayer()
        {
            if (PlayerLeft)
            {
                BtnRollLeft.Source = new BitmapImage(new Uri(Button.RedButton, UriKind.Absolute));
                BtnRollRight.Source = new BitmapImage(new Uri(Button.GreenButton, UriKind.Absolute));
                ContainerLeft.Source = new BitmapImage(new Uri(new Dice(DiceName.None).GetPath(), UriKind.Absolute));
            }
            else
            {
                BtnRollLeft.Source = new BitmapImage(new Uri(Button.GreenButton, UriKind.Absolute));
                BtnRollRight.Source = new BitmapImage(new Uri(Button.RedButton, UriKind.Absolute));
                ContainerRight.Source = new BitmapImage(new Uri(new Dice(DiceName.None).GetPath(), UriKind.Absolute));
            }

            PlayerLeft ^= true;
        }

        private void SetButtonsInContainer()
        {
            BtnRollLeft.Source = new BitmapImage(new Uri(Button.RedButton, UriKind.Absolute));
            BtnRollRight.Source = new BitmapImage(new Uri(Button.RedButton, UriKind.Absolute));
        }

        public Dice RollBtnClicked(string name)
        {
            Dice newDice = new Dice();
            if (name == "_0_BtnRoll" && PlayerLeft)
            {
                ContainerLeft.Source = new BitmapImage(new Uri(newDice.GetPath(), UriKind.Absolute));
                SetButtonsInContainer();

                return newDice;
            }
            else if (name == "_1_BtnRoll" && !PlayerLeft)
            {
                ContainerRight.Source = new BitmapImage(new Uri(newDice.GetPath(), UriKind.Absolute));
                SetButtonsInContainer();

                return newDice;
            }
            return null;
        }

        public bool CorrectField(string name)
        {
            return !((name[1] == '0') ^ PlayerLeft);
        }
    }
}
