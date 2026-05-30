using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace venolocation.classee
{
    internal class UpdateHelper
    {

       
            public static UpdateInfo CheckForUpdate(string updateUrl)
            {
                string updateFilePath = Path.Combine(Application.StartupPath, "update.txt");

                try
                {
                    if (File.Exists(updateFilePath))
                        File.Delete(updateFilePath);

                    using (WebClient wc = new WebClient())
                    {
                        wc.DownloadFile(updateUrl, updateFilePath);
                    }

                    if (!File.Exists(updateFilePath))
                        return null;

                    string content = File.ReadAllText(updateFilePath);

                    if (content.StartsWith("<!DOCTYPE html>") || content.Contains("<html>"))
                    {
                        MessageBox.Show(
                            "Le lien de mise à jour n'est pas un lien direct.",
                            "Mise à jour",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        return null;
                    }

                    Dictionary<string, string> data = new Dictionary<string, string>();

                    string[] lines = content.Split(
                        new[] { "\r\n", "\n", "\r" },
                        StringSplitOptions.RemoveEmptyEntries
                    );

                    foreach (string line in lines)
                    {
                        int index = line.IndexOf('=');

                        if (index <= 0)
                            continue;

                        string key = line.Substring(0, index).Trim().ToLower();
                        string value = line.Substring(index + 1).Trim();

                        data[key] = value;
                    }

                    string latestVersion = data.ContainsKey("version") ? data["version"] : "";
                    string url = data.ContainsKey("url") ? data["url"] : "";
                    string description = data.ContainsKey("description") ? data["description"] : "";
                    string obligatoireText = data.ContainsKey("obligatoire") ? data["obligatoire"] : "false";

                    if (string.IsNullOrWhiteSpace(latestVersion))
                    {
                        MessageBox.Show(
                            "Version introuvable dans update.txt.",
                            "Mise à jour",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        return null;
                    }

                    Version current = new Version(App_Config.Instance.verssion);
                    Version latest = new Version(latestVersion);

                    bool isNew = latest > current;
                    bool obligatoire = obligatoireText.Equals("true", StringComparison.OrdinalIgnoreCase);

                    UpdateInfo info = new UpdateInfo
                    {
                        CurrentVersion = App_Config.Instance.verssion,
                        LatestVersion = latestVersion,
                        Url = url,
                        Description = description,
                        Obligatoire = obligatoire,
                        IsNewVersion = isNew
                    };

                    return info;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erreur vérification mise à jour : " + ex.Message,
                        "Mise à jour",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return null;
                }
                finally
                {
                    try
                    {
                        if (File.Exists(updateFilePath))
                            File.Delete(updateFilePath);
                    }
                    catch
                    {
                    }
                }
            }
        
    }
}

