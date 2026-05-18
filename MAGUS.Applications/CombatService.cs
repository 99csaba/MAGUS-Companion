using MAGUS.Domain;

namespace MAGUS.Applications
{
    public class CombatService
    {
        private readonly Random rng;

        public CombatService(Random rng)
        {
            this.rng = rng;
        }

        public int MakeInitiative(Character attacker, Weapon weapon)
        {
            return attacker.GetInitiationvalue(weapon)+weapon.InitiativeDice.Roll(rng);
        }
        public int MakeAttack(Character attacker, Weapon weapon)
        {
            return attacker.GetAttackValue(weapon) + weapon.AttackDice.Roll(rng);
        }

        public int MakeDamage(Weapon weapon) 
        {
            return weapon.DamageDice.Roll(rng);
        }
    }
}
