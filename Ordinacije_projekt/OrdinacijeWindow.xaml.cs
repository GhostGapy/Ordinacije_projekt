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

            int rowCount = SQL_code.RowCount();

            string[,] array = SQL_code.TableRow();

            for (int i = 1; i <= rowCount; i++)
            {
                OrdinacijeGrid.Items.Add(new { id = array[i, 0], ime = array[i,1], naslov = array[i,2], kraj = array[i,3], vrsta = array[i,4], zdravnik = array[i,5] });
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWin = new MainWindow();
            mainWin.Show();
            this.Close();
        }
    }
}
