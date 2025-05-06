using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class UserControl3 : UserControl
    {

        private Doctor[] doctors = new Doctor[100];
        private int count = 0;

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

        private void LoadDoctorsFromFile()
        {
            try
            {
                if (!File.Exists("doctors.txt")) return;

                string[] lines = File.ReadAllLines("doctors.txt");
                count = 0;

                foreach (string line in lines)
                {
                    try
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length == 9)
                        {
                            Doctor dr = new Doctor(
                                int.Parse(parts[0]),
                                parts[1],
                                parts[2],
                                int.Parse(parts[3]),
                                (Gender_doc)Enum.Parse(typeof(Gender_doc), parts[4]),
                                parts[5],
                                parts[6],
                                parts[7]
                            );

                            doctors[count++] = dr;
                        }
                        else
                        {
                            MessageBox.Show($"Skipping invalid line: {line}");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error parsing line: {line}\nException: {ex.Message}");
                    }
                }

                RefreshDoctorsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading data: " + ex.Message);
            }
        }

        private void RefreshDoctorsGrid()
        {
            dataGridViewOperations.DataSource = null;
            dataGridViewOperations.DataSource = doctors.Take(count).ToList();
        }

        private void ClearFields()
        {
            textBoxDoctorId.Clear();
            textBoxDoctorName.Clear();
            textBoxEmail.Clear();
            textBoxAge.Clear();
            cmbStatus.SelectedIndex = -1;
            textBoxSpecialization.Clear();
            textBoxHospitalAffiliation.Clear();
            textBoxQualifications.Clear();
        }

        private void SaveDoctorsToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("doctors.txt"))
                {
                    for (int i = 0; i < count; i++)
                    {
                        Doctor dr = doctors[i];
                        string line = $"{dr.Id},{dr.Name},{dr.Email},{dr.Age},{dr.Gender}" +
                                      $"{dr.Specialization},{dr.HospitalAffiliation},{dr.Qualifications}";
                        writer.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during save: " + ex.Message);
            }
        }

        public UserControl3()
        {
            InitializeComponent();
            MakeRoundedPanel(panel1, 10);
            MakeRoundedPanel(panel2, 10);
            MakeRoundedPanel(panel3, 10);
            LoadDoctorsFromFile();
            cmbStatus.DataSource = Enum.GetValues(typeof(Gender_doc));
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void panel2_Paint(object sender, PaintEventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void panel3_Paint(object sender, PaintEventArgs e) { }

        private void panel3_Paint_1(object sender, PaintEventArgs e) { }

        private void textBox7_TextChanged(object sender, EventArgs e) { }

        private void button4_Click(object sender, EventArgs e) // Add
        {
            try
            {
                Doctor dr = new Doctor(
                    int.Parse(textBoxDoctorId.Text),
                    textBoxDoctorName.Text,
                    textBoxEmail.Text,
                    int.Parse(textBoxAge.Text),
                    (Gender_doc)Enum.Parse(typeof(Gender_doc), cmbStatus.SelectedItem.ToString()),
                    textBoxSpecialization.Text,
                    textBoxHospitalAffiliation.Text,
                    textBoxQualifications.Text
                );

                doctors[count++] = dr;
                RefreshDoctorsGrid();
                SaveDoctorsToFile();
                MessageBox.Show("Doctor added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridViewOperations.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridViewOperations.SelectedRows[0].Index;
                for (int i = rowIndex; i < count - 1; i++)
                {
                    doctors[i] = doctors[i + 1];
                }
                doctors[count - 1] = null;
                count--;

                RefreshDoctorsGrid();
                SaveDoctorsToFile();
                MessageBox.Show("Doctor deleted successfully.");
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridViewOperations.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridViewOperations.SelectedRows[0].Index;

                try
                {
                    Doctor updatedDoctor = new Doctor(
                        int.Parse(textBoxDoctorId.Text),
                        textBoxDoctorName.Text,
                        textBoxEmail.Text,
                        int.Parse(textBoxAge.Text),
                        (Gender_doc)Enum.Parse(typeof(Gender_doc), cmbStatus.SelectedItem.ToString()),
                        textBoxSpecialization.Text,
                        textBoxHospitalAffiliation.Text,
                        textBoxQualifications.Text
                    );

                    doctors[rowIndex] = updatedDoctor;
                    RefreshDoctorsGrid();
                    SaveDoctorsToFile();
                    MessageBox.Show("Doctor updated successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to update.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e) { }
    }
}
