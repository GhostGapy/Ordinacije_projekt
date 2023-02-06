using System;
using System.IO;
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
using Spire.Xls;
using Microsoft.Win32;

namespace Ordinacije_projekt
{
    /// <summary>
    /// Interaction logic for OrdinacijeWindow.xaml
    /// </summary>
    public partial class OrdinacijeWindow : Window
    {
        string[,] array;
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

            array = SQL_code.TableRow();

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
            if (OrdinacijeGrid.SelectedItem != null)
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
            else
            {
                MessageBox.Show("Izberite ordinacijo!");
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Workbook workbook = new Workbook();

            Worksheet sheet = workbook.Worksheets[0];

            sheet.Range["A1"].Text = "ID";
            sheet.Range["B1"].Text = "Ime";
            sheet.Range["C1"].Text = "Naslov";
            sheet.Range["D1"].Text = "Kraj";
            sheet.Range["E1"].Text = "Vrsta";
            sheet.Range["F1"].Text = "Zdravnik";

            sheet.Range["A1"].ColumnWidth = 5;
            sheet.Range["B1"].ColumnWidth = 55;
            sheet.Range["C1"].ColumnWidth = 25;
            sheet.Range["D1"].ColumnWidth = 25;
            sheet.Range["E1"].ColumnWidth = 15;
            sheet.Range["F1"].ColumnWidth = 25;

            for (int i = 1; i <= SQL_code.RowCount(); i++)
            {
                sheet.Range["A" + (i + 1)].Text = array[i, 0];
                sheet.Range["B" + (i + 1)].Text = array[i, 1];
                sheet.Range["C" + (i + 1)].Text = array[i, 2];
                sheet.Range["D" + (i + 1)].Text = array[i, 3];
                sheet.Range["E" + (i + 1)].Text = array[i, 4];
                sheet.Range["F" + (i + 1)].Text = array[i, 5];
            }


            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Save Workbook",
                FileName = "ordinacije.xlsx"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                workbook.SaveToFile(filePath, ExcelVersion.Version2013);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
