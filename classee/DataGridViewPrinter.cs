using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace venolocation.classee
{
    internal class DataGridViewPrinter
    {

            private DataGridView _dgv;
            private string _titre;
            private string _utilisateur;

            private PrintDocument _document;

            private int _rowIndex = 0;
            private int _pageNumber = 1;

            private List<DataGridViewColumn> _columns;
            private List<int> _columnWidths;

            private Font _fontTitle = new Font("Arial", 16, FontStyle.Bold);
            private Font _fontHeader = new Font("Arial", 9, FontStyle.Bold);
            private Font _fontCell = new Font("Arial", 8, FontStyle.Regular);
            private Font _fontSmall = new Font("Arial", 8, FontStyle.Italic);

            private int _rowHeight = 28;
            private int _headerHeight = 32;

            public DataGridViewPrinter(DataGridView dgv, string titre, string utilisateur)
            {
                _dgv = dgv;
                _titre = titre;
                _utilisateur = utilisateur;

                _document = new PrintDocument();
                _document.PrintPage += PrintPage;

                _document.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
                _document.DefaultPageSettings.Margins = new Margins(35, 35, 35, 35);

             
                _document.DefaultPageSettings.Landscape = true;
            }

            public void ShowPreview()
            {
                _rowIndex = 0;
                _pageNumber = 1;

                using (PrintPreviewDialog preview = new PrintPreviewDialog())
                {
                    preview.Document = _document;
                    preview.Width = 1100;
                    preview.Height = 800;
                    preview.ShowDialog();
                }
            }

            public void PrintDirect()
            {
                _rowIndex = 0;
                _pageNumber = 1;
                _document.Print();
            }

            private void PrepareColumns(int tableWidth)
            {
                _columns = new List<DataGridViewColumn>();
                _columnWidths = new List<int>();

                foreach (DataGridViewColumn col in _dgv.Columns)
                {
                    if (col.Visible)
                        _columns.Add(col);
                }

                if (_columns.Count == 0)
                    return;

                int totalOriginalWidth = 0;

                foreach (DataGridViewColumn col in _columns)
                    totalOriginalWidth += col.Width;

                foreach (DataGridViewColumn col in _columns)
                {
                    int w = (int)((double)col.Width / totalOriginalWidth * tableWidth);

                    if (w < 60)
                        w = 60;

                    _columnWidths.Add(w);
                }

                int sum = 0;
                foreach (int w in _columnWidths)
                    sum += w;

                int diff = tableWidth - sum;

                if (_columnWidths.Count > 0)
                    _columnWidths[_columnWidths.Count - 1] += diff;
            }

            private void PrintPage(object sender, PrintPageEventArgs e)
            {
                Graphics g = e.Graphics;

                int x = e.MarginBounds.Left;
                int y = e.MarginBounds.Top;
                int pageWidth = e.MarginBounds.Width;
                int pageHeight = e.MarginBounds.Height;

                if (_columns == null)
                    PrepareColumns(pageWidth);

                DrawHeader(g, x, y, pageWidth);
                y += 95;

                DrawTableHeader(g, x, y, pageWidth);
                y += _headerHeight;

                int bottom = e.MarginBounds.Bottom - 45;

                while (_rowIndex < _dgv.Rows.Count)
                {
                    DataGridViewRow row = _dgv.Rows[_rowIndex];

                    if (row.IsNewRow)
                    {
                        _rowIndex++;
                        continue;
                    }

                    if (y + _rowHeight > bottom)
                    {
                        DrawFooter(g, e.MarginBounds.Left, e.MarginBounds.Bottom, pageWidth);
                        _pageNumber++;
                        e.HasMorePages = true;
                        return;
                    }

                    DrawRow(g, row, x, y);
                    y += _rowHeight;

                    _rowIndex++;
                }

                DrawFooter(g, e.MarginBounds.Left, e.MarginBounds.Bottom, pageWidth);

                e.HasMorePages = false;

               
                _rowIndex = 0;
                _pageNumber = 1;
                _columns = null;
                _columnWidths = null;
            }

            private void DrawHeader(Graphics g, int x, int y, int width)
            {
                string dateText = "Date impression : " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                string userText = "Utilisateur : " + _utilisateur;

                Rectangle titleRect = new Rectangle(x, y, width, 35);

                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    g.DrawString(_titre, _fontTitle, Brushes.Black, titleRect, sf);
                }

                y += 45;

                g.DrawString(dateText, _fontSmall, Brushes.Black, x, y);
                g.DrawString(userText, _fontSmall, Brushes.Black, x, y + 20);

                g.DrawLine(Pens.Black, x, y + 45, x + width, y + 45);
            }

            private void DrawTableHeader(Graphics g, int x, int y, int tableWidth)
            {
                int currentX = x;

                using (Brush headerBrush = new SolidBrush(Color.FromArgb(230, 230, 230)))
                {
                    g.FillRectangle(headerBrush, x, y, tableWidth, _headerHeight);
                }

                for (int i = 0; i < _columns.Count; i++)
                {
                    Rectangle rect = new Rectangle(currentX, y, _columnWidths[i], _headerHeight);

                    g.DrawRectangle(Pens.Black, rect);

                    using (StringFormat sf = new StringFormat())
                    {
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        sf.Trimming = StringTrimming.EllipsisCharacter;

                        g.DrawString(_columns[i].HeaderText, _fontHeader, Brushes.Black, rect, sf);
                    }

                    currentX += _columnWidths[i];
                }
            }

            private void DrawRow(Graphics g, DataGridViewRow row, int x, int y)
            {
                int currentX = x;

                for (int i = 0; i < _columns.Count; i++)
                {
                    DataGridViewColumn col = _columns[i];

                    Rectangle rect = new Rectangle(currentX, y, _columnWidths[i], _rowHeight);

                    g.DrawRectangle(Pens.Gray, rect);

                    object value = row.Cells[col.Index].Value;
                    string text = value == null ? "" : value.ToString();

                    Rectangle textRect = new Rectangle(rect.X + 4, rect.Y + 2, rect.Width - 8, rect.Height - 4);

                    using (StringFormat sf = new StringFormat())
                    {
                        sf.Alignment = StringAlignment.Near;
                        sf.LineAlignment = StringAlignment.Center;
                        sf.Trimming = StringTrimming.EllipsisCharacter;
                        sf.FormatFlags = StringFormatFlags.NoWrap;

                        g.DrawString(text, _fontCell, Brushes.Black, textRect, sf);
                    }

                    currentX += _columnWidths[i];
                }
            }

            private void DrawFooter(Graphics g, int x, int y, int width)
            {
                g.DrawLine(Pens.Black, x, y - 25, x + width, y - 25);

                string footer = "Page " + _pageNumber;

                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;

                    g.DrawString(
                        footer,
                        _fontSmall,
                        Brushes.Black,
                        new RectangleF(x, y - 20, width, 20),
                        sf
                    );
                }
            }
        
    }
}

