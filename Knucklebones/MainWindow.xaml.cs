using System.Drawing;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Knucklebones
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FieldManager FieldManager;
        private PlayerManager PlayerManager;
        private bool Win = false;
        private Dice CurrentDiceInContainer;

        public MainWindow()
        {
            InitializeComponent();

            FieldManager = new FieldManager(_0_Score, _1_Score);
            SetStartImages();
            PlayerManager = new PlayerManager(_0_Container, _0_BtnRoll, _1_Container, _1_BtnRoll);
        }

        private void SetStartImages()
        {
            for (int player = 0;  player < 2; player++)
            {
                for(int x = 0;  x < 3; x++)
                {
                    for(int y = 0; y < 3; y++)
                    {
                        FieldManager.Add((Image)FindName($"_{player}_{x}{y}"), player, x, y);
                    }
                }
            }
        }

        public void Roll_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string name = (sender as Image).Name;
            if (CurrentDiceInContainer == null && !Win)
            {
                CurrentDiceInContainer = PlayerManager.RollBtnClicked(name);
            }
        }

        public void Field_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string name = (sender as Image).Name;
            if (PlayerManager.CorrectField(name) && CurrentDiceInContainer != null)
            {
                if(FieldManager.FieldClicked(name, CurrentDiceInContainer))
                {
                    CurrentDiceInContainer = null;
                    if (FieldManager.CheckIfWin(PlayerManager.PlayerLeft))
                    {
                        PlayerManager.Win();
                        Win = true;
                    }
                    else
                    {
                        PlayerManager.ChangeToOtherPlayer();
                    }
                }              
            }
        }
    }

    public class Button
    {
        public static string GreenButton = @"F:\Schule\IMST23_4\M322\Knucklebones\" + "\\Images\\Buttons\\Roll_Green.png";
        public static string RedButton = @"F:\Schule\IMST23_4\M322\Knucklebones\" + "\\Images\\Buttons\\Roll_Red.png";
    }
}