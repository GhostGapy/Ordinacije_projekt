using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

            Osvezi();
        }

        private void Button_Click(object sender, RoutedEventArgs e)//ZAPRI
        {
            MainWindow mainWin = new MainWindow();
            mainWin.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Osvezi();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//DODAJ
        {
            DodajOrdinacijo dodaj_ordinacijo = new DodajOrdinacijo();
            dodaj_ordinacijo.Show();
        }
        
        public void Osvezi()
        {
            OrdinacijeGrid.Items.Clear();
            int rowCount = SQL_code.RowCount();

            string[,] array = SQL_code.TableRow();

            for (int i = 1; i <= rowCount; i++)
            {
                int _id = Convert.ToInt32(array[i, 0]);
                OrdinacijeGrid.Items.Add(new { id = _id, ime = array[i, 1], naslov = array[i, 2], kraj = array[i, 3], vrsta = array[i, 4], zdravnik = array[i, 5] });
            }
        }

        
        private void Button_Click_3(object sender, RoutedEventArgs e)//Izbriši
        {

            if (OrdinacijeGrid.SelectedItem != null)
            {
                string selectedItemString = OrdinacijeGrid.SelectedItem.ToString();

                string[] parts = selectedItemString.Split(',');
                string idPart = parts[0];
                int id = int.Parse(idPart.Split('=')[1].Trim());

                SQL_code.DeleteRow(id);
            }
            else
            {
                MessageBox.Show("Izberite ordinacijo!");
            }
            Osvezi();
        }
        
        private void OrdinacijeGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        
        private void Button_Click_4(object sender, RoutedEventArgs e)//UREDI
        {
            string selectedItemString = OrdinacijeGrid.SelectedItem.ToString();

            string[] parts = selectedItemString.Split(',');
            string idPart = parts[0];
            string imePart = parts[1];
            string naslovPart = parts[2];
            string krajPart = parts[3];
            string vrstaPart = parts[4];
            string zdravnikPart = parts[5];
            
            int id = int.Parse(idPart.Split('=')[1].Trim());
            string ime = imePart.Split('=')[1].Trim();
            string naslov = naslovPart.Split('=')[1].Trim();
            string kraj = krajPart.Split('=')[1].Trim();
            string vrsta = vrstaPart.Split('=')[1].Trim();
            string zdravnik = zdravnikPart.Split('=')[1].Trim();
            zdravnik = zdravnik.Substring(0, zdravnik.Length - 2);

            EditOrdinacije editWin = new EditOrdinacije(id, ime, naslov, kraj, vrsta, zdravnik);
            editWin.Show();
        }
    }
}
