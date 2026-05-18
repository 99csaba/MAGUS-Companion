using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAGUS.Domain
{
    public class Dice
    {
        public int DiceCount { get; }
        public int DiceSides { get; }
        public int Modifier { get; }

        public Dice(int diceCount, int diceSides, int modifier = 0)
        {
            if (diceCount <= 0)
            {
                throw new ArgumentException("dice count must be positive!");
            }
            if (diceSides <= 1)
            {
                throw new ArgumentException("dice sides must be greather than 1!");
            }

            DiceCount = diceCount;
            DiceSides = diceSides;
            Modifier = modifier;
        }

        public override string ToString()
        {
            if (Modifier == 0)
                return $"{DiceCount}k{DiceSides}";

            return $"{DiceCount}k{DiceSides}+{Modifier}";
        }

        public int Roll(Random rnd)
        {
            int total = 0;
            for (int i = 0; i < DiceCount; i++)
            {
                total += rnd.Next(1, DiceSides + 1);
            }
            return total + Modifier;
        }

    }
}
