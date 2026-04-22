using System;
using MySql.Data.MySqlClient;


namespace venolocation.classee
{
    internal class LogHelper
    {
        public static void AddLog(string message, string utilisateur)
        {
            try
            {
                using (MySqlConnection cn = Dbexec.GetConnection())
                {
                    cn.Open();

                    string q = "INSERT INTO logs (message, utilisateur) VALUES (@m, @u)";

                    using (MySqlCommand cmd = new MySqlCommand(q, cn))
                    {
                        cmd.Parameters.AddWithValue("@m", message);
                        cmd.Parameters.AddWithValue("@u", utilisateur);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                
            }
        }
    }
}