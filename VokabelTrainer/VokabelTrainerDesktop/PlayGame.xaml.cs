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

namespace VokabelTrainerDesktop
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class PlayGameWindow : Window
    {
        public PlayGameWindow()
        {
            InitializeComponent();
        }

        private void cmdCheck_Click(object sender, RoutedEventArgs e)
        {
            //string strInput = txtInput.Text.Length > 0 ? txtInput.Text : "(empty)";

            if (txtInput.Text.Length == 0)
            {
                MessageBox.Show("Bitte eine Antwort eingeben!", "Vokabeltrainer - Abfrage", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            StartGame startGame = new StartGame();

            if (startGame.ShowDialog() == true)
            {
                System.Diagnostics.Trace.WriteLine("Der Benutzer möchte ein Spiel starten...");
            }
        }
    }
}
