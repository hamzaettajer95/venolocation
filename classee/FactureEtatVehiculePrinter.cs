using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace venolocation.classee
{
    internal class FactureEtatVehiculePrinter
    {

      
            private readonly FactureEtatVehiculeData _data;
            private readonly Image _logo;
            private readonly Image _etatVoiture;
            private readonly Image _etatVoiture2;

        private PrintDocument _document;

            private Font fontTitle = new Font("Arial", 16, FontStyle.Bold);
            private Font fontBig = new Font("Arial", 13, FontStyle.Bold);
            private Font fontSection = new Font("Arial", 9, FontStyle.Bold);
            private Font fontNormal = new Font("Arial", 8, FontStyle.Regular);
            private Font fontBold = new Font("Arial", 8, FontStyle.Bold);
            private Font fontSmall = new Font("Arial", 7, FontStyle.Regular);

            private Brush blueBrush = new SolidBrush(Color.FromArgb(20, 70, 150));
            private Pen bluePen = new Pen(Color.FromArgb(20, 70, 150), 1);
            private Pen grayPen = new Pen(Color.Gray, 1);

        public FactureEtatVehiculePrinter(FactureEtatVehiculeData data, Image logo, Image etatVoiture, Image etatVoiture2 = null)
        {
            _data = data;
            _logo = logo;
            _etatVoiture = etatVoiture;
            _etatVoiture2 = etatVoiture2;

            _document = new PrintDocument();
            _document.PrintPage += PrintPage;

            _document.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
            _document.DefaultPageSettings.Margins = new Margins(25, 25, 25, 25);
        }

        public void ShowPreview()
            {
                using (PrintPreviewDialog preview = new PrintPreviewDialog())
                {
                    preview.Document = _document;
                    preview.Width = 1100;
                    preview.Height = 800;
                    preview.ShowDialog();
                }
            }

            public void Print()
            {
                _document.Print();
            }

            private void PrintPage(object sender, PrintPageEventArgs e)
            {
            Graphics g = e.Graphics;
            g.PageUnit = GraphicsUnit.Display;

            int x = 30;
            int y = 25;
            int w = 755;

            DrawHeader(g, x, y, w);
            y += 125;

            int leftW = 365;
            int rightW = 365;
            int gap = 25;
            int rightX = x + leftW + gap;

            DrawClient(g, x, y, leftW, 145);
            DrawVehicule(g, rightX, y, rightW, 145);
            y += 165;

            DrawLocation(g, x, y, leftW, 145);
            DrawPaiement(g, rightX, y, rightW, 145);
            y += 165;

            DrawCarburant(g, x, y, w, 80);
            y += 100;

            DrawEtatVehicule(g, x, y, w, 260);
            y += 280;

            DrawObservations(g, x, y, w, 85);
            y += 105;

            DrawSignatures(g, x, y, leftW, rightX, rightW);
            y += 110;

            DrawFooter(g, x, y, w);

            e.HasMorePages = false;
        }

        private void DrawHeader(Graphics g, int x, int y, int w)
        {
            Rectangle logoRect = new Rectangle(x, y, 110, 95);
            g.DrawRectangle(bluePen, logoRect);

            if (_logo != null)
            {
                g.DrawImage(_logo, logoRect);
            }
            else
            {
                DrawCenter(g, "VOTRE LOGO\nICI", fontBold, blueBrush, logoRect);
            }

            int titleX = x + 150;

            g.DrawString("FACTURE / FICHE ÉTAT DU VÉHICULE", fontTitle, blueBrush, titleX, y + 5);
            g.DrawLine(new Pen(Color.FromArgb(20, 70, 150), 4), titleX, y + 38, titleX + 95, y + 38);

            Rectangle box = new Rectangle(x + w - 320, y + 55, 320, 75);
            g.DrawRectangle(bluePen, box);

            g.DrawString("N° Facture : " + Safe(_data.NumeroFacture), fontNormal, Brushes.Black, box.X + 15, box.Y + 17);
            g.DrawString("Date : " + Safe(_data.DateFacture), fontNormal, Brushes.Black, box.X + 15, box.Y + 45);
        }

        private void DrawClient(Graphics g, int x, int y, int w, int h)
            {
                DrawSection(g, "3. CLIENT", x, y, w, h);

                int yy = y + 40;
                DrawLineValue(g, "Nom complet :", _data.ClientNom, x + 15, yy); yy += 24;
                DrawLineValue(g, "Téléphone :", _data.ClientTelephone, x + 15, yy); yy += 24;
                DrawLineValue(g, "CIN / Passport :", _data.ClientCin, x + 15, yy); yy += 24;
                DrawLineValue(g, "Adresse :", _data.ClientAdresse, x + 15, yy);
            }

        private void DrawVehicule(Graphics g, int x, int y, int w, int h)
        {
            DrawSection(g, "4. VÉHICULE", x, y, w, h);

            int yy = y + 40;

            DrawLineValue(g, "Marque :", _data.Marque, x + 15, yy);
            yy += 24;

            DrawLineValue(g, "Modèle :", _data.Modele, x + 15, yy);
            yy += 24;

            DrawLineValue(g, "Immatriculation :", _data.Immatriculation, x + 15, yy);
            yy += 24;

            DrawLineValue(g, "Kilométrage départ :", Safe(_data.KmDepart) + " km", x + 15, yy);
        }

        private void DrawLocation(Graphics g, int x, int y, int w, int h)
        {
            DrawSection(g, "5. LOCATION", x, y, w, h);

            int yy = y + 45;

            g.DrawString("Date départ :", fontBold, Brushes.Black, x + 15, yy);
            g.DrawString(Safe(_data.DateDepart), fontNormal, Brushes.Black, x + 110, yy);

            g.DrawString("Heure départ :", fontBold, Brushes.Black, x + 205, yy);
            g.DrawString(Safe(_data.HeureDepart), fontNormal, Brushes.Black, x + 305, yy);

            yy += 35;

            g.DrawString("Date retour :", fontBold, Brushes.Black, x + 15, yy);
            g.DrawString(Safe(_data.DateRetour), fontNormal, Brushes.Black, x + 110, yy);

            g.DrawString("Heure retour :", fontBold, Brushes.Black, x + 205, yy);
            g.DrawString(Safe(_data.HeureRetour), fontNormal, Brushes.Black, x + 305, yy);

            yy += 35;

            g.DrawString("Nombre jours :", fontBold, Brushes.Black, x + 15, yy);
            g.DrawString(Safe(_data.NombreJours), fontNormal, Brushes.Black, x + 115, yy);

            g.DrawString("Prix / jour :", fontBold, Brushes.Black, x + 205, yy);

            string prixJour = Safe(_data.PrixJour) + " MAD";
            RectangleF prixRect = new RectangleF(x + 280, yy - 2, w - 290, 20);

            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Far;
                sf.LineAlignment = StringAlignment.Center;
                g.DrawString(prixJour, fontNormal, Brushes.Black, prixRect, sf);
            }
        }

        private void DrawPaiement(Graphics g, int x, int y, int w, int h)
            {
                DrawSection(g, "6. PAIEMENT", x, y, w, h);

                int tableX = x + 15;
                int tableY = y + 38;
                int tableW = w - 30;
                int rowH = 25;

                DrawPaymentRow(g, "Total :", Safe(_data.Total) + " MAD", tableX, tableY, tableW, rowH);
                DrawPaymentRow(g, "Avance :", Safe(_data.Avance) + " MAD", tableX, tableY + rowH, tableW, rowH);
                DrawPaymentRow(g, "Reste :", Safe(_data.Reste) + " MAD", tableX, tableY + rowH * 2, tableW, rowH);
                DrawPaymentRow(g, "Mode de paiement :", Safe(_data.ModePaiement), tableX, tableY + rowH * 3, tableW, rowH);
            }

            private void DrawCarburant(Graphics g, int x, int y, int w, int h)
            {
                DrawSection(g, "7. NIVEAU CARBURANT", x, y, w, h);

                int lineY = y + 58;
                int startX = x + 90;
                int endX = x + w - 90;

                g.DrawLine(grayPen, startX, lineY, endX, lineY);

                DrawFuel(g, "E\n(Vide)", "E", startX, lineY);
                DrawFuel(g, "1/4", "1/4", startX + 155, lineY);
                DrawFuel(g, "1/2", "1/2", startX + 310, lineY);
                DrawFuel(g, "3/4", "3/4", startX + 465, lineY);
                DrawFuel(g, "F\n(Plein)", "F", endX, lineY);
            }
        private void DrawImageFit(Graphics g, Image image, Rectangle rect)
        {
            if (image == null)
                return;

            float ratioImage = (float)image.Width / image.Height;
            float ratioRect = (float)rect.Width / rect.Height;

            int drawWidth;
            int drawHeight;

            if (ratioImage > ratioRect)
            {
                drawWidth = rect.Width;
                drawHeight = (int)(rect.Width / ratioImage);
            }
            else
            {
                drawHeight = rect.Height;
                drawWidth = (int)(rect.Height * ratioImage);
            }

            int drawX = rect.X + (rect.Width - drawWidth) / 2;
            int drawY = rect.Y + (rect.Height - drawHeight) / 2;

            Rectangle dest = new Rectangle(drawX, drawY, drawWidth, drawHeight);
            g.DrawImage(image, dest);
        }
        private void DrawEtatVehicule(Graphics g, int x, int y, int w, int h)
        {
            DrawSection(g, "8. ÉTAT DU VÉHICULE", x, y, w, h);

            Rectangle imgRect1 = new Rectangle(x + 30, y + 40, 335, 150);
            Rectangle imgRect2 = new Rectangle(x + 390, y + 40, 335, 150);

            if (_etatVoiture != null)
            {
                DrawImageFit(g, _etatVoiture, imgRect1);
            }
            else
            {
                g.DrawRectangle(grayPen, imgRect1);
                DrawCenter(g, "Image état véhicule 1", fontNormal, Brushes.Gray, imgRect1);
            }

            if (_etatVoiture2 != null)
            {
                DrawImageFit(g, _etatVoiture2, imgRect2);
            }
            else if (_etatVoiture != null)
            {
                DrawImageFit(g, _etatVoiture, imgRect2);
            }
            else
            {
                g.DrawRectangle(grayPen, imgRect2);
                DrawCenter(g, "Image état véhicule 2", fontNormal, Brushes.Gray, imgRect2);
            }

            int legY = y + h - 42;

            g.DrawString("LÉGENDE", fontBold, Brushes.Black, x + 15, legY);
            DrawCheckText(g, "Rayure", x + 110, legY);
            DrawCheckText(g, "Bosse", x + 220, legY);
            DrawCheckText(g, "Cassé", x + 320, legY);
            DrawCheckText(g, "Manquant", x + 420, legY);
            DrawCheckText(g, "Autre :", x + 555, legY);

            g.DrawLine(Pens.Gray, x + 630, legY + 10, x + w - 20, legY + 10);
        }

        private void DrawObservations(Graphics g, int x, int y, int w, int h)
            {
                DrawSection(g, "9. OBSERVATIONS", x, y, w, h);

                Rectangle rect = new Rectangle(x + 15, y + 35, w - 30, h - 40);

                for (int i = 0; i < 3; i++)
                {
                    int yy = y + 42 + i * 18;
                    //g.DrawLine(Pens.LightGray, x + 15, yy, x + w - 15, yy);
                }

                g.DrawString(Safe(_data.Observations), fontNormal, Brushes.Black, rect);
            }

            private void DrawSignatures(Graphics g, int x, int y, int leftW, int rightX, int rightW)
            {
                DrawSection(g, "10. SIGNATURE CLIENT", x, y, leftW, 100);
                g.DrawString("Je reconnais avoir pris connaissance de l'état du véhicule.", fontSmall, Brushes.Black, x + 15, y + 35);
                g.DrawString("Date : ____ / ____ / ______      Heure : __________", fontSmall, Brushes.Black, x + 15, y + 68);

                DrawSection(g, "11. SIGNATURE AGENCE", rightX, y, rightW, 100);
                g.DrawString("Je confirme l'exactitude des informations ci-dessus.", fontSmall, Brushes.Black, rightX + 15, y + 35);
                g.DrawString("Date : ____ / ____ / ______      Heure : __________", fontSmall, Brushes.Black, rightX + 15, y + 68);
            }

        private void DrawFooter(Graphics g, int x, int y, int w)
        {
            g.DrawLine(bluePen, x, y + 10, x + 250, y + 10);
            g.DrawString("Merci de votre confiance et bonne route !", fontBold, blueBrush, x + 270, y);
            g.DrawLine(bluePen, x + 515, y + 10, x + w, y + 10);

            y += 28;

            string infoSociete =
                "Agence : " + Safe(_data.NomSociete) +
                "  |  Adresse : " + Safe(_data.AdresseSociete) +
                "  |  Téléphone : " + Safe(_data.TelephoneSociete) +
                "  |  Email : " + Safe(_data.EmailSociete);

            RectangleF rect = new RectangleF(x, y, w, 25);

            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                g.DrawString(infoSociete, fontSmall, Brushes.Black, rect, sf);
            }
        }

        private void DrawSection(Graphics g, string title, int x, int y, int w, int h)
        {
            g.DrawRectangle(bluePen, x, y, w, h);

            int titleWidth = 150;

            if (title.Contains("SIGNATURE"))
                titleWidth = 190;

            Rectangle titleRect = new Rectangle(x, y, titleWidth, 24);
            g.FillRectangle(blueBrush, titleRect);
            g.DrawString(title, fontSection, Brushes.White, x + 7, y + 5);
        }

        private void DrawLineValue(Graphics g, string label, string value, int x, int y)
            {
                g.DrawString(label, fontBold, Brushes.Black, x, y);
                g.DrawString(Safe(value), fontNormal, Brushes.Black, x + 110, y);
            }

            private void DrawPaymentRow(Graphics g, string label, string value, int x, int y, int w, int h)
            {
                g.DrawRectangle(bluePen, x, y, w, h);
                g.DrawLine(bluePen, x + 120, y, x + 120, y + h);

                g.DrawString(label, fontBold, Brushes.Black, x + 8, y + 6);

                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Far;
                sf.LineAlignment = StringAlignment.Center;

                g.DrawString(value, fontNormal, Brushes.Black, new RectangleF(x + 125, y, w - 135, h), sf);
            }

            private void DrawFuel(Graphics g, string label, string value, int centerX, int lineY)
            {
                g.DrawString(label, fontSmall, Brushes.Black, centerX - 18, lineY - 38);

                bool selected = Safe(_data.NiveauCarburant).Equals(value, StringComparison.OrdinalIgnoreCase);
                DrawCheckBox(g, centerX - 7, lineY - 7, selected);
            }

            private void DrawCheckText(Graphics g, string text, int x, int y)
            {
                DrawCheckBox(g, x, y, false);
                g.DrawString(text, fontSmall, Brushes.Black, x + 18, y - 1);
            }

            private void DrawCheckBox(Graphics g, int x, int y, bool check)
            {
                g.DrawRectangle(Pens.Black, x, y, 14, 14);

                if (check)
                {
                    using (Pen p = new Pen(Color.Black, 2))
                    {
                        g.DrawLine(p, x + 3, y + 7, x + 6, y + 11);
                        g.DrawLine(p, x + 6, y + 11, x + 12, y + 3);
                    }
                }
            }

            private void DrawCenter(Graphics g, string text, Font font, Brush brush, Rectangle rect)
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

