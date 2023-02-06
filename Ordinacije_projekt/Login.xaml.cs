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

namespace Ordinacije_projekt
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = username_box.Text;
            string password = password_box.Password;

            string passHash = hash.GetHashString(password);

            bool x = SQL_code.Login(username, passHash);

            if (x == true)
            {
                OrdinacijeWindow ordinacijeWin = new OrdinacijeWindow(username);
                ordinacijeWin.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Napaka pri prijavi");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWin = new MainWindow();
            mainWin.Show();
            this.Close();
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            PozabljenoGeslo pozabljenoGesloWin = new PozabljenoGeslo();
            pozabljenoGesloWin.Show();
            this.Close();
        }
    }
}
