﻿using Npgsql;
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
                    cmd.CommandText = "SELECT * FROM users WHERE username = @username AND password1 = @password";
                    cmd.Parameters.AddWithValue("username", userName);
                    cmd.Parameters.AddWithValue("password", userPassword1);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
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
                    cmd.CommandText = "INSERT INTO users (username, password1) VALUES (@username, @password)";
                    cmd.Parameters.AddWithValue("username", userName);
                    cmd.Parameters.AddWithValue("password", userPassword1);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }

        public static bool freeUsername(string username)
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
                    cmd.CommandText = "SELECT * FROM users WHERE username = @username";
                    cmd.Parameters.AddWithValue("username", username);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
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
                    cmd2.CommandText = "SELECT COUNT(id) FROM vrste_ordinacij;";
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

            string[] vrsteOr = new string[5];
            int x = vrsteCount();

            string connString = String.Format("Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer", db_host, db_username, db_name, db_port, db_password);

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                for(int i = 0; i <= x; i++)
                {
                    using (var cmd = new NpgsqlCommand())
                    {
                        int _i = i + 1;
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT ime FROM vrste_ordinacij WHERE id="+ _i +";";
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                vrsteOr[i] = reader.GetString(0);
                            }
                        }
                    }
                }
                return vrsteOr;
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
                    cmd2.CommandText = "SELECT COUNT(id) FROM kraji;";
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
            int x = krajiCount();

            string connString = String.Format("Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer", db_host, db_username, db_name, db_port, db_password);

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                for (int i = 0; i <= x; i++)
                {
                    using (var cmd = new NpgsqlCommand())
                    {
                        int _i = i + 1;
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT ime FROM kraji WHERE id=" + _i + ";";
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                kraji[i] = reader.GetString(0);
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
                    cmd2.CommandText = "SELECT COUNT(id) FROM ordinacije;";
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
            int rowCount = RowCount();

            string[,] arr = new string[40,8];

            string connString = String.Format("Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer", db_host, db_username, db_name, db_port, db_password);
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                for (int i = 1; i <= rowCount; i++)
                {
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText =
                        "SELECT o.id, o.ime, o.naslov, k.ime, v.ime, z.ime, z.priimek" +
                        " FROM ordinacije o" +
                        " INNER JOIN kraji k on k.id = o.kraj_id" +
                        " INNER JOIN vrste_ordinacij v on v.id = o.vrsta_id" +
                        " INNER JOIN \"Entity9\" e on o.id = e.ordinacija_id" +
                        " INNER JOIN zdravniki z on z.id = e.zdravnik_id" +
                        " WHERE o.id = " + i + " LIMIT 1;";
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    int x = reader.GetInt32(0);
                                    arr[i, 0] = x.ToString();
                                    arr[i, 1] = reader.GetString(1);
                                    arr[i, 2] = reader.GetString(2);
                                    arr[i, 3] = reader.GetString(3);
                                    arr[i, 4] = reader.GetString(4);
                                    arr[i, 5] = reader.GetString(5);
                                    string temp1 = reader.GetString(6);

                                    arr[i, 5] = arr[i, 5] + " " + temp1;

                                }
                            }
                            else
                            {
                                MessageBox.Show("Nekaj je šlo narobe.");
                            }
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
    }
}
