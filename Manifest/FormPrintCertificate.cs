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
        private PrintDocument pd;

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
            this.pd = new PrintDocument();
            this.pd.PrintPage += this.Pd_PrintPage;

            this.pd.Print();

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

            string texto = string.Empty;
            Font font = new Font("Arial", 26);
            SizeF sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);

            e.Graphics.DrawRectangle(new Pen(Color.Black, .5F), 0, 0, availableWidth - 2, availableHeight - 2);

            texto = "                  West Tennessee Skydiving";
            sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);
            e.Graphics.DrawString(texto,
                                     font,
                                     new SolidBrush(Color.Black),
                                     new RectangleF(new PointF(x, y), sizeF));
            y = y + 120;

            float center = availableWidth / 2.0f;
            float centername = (n.Length / 2.0f) * 35;
            if (centername > center)
            {
                centername = center;
            }

            texto = "\n" + n;
            font = new Font("Arial", 32, FontStyle.Bold);
            sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);
            e.Graphics.DrawString(texto,
                                     font,
                                     new SolidBrush(Color.Black),
                                     new RectangleF(new PointF(x + center - centername, y), sizeF));

            y = y + 120;

            texto = "\n\n          Completed a Tandem Skydive";
            font = new Font("Arial", 26);
            sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);
            e.Graphics.DrawString(texto,
                                     font,
                                     new SolidBrush(Color.Black),
                                     new RectangleF(new PointF(x, y), sizeF));

            y = y + 40;

            texto = "\n\n             from an altitude of " + alt + "'";
            font = new Font("Arial", 26);
            sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);
            e.Graphics.DrawString(texto,
                                     font,
                                     new SolidBrush(Color.Black),
                                     new RectangleF(new PointF(x, y), sizeF));

            y = y + 40;

            texto = "\n\n            with a freefall of " + f + " seconds";
            font = new Font("Arial", 26);
            sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);
            e.Graphics.DrawString(texto,
                                     font,
                                     new SolidBrush(Color.Black),
                                     new RectangleF(new PointF(x, y), sizeF));

            y = y + 40;

            texto = "\n\n          at West Tennessee Skydiving";
            font = new Font("Arial", 26);
            sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);
            e.Graphics.DrawString(texto,
                                     font,
                                     new SolidBrush(Color.Black),
                                     new RectangleF(new PointF(x, y), sizeF));

            y = y + 170;

            texto = "\n                 Date: " + d;
            font = new Font("Arial", 26);
            sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);
            e.Graphics.DrawString(texto,
                                     font,
                                     new SolidBrush(Color.Black),
                                     new RectangleF(new PointF(x, y), sizeF));

            y = y + 70;

            texto = "\n                 Aircraft: " + a;
            font = new Font("Arial", 26);
            sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);
            e.Graphics.DrawString(texto,
                                     font,
                                     new SolidBrush(Color.Black),
                                     new RectangleF(new PointF(x, y), sizeF));

            y = y + 70;

            texto = "\n                 Instructor: " + i;
            font = new Font("Arial", 26);
            sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);
            e.Graphics.DrawString(texto,
                                     font,
                                     new SolidBrush(Color.Black),
                                     new RectangleF(new PointF(x, y), sizeF));

            y = y + 200;

            texto = "\n                        West Tennessee Skydiving\n               Wings Field, Memphis, TN 901-SKY-DIVE\n                         www.SkydiveKingAir.com";
            font = new Font("Arial", 20);
            sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);
            e.Graphics.DrawString(texto,
                                     font,
                                     new SolidBrush(Color.Black),
                                     new RectangleF(new PointF(x, y), sizeF));
        }
    }
}
