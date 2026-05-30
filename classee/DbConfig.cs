using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySqlConnector;

namespace venolocation.classee
{
    internal class DbConfig
    {
        //public static string GetConnectionString()
        //{
        //    string server = App_Config.Instance.db_server;
        //    string database = App_Config.Instance.db_name;
        //    string user = App_Config.Instance.db_user;
        //    string password = App_Config.Instance.db_password;
        //    string port = App_Config.Instance.db_port;

        //    if (string.IsNullOrWhiteSpace(port))
        //        port = "3306";

        //    return
        //        //"Server=" + server + ";" +
        //        //"Port=" + port + ";" +
        //        //"Database=" + database + ";" +
        //        //"Uid=" + user + ";" +
        //        //"Pwd=" + password + ";" +
        //        //"SslMode=None;" +
        //        //"CharSet=utf8;";


        //    "server = " + server + "; database = " + database + "; uid = " + user + "; password =" + password + ";";
        //}

        public static string GetConnectionString()
        {
            string server = App_Config.Instance.db_server;
            string database = App_Config.Instance.db_name;
            string user = App_Config.Instance.db_user;
            string password = App_Config.Instance.db_password;
            string portText = App_Config.Instance.db_port;

            uint port = 3306;

            if (!string.IsNullOrWhiteSpace(portText))
            {
                uint.TryParse(portText, out port);

                if (port == 0)
                    port = 3306;
            }
            //MessageBox.Show(server + " " + database + " " + user + " " + password + " " + port);
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
            {
               
                Server = server,
                Database = database,
                UserID = user,
                Password = password,
                Port = port
            };

            return builder.ConnectionString;
        }
    }
}
