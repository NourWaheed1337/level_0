using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class UserControl2 : UserControl
    {
        Random rnd = new Random();
        decimal number;
        private void MakeRoundedPanel(Panel panel, int radius)
        {
            Rectangle bounds = panel.ClientRectangle;
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            path.StartFigure();
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            panel.Region = new Region(path);
        }
        public UserControl2()
        {
            InitializeComponent();
            chart1.Series["Patients"].Points.Clear();

            for (int i = 1; i < 6; i++)
            {
                number = rnd.Next(0, 10);
                chart1.Series["Patients"].Points.AddXY(i, number);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            MakeRoundedPanel(panel1, 15);
            MakeRoundedPanel(panel2, 10);
            MakeRoundedPanel(panel3, 15);
            MakeRoundedPanel(panel4, 10);
            MakeRoundedPanel(panel5, 15);
            MakeRoundedPanel(panel6, 10);
            MakeRoundedPanel(panel7, 10);
            MakeRoundedPanel(panel8, 10);
            MakeRoundedPanel(panel9, 10);
            MakeRoundedPanel(panel10, 10);
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
