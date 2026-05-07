using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace venolocation.classee
{
    internal class FacturePrinter
    {

       


            private FactureData _data;
            private PrintDocument _printDocument;

            private Font _fontTitle;
            private Font _fontSection;
            private Font _fontNormal;
            private Font _fontBold;
            private Font _fontSmall;

            private Brush _blueBrush;
            private Pen _bluePen;
            private Pen _grayPen;

            public FacturePrinter(FactureData data)
            {
                _data = data;

                _printDocument = new PrintDocument();
                _printDocument.PrintPage += PrintDocument_PrintPage;

                _printDocument.DefaultPageSettings.PaperSize =
                    new PaperSize("A4", 827, 1169);

                _printDocument.DefaultPageSettings.Margins =
                    new Margins(25, 25, 25, 25);
            }

            public static void PrintPreview(FactureData data)
            {
                FacturePrinter printer = new FacturePrinter(data);

                using (PrintPreviewDialog preview = new PrintPreviewDialog())
                {
                    preview.Document = printer._printDocument;
                    preview.Width = 1100;
                    preview.Height = 800;
                    preview.ShowDialog();
                }
            }

            public static void PrintDirect(FactureData data)
            {
                FacturePrinter printer = new FacturePrinter(data);
                printer._printDocument.Print();
            }

            private void InitStyles()
            {
                _fontTitle = new Font("Arial", 18, FontStyle.Bold);
                _fontSection = new Font("Arial", 9, FontStyle.Bold);
                _fontNormal = new Font("Arial", 8, FontStyle.Regular);
                _fontBold = new Font("Arial", 8, FontStyle.Bold);
                _fontSmall = new Font("Arial", 7, FontStyle.Regular);

                _blueBrush = new SolidBrush(Color.FromArgb(15, 70, 150));
                _bluePen = new Pen(Color.FromArgb(15, 70, 150), 1);
                _grayPen = new Pen(Color.Gray, 1);
            }

            private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
            {
                InitStyles();

                Graphics g = e.Graphics;
                g.PageUnit = GraphicsUnit.Display;

                int margin = 30;
                int pageWidth = e.MarginBounds.Width;
                int y = 25;

                DrawHeader(g, margin, y);
                y += 155;

                int leftX = margin;
                int leftW = 365;
                int gap = 25;
                int rightX = leftX + leftW + gap;
                int rightW = 365;

                DrawClientSection(g, leftX, y, leftW, 145);
                DrawVehiculeSection(g, rightX, y, rightW, 145);

                y += 165;

                DrawLocationSection(g, leftX, y, leftW, 145);
                DrawPaiementSection(g, rightX, y, rightW, 145);

                y += 165;

                DrawCarburantSection(g, margin, y, 755, 75);

                y += 95;

                DrawEtatVehiculeSection(g, margin, y, 755, 260);

                y += 280;

                DrawObservationsSection(g, margin, y, 755, 85);

                y += 105;

                DrawSignaturesSection(g, margin, y, leftW, rightX, rightW);

                y += 115;

                DrawFooter(g, margin, y, 755);

                e.HasMorePages = false;
            }

            private void DrawHeader(Graphics g, int x, int y)
            {
                Rectangle logoRect = new Rectangle(x, y, 120, 95);
                g.DrawRectangle(_bluePen, logoRect);

                if (!string.IsNullOrWhiteSpace(_data.LogoPath) && File.Exists(_data.LogoPath))
                {
                    using (Image logo = Image.FromFile(_data.LogoPath))
                    {
                        g.DrawImage(logo, logoRect);
                    }
                }
                else
                {
                    DrawCenteredText(g, "VOTRE LOGO", _fontBold, _blueBrush, logoRect);
                }

                int infoX = x + 150;

                g.DrawString(Safe(_data.NomSociete), new Font("Arial", 13, FontStyle.Bold), Brushes.Black, infoX, y + 8);
                g.DrawString("Adresse : " + Safe(_data.AdresseSociete), _fontNormal, Brushes.Black, infoX, y + 35);
                g.DrawString("Téléphone : " + Safe(_data.TelephoneSociete), _fontNormal, Brushes.Black, infoX, y + 58);
                g.DrawString("Email : " + Safe(_data.EmailSociete), _fontNormal, Brushes.Black, infoX, y + 81);

                int titleX = x + 395;
                g.DrawString("FACTURE / FICHE ÉTAT DU VÉHICULE", _fontTitle, _blueBrush, titleX, y);

                Rectangle factureBox = new Rectangle(titleX + 40, y + 50, 320, 88);
                g.DrawRectangle(_bluePen, factureBox);

                g.DrawString("N° Facture : " + Safe(_data.NumeroFacture), _fontNormal, Brushes.Black, factureBox.X + 15, factureBox.Y + 15);
                g.DrawString("Date : " + Safe(_data.DateFacture), _fontNormal, Brushes.Black, factureBox.X + 15, factureBox.Y + 40);
                g.DrawString("Référence : " + Safe(_data.Reference), _fontNormal, Brushes.Black, factureBox.X + 15, factureBox.Y + 65);
            }

            private void DrawClientSection(Graphics g, int x, int y, int w, int h)
            {
                DrawSection(g, "3. CLIENT", x, y, w, h);

                int yy = y + 38;
                DrawLabelValue(g, "Nom complet :", _data.ClientNom, x + 15, yy); yy += 23;
                DrawLabelValue(g, "Téléphone :", _data.ClientTelephone, x + 15, yy); yy += 23;
                DrawLabelValue(g, "CIN / Passport :", _data.ClientCin, x + 15, yy); yy += 23;
                DrawLabelValue(g, "Permis :", _data.ClientPermis, x + 15, yy); yy += 23;
                DrawLabelValue(g, "Adresse :", _data.ClientAdresse, x + 15, yy);
            }

            private void DrawVehiculeSection(Graphics g, int x, int y, int w, int h)
            {
                DrawSection(g, "4. VÉHICULE", x, y, w, h);

                int yy = y + 38;
                DrawLabelValue(g, "Marque :", _data.Marque, x + 15, yy); yy += 23;
                DrawLabelValue(g, "Modèle :", _data.Modele, x + 15, yy); yy += 23;
                DrawLabelValue(g, "Immatriculation :", _data.Immatriculation, x + 15, yy); yy += 23;
                DrawLabelValue(g, "Carburant :", _data.Carburant, x + 15, yy); yy += 23;
                DrawLabelValue(g, "Kilométrage départ :", Safe(_data.KilometrageDepart) + " km", x + 15, yy);
            }

            private void DrawLocationSection(Graphics g, int x, int y, int w, int h)
            {
                DrawSection(g, "5. LOCATION", x, y, w, h);

                int yy = y + 40;

                DrawLabelValue(g, "Date départ :", _data.DateDepart, x + 15, yy);
                DrawLabelValue(g, "Heure :", _data.HeureDepart, x + 205, yy);

                yy += 35;

                DrawLabelValue(g, "Date retour :", _data.DateRetour, x + 15, yy);
                DrawLabelValue(g, "Heure :", _data.HeureRetour, x + 205, yy);

                yy += 35;

                DrawLabelValue(g, "Nombre jours :", _data.NombreJours, x + 15, yy);
                DrawLabelValue(g, "Prix / jour :", Safe(_data.PrixJour) + " MAD", x + 205, yy);
            }

            private void DrawPaiementSection(Graphics g, int x, int y, int w, int h)
            {
                DrawSection(g, "6. PAIEMENT", x, y, w, h);

                int tableX = x + 15;
                int tableY = y + 38;
                int tableW = w - 30;
                int rowH = 24;

                DrawPaymentRow(g, "Total :", Safe(_data.Total) + " MAD", tableX, tableY, tableW, rowH);
                DrawPaymentRow(g, "Avance :", Safe(_data.Avance) + " MAD", tableX, tableY + rowH, tableW, rowH);
                DrawPaymentRow(g, "Reste :", Safe(_data.Reste) + " MAD", tableX, tableY + rowH * 2, tableW, rowH);
                DrawPaymentRow(g, "Mode paiement :", Safe(_data.ModePaiement), tableX, tableY + rowH * 3, tableW, rowH);
            }

            private void DrawCarburantSection(Graphics g, int x, int y, int w, int h)
            {
                DrawSection(g, "7. NIVEAU CARBURANT", x, y, w, h);

                int lineY = y + 52;
                int startX = x + 100;
                int endX = x + w - 100;

                g.DrawLine(_grayPen, startX, lineY, endX, lineY);

                DrawFuelOption(g, "E\n(Vide)", "E", startX, lineY);
                DrawFuelOption(g, "1/4", "1/4", startX + 155, lineY);
                DrawFuelOption(g, "1/2", "1/2", startX + 310, lineY);
                DrawFuelOption(g, "3/4", "3/4", startX + 465, lineY);
                DrawFuelOption(g, "F\n(Plein)", "F", endX, lineY);
            }

            private void DrawEtatVehiculeSection(Graphics g, int x, int y, int w, int h)
            {
                DrawSection(g, "8. ÉTAT DU VÉHICULE", x, y, w, h);

                Rectangle carRect = new Rectangle(x + 20, y + 35, w - 40, 175);

                if (!string.IsNullOrWhiteSpace(_data.EtatVoitureImagePath) &&
                    File.Exists(_data.EtatVoitureImagePath))
                {
                    using (Image car = Image.FromFile(_data.EtatVoitureImagePath))
                    {
                        g.DrawImage(car, carRect);
                    }
                }
                else
                {
                    g.DrawRectangle(_grayPen, carRect);
                    DrawCenteredText(g, "Image état véhicule introuvable", _fontNormal, Brushes.Gray, carRect);
                }

                int legY = y + h - 38;
                g.DrawString("LÉGENDE", _fontBold, Brushes.Black, x + 15, legY);

                int checkX = x + 110;
                DrawCheckWithText(g, "Rayure", checkX, legY);
                DrawCheckWithText(g, "Bosse", checkX + 120, legY);
                DrawCheckWithText(g, "Cassé", checkX + 230, legY);
                DrawCheckWithText(g, "Manquant", checkX + 340, legY);
                DrawCheckWithText(g, "Autre :", checkX + 475, legY);
                g.DrawLine(Pens.Gray, checkX + 550, legY + 12, x + w - 20, legY + 12);
            }

            private void DrawObservationsSection(Graphics g, int x, int y, int w, int h)
            {
                DrawSection(g, "9. OBSERVATIONS", x, y, w, h);

                Rectangle textRect = new Rectangle(x + 15, y + 35, w - 30, h - 45);
                g.DrawString(Safe(_data.Observations), _fontNormal, Brushes.Black, textRect);

                for (int i = 0; i < 3; i++)
                {
                    int lineY = y + 42 + i * 18;
                    g.DrawLine(Pens.LightGray, x + 15, lineY, x + w - 15, lineY);
                }
            }

            private void DrawSignaturesSection(Graphics g, int x, int y, int leftW, int rightX, int rightW)
            {
                DrawSection(g, "10. SIGNATURE CLIENT", x, y, leftW, 90);
                g.DrawString("Je reconnais avoir pris connaissance de l'état du véhicule.", _fontSmall, Brushes.Black, x + 15, y + 35);
                g.DrawString("Date : ____ / ____ / ______      Heure : __________", _fontSmall, Brushes.Black, x + 15, y + 68);

                DrawSection(g, "11. SIGNATURE AGENCE", rightX, y, rightW, 90);
                g.DrawString("Je confirme l'exactitude des informations ci-dessus.", _fontSmall, Brushes.Black, rightX + 15, y + 35);
                g.DrawString("Date : ____ / ____ / ______      Heure : __________", _fontSmall, Brushes.Black, rightX + 15, y + 68);
            }

            private void DrawFooter(Graphics g, int x, int y, int w)
            {
                g.DrawLine(_bluePen, x, y + 10, x + 260, y + 10);
                g.DrawString("Merci de votre confiance et bonne route !", _fontBold, _blueBrush, x + 275, y);
                g.DrawLine(_bluePen, x + 515, y + 10, x + w, y + 10);
            }

            private void DrawSection(Graphics g, string title, int x, int y, int w, int h)
            {
                g.DrawRectangle(_bluePen, x, y, w, h);

                Rectangle titleRect = new Rectangle(x, y, 145, 24);
                g.FillRectangle(_blueBrush, titleRect);
                g.DrawString(title, _fontSection, Brushes.White, x + 7, y + 5);
            }

            private void DrawLabelValue(Graphics g, string label, string value, int x, int y)
            {
                g.DrawString(label, _fontBold, Brushes.Black, x, y);
                g.DrawString(Safe(value), _fontNormal, Brushes.Black, x + 105, y);
            }

            private void DrawPaymentRow(Graphics g, string label, string value, int x, int y, int w, int h)
            {
                g.DrawRectangle(_bluePen, x, y, w, h);
                g.DrawLine(_bluePen, x + 120, y, x + 120, y + h);

                g.DrawString(label, _fontBold, Brushes.Black, x + 8, y + 6);
                g.DrawString(value, _fontNormal, Brushes.Black, x + 130, y + 6);
            }

            private void DrawCheckBox(Graphics g, int x, int y, bool isChecked)
            {
                Rectangle rect = new Rectangle(x, y, 13, 13);
                g.DrawRectangle(Pens.Black, rect);

                if (isChecked)
                {
                    using (Pen p = new Pen(Color.Black, 2))
                    {
                        g.DrawLine(p, x + 2, y + 7, x + 5, y + 11);
                        g.DrawLine(p, x + 5, y + 11, x + 12, y + 2);
                    }
                }
            }

            private void DrawFuelOption(Graphics g, string text, string value, int centerX, int lineY)
            {
                bool selected = Safe(_data.NiveauCarburant).Equals(value, StringComparison.OrdinalIgnoreCase);

                g.DrawString(text, _fontSmall, Brushes.Black, centerX - 18, lineY - 35);
                DrawCheckBox(g, centerX - 6, lineY - 6, selected);
            }

            private void DrawCheckWithText(Graphics g, string text, int x, int y)
            {
                DrawCheckBox(g, x, y, false);
                g.DrawString(text, _fontSmall, Brushes.Black, x + 18, y - 1);
            }

            private void DrawCenteredText(Graphics g, string text, Font font, Brush brush, Rectangle rect)
            {
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    g.DrawString(text, font, brush, rect, sf);
                }
            }

            private string Safe(string value)
            {
                return string.IsNullOrWhiteSpace(value) ? "" : value;
            }
        
    }
}
