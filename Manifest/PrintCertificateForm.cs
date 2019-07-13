namespace Manifest
{
    using System;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Windows.Forms;

    public partial class PrintCertificateForm : Form
    {
        private string studentname;
        private string aircraft;
        private string instructor;

        public PrintCertificateForm(string sn, string a, string i)
        {
            this.InitializeComponent();
            this.studentname = sn;
            this.aircraft = a;
            this.instructor = i;

            this.nameTextBox.Text = this.studentname;
            this.aircraftTextBox.Text = this.aircraft;
            this.instructorTextBox.Text = this.instructor;
            this.altitudeTextBox.Text = "14,500";
            this.freefallTextBox.Text = "60";
            this.dateTextBox.Text = DateTime.Today.ToString("dd MMMM yyyy");
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            using (PrintDocument printDocument = new PrintDocument())
            {
                printDocument.PrintPage += this.PrintDocument_PrintPage;

                printDocument.Print();
            }

            this.Close();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            PrintDocument printDocument = sender as PrintDocument;

            string n = this.nameTextBox.Text;
            string a = this.aircraftTextBox.Text;
            string i = this.instructorTextBox.Text;
            string alt = this.altitudeTextBox.Text;
            string f = this.freefallTextBox.Text;
            string d = this.dateTextBox.Text;
            float x = 0.1f;
            float y = 20f;

            float availableWidth = (float)Math.Floor(printDocument.OriginAtMargins
                ? e.MarginBounds.Width
                : (e.PageSettings.Landscape
                    ? e.PageSettings.PrintableArea.Height
                    : e.PageSettings.PrintableArea.Width));

            float availableHeight = (float)Math.Floor(printDocument.OriginAtMargins
                ? e.MarginBounds.Height
                : (e.PageSettings.Landscape
                    ? e.PageSettings.PrintableArea.Width
                    : e.PageSettings.PrintableArea.Height));

            using (Pen pen = new Pen(Color.Black, .5F))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, availableWidth - 2, availableHeight - 2);
            }

            using (Font font = new Font("Arial", 26))
            {
                string texto = "                  West Tennessee Skydiving";
                SizeF sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);

                e.Graphics.DrawString(
                    texto,
                    font,
                    Brushes.Black,
                    new RectangleF(new PointF(x, y), sizeF));
            }

            y = y + 120;

            float center = availableWidth / 2.0f;
            float centername = (n.Length / 2.0f) * 35;
            if (centername > center)
            {
                centername = center;
            }

            using (Font font = new Font("Arial", 32, FontStyle.Bold))
            {
                string texto = "\n" + n;
                SizeF sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);

                e.Graphics.DrawString(
                    texto,
                    font,
                    Brushes.Black,
                    new RectangleF(new PointF(x + center - centername, y), sizeF));
            }

            y = y + 120;

            using (Font font = new Font("Arial", 26))
            {
                string texto = "\n\n          Completed a Tandem Skydive";
                SizeF sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);

                e.Graphics.DrawString(
                    texto,
                    font,
                    Brushes.Black,
                    new RectangleF(new PointF(x, y), sizeF));
            }

            y = y + 40;

            using (Font font = new Font("Arial", 26))
            {
                string texto = "\n\n             from an altitude of " + alt + "'";
                SizeF sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);

                e.Graphics.DrawString(
                    texto,
                    font,
                    Brushes.Black,
                    new RectangleF(new PointF(x, y), sizeF));
            }

            y = y + 40;

            using (Font font = new Font("Arial", 26))
            {
                string texto = "\n\n            with a freefall of " + f + " seconds";
                SizeF sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);

                e.Graphics.DrawString(
                    texto,
                    font,
                    Brushes.Black,
                    new RectangleF(new PointF(x, y), sizeF));
            }

            y = y + 40;

            using (Font font = new Font("Arial", 26))
            {
                string texto = "\n\n          at West Tennessee Skydiving";
                SizeF sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);

                e.Graphics.DrawString(
                    texto,
                    font,
                    Brushes.Black,
                    new RectangleF(new PointF(x, y), sizeF));
            }

            y = y + 170;

            using (Font font = new Font("Arial", 26))
            {
                string texto = "\n                 Date: " + d;
                SizeF sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);

                e.Graphics.DrawString(
                    texto,
                    font,
                    Brushes.Black,
                    new RectangleF(new PointF(x, y), sizeF));
            }

            y = y + 70;

            using (Font font = new Font("Arial", 26))
            {
                string texto = "\n                 Aircraft: " + a;
                SizeF sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);

                e.Graphics.DrawString(
                    texto,
                    font,
                    Brushes.Black,
                    new RectangleF(new PointF(x, y), sizeF));
            }

            y = y + 70;

            using (Font font = new Font("Arial", 26))
            {
                string texto = "\n                 Instructor: " + i;
                SizeF sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);

                e.Graphics.DrawString(
                    texto,
                    font,
                    Brushes.Black,
                    new RectangleF(new PointF(x, y), sizeF));
            }

            y = y + 200;

            using (Font font = new Font("Arial", 20))
            {
                string texto = "\n                        West Tennessee Skydiving\n               Wings Field, Memphis, TN 901-SKY-DIVE\n                         www.SkydiveKingAir.com";
                SizeF sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);

                e.Graphics.DrawString(
                    texto,
                    font,
                    Brushes.Black,
                    new RectangleF(new PointF(x, y), sizeF));
            }
        }
    }
}
