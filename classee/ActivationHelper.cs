using Microsoft.Win32;
using System;
using System.IO;
using System.Management;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace venolocation.classee
{
    internal class ActivationHelper
    {
       
        private static string encryptionKey = Ajouter();

        private static string Ajouter()
        {
            string p1 = Encoding.UTF8.GetString(Convert.FromBase64String("TWFDbGVm"));
            string p2 = Encoding.UTF8.GetString(Convert.FromBase64String("MTIzNDU="));
            string p3 = Encoding.UTF8.GetString(Convert.FromBase64String("QEhhbXph"));

            return p1 + p2 + p3;
        }
        
        public static string Decrypt(string cipherText)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(encryptionKey.PadRight(32));

            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = new byte[16];

                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                byte[] plainBytes = aes.CreateDecryptor()
                                         .TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);

                return Encoding.UTF8.GetString(plainBytes);
            }
        }

        public static string GetProcessorId()
        {
            try
            {
                using (ManagementObjectSearcher searcher =
                       new ManagementObjectSearcher("SELECT ProcessorId FROM Win32_Processor"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        return obj["ProcessorId"]?.ToString() ?? "";
                        
                    }
                    
                }
               
            }
            catch
            {
                return "";
            }

            return "";
        }

        public static bool CheckLicense(string localFilePath, string programName, string processorIdToCheck, string serialToCheck)
        {
            try
            {
                if (!File.Exists(localFilePath))
                {
                    return false;
                }
                

                string encryptedText = File.ReadAllText(localFilePath);
                string decryptedText = Decrypt(encryptedText);

                var lines = decryptedText.Split(
                    new[] { Environment.NewLine },
                    StringSplitOptions.RemoveEmptyEntries
                );

                foreach (var line in lines)
                {
                    
                    var parts = line.Split('|');

                    if (parts.Length != 3)
                        continue;

                    string prog = parts[0].Trim();
                    string processorId = parts[1].Trim();
                    string serial = parts[2].Trim();
                    
                    if (prog.Equals(programName, StringComparison.OrdinalIgnoreCase))
                    {
                        if (processorId.Equals(processorIdToCheck, StringComparison.OrdinalIgnoreCase) &&
                            serial.Equals(serialToCheck, StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                        }

                        return false;
                    }
                }
                
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool DownloadFileKey(string url, string destinationPath)
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadFile(url, destinationPath);
                }
                
                return File.Exists(destinationPath);
            }
            catch
            {
                return false;
            }
        }

        public static bool CheckActivationFromDrive(string programName, string driveUrl)
        {
            string keyPath = Path.Combine(Application.StartupPath, "licence.key");

            try
            {
                if (File.Exists(keyPath))
                    File.Delete(keyPath);

                bool downloaded = DownloadFileKey(driveUrl, keyPath);
                
                if (!downloaded)
                {
                    MessageBox.Show(
                        "Impossible de télécharger le fichier d'activation.",
                        "Activation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return false;
                }
                

                string processorIdPc = GetProcessorId();
                string serialLocal = Properties.Settings.Default.serial;

                if (string.IsNullOrWhiteSpace(serialLocal))
                {
                    MessageBox.Show(
                        "Serial local introuvable.",
                        "Activation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return false;
                }

                
                bool isValid = CheckLicense(keyPath,programName,processorIdPc,serialLocal);

                if (!isValid)
                {
                    MessageBox.Show(
                        "Licence invalide pour ce PC.",
                        "Activation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                   
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur d'activation : " + ex.Message,
                    "Activation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }
            finally
            {
                try
                {
                    if (File.Exists(keyPath))
                        File.Delete(keyPath);
                }
                catch
                {
                }
            }
        }
    }
}

