using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Manifest
{
    public partial class FormPrintCertificate : Form
    {
        String studentname;
        String aircraft;
        String instructor;
        private PrintDocument pd;

        public FormPrintCertificate(String sn, String a, String i)
        {
            InitializeComponent();
            studentname = sn;
            aircraft = a;
            instructor = i;

            textBoxName.Text = studentname;
            textBoxAircraft.Text = aircraft;
            textBoxInstructor.Text = instructor;
            textBoxAltitude.Text = "14,500";
            textBoxFreefall.Text = "60";
            textBoxDate.Text = DateTime.Today.ToString("dd MMMM yyyy");

        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            pd = new PrintDocument();
            pd.PrintPage += Pd_PrintPage;

            pd.Print();

            this.Close();
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            String n = textBoxName.Text;
            String a = textBoxAircraft.Text;
            String i = textBoxInstructor.Text;
            String alt = textBoxAltitude.Text;
            String f = textBoxFreefall.Text;
            String d = textBoxDate.Text;
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
                                     new RectangleF(new PointF(x, y), sizeF)
                                    //new StringFormat { Alignment = StringAlignment.Center }
                                    );
            y = y + 120;

            float center = availableWidth / 2.0f;
            float centername = (n.Length / 2.0f)*35;
            if (centername > center)
                centername = center;

            texto = "\n" + n;
            font = new Font("Arial", 32, FontStyle.Bold);
            sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);
            e.Graphics.DrawString(texto,
                                     font,
                                     new SolidBrush(Color.Black),
                                     new RectangleF(new PointF(x + center - centername, y), sizeF)
                                     //new StringFormat { Alignment = StringAlignment.Center }
                                    );

            y = y + 120;

            texto = "\n\n          Completed a Tandem Skydive";
            font = new Font("Arial", 26);
            sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);
            e.Graphics.DrawString(texto,
                                     font,
                                     new SolidBrush(Color.Black),
                                     new RectangleF(new PointF(x, y), sizeF)
                                    //new StringFormat { Alignment = StringAlignment.Center }
                                    );

            y = y + 40;

            texto = "\n\n             from an altitude of " + alt + "'";
            font = new Font("Arial", 26);
            sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);
            e.Graphics.DrawString(texto,
                                     font,
                                     new SolidBrush(Color.Black),
                                     new RectangleF(new PointF(x, y), sizeF)
                                    //new StringFormat { Alignment = StringAlignment.Center }
                                    );

            y = y + 40;

            texto = "\n\n            with a freefall of " + f + " seconds";
            font = new Font("Arial", 26);
            sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);
            e.Graphics.DrawString(texto,
                                     font,
                                     new SolidBrush(Color.Black),
                                     new RectangleF(new PointF(x, y), sizeF)
                                    //new StringFormat { Alignment = StringAlignment.Center }
                                    );

            y = y + 40;

            texto = "\n\n          at West Tennessee Skydiving";
            font = new Font("Arial", 26);
            sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);
            e.Graphics.DrawString(texto,
                                     font,
                                     new SolidBrush(Color.Black),
                                     new RectangleF(new PointF(x, y), sizeF)
                                    //new StringFormat { Alignment = StringAlignment.Center }
                                    );

            y = y + 170;

            texto = "\n                 Date: " + d;
            font = new Font("Arial", 26);
            sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);
            e.Graphics.DrawString(texto,
                                     font,
                                     new SolidBrush(Color.Black),
                                     new RectangleF(new PointF(x, y), sizeF)
                                    //new StringFormat { Alignment = StringAlignment.Center }
                                    );

            y = y + 70;

            texto = "\n                 Aircraft: " + a;
            font = new Font("Arial", 26);
            sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);
            e.Graphics.DrawString(texto,
                                     font,
                                     new SolidBrush(Color.Black),
                                     new RectangleF(new PointF(x, y), sizeF)
                                    //new StringFormat { Alignment = StringAlignment.Center }
                                    );

            y = y + 70;

            texto = "\n                 Instructor: " + i;
            font = new Font("Arial", 26);
            sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);
            e.Graphics.DrawString(texto,
                                     font,
                                     new SolidBrush(Color.Black),
                                     new RectangleF(new PointF(x, y), sizeF)
                                    //new StringFormat { Alignment = StringAlignment.Center }
                                    );

            y = y + 200;

            texto = "\n                        West Tennessee Skydiving\n               Wings Field, Memphis, TN 901-SKY-DIVE\n                         www.SkydiveKingAir.com";
            font = new Font("Arial", 20);
            sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);
            e.Graphics.DrawString(texto,
                                     font,
                                     new SolidBrush(Color.Black),
                                     new RectangleF(new PointF(x, y), sizeF)
                                    //new StringFormat { Alignment = StringAlignment.Center }
                                    );
        }
    }
}
