using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for EditOrdinacije.xaml
    /// </summary>
    public partial class EditOrdinacije : Window
    {
        int id = 0;


        public EditOrdinacije()
        {
            InitializeComponent();
        }

        public EditOrdinacije(int _id, string _ime, string _naslov, string _kraj, string _vrsta, string _zdravnik)
        {
            InitializeComponent();
            id = _id;
            ime_box.Text = _ime;
            naslov_box.Text = _naslov;

            string[] vrsteOr = SQL_code.VrsteOrdinacij();
            int stVrst = SQL_code.vrsteCount();
            for (int i = 0; i < stVrst; i++) { vrsta_cbox.Items.Add(vrsteOr[i]); }

            vrsta_cbox.SelectedItem = _vrsta;

            string[] kraji = SQL_code.Kraji();
            int stkrajev = SQL_code.krajiCount();
            for (int i = 0; i < stkrajev; i++) { kraj_cbox.Items.Add(kraji[i]); }

            kraj_cbox.SelectedItem = _kraj;

            zdravnik_box.Text = _zdravnik;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
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


            SQL_code.EditOrdinacijo(id, ime, vrsta, kraj, naslov, z_ime, z_priimek);
            this.Close();
        }
    }
}
