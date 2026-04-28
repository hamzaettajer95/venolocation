using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace venolocation.classee
{
    internal class Dbexec
    {


        private static readonly string connString = Properties.Settings.Default.conx;

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connString);
        }

        
        public static DataTable GetData(string query)
        {
            using (MySqlConnection conn = GetConnection())
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        
        public static DataTable GetData(string query, MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

       
        public static int ExecuteQuery(string query, MySqlParameter[] parameters = null)
        {
            using (MySqlConnection conn = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

       
        public static object ExecuteScalar(string query, MySqlParameter[] parameters = null)
        {
            using (MySqlConnection conn = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

      
        public static int ExecuteScalarInt(string query, MySqlParameter[] parameters = null)
        {
            object result = ExecuteScalar(query, parameters);

            if (result == null || result == DBNull.Value)
                return 0;

            return Convert.ToInt32(result);
        }

        
        public static decimal ExecuteScalarDecimal(string query, MySqlParameter[] parameters = null)
        {
            object result = ExecuteScalar(query, parameters);

            if (result == null || result == DBNull.Value)
                return 0;

            return Convert.ToDecimal(result);
        }

        
        public static bool Exists(string query, MySqlParameter[] parameters = null)
        {
            int count = ExecuteScalarInt(query, parameters);
            return count > 0;
        }

    }
}
