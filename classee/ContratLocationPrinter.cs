using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace venolocation.classee
{
    internal class ContratLocationPrinter
    {
        private readonly FactureEtatVehiculeData _data;
        private readonly Image _logo;
        private readonly Image _etatVoiture;
        private readonly Image _etatVoiture2;

        private readonly PrintDocument _document;

        private readonly Font fTitleLarge = new Font("Times New Roman", 18, FontStyle.Bold);
        private readonly Font fBig = new Font("Times New Roman", 12, FontStyle.Bold);
        private readonly Font fHeader = new Font("Times New Roman", 9, FontStyle.Bold);
        private readonly Font fNormal = new Font("Times New Roman", 8, FontStyle.Regular);
        private readonly Font fBold = new Font("Times New Roman", 8, FontStyle.Bold);
        private readonly Font fSmall = new Font("Times New Roman", 7, FontStyle.Regular);
        private readonly Font fSmallBold = new Font("Times New Roman", 7, FontStyle.Bold);

        private readonly Pen blackPen = new Pen(Color.Black, 1);
        private readonly Pen thickPen = new Pen(Color.Black, 1.3f);

        public ContratLocationPrinter(
            FactureEtatVehiculeData data,
            Image logo,
            Image etatVoiture,
            Image etatVoiture2 = null)
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
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int x = 55;
            int y = 15;
            int pageW = 720;

            DrawHeader(g, x, y, pageW);
            y += 205; 

            DrawTitle(g, x, y, pageW);
            y += 55;

            int mainH = 680;
            DrawMainContract(g, x, y, pageW, mainH);
            y += mainH + 22;

            DrawObservations(g, x, y, pageW);
            y += 65;

            DrawFooter(g, x, y, pageW);

            e.HasMorePages = false;
        }

        private void DrawHeader(Graphics g, int x, int y, int w)
        {
            Rectangle logoRect = new Rectangle(x + 20, y + 15, 160, 95);

            if (_logo != null)
                DrawImageFit(g, _logo, logoRect);
            else
            {
                g.DrawString("MTZ", new Font("Arial", 28, FontStyle.Bold), Brushes.Black, x + 45, y + 35);
                g.DrawString("CARS", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, x + 70, y + 75);
            }

            Rectangle societeRect = new Rectangle(x + 230, y + 55, 220, 45);

            if (string.IsNullOrWhiteSpace(_data.NomSociete))
                DrawCenter(g, "Location de Voiture", fBig, Brushes.Black, societeRect);
            else
            {
                DrawCenter(g, Safe(_data.NomSociete), fBig, Brushes.Black, societeRect);
                g.DrawString("Location de Voiture", fBig, Brushes.Black, x + 265, y + 95);
            }

            int damageX = x + 460;
            int damageY = y + 20;
            Rectangle damageRect = new Rectangle(damageX, damageY, 120, 100);
            g.DrawRectangle(blackPen, damageRect);

            DrawCenter(g, "DOMMAGES\nIDENTIFIES\nET ACCEPTES",
                fSmallBold, Brushes.Black, new Rectangle(damageX + 5, damageY + 5, 110, 35));

            int ly = damageY + 42;
            g.DrawLine(blackPen, damageX + 10, ly + 2, damageX + 18, ly + 15);
            g.DrawLine(blackPen, damageX + 15, ly + 2, damageX + 23, ly + 15);
            g.DrawString("Erafure", fSmall, Brushes.Black, damageX + 30, ly);

            ly += 16;
            g.DrawString("X", fSmallBold, Brushes.Black, damageX + 12, ly);
            g.DrawString("Bosse", fSmall, Brushes.Black, damageX + 30, ly);

            ly += 16;
            g.DrawRectangle(blackPen, damageX + 12, ly + 2, 8, 8);
            g.DrawString("Manque", fSmall, Brushes.Black, damageX + 30, ly);

            g.DrawString("Nombre", fSmallBold, Brushes.Black, damageX + 8, damageY + 83);
            g.DrawString("Paraphe Client", fSmallBold, Brushes.Black, damageX + 55, damageY + 83);

            Rectangle carRect = new Rectangle(x + 595, y + 20, 100, 100);

            if (_etatVoiture != null)
                DrawImageFit(g, _etatVoiture, carRect);
            else if (_etatVoiture2 != null)
                DrawImageFit(g, _etatVoiture2, carRect);
            else
            {
                g.DrawRectangle(blackPen, carRect);
                DrawCenter(g, "AR\n\nAV", fSmallBold, Brushes.Black, carRect);
            }

            DrawFuelSmall(g, damageX + 25, y + 125);
        }

        private void DrawFuelSmall(Graphics g, int x, int y)
        {
            g.DrawString("0", fSmall, Brushes.Black, x - 5, y + 15);
            g.DrawString("1/4", fSmall, Brushes.Black, x + 30, y - 5);
            g.DrawString("1/2", fSmall, Brushes.Black, x + 65, y - 12);
            g.DrawString("3/4", fSmall, Brushes.Black, x + 100, y - 5);
            g.DrawString("1", fSmall, Brushes.Black, x + 135, y + 15);

            g.DrawArc(blackPen, x + 8, y, 120, 55, 180, 180);
            g.DrawLine(blackPen, x + 65, y + 28, x + 95, y + 8);
            g.DrawString("Carburant", fSmall, Brushes.Black, x + 50, y + 30);
        }

        private void DrawTitle(Graphics g, int x, int y, int w)
        {
            string num = Safe(_data.NumeroContrat);

            if (string.IsNullOrWhiteSpace(num))
                num = Safe(_data.NumeroFacture);

            DrawCenter(
                g,
                "CONTRAT LOCATION VOITURE",
                fTitleLarge,
                Brushes.Black,
                new Rectangle(x + 80, y, 460, 35)
            );

            g.DrawString("N° " + num, fBig, Brushes.Black, x + 570, y + 10);
        }

        private void DrawMainContract(Graphics g, int x, int y, int w, int h)
        {
            int leftW = w / 2;
            int rightW = w - leftW;
            int headerH = 35;

            g.DrawRectangle(thickPen, x, y, w, h);
            g.DrawLine(thickPen, x + leftW, y, x + leftW, y + h);
            g.DrawLine(thickPen, x, y + headerH, x + w, y + headerH);

            DrawCenter(g, "CLIENT", fHeader, Brushes.Black, new Rectangle(x, y, leftW, headerH));
            DrawCenter(g, "VOITURE", fHeader, Brushes.Black, new Rectangle(x + leftW, y, rightW, headerH));

            DrawClientBlock(g, x, y + headerH, leftW, h - headerH);
            DrawVoitureBlock(g, x + leftW, y + headerH, rightW, h - headerH);
        }

        private void DrawClientBlock(Graphics g, int x, int y, int w, int h)
        {
            int yy = y + 8;
            int pad = 8;
            int lineW = w - 22;

            DrawDottedField(g, "Nom :", Safe(_data.ClientNom), x + pad, yy, lineW); yy += 18;
            DrawDottedField(g, "Prénom :", Safe(_data.ClientPrenom), x + pad, yy, lineW); yy += 18;
            DrawDottedField(g, "Adresse :", Safe(_data.ClientAdresse), x + pad, yy, lineW); yy += 18;
            DrawDottedOnly(g, x + pad, yy, lineW); yy += 23;

            DrawDottedField(g, "C.I.N. N° :", Safe(_data.ClientCin), x + pad, yy, lineW); yy += 18;
            DrawDottedField(g, "Délivré le :", "", x + pad, yy, lineW); yy += 18;
            DrawDottedField(g, "N° de Permis :", Safe(_data.ClientPermis), x + pad, yy, lineW); yy += 18;
            DrawDottedField(g, "Délivré le :", Safe(_data.ClientPermisDate), x + pad, yy, lineW); yy += 18;
            DrawDottedField(g, "N° de Passeport :", Safe(_data.ClientPassport), x + pad, yy, lineW); yy += 18;
            DrawDottedField(g, "Délivré le :", Safe(_data.ClientPassportDate), x + pad, yy, lineW); yy += 22;

            DrawDottedField(g, "Tél. :", Safe(_data.ClientTelephone), x + pad, yy, lineW); yy += 18;
            DrawDottedField(g, "GSM :", Safe(_data.ClientTelephone), x + pad, yy, lineW); yy += 20;

            g.DrawLine(thickPen, x, yy, x + w, yy);
            DrawCenter(g, "AUTRE CONDUCTEURS :", fBold, Brushes.Black, new Rectangle(x, yy + 2, w, 20));
            yy += 28;

            DrawDottedField(g, "Nom :", Safe(_data.Conducteur2Nom), x + pad, yy, lineW); yy += 18;
            DrawDottedField(g, "Prénom :", Safe(_data.Conducteur2Prenom), x + pad, yy, lineW); yy += 18;
            DrawDottedField(g, "Adresse :", Safe(_data.Conducteur2Adresse), x + pad, yy, lineW); yy += 18;
            DrawDottedOnly(g, x + pad, yy, lineW); yy += 22;

            DrawDottedField(g, "C.I.N. N° :", Safe(_data.Conducteur2Cin), x + pad, yy, lineW); yy += 18;
            DrawDottedField(g, "Délivré le :", "", x + pad, yy, lineW); yy += 18;
            DrawDottedField(g, "N° de Permis :", Safe(_data.Conducteur2Permis), x + pad, yy, lineW); yy += 18;
            DrawDottedField(g, "Délivré le :", Safe(_data.Conducteur2PermisDate), x + pad, yy, lineW); yy += 20;

            g.DrawLine(thickPen, x, yy, x + w, yy);
            g.DrawString("NB : Ce contrat ne vaut en aucun cas comme facture", fBold, Brushes.Black, x + pad, yy + 6);
            yy += 30;

            g.DrawLine(thickPen, x, yy, x + w, yy);

            Rectangle txtRect = new Rectangle(x + pad, yy + 8, w - 15, 62);
            g.DrawString(
                "J’ai lu et accepté les conditions stipulées ci-contre au\n" +
                "verso de ce contrat.\n" +
                "Le client est seul responsable des violations de la loi\n" +
                "sur la circulation routière",
                fNormal,
                Brushes.Black,
                txtRect
            );

            yy += 78;
            DrawCenter(g, "Signature de Client :", fNormal, Brushes.Black, new Rectangle(x, yy, w, 18));
            g.DrawString("1er Conducteur", fNormal, Brushes.Black, x + 35, yy + 28);
            g.DrawString("2ème Conducteur", fNormal, Brushes.Black, x + 210, yy + 28);
        }

        private void DrawVoitureBlock(Graphics g, int x, int y, int w, int h)
        {
            int pad = 8;
            int yy = y + 8;
            int fullW = w - 16;

            DrawDottedField(g, "Marque :", Safe(_data.Marque) + " " + Safe(_data.Modele), x + pad, yy, 210);
            DrawDottedField(g, "Type :", Safe(_data.TypeVoiture), x + 210, yy, 140);
            yy += 20;

            DrawDottedField(g, "Matricule :", Safe(_data.Immatriculation), x + pad, yy, 210);
            DrawDottedField(g, "Carburant :", Safe(_data.Carburant), x + 210, yy, 140);
            yy += 25;

            int tableX = x + pad;
            int tableY = yy;
            int tableW = fullW;
            int rowH = 22;
            int col1 = 55;
            int col2 = (tableW - col1) / 2;

            DrawAgenceTable(g, tableX, tableY, tableW, rowH, col1, col2,
                Safe(_data.DateDepart), Safe(_data.HeureDepart), Safe(_data.LieuDepart),
                Safe(_data.DateRetour), Safe(_data.HeureRetour), Safe(_data.LieuRetour));

            yy += rowH * 4 + 8;

            g.DrawRectangle(thickPen, x + pad, yy, fullW, 95);

            DrawDottedField(
                g,
                "Durée de location :",
                Safe(_data.NombreJours) + " Jours",
                x + pad + 8,
                yy + 8,
                fullW - 18
            );

            g.DrawString(
                "Prix : " + Safe(_data.PrixJour) + " DH x " + Safe(_data.NombreJours) +
                " Jours = " + Safe(_data.Total) + " DH",
                fNormal,
                Brushes.Black,
                x + pad + 8,
                yy + 33
            );

            g.DrawString(
                "Avance : " + Safe(_data.Avance) + " DH",
                fNormal,
                Brushes.Black,
                x + pad + 8,
                yy + 55
            );

            g.DrawString(
                "Reste à payer : " + Safe(_data.Reste) + " DH",
                fBold,
                Brushes.Black,
                x + pad + 180,
                yy + 55
            );

            yy += 103;

            g.DrawRectangle(thickPen, x + pad, yy, fullW, 28);
            DrawDottedField(g, "Km Départ :", Safe(_data.KmDepart), x + pad + 8, yy + 7, fullW - 18);

            yy += 34;

            DrawCenter(g, "PROLONGATION :", fBold, Brushes.Black, new Rectangle(x, yy, w, 18));
            yy += 22;

            g.DrawRectangle(thickPen, x + pad, yy, fullW, 88);
            g.DrawString("Du : " + Safe(_data.ProlongationDu) + "     Au " + Safe(_data.ProlongationAu), fNormal, Brushes.Black, x + pad + 8, yy + 8);
            DrawDottedField(g, "Lieu de départ :", Safe(_data.ProlongationLieuDepart), x + pad + 8, yy + 28, fullW - 18);
            DrawDottedField(g, "Lieu de retour :", Safe(_data.ProlongationLieuRetour), x + pad + 8, yy + 48, fullW - 18);
            DrawDottedField(g, "Frais de livraison / Reprise :", Safe(_data.ProlongationFrais), x + pad + 8, yy + 68, fullW - 18);

            yy += 95;

            DrawCenter(g, "CHANGEMENT DE VEHICULE :", fBold, Brushes.Black, new Rectangle(x, yy, w, 18));
            yy += 22;

            g.DrawRectangle(thickPen, x + pad, yy, fullW, 48);
            DrawDottedField(g, "Marque :", Safe(_data.ChangementMarque), x + pad + 8, yy + 8, fullW - 18);
            DrawDottedField(g, "Matricule :", Safe(_data.ChangementMatricule), x + pad + 8, yy + 28, fullW - 18);

            yy += 55;

            DrawAgenceTable(g, tableX, yy, tableW, rowH, col1, col2,
                Safe(_data.ChangementDate), Safe(_data.ChangementHeure), Safe(_data.ChangementLieu),
                "", "", "");

            yy += rowH * 4 + 7;

            g.DrawRectangle(thickPen, x + pad, yy, fullW, 30);
            g.DrawString("Mode de règlement :", fNormal, Brushes.Black, x + pad + 8, yy + 8);

            DrawCheckText(g, "Espèces", x + pad + 115, yy + 8);
            DrawCheckText(g, "Chèque", x + pad + 210, yy + 8);
            DrawCheckText(g, "Autres", x + pad + 300, yy + 8);

            yy += 38;

            DrawCenter(g, "Visa de la Direction :", fNormal, Brushes.Black, new Rectangle(x, yy, w, 18));
            g.DrawLine(blackPen, x + 140, yy + 20, x + 230, yy + 20);
        }

        private void DrawAgenceTable(
            Graphics g,
            int tableX,
            int tableY,
            int tableW,
            int rowH,
            int col1,
            int col2,
            string dateDepart,
            string heureDepart,
            string lieuDepart,
            string dateRetour,
            string heureRetour,
            string lieuRetour)
        {
            g.DrawRectangle(thickPen, tableX, tableY, tableW, rowH * 4);
            g.DrawLine(thickPen, tableX + col1, tableY, tableX + col1, tableY + rowH * 4);
            g.DrawLine(thickPen, tableX + col1 + col2, tableY, tableX + col1 + col2, tableY + rowH * 4);

            for (int i = 1; i <= 3; i++)
                g.DrawLine(blackPen, tableX, tableY + rowH * i, tableX + tableW, tableY + rowH * i);

            DrawCenter(g, "Agence Départ", fNormal, Brushes.Black, new Rectangle(tableX + col1, tableY, col2, rowH));
            DrawCenter(g, "Agence Retour", fNormal, Brushes.Black, new Rectangle(tableX + col1 + col2, tableY, col2, rowH));

            g.DrawString("Date :", fNormal, Brushes.Black, tableX + 5, tableY + rowH + 5);
            g.DrawString("Heure :", fNormal, Brushes.Black, tableX + 5, tableY + rowH * 2 + 5);
            g.DrawString("Lieu :", fNormal, Brushes.Black, tableX + 5, tableY + rowH * 3 + 5);

            g.DrawString(dateDepart, fNormal, Brushes.Black, tableX + col1 + 8, tableY + rowH + 5);
            g.DrawString(heureDepart, fNormal, Brushes.Black, tableX + col1 + 8, tableY + rowH * 2 + 5);
            g.DrawString(lieuDepart, fNormal, Brushes.Black, tableX + col1 + 8, tableY + rowH * 3 + 5);

            g.DrawString(dateRetour, fNormal, Brushes.Black, tableX + col1 + col2 + 8, tableY + rowH + 5);
            g.DrawString(heureRetour, fNormal, Brushes.Black, tableX + col1 + col2 + 8, tableY + rowH * 2 + 5);
            g.DrawString(lieuRetour, fNormal, Brushes.Black, tableX + col1 + col2 + 8, tableY + rowH * 3 + 5);
        }

        private void DrawObservations(Graphics g, int x, int y, int w)
        {
            g.DrawString("OBSERVATIONS :", fBold, Brushes.Black, x, y);
            g.DrawLine(blackPen, x, y + 55, x + w, y + 55);

            if (!string.IsNullOrWhiteSpace(_data.Observations))
            {
                g.DrawString(
                    _data.Observations,
                    fNormal,
                    Brushes.Black,
                    new Rectangle(x + 5, y + 18, w - 10, 35)
                );
            }
        }

        private void DrawFooter(Graphics g, int x, int y, int w)
        {
            g.DrawLine(blackPen, x, y, x + w, y);

            string ligne1 = Safe(_data.AdresseSociete) + "   Tél : " + Safe(_data.TelephoneSociete);
            string ligne2 = "E-mail : " + Safe(_data.EmailSociete);

            DrawCenter(g, ligne1, fSmall, Brushes.Black, new Rectangle(x, y + 8, w, 18));
            DrawCenter(g, ligne2, fSmall, Brushes.Black, new Rectangle(x, y + 25, w, 18));
        }

        private void DrawDottedField(Graphics g, string label, string value, int x, int y, int w)
        {
            g.DrawString(label, fNormal, Brushes.Black, x, y);

            int labelW = (int)g.MeasureString(label, fNormal).Width + 3;
            int lineX = x + labelW;
            int lineY = y + 13;

            DrawDots(g, lineX, lineY, x + w);

            if (!string.IsNullOrWhiteSpace(value))
                g.DrawString(value, fNormal, Brushes.Black, lineX + 4, y);
        }

        private void DrawDottedOnly(Graphics g, int x, int y, int w)
        {
            DrawDots(g, x, y + 13, x + w);
        }

        private void DrawDots(Graphics g, int x1, int y, int x2)
        {
            using (Pen dotPen = new Pen(Color.Black, 1))
            {
                dotPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                g.DrawLine(dotPen, x1, y, x2, y);
            }
        }

        private void DrawCheckText(Graphics g, string text, int x, int y)
        {
            DrawCheckBox(g, x, y, IsModePaiement(text));
            g.DrawString(text, fSmall, Brushes.Black, x + 16, y - 1);
        }

        private bool IsModePaiement(string text)
        {
            string mode = Safe(_data.ModePaiement).Trim().ToLower();
            string t = Safe(text).Trim().ToLower();

            if (string.IsNullOrWhiteSpace(mode))
                return false;

            if (t == "espèces")
                return mode == "cash" || mode == "espèces" || mode == "espece" || mode == "espèces";

            if (t == "chèque")
                return mode == "chèque" || mode == "cheque";

            if (t == "autres")
                return mode == "autre" || mode == "autres" || mode == "virement" || mode == "carte";

            return mode.Contains(t);
        }

        private void DrawCheckBox(Graphics g, int x, int y, bool check)
        {
            g.DrawRectangle(blackPen, x, y, 12, 12);

            if (check)
            {
                using (Pen p = new Pen(Color.Black, 2))
                {
                    g.DrawLine(p, x + 2, y + 7, x + 5, y + 10);
                    g.DrawLine(p, x + 5, y + 10, x + 11, y + 2);
                }
            }
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

            g.DrawImage(image, new Rectangle(drawX, drawY, drawWidth, drawHeight));
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