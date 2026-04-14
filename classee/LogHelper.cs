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
                using (MySqlConnection cn = DbHelper.GetConnection())
                {
                    cn.Open();

                    string q = "INSERT INTO logs (message, utilisateur, date) VALUES (@m, @u, NOW())";

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