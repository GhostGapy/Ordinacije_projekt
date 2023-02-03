using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
