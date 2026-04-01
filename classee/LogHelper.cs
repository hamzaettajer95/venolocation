using MySql.Data.MySqlClient;

using static Guna.UI2.WinForms.Suite.Descriptions;

public class LogHelper
{
    public static void AddLog(string message, string utilisateur)
    {
        try
        {
            using (MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.conx))
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