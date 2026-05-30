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
                    if (!App_Config.Instance.telegram_error_enabled)
                        return;

                    string token = App_Config.Instance.telegram_bot_token;
                    string chatId = App_Config.Instance.telegram_chat_id;

                    if (string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(chatId))
                        return;

                string message =
                        "🚨 ERREUR LOGICIEL" + Environment.NewLine +
                        Environment.NewLine +
                        "Programme : "+App_Config.Instance.name_programe + Environment.NewLine +
                        "Version : " + App_Config.Instance.verssion + Environment.NewLine +
                        "Utilisateur : " + Session.Username + Environment.NewLine +
                        "PC Name : " + Environment.MachineName + Environment.NewLine +
                        "ID_prosesseur : " +  ActivationHelper.GetProcessorId() + Environment.NewLine +
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
                    string token = App_Config.Instance.telegram_bot_token;
                    string chatId = App_Config.Instance.telegram_chat_id;

                    if (string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(chatId))
                    {
                        MessageBox.Show(
                            "Veuillez renseigner Bot Token et Chat ID.",
                            "Test",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                string message =
                     "Message LOGICIEL" + Environment.NewLine +
                     Environment.NewLine +
                     "Programme : " + App_Config.Instance.name_programe + Environment.NewLine +
                     "Utilisateur : " + Session.Username + Environment.NewLine +
                     "PC Name : " + Environment.MachineName + Environment.NewLine +
                     "ID_prosesseur : " + ActivationHelper.GetProcessorId() + Environment.NewLine +
                     "Date : " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + Environment.NewLine +
                     Environment.NewLine +
                     
                     "Message : " + messa;
                    

                SendTelegramMessageAsync(token, chatId, message);

                   
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

