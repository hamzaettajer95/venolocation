using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace venolocation.classee
{
    internal class ErrorReporter
    {


      
            public static void SendError(Exception ex, string formName, string actionName)
            {
                try
                {
                    if (!Properties.Settings.Default.telegram_error_enabled)
                        return;

                    string token = Properties.Settings.Default.telegram_bot_token;
                    string chatId = Properties.Settings.Default.telegram_chat_id;

                    if (string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(chatId))
                        return;

                    string message =
                        "🚨 ERREUR LOGICIEL" + Environment.NewLine +
                        Environment.NewLine +
                        "Programme : venolocation" + Environment.NewLine +
                        "Version : " + Properties.Settings.Default.verssion + Environment.NewLine +
                        "Utilisateur : " + Session.Username + Environment.NewLine +
                        "PC : " + Environment.MachineName + Environment.NewLine +
                        "Date : " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + Environment.NewLine +
                        Environment.NewLine +
                        "Form : " + formName + Environment.NewLine +
                        "Action : " + actionName + Environment.NewLine +
                        Environment.NewLine +
                        "Message :" + Environment.NewLine +
                        ex.Message + Environment.NewLine +
                        Environment.NewLine +
                        "Détails :" + Environment.NewLine +
                        ex.ToString();

                    SendTelegramMessageAsync(token, chatId, message);
                }
                catch
                {
                   
                }
            }

            public static void SendTestMessage(string messa)
            {
                try
                {
                    string token = Properties.Settings.Default.telegram_bot_token;
                    string chatId = Properties.Settings.Default.telegram_chat_id;

                    if (string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(chatId))
                    {
                        MessageBox.Show(
                            "Veuillez renseigner Bot Token et Chat ID.",
                            "Telegram",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    string message =
                        messa + Environment.NewLine +
                        Environment.NewLine +
                        "Programme : venolocation" + Environment.NewLine +
                        "Version : " + Properties.Settings.Default.verssion + Environment.NewLine +
                        "Utilisateur : " + Session.Username + Environment.NewLine +
                        "Date : " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                    SendTelegramMessageAsync(token, chatId, message);

                    MessageBox.Show(
                        "Message de test envoyé. ",
                        "Ressage",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erreur envoyé message : " + ex.Message,
                        "message",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }

            private static void SendTelegramMessageAsync(string token, string chatId, string message)
            {
                Task.Run(() =>
                {
                    try
                    {
                        string url = "https://api.telegram.org/bot" + token + "/sendMessage";

                        using (WebClient wc = new WebClient())
                        {
                            wc.Encoding = Encoding.UTF8;

                            var data = new System.Collections.Specialized.NameValueCollection();
                            data["chat_id"] = chatId;
                            data["text"] = message;

                            wc.UploadValues(url, "POST", data);
                        }
                    }
                    catch
                    {
                        
                    }
                });
            }
        
    }

}

