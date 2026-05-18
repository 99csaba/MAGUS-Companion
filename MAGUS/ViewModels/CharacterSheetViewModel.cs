using MAGUS.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAGUS.Presentation.ViewModels
{
    public class CharacterSheetViewModel : INotifyPropertyChanged
    {
        public Character Hero { get; set; }
        public ObservableCollection<Weapon> Weapons { get; set; }
        public ObservableCollection<Shield> Shields { get; set; }
        public ObservableCollection<Armor> Armors { get; set; }

        public CharacterSheetViewModel(Character hero)
        {
            Hero = hero;
            Weapons = new ObservableCollection<Weapon>(hero.Weapons);
            Shields = new ObservableCollection<Shield>(hero.Shields);
            Armors = new ObservableCollection<Armor>(hero.Armors);
        }

        public CharacterSheetViewModel()
        {
            
        }




        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
