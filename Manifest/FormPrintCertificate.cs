namespace Manifest
{
    using System;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Windows.Forms;

    public partial class FormPrintCertificate : Form
    {
        private string studentname;
        private string aircraft;
        private string instructor;

        public FormPrintCertificate(string sn, string a, string i)
        {
            this.InitializeComponent();
            this.studentname = sn;
            this.aircraft = a;
            this.instructor = i;

            this.textBoxName.Text = this.studentname;
            this.textBoxAircraft.Text = this.aircraft;
            this.textBoxInstructor.Text = this.instructor;
            this.textBoxAltitude.Text = "14,500";
            this.textBoxFreefall.Text = "60";
            this.textBoxDate.Text = DateTime.Today.ToString("dd MMMM yyyy");
        }

        private void ButtonPrint_Click(object sender, EventArgs e)
        {
            using (PrintDocument pd = new PrintDocument())
            {
                pd.PrintPage += this.Pd_PrintPage;

                pd.Print();
            }

            this.Close();
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            string n = this.textBoxName.Text;
            string a = this.textBoxAircraft.Text;
            string i = this.textBoxInstructor.Text;
            string alt = this.textBoxAltitude.Text;
            string f = this.textBoxFreefall.Text;
            string d = this.textBoxDate.Text;
            float x = 0.1f;
            float y = 20f;

            float availableWidth = (float)Math.Floor(((PrintDocument)sender).OriginAtMargins
                ? e.MarginBounds.Width
                : (e.PageSettings.Landscape
                    ? e.PageSettings.PrintableArea.Height
                    : e.PageSettings.PrintableArea.Width));

            float availableHeight = (float)Math.Floor(((PrintDocument)sender).OriginAtMargins
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
