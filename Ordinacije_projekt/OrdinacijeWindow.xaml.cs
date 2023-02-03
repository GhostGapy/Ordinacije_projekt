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

namespace Ordinacije_projekt
{
    /// <summary>
    /// Interaction logic for OrdinacijeWindow.xaml
    /// </summary>
    public partial class OrdinacijeWindow : Window
    {
        public OrdinacijeWindow()
        {
            InitializeComponent();
        }

        public OrdinacijeWindow(string username)
        {
            InitializeComponent();
            username_label.Content = "Prijavljeni ste kot: " + username;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWin = new MainWindow();
            mainWin.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Ordinacije_projekt.ordinacije_projekt ordinacije_projekt = ((Ordinacije_projekt.ordinacije_projekt)(this.FindResource("ordinacije_projekt")));
            // Load data into the table ordinacije. You can modify this code as needed.
            Ordinacije_projekt.ordinacije_projektTableAdapters.ordinacijeTableAdapter ordinacije_projektordinacijeTableAdapter = new Ordinacije_projekt.ordinacije_projektTableAdapters.ordinacijeTableAdapter();
            ordinacije_projektordinacijeTableAdapter.Fill(ordinacije_projekt.ordinacije);
            System.Windows.Data.CollectionViewSource ordinacijeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("ordinacijeViewSource")));
            ordinacijeViewSource.View.MoveCurrentToFirst();
        }
    }
}
