using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class UserControl6 : UserControl
    {
        Random rnd = new Random();
        decimal number;

        private void chart1_random(string name)
        {
            chart1.Series[name].Points.Clear();

            for (int i = 1; i < 6; i++)
            {
                number = rnd.Next(0, 10);
                chart1.Series[name].Points.AddXY(i, number);
            }
        }
        private void CreateDoughnutChart()
        {
            chart2.Series.Clear();

            Series series = new Series
            {
                Name = "MyData",
                ChartType = SeriesChartType.Doughnut,
                IsValueShownAsLabel = true,
                LabelForeColor = Color.White,
               Font = new Font("Arial", 12, FontStyle.Regular)
            };

            series.Points.AddXY("In Come1", 70);
            series.Points.AddXY("New Patient1", 30);

            chart2.Series.Add(series);
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
        public UserControl6()
        {
            InitializeComponent();
            MakeRoundedPanel(panel2, 10);
            MakeRoundedPanel(panel3, 10);
            MakeRoundedPanel(panel4, 10);
            MakeRoundedPanel(panel5, 10);
            MakeRoundedPanel(panel6, 10);
            MakeRoundedPanel(panel7, 10);
            MakeRoundedPanel(panel8, 10);
            MakeRoundedPanel(panel9, 10);
            chart1_random("New Patient");
            chart1_random("In Come");
            CreateDoughnutChart();
            FetchTableData("payment_activity");


        }
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
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
