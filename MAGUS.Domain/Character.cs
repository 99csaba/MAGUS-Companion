using System.Collections.ObjectModel;

namespace MAGUS.Domain
{
    public class Character
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public CharacherClass Kaszt { get; private set; }
        public int Ero { get; private set; }
        public int Gyorsasag { get; private set; }
        public int Ugyesseg { get; private set; }
        public int Allokepesseg { get; private set; }
        public int Egeszseg { get; private set; }
        public int Szepseg { get; private set; }
        public int Intelligencia { get; private set; }
        public int Akaratero { get; private set; }
        public int Asztral { get; private set; }
        public int Ke { get; private set; }
        public int Te { get; private set; }
        public int Ve { get; private set; }
        public int Ce { get; private set; }
        public int MaxEp { get; private set; }
        public int AktEp { get; private set; }
        public int MaxFp { get; private set; }
        public int AktFp { get; private set; }
        public int Experiece { get; private set; }
        public ObservableCollection<Weapon> Weapons { get; private set; } = new ObservableCollection<Weapon>();
        public ObservableCollection<Items> Items { get; private set; } = new ObservableCollection<Items>();
        public ObservableCollection<Shield> Shields { get; private set; } = new ObservableCollection<Shield>();
        public ObservableCollection<Armor> Armors { get; private set; } = new ObservableCollection<Armor>();

        public Character(string name, int level, CharacherClass kaszt,
            int ero, int ugy, int gyors, int allo, int egesz, int szep, int intel, int akar, int aszt,
            int ke, int te,int ve, int ce,int ep, int fp, int xp)
        {
            this.Name = name;
            this.Level = level;
            this.Kaszt = kaszt;
            this.Ero = ero;
            this.Ugyesseg = ugy;
            this.Gyorsasag = gyors;
            this.Allokepesseg = allo;
            this.Egeszseg = egesz;
            this.Szepseg = szep;
            this.Intelligencia = intel;
            this.Akaratero = akar;
            this.Asztral = aszt;
            this.Ke = ke;
            this.Te = te;
            this.Ve = ve;
            this.Ce = ce;
            this.MaxEp = ep;
            this.AktEp = ep;
            this.MaxFp = fp;
            this.AktFp = fp;
            this.Experiece = xp;
            
        }

        public void AddWeapon(Weapon weapon)
        {
            Weapons.Add(weapon);
        }
        public void AddShield(Shield shield)
        {
            Shields.Add(shield);
        }
        public void AddArmor(Armor armor) //
        {
            Armors.Add(armor);
        }
        public void AddItem(Items item) 
        {
            Items.Add(item);
        }

        public int GetInitiationvalue(Weapon weapon) // át kell alakítani  mert a fegyverek és pajzsok különböző értékeket adnak a kezdeményezéshez
        {
            return Ke + weapon.Ke;
        }
        public int GetAttackValue(Weapon weapon) // át kell alakítani  mert a fegyverek és pajzsok különböző értékeket adnak a támadáshoz
        {
            return weapon switch
            {
                MeleeWeapon mw => Te + mw.Te,
                RangedWeapon rw => Ce + rw.Ce,
                _ => 0
            };
        }
    }
}
