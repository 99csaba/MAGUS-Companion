using MAGUS.Applications;
using MAGUS.Domain;
using MAGUS.Presentation.Commands;
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
    public class CombatViewModel : INotifyPropertyChanged
    {
        public ICommand MakeInitiativeCommand { get; }
        public ICommand MakeAttackCommand { get; }
        public ICommand MakeDamageCommand { get; }
        private readonly CombatService _combatService;

        private Character _hero;
        public Character Hero { get => _hero; set { _hero = value; OnPropertyChanged(); } }

        private Weapon selectedWeapon;
        public Weapon SelectedWeapon { get => selectedWeapon; set { selectedWeapon = value; OnPropertyChanged(); } }

        private int initiativeResult;
        public int InitiativeResult { get => initiativeResult; private set { initiativeResult = value; OnPropertyChanged(); } }

        private int attackResult;
        public int AttackResult { get => attackResult; private set { attackResult = value; OnPropertyChanged(); } }

        private int damageResult;
        public int DamageResult { get => damageResult; private set {  damageResult = value; OnPropertyChanged();} }
     
        public CombatViewModel(Character character,CombatService service)
        {
            Hero = character;
            _combatService = service;
            MakeInitiativeCommand = new RelayCommand(MakeInitiative);
            MakeAttackCommand = new RelayCommand(MakeAttack);
            MakeDamageCommand = new RelayCommand(MakeDamage);
        }

        public void MakeInitiative()
        {
            if (selectedWeapon != null)
            {
                InitiativeResult = _combatService.MakeInitiative(_hero, selectedWeapon);
            }
        }
        public void MakeAttack()
        {
            if (selectedWeapon !=null)
            {
                AttackResult = _combatService.MakeAttack(_hero,selectedWeapon);
            }
        }

        public void MakeDamage()
        {
            if (selectedWeapon != null)
            {
                DamageResult = _combatService.MakeDamage(selectedWeapon);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
