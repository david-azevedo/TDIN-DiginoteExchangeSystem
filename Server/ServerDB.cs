﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ServerDB
    {

        public static string connectionString = "Data Source = .\\SQLEXPRESS;Initial Catalog = TDIN1; Integrated Security = True; MultipleActiveResultSets=True";

        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public static string Register(string username, string password)
        {
            using (SqlConnection connection = GetConnection())
            {
                string commandString;

                commandString = string.Format("SELECT Count(*) FROM \"User\" WHERE username = '{0}';", username);
                using (var command = new SqlCommand(commandString, connection))
                {
                    if ((int)command.ExecuteScalar() > 0)
                    {
                        return "Username already exists";
                    }
                }

                commandString = string.Format("INSERT INTO \"User\" (username, password) VALUES ('{0}', '{1}')", username, password);
                using (var command = new SqlCommand(commandString, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            return "Successfully registered";
        }

        public static bool Login(string username, string password)
        {
            using (SqlConnection connection = GetConnection())
            {
                string commandString;

                commandString = string.Format("SELECT COUNT(*) FROM \"User\" WHERE username = '{0}' AND password = '{1}'", username, password);
                using (var command = new SqlCommand(commandString, connection))
                {
                    if ((int)command.ExecuteScalar() > 0)
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
}