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
    /// Interaction logic for PozabljenoGeslo.xaml
    /// </summary>
    public partial class PozabljenoGeslo : Window
    {
        public PozabljenoGeslo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string passAdmin = "Admin";
            string username = username_box.Text;
            string passwordUser = password_box.Password;
            string passwordAdmin = password_box_admin.Password;
            
            if (username == "" || passwordUser == "" || passwordAdmin == "")
            {
                MessageBox.Show("Prosim izpolnite vsa polja");
            }
            else
            {
                if (passAdmin == passwordAdmin)
                {
                    string passHash = hash.GetHashString(passwordUser);
                    SQL_code.ChangePassword(username, passHash);
                    MessageBox.Show("Geslo uspešno spremenjeno");
                    Login login = new Login();
                    login.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Napačno geslo administratorja");
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
