using System.Drawing;
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
        private Field[,,] Fields = new Field[2, 3, 3];

        public MainWindow()
        {
            InitializeComponent();
            SetStartImages();
        }

        private void SetStartImages()
        {
            Fields[0, 0, 0] = new Field();

            for(int player = 0;  player < Fields.GetLength(0); player++)
            {
                for(int x = 0;  x < Fields.GetLength(1); x++)
                {
                    for(int y = 0; y < Fields.GetLength(2); y++)
                    {
                        Fields[player, ]
                    }
                }
            }
        }

        public void Field_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(sender is Image field)
            {
                //field.Name
            }
        }
    }

    public class Field
    {
        public Image ImageElement { get; set; }

        public string DiceOnFieldPath { get; set
            {
                base = value;
                LoadDiceImage();
            } }

        public Field(Image imageElement) 
        {
            this.ImageElement = imageElement;
            this.DiceOnFieldPath = Dice.None;
        }

        private void LoadDiceImage()
        {
            ImageElement.Source = new BitmapImage(new Uri(@"component/Images/down.png", UriKind.RelativeOrAbsolute));
        }
    }

    public class Dice
    {
        public static string None = AppContext.BaseDirectory + "\\Images\\Dice\\Empty_Dice.png";
        public static string One = AppContext.BaseDirectory + "\\Images\\Dice\\One_Dice.png";
        public static string Two = AppContext.BaseDirectory + "\\Images\\Dice\\Two_Dice.png";
        public static string Three = AppContext.BaseDirectory + "\\Images\\Dice\\Three_Dice.png";
        public static string Four = AppContext.BaseDirectory + "\\Images\\Dice\\Four_Dice.png";
        public static string Five = AppContext.BaseDirectory + "\\Images\\Dice\\Five_Dice.png";
        public static string Six = AppContext.BaseDirectory + "\\Images\\Dice\\Six_Dice.png";
    }

    public enum Button
    {
        [EnumMember(Value = "\\Images\\Buttons\\Roll_Green.png")]
        GreenButton,
        [EnumMember(Value = "\\Images\\Buttons\\Roll_Red.png")]
        RedButton
    }
}