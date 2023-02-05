using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ordinacije_projekt
{
    public class SQL_code
    {
        public static bool Login(string userName, string userPassword1)
        {
            string db_host = "ep-purple-breeze-177741.eu-central-1.aws.neon.tech";
            string db_name = "neondb";
            string db_username = "GhostGapy";
            string db_password = "G4XZhDPTB0WC";
            string db_port = "5432";

            string connString = String.Format("Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer", db_host, db_username, db_name, db_port, db_password);
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT Login(@username, @password)";
                    cmd.Parameters.AddWithValue("username", userName);
                    cmd.Parameters.AddWithValue("password", userPassword1);
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        return reader.GetBoolean(0);
                    }
                }
            }
        }


        public static bool Register(string userName, string userPassword1)
        {
            string db_host = "ep-purple-breeze-177741.eu-central-1.aws.neon.tech";
            string db_name = "neondb";
            string db_username = "GhostGapy";
            string db_password = "G4XZhDPTB0WC";
            string db_port = "5432";

            string connString = String.Format("Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer", db_host, db_username, db_name, db_port, db_password);
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT Register(@username, @password)";
                    cmd.Parameters.AddWithValue("username", userName);
                    cmd.Parameters.AddWithValue("password", userPassword1);
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        return reader.GetBoolean(0);
                    }
                }
            }
        }


        public static int vrsteCount()
        {
            string db_host = "ep-purple-breeze-177741.eu-central-1.aws.neon.tech";
            string db_name = "neondb";
            string db_username = "GhostGapy";
            string db_password = "G4XZhDPTB0WC";
            string db_port = "5432";
            int vrsteCount = 0;

            string connString = String.Format("Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer", db_host, db_username, db_name, db_port, db_password);

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var cmd2 = new NpgsqlCommand())
                {
                    cmd2.Connection = conn;
                    cmd2.CommandText = "SELECT PreštejVrsticeVrstOrdinacij();";
                    using (var reader2 = cmd2.ExecuteReader())
                    {
                        while (reader2.Read())
                        {
                            vrsteCount = reader2.GetInt32(0);
                        }
                    }
                }
                return vrsteCount;
            }
        }

        public static string[] VrsteOrdinacij()
        {
            string db_host = "ep-purple-breeze-177741.eu-central-1.aws.neon.tech";
            string db_name = "neondb";
            string db_username = "GhostGapy";
            string db_password = "G4XZhDPTB0WC";
            string db_port = "5432";

            string[] vrste = new string[10];

            string connString = String.Format("Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer", db_host, db_username, db_name, db_port, db_password);

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT ImenaVrstString();";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int i = 0;
                            int x = 1;
                            string vrsteImena = reader.GetString(0);
                            string[] _vrsteImena = vrsteImena.Split('%');

                            while (x < _vrsteImena.Length)
                            {
                                vrste[i] = _vrsteImena[x];
                                i++;
                                x++;

                            }
                        }
                    }
                }
                return vrste;
            }
        }


        public static int krajiCount()
        {
            string db_host = "ep-purple-breeze-177741.eu-central-1.aws.neon.tech";
            string db_name = "neondb";
            string db_username = "GhostGapy";
            string db_password = "G4XZhDPTB0WC";
            string db_port = "5432";
            int krajiCount = 0;

            string connString = String.Format("Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer", db_host, db_username, db_name, db_port, db_password);

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var cmd2 = new NpgsqlCommand())
                {
                    cmd2.Connection = conn;
                    cmd2.CommandText = "SELECT PreštejVrsticeKrajev();";
                    using (var reader2 = cmd2.ExecuteReader())
                    {
                        while (reader2.Read())
                        {
                            krajiCount = reader2.GetInt32(0);
                        }
                    }
                }
                return krajiCount;
            }
        }


        public static string[] Kraji()
        {
            string db_host = "ep-purple-breeze-177741.eu-central-1.aws.neon.tech";
            string db_name = "neondb";
            string db_username = "GhostGapy";
            string db_password = "G4XZhDPTB0WC";
            string db_port = "5432";

            string[] kraji = new string[500];

            string connString = String.Format("Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer", db_host, db_username, db_name, db_port, db_password);

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT ImenaKrajevString();";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int i = 0;
                            int x = 1;
                            string kImena = reader.GetString(0);
                            string[] _kImena = kImena.Split('%');

                            while (x < _kImena.Length)
                            {
                                kraji[i] = _kImena[x];
                                i++;
                                x++;

                            }
                        }
                    }
                }
                return kraji;
            }
        }



        public static int RowCount()
        {
            string db_host = "ep-purple-breeze-177741.eu-central-1.aws.neon.tech";
            string db_name = "neondb";
            string db_username = "GhostGapy";
            string db_password = "G4XZhDPTB0WC";
            string db_port = "5432";
            int rowCount = 1;

            string connString = String.Format("Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer", db_host, db_username, db_name, db_port, db_password);

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var cmd2 = new NpgsqlCommand())
                {
                    cmd2.Connection = conn;
                    cmd2.CommandText = "SELECT PreštejVrsticeOrdinacij();";
                    using (var reader2 = cmd2.ExecuteReader())
                    {
                        while (reader2.Read())
                        {
                            rowCount = reader2.GetInt32(0);
                        }
                    }
                }
                return rowCount;
            }
        }

        public static string[,] TableRow()
        {
            string db_host = "ep-purple-breeze-177741.eu-central-1.aws.neon.tech";
            string db_name = "neondb";
            string db_username = "GhostGapy";
            string db_password = "G4XZhDPTB0WC";
            string db_port = "5432";

            string[,] arr = new string[40,8];

            string connString = String.Format("Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer", db_host, db_username, db_name, db_port, db_password);
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                int y = 1;
                
                
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText =
                        "SELECT * FROM OrdinacijaVsebinaString();";
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                            int i = 0;
                                while (reader.Read())
                                {
                                    string x = reader.GetString(0);
                                    string[] _x = x.Split('%');
                                    while(y < _x.Length)
                                    {
                                    i = i + 1;
                                        
                                            arr[i, 0] = _x[y];
                                            y++;
                                            arr[i, 1] = _x[y];
                                            y++;
                                            arr[i, 2] = _x[y];
                                            y++;
                                            arr[i, 3] = _x[y];
                                            y++;
                                            arr[i, 4] = _x[y];
                                            y++;
                                            arr[i, 5] = _x[y];
                                            y++;

                                            string temp1 = _x[y];
                                            y++;

                                            arr[i, 5] = arr[i, 5] + " " + temp1;
                                        
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Nekaj je šlo narobe.");
                            }
                        }
                    }
                
            }
            return arr;
        }



        public static void DodajOrdinacijo(string _ime, string _vrsta, string _kraj, string _naslov, string _z_ime, string _z_priimek)
        {
            string db_host = "ep-purple-breeze-177741.eu-central-1.aws.neon.tech";
            string db_name = "neondb";
            string db_username = "GhostGapy";
            string db_password = "G4XZhDPTB0WC";
            string db_port = "5432";

            string connString = String.Format("Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer", db_host, db_username, db_name, db_port, db_password);

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT DodajOrdinacijo('" + _ime + "', '" + _naslov + "', '" + _kraj + "', '" + _vrsta + "', '" + _z_ime + "', '" + _z_priimek + "')";
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public static void DeleteRow(int index)
        {
            string db_host = "ep-purple-breeze-177741.eu-central-1.aws.neon.tech";
            string db_name = "neondb";
            string db_username = "GhostGapy";
            string db_password = "G4XZhDPTB0WC";
            string db_port = "5432";

            string connString = String.Format("Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer", db_host, db_username, db_name, db_port, db_password);

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT DeleteRow(" + index + ")";
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
