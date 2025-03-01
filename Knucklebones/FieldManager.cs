using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static System.Formats.Asn1.AsnWriter;

namespace Knucklebones
{
    public class FieldManager
    {
        /// <summary>
        /// [player, x, y]
        /// </summary>
        private Field[,,] Fields = new Field[2, 3, 3];

        private Label LblScoreLeft;
        private int scoreLeft;
        private int ScoreLeft { get { return scoreLeft; } set { scoreLeft = value; SetScoreLabelLeft(); } }

        private Label LblScoreRight;
        private int scoreRight;
        private int ScoreRight { get { return scoreRight; } set { scoreRight = value; SetScoreLabelRight(); }   }

        public FieldManager(Label scoreLeft, Label scoreRight)
        {
            LblScoreLeft = scoreLeft;
            LblScoreRight = scoreRight;
        }

        public void Add(Image singleFieldImage, int player, int x, int y)
        {
            Fields[player, x, y] = new Field(singleFieldImage);
        }

        public bool FieldClicked(string name, Dice newDice)
        {
            int player = Convert.ToInt32(name[1].ToString());
            int playerOther = (player == 1) ? 0 : 1;
            int x = Convert.ToInt32(name[3].ToString());
            int y = Convert.ToInt32(name[4].ToString());

            if (!Fields[player, x, y].IsNone()) { return false; }

            Fields[player, x, y].DiceOnField = newDice;

            for (int yOther = 0; yOther < 3; yOther++)
            {
                if (Fields[playerOther, x, yOther].DiceOnField.CurrentDice == newDice.CurrentDice)
                {
                    Fields[playerOther, x, yOther].DiceOnField = new Dice(DiceName.None);
                }
            }

            CalculateScore();
            DiceRerange(x);
            return true;
        }

        private void CalculateScore()
        {
            int score = 0;
            int valueDiceBefore = 0;
            int multipleIdenticalDiceValue = 0;
            for (int player = 0; player < 2; player++)
            {
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        if (valueDiceBefore != Fields[player, x, y].DiceOnField.GetValue())
                        {
                            score += Fields[player, x, y].DiceOnField.GetValue();
                        }
                        else
                        {
                            score += Fields[player, x, y].DiceOnField.GetValue() * 2;
                            multipleIdenticalDiceValue = Fields[player, x, y].DiceOnField.GetValue();
                        }

                        valueDiceBefore = Fields[player, x, y].DiceOnField.GetValue();
                    }
                    if(multipleIdenticalDiceValue != 0) 
                    {
                        score += multipleIdenticalDiceValue;
                        multipleIdenticalDiceValue = 0;
                    }
                    valueDiceBefore = 0;
                }
                if(player == 0)
                {
                    ScoreLeft = score;
                }
                else
                {
                    ScoreRight = score;
                }
                score = 0;
            }
        }

        private void DiceRerange(int xToRerange)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int y = 0; y < 2; y++)
                {
                    if (Fields[0, xToRerange, y].IsNone())
                    {
                        Fields[0, xToRerange, y].DiceOnField = Fields[0, xToRerange, y + 1].DiceOnField;
                        Fields[0, xToRerange, y + 1].DiceOnField = new Dice(DiceName.None);
                    }
                }
                for (int y = 2; y > 0; y--)
                {
                    if (Fields[1, xToRerange, y].IsNone())
                    {
                        Fields[1, xToRerange, y].DiceOnField = Fields[1, xToRerange, y - 1].DiceOnField;
                        Fields[1, xToRerange, y - 1].DiceOnField = new Dice(DiceName.None);
                    }
                }
            }
        }

        private void SetScoreLabelLeft()
        {
            LblScoreLeft.Content = ScoreLeft;
        }

        private void SetScoreLabelRight()
        {
            LblScoreRight.Content = ScoreRight;
        }

        public bool CheckIfWin(bool playerLeft)
        {
            int player = Convert.ToInt32(!playerLeft);
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (Fields[player, x, y].IsNone())
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
