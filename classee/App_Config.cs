using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace venolocation.classee
{
    public class App_Config
    {


        // ================================
        // PATH FILE
        // ================================
        private static readonly string path =
            Path.Combine(Application.StartupPath, "sys.dat");

        // ================================
        // DATABASE
        // ================================
        public string conx { get; set; }

            public string db_server { get; set; }

            public string db_name { get; set; }

            public string db_user { get; set; }

            public string db_password { get; set; }

            public string db_port { get; set; }

            // ================================
            // LICENCE & UPDATE
            // ================================
            public string url_licence { get; set; }

            public string updateUrl { get; set; }

            public string serial { get; set; }

            // ================================
            // TELEGRAM
            // ================================
            public bool telegram_error_enabled { get; set; }

            public string telegram_bot_token { get; set; }

            public string telegram_chat_id { get; set; }

            // ================================
            // PROGRAMME
            // ================================
            public string name_programe { get; set; }

            public string verssion { get; set; }

            // ================================
            // SOCIETE
            // ================================
            public string nom_societe { get; set; }

            public string telephone_societe { get; set; }

            public string adresse_societe { get; set; }

            public string email_societe { get; set; }




        public static App_Config Instance { get; set; } = Load();

        // ================================
        // SAVE
        // ================================
        public static void Save(App_Config config)
            {
                try
                {

                string json = JsonSerializer.Serialize(config);

                string encoded = Convert.ToBase64String(
                    Encoding.UTF8.GetBytes(json));

                File.WriteAllText(path, encoded);

                Instance = config;

            }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "SAVE ERROR",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            // ================================
            // LOAD
            // ================================
            public static App_Config Load()
            {
                try
                {

                if (!File.Exists(path))
                    return new App_Config();

                string data = File.ReadAllText(path);

                string json = Encoding.UTF8.GetString(
                    Convert.FromBase64String(data));

                return JsonSerializer.Deserialize<App_Config>(json)
                       ?? new App_Config();


            }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "LOAD ERROR",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return new App_Config();
                }
            }
        
    }

}


