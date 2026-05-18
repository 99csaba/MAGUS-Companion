using MAGUS.Domain;
using MAGUS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MAGUS.Presentation.Views
{
    /// <summary>
    /// Interaction logic for CombatView.xaml
    /// </summary>
    public partial class CombatView : Window
    {
        public CombatView(Character character)
        {
            InitializeComponent();
            DataContext = new CombatViewModel(character,new Applications.CombatService(new Random()));
        }

        private void AttackButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
