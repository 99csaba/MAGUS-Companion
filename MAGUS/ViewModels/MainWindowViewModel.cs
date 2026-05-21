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
using System.Xml.Linq;

namespace MAGUS.Presentation.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ICommand LoadCharacterCommand { get; }

        private ObservableCollection<Character> characterList;
        public ObservableCollection<Character> CharacterList { get => characterList; set { characterList = value; OnPropertyChanged(); } }

        private Character selectedCharacter;
        public Character SelectedCharacter { get => selectedCharacter; set { selectedCharacter = value; OnPropertyChanged(); } }

        public MainWindowViewModel()
        {
            CharacterList = BaseLoad();
            LoadCharacterCommand = new RelayCommand(LoadCharacter);
        }

        private ObservableCollection<Character> BaseLoad()
        {
            var baseList = new ObservableCollection<Character>();

            baseList.Add( new Character
                ("Brutális Attila",6,new Warrior(), 10,10,10,10,10,10,10,10,10, 30,60,200,5,20,50, 600));

            baseList.First().Weapons.Add(BaseLoadAddMeleeWeapon());
            baseList.First().Weapons.Add(BaseLoadAddRangedWeapon());

            return baseList;
        }// teszteléshez feltölti Berci karakterét a CharacterList-be
        private Weapon BaseLoadAddMeleeWeapon() 
        {
            return new MeleeWeapon("Hosszú kard",6,1,14,16, new Dice(1,10));
        }
        private Weapon BaseLoadAddRangedWeapon() 
        {
            return new RangedWeapon("Visszacsapó íj",3,2,8,180, new Dice(1,10));
        }

        public void LoadCharacter()
        {
            if (SelectedCharacter != null)   
            {
               var view = new CharachterSheetWindow(SelectedCharacter);
                view.Show();
            }
        }
        public void OpenCombat()
        {
            var view = new CombatView(SelectedCharacter);
            view.Show();
        }
        
        //---------------------------------------------------------------------------------------------------
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
