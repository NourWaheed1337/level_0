using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace WindowsFormsApp1
{
    public partial class UserControl2 : UserControl
    {
        Random rnd = new Random();
        decimal number;
        private DataGridView dataGridView;

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
        private void FetchTableData(string tableName)
        {
            string connectionString = "Data Source=.;Initial Catalog=data_patients;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = $"SELECT * FROM {tableName}";

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching table data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            this.AutoScrollPosition = new Point(0, this.DisplayRectangle.Height);
            this.AutoScroll = true;
            FetchTableData("new_employee");
            this.dataGridView = new System.Windows.Forms.DataGridView();
            dataGridView1 = new DataGridView();
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
            MakeRoundedPanel(panel12, 10);
        }

        private void chart1_Click(object sender, EventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void panel3_Paint(object sender, PaintEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void panel12_Paint(object sender, PaintEventArgs e) { }
        private void label16_Click(object sender, EventArgs e) { }
        private void panel7_Paint(object sender, PaintEventArgs e) { }
        private void panel8_Paint(object sender, PaintEventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void panel5_Paint(object sender, PaintEventArgs e) { }
        private void panel4_Paint(object sender, PaintEventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void panel9_Paint(object sender, PaintEventArgs e) { }
        private void panel6_Paint(object sender, PaintEventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void panel10_Paint(object sender, PaintEventArgs e) { }
        private void panel11_Paint(object sender, PaintEventArgs e) { }
        private void label15_Click(object sender, EventArgs e) { }
        private void button3_Click(object sender, EventArgs e) { }
        private void label14_Click(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void label13_Click(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }
        private void label12_Click(object sender, EventArgs e) { }
        private void label11_Click(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }

  
    }
