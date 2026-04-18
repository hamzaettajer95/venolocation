using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace venolocation.classee
{
    internal class dbErreur
    {

        public static void AddLog(string message, string utilisateur, string formName, string actionName)
        {
            try
            {
                using (MySqlConnection cn = Dbexec.GetConnection())
                {
                    cn.Open();

                    string q = @"INSERT INTO erreur
                                 (message, utilisateur, form_name, action_name, created_at)
                                 VALUES
                                 (@message, @utilisateur, @form_name, @action_name, NOW())";

                    using (MySqlCommand cmd = new MySqlCommand(q, cn))
                    {
                        cmd.Parameters.AddWithValue("@message", message);
                        cmd.Parameters.AddWithValue("@utilisateur", string.IsNullOrWhiteSpace(utilisateur) ? "Inconnu" : utilisateur);
                        cmd.Parameters.AddWithValue("@form_name", formName);
                        cmd.Parameters.AddWithValue("@action_name", actionName);

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
