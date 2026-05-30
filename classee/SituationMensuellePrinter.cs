using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace venolocation.classee
{
    internal class SituationMensuellePrinter
    {



       
            private int _mois;
            private int _annee;

            private PrintDocument _document;

            private Font titleFont = new Font("Arial", 18, FontStyle.Bold);
            private Font sectionFont = new Font("Arial", 11, FontStyle.Bold);
            private Font textFont = new Font("Arial", 10);

            public SituationMensuellePrinter(int mois, int annee)
            {
                _mois = mois;
                _annee = annee;

                _document = new PrintDocument();
                _document.PrintPage += PrintPage;

                _document.DefaultPageSettings.PaperSize =
                    new PaperSize("A4", 827, 1169);

                _document.DefaultPageSettings.Margins =
                    new Margins(40, 40, 40, 40);
            }

            public void ShowPreview()
            {
                PrintPreviewDialog preview = new PrintPreviewDialog();
                preview.Document = _document;
                preview.WindowState = FormWindowState.Maximized;
                preview.ShowDialog();
            }

            private void PrintPage(object sender, PrintPageEventArgs e)
            {
                Graphics g = e.Graphics;

                int x = 40;
                int y = 40;

                g.DrawString(
                    "SITUATION GÉNÉRALE",
                    titleFont,
                    Brushes.DarkBlue,
                    x,
                    y);

                y += 40;

                g.DrawString(
                    "Mois : " + _mois + "/" + _annee,
                    sectionFont,
                    Brushes.Black,
                    x,
                    y);

                y += 50;

                int totalVehicules =
                    Dbexec.ExecuteScalarInt(
                        "SELECT COUNT(*) FROM voitures");

                int totalClients =
                    Dbexec.ExecuteScalarInt(
                        "SELECT COUNT(*) FROM clients");

                decimal revenus =
                    Dbexec.ExecuteScalarDecimal(@"
                    SELECT IFNULL(SUM(montant),0)
                    FROM recettes
                    WHERE MONTH(date_recette)=@m
                    AND YEAR(date_recette)=@a",
                        new MySqlParameter[]
                        {
                        new MySqlParameter("@m", _mois),
                        new MySqlParameter("@a", _annee)
                        });

                decimal depenses =
                    Dbexec.ExecuteScalarDecimal(@"
                    SELECT IFNULL(SUM(montant),0)
                    FROM depenses
                    WHERE MONTH(date_depense)=@m
                    AND YEAR(date_depense)=@a",
                        new MySqlParameter[]
                        {
                        new MySqlParameter("@m", _mois),
                        new MySqlParameter("@a", _annee)
                        });

                decimal benefice = revenus - depenses;

                DrawLine(g, "Total véhicules :", totalVehicules.ToString(), x, ref y);
                DrawLine(g, "Total clients :", totalClients.ToString(), x, ref y);
                DrawLine(g, "Revenus :", revenus.ToString("N2") + " DH", x, ref y);
                DrawLine(g, "Dépenses :", depenses.ToString("N2") + " DH", x, ref y);
                DrawLine(g, "Bénéfice net :", benefice.ToString("N2") + " DH", x, ref y);

                y += 30;

                g.DrawString(
                    "TOP VÉHICULES",
                    sectionFont,
                    Brushes.DarkBlue,
                    x,
                    y);

                y += 35;

                DataTable dt = Dbexec.GetData(@"
                SELECT
                    CONCAT(v.matricule,' - ',v.marque,' ',v.modele) AS vehicule,
                    COUNT(*) AS total
                FROM contrats c
                INNER JOIN voitures v
                    ON c.voiture_id=v.voiture_id
                WHERE MONTH(c.date_contrat)=@m
                AND YEAR(c.date_contrat)=@a
                GROUP BY c.voiture_id
                ORDER BY total DESC
                LIMIT 5",
                    new MySqlParameter[]
                    {
                    new MySqlParameter("@m", _mois),
                    new MySqlParameter("@a", _annee)
                    });

                foreach (DataRow row in dt.Rows)
                {
                    string txt =
                        row["vehicule"] + "   :   " +
                        row["total"] + " locations";

                    g.DrawString(txt, textFont, Brushes.Black, x + 20, y);

                    y += 25;
                }

                y += 30;

                g.DrawLine(Pens.Gray, x, y, 750, y);

                y += 15;

                g.DrawString(
                    "Imprimé le : " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                    new Font("Arial", 8),
                    Brushes.Gray,
                    x,
                    y);

                e.HasMorePages = false;
            }

            private void DrawLine(
                Graphics g,
                string label,
                string value,
                int x,
                ref int y)
            {
                g.DrawString(label, sectionFont, Brushes.Black, x, y);

                g.DrawString(value, textFont, Brushes.Black, x + 220, y);

                y += 28;
            }
        
    }

}
