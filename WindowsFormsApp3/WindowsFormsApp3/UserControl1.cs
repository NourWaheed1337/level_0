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
using System.Windows.Forms.DataVisualization.Charting;
using WindowsFormsApp3.repo;

namespace WindowsFormsApp3
{
    public partial class UserControl1 : UserControl
    {
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

        public UserControl1()
        {
            InitializeComponent();
            Random rnd = new Random();
            decimal number;

            chart1.Series["Patients"].Points.Clear();

            for (int i = 1; i < 6; i++)
            {
                number = rnd.Next(0, 10);
                chart1.Series["Patients"].Points.AddXY(i, number);
            }
            ReadClients();

        }
        private void ReadClients()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Email");
            dataTable.Columns.Add("Phone");
            dataTable.Columns.Add("Date");
            dataTable.Columns.Add("gender");
            dataTable.Columns.Add("weight");
            var repo = new ClientRepo();
            var clients = repo.GetClients();
            foreach (var client in clients)
            {
                var row = dataTable.NewRow();
                row["ID"] = client.id;
                row["Name"] = client.firstName + " " + client.lastName;
                row["Email"] = client.email;
                row["Phone"] = client.phone;
                row["Date"] = client.createdAt;
                row["gender"] = client.gender;
                row["weight"] = client.weight;
                dataTable.Rows.Add(row);
            }
            this.clientsTable.DataSource = dataTable;

        }

        private void UserControl1_Load(object sender, EventArgs e)
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
            MakeRoundedPanel(panel11, 10);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
