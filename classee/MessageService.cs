using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace venolocation.classee
{
    internal class MessageService
    {
        public static void Success(string message)
        {
            MessageBox.Show(message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Info(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Warning(string message)
        {
            MessageBox.Show(message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Error(string message)
        {
            MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult Confirm(string message)
        {
            return MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
