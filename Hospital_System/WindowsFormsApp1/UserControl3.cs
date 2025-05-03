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

namespace WindowsFormsApp1
{
    public partial class UserControl3 : UserControl
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
        private void AddDoctor()
        {
            string connectionString = "Data Source=.;Initial Catalog=data_patients;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO doctor 
                             (id, name, email, age, gender, specialization, qualifications, hospital_affiliation, joined_on) 
                             VALUES 
                             (@id, @name, @email, @age, @gender, @specialization, @qualifications, @hospital_affiliation, @joined_on)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", textBox7.Text);
                    cmd.Parameters.AddWithValue("@name", textBox8.Text);
                    cmd.Parameters.AddWithValue("@email", textBox2.Text);
                    cmd.Parameters.AddWithValue("@age", textBox1.Text);
                    cmd.Parameters.AddWithValue("@gender", textBox3.Text);
                    cmd.Parameters.AddWithValue("@specialization", textBox6.Text);
                    cmd.Parameters.AddWithValue("@qualifications", textBox4.Text);
                    cmd.Parameters.AddWithValue("@hospital_affiliation", textBox5.Text);
                    cmd.Parameters.AddWithValue("@joined_on", dateTimePicker1.Value);

                    int rows = cmd.ExecuteNonQuery();
                    MessageBox.Show(rows > 0 ? "Doctor added successfully." : "Insert failed.");
                    FetchTableData("doctor");
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding doctor: " + ex.Message);
                }
            }
        }
        private void DeleteDoctor()
        {
            string connectionString = "Data Source=.;Initial Catalog=data_patients;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM doctor WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", textBox8.Text);

                    int rows = cmd.ExecuteNonQuery();
                    MessageBox.Show(rows > 0 ? "Doctor deleted successfully." : "Delete failed.");
                    FetchTableData("doctor");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting doctor: " + ex.Message);
                }
            }
        }
        private void UpdateDoctor()
        {
            string connectionString = "Data Source=.;Initial Catalog=data_patients;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE doctor SET 
                             name = @name, 
                             email = @email, 
                             age = @age, 
                             gender = @gender, 
                             specialization = @specialization,
                             qualifications = @qualifications,
                             hospital_affiliation = @hospital_affiliation,
                             joined_on = @joined_on
                             WHERE id = @id";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@id", textBox7.Text);                      // Doctor ID
                    cmd.Parameters.AddWithValue("@name", textBox8.Text);                    // Doctor Name
                    cmd.Parameters.AddWithValue("@email", textBox2.Text);                   // Email
                    cmd.Parameters.AddWithValue("@age", textBox1.Text);                     // Age
                    cmd.Parameters.AddWithValue("@gender", textBox3.Text);                  // Gender
                    cmd.Parameters.AddWithValue("@specialization", textBox6.Text); 
                    cmd.Parameters.AddWithValue("@qualifications", textBox4.Text);
                    cmd.Parameters.AddWithValue("@hospital_affiliation", textBox5.Text);
                    cmd.Parameters.AddWithValue("@joined_on", dateTimePicker1.Value); 

                    int rows = cmd.ExecuteNonQuery();
                    MessageBox.Show(rows > 0 ? "Doctor updated successfully." : "Update failed.");
                    FetchTableData("doctor");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating doctor: " + ex.Message);
                }
            }
        }


        private void ClearFields()
        {
            throw new NotImplementedException();
        }

        private void ClearFields_2(){
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }

        public UserControl3()
        {
            InitializeComponent();
            MakeRoundedPanel(panel1, 10);
            MakeRoundedPanel(panel2, 10);
            MakeRoundedPanel(panel3, 10);
            FetchTableData("doctor");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddDoctor();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteDoctor();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateDoctor();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearFields_2();
        }
    }
}
