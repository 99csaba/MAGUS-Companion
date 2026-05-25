using MAGUS.Applications;
using MAGUS.Domain;
using MAGUS.Presentation.Commands;
using MAGUS.Presentation.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MAGUS.Presentation.ViewModels
{
    public class CharacterSheetViewModel : INotifyPropertyChanged
    {
        private readonly CharacterService _characterService;
        public ICommand Combat { get; }
        public Character Hero { get; set; }
        public ObservableCollection<Weapon> Weapons { get; set; }
        public ObservableCollection<Shield> Shields { get; set; }
        public ObservableCollection<Armor> Armors { get; set; }

        public CharacterSheetViewModel(Character hero, CharacterService characterService)
        {
            _characterService = characterService;
            Hero = hero;
            Weapons = new ObservableCollection<Weapon>(hero.Weapons);
            Shields = new ObservableCollection<Shield>(hero.Shields);
            Armors = new ObservableCollection<Armor>(hero.Armors);
            Combat = new RelayCommand(OpenCombat);
        }

        private void OpenCombat()
        {
            var view = new CombatView(Hero);
            view.Show();
        }

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
