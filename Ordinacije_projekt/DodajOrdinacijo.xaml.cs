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
    /// Interaction logic for DodajOrdinacijo.xaml
    /// </summary>
    public partial class DodajOrdinacijo : Window
    {
        public DodajOrdinacijo()
        {
            InitializeComponent();

            string[] vrsteOr = SQL_code.VrsteOrdinacij();
            int stVrst = SQL_code.vrsteCount();
            for (int i = 0; i < stVrst; i++){     vrsta_cbox.Items.Add(vrsteOr[i]);    }

            string[] kraji = SQL_code.Kraji();
            int stkrajev = SQL_code.krajiCount();
            for (int i = 0; i < stkrajev; i++){    kraj_cbox.Items.Add(kraji[i]);    }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(ime_box.Text) ||
                string.IsNullOrWhiteSpace(naslov_box.Text) ||
                string.IsNullOrWhiteSpace(zdravnik_box.Text) ||
                string.IsNullOrWhiteSpace(kraj_cbox.Text) ||
                string.IsNullOrWhiteSpace(vrsta_cbox.Text))
            {
                MessageBox.Show("Please fill out all the fields.");
            }
            else
            {
                string ime = ime_box.Text;
                string vrsta = vrsta_cbox.Text;
                string kraj = kraj_cbox.Text;
                string naslov = naslov_box.Text;
                string zdravnik = zdravnik_box.Text;

                string[] ime_priimek_zdravnik = zdravnik.Split(new[] { ' ' }, 2);

                string z_ime = ime_priimek_zdravnik[0];
                string z_priimek = " - ";

                int dolz = ime_priimek_zdravnik.Length;

                if (dolz > 1) { z_priimek = ime_priimek_zdravnik[1]; }


                SQL_code.DodajOrdinacijo(ime, vrsta, kraj, naslov, z_ime, z_priimek);
                title.Content = ime + " " + vrsta + " " + kraj + " " + naslov + " " + z_ime + " " + z_priimek;
            }

        }
    }
}
