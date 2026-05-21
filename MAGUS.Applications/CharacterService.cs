using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAGUS.Domain;

namespace MAGUS.Applications
{
    public class CharacterService
    {
        public CharacterService()
        {
                
        }

        public void AddWeapon(Character character, Weapon weapon)
        {
            character.Weapons.Add(weapon);
        }
        public void RemoveWeapon(Character character, Weapon weapon)
        {
            character.Weapons.Remove(weapon);
        }
    }
}
