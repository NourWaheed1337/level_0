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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class UserControl4 : UserControl
    {

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
        private void UpdatePatient()
        {
            string connectionString = "Data Source=.;Initial Catalog=data_patients;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE patient SET 
                                name = @name, 
                                email = @email, 
                                age = @age, 
                                gender = @gender, 
                                diagnosis = @diagnosis, 
                                treatment_plan = @treatment_plan, 
                                insurance_provider = @insurance_provider
                             WHERE id = @id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", textBox8.Text);
                    cmd.Parameters.AddWithValue("@name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@email", textBox2.Text);
                    cmd.Parameters.AddWithValue("@age", textBox3.Text);
                    cmd.Parameters.AddWithValue("@gender", textBox4.Text);
                    cmd.Parameters.AddWithValue("@diagnosis", textBox5.Text);
                    cmd.Parameters.AddWithValue("@treatment_plan", textBox7.Text);
                    cmd.Parameters.AddWithValue("@insurance_provider", textBox6.Text);

                    int rows = cmd.ExecuteNonQuery();
                    MessageBox.Show(rows > 0 ? "Patient updated successfully." : "Update failed.");
                    FetchTableData("patient");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating patient: " + ex.Message);
                }
            }
        }


        private void AddPatient()
        {
            string connectionString = "Data Source=.;Initial Catalog=data_patients;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO patient 
                             (name, email, age, gender, diagnosis, treatment_plan, insurance_provider) 
                             VALUES 
                             (@name, @email, @age, @gender, @diagnosis, @treatment_plan, @insurance_provider)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@email", textBox2.Text);
                    cmd.Parameters.AddWithValue("@age", textBox3.Text);
                    cmd.Parameters.AddWithValue("@gender", textBox4.Text);
                    cmd.Parameters.AddWithValue("@diagnosis", textBox5.Text);
                    cmd.Parameters.AddWithValue("@treatment_plan", textBox7.Text);
                    cmd.Parameters.AddWithValue("@insurance_provider", textBox6.Text);

                    int rows = cmd.ExecuteNonQuery();
                    MessageBox.Show(rows > 0 ? "Patient added successfully." : "Insert failed.");
                    FetchTableData("patient");
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding patient: " + ex.Message);
                }
            }
        }



        private void DeletePatient()
        {
            string connectionString = "Data Source=.;Initial Catalog=data_patients;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM patient WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", textBox8.Text);

                    int rows = cmd.ExecuteNonQuery();
                    MessageBox.Show(rows > 0 ? "Patient deleted successfully." : "Delete failed.");
                    FetchTableData("patient");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting patient: " + ex.Message);
                }
            }
        }


        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }



        public UserControl4()
        {
            InitializeComponent();
            MakeRoundedPanel(panel1, 10);
            MakeRoundedPanel(panel2, 10);
            MakeRoundedPanel(panel3, 10);
            FetchTableData("patient");
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdatePatient();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeletePatient();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddPatient();

        }
    }

}