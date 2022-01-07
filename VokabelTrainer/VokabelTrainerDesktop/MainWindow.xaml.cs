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
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.EntityFrameworkCore;
using VokabelTrainerAPI.Data;
using VokabelTrainerAPI.Models;
using VokabelTrainerLogik;

namespace VokabelTrainerDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DbContextOptionsBuilder<VokabelTrainerAPIContext> OptionsBuilder { get; }   

        public MainWindow()
        {
            InitializeComponent();

            OptionsBuilder = new DbContextOptionsBuilder<VokabelTrainerAPIContext>().UseSqlite("Data Source = C:\\temp\\vokabeln.db");
            
        }

        private void cmdGo_Click(object sender, RoutedEventArgs e)
        {
            VokabelTrainerSpiel spiel = new VokabelTrainerSpiel(OptionsBuilder.Options);
            StartGame dialog = new StartGame();

            List<Sprache> sprachen = spiel.GetAllLanguages();

            List<string> abschnitte = spiel.GetAllSections();

            dialog.lstLanguages.ItemsSource = sprachen.Select(s => s.Name);
            dialog.lstAbschnitte.ItemsSource = abschnitte;
            dialog.butLinear.IsChecked = true;

            if (dialog.ShowDialog() == true)
            {
                System.Diagnostics.Trace.WriteLine("User has started a game");
            }
        }

        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
