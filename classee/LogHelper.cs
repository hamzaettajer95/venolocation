using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

using venolocation.formee;

namespace venolocation.classee
{
    internal class LogHelper
    {

        public static void AddLog(string message, string utilisateur)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(formee.dashboard.connection_string))
                {
                    cn.Open();

                    string q = "INSERT INTO logs (message, utilisateur, date) VALUES (@m,@u,NOW())";

                    MySqlCommand cmd = new MySqlCommand(q, cn);

                    cmd.Parameters.AddWithValue("@m", message);
                    cmd.Parameters.AddWithValue("@u", utilisateur);

                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                
            }
        }
    }
}
