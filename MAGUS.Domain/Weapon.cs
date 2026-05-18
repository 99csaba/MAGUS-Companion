using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MAGUS.Domain
{
    public abstract class Weapon
    {
        public Guid Id { get; set; }
        public string Name { get; }
        public int Ke { get; }

        public int DisplayeAttack { get
            {
                if (this is MeleeWeapon mw)
                {
                    return mw.Te;
                }
                else if(this is RangedWeapon rw)
                {
                    return rw.Ce;
                }
                return 0;
            } } // vissza adja a té vagy Cé-t

        public int DisplayDefenseOrRange
        {
            get
            {
                if (this is MeleeWeapon mw)
                {
                    return mw.Ve;
                }
                else if (this is RangedWeapon rw)
                {
                    return rw.Range;
                }
                return 0;
            }
        }   // vissza adja a VE-t vagy a távot

        public int Attacks { get; }    //tám/kör
        public Dice InitiativeDice { get; } = new Dice(1, 10);
        public Dice DamageDice { get; }
        public string DamageToString { get { return $"{DamageDice.DiceCount}k{DamageDice.DiceSides}+{DamageDice.Modifier}"; } }
        public Dice AttackDice { get; } = new Dice(1,100);

        protected Weapon(string name, int ke, int attacks, Dice damage)
        {
            Id = Guid.NewGuid();
            Name = name;
            Ke = ke;
            Attacks = attacks;
            DamageDice = damage;
        }
    }
    //-----------------------------------------------------------------------------------------------------
    public class MeleeWeapon : Weapon
    {
        public int Te { get; } //TÉ
        public int Ve { get; } // VÉ

        public MeleeWeapon( string name, int ke, int attacks, int attackValue, int defenseValue, Dice damage)
        : base(name, ke, attacks, damage)
        {
            Te = attackValue;
            Ve = defenseValue;
        }
    }
    //-----------------------------------------------------------------------------------------------------
    public class RangedWeapon : Weapon
    {
        public int Ce { get; } //Cé
        public int Range { get; } // range

        public RangedWeapon( string name, int ke, int attacks, int ce, int range, Dice damage)
        : base( name, ke, attacks, damage)
        {
            Ce = ce;
            Range = range;
        }
    }
}
