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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const double AspectRatio = 16.0 / 9.0;
        private bool _isResizing = false;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            this.SizeChanged += MainWindow_SizeChanged;
        }
        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (_isResizing)
                return;

            _isResizing = true;

            // Ha a szélesség változott jobban → magasságot igazítjuk
            if (e.WidthChanged)
            {
                this.Height = this.Width / AspectRatio;
            }
            else if (e.HeightChanged)
            {
                this.Width = this.Height * AspectRatio;
            }

            _isResizing = false;
        }

    }
}
