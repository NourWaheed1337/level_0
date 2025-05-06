using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class UserControl4 : UserControl
    {
        private Patient[] patients = new Patient[100];
        private int count = 0;

        public UserControl4()
        {
            InitializeComponent();
            MakeRoundedPanel(panel1, 10);
            MakeRoundedPanel(panel2, 10);
            MakeRoundedPanel(panel3, 10);

            cmbGender.DataSource = Enum.GetValues(typeof(Gender_pat));
            cmbStatus.DataSource = Enum.GetValues(typeof(OperationStatus));

            LoadPatientsFromFile();
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

        private void LoadPatientsFromFile()
        {
            try
            {
                if (!File.Exists("patients.txt")) return;

                string[] lines = File.ReadAllLines("patients.txt");
                count = 0;

                foreach (string line in lines)
                {
                    try
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length == 8)
                        {
                            Patient patient = new Patient(
                                int.Parse(parts[0]),
                                parts[1],
                                parts[2],
                                int.Parse(parts[3]),
                                (Gender_pat)Enum.Parse(typeof(Gender_pat), parts[4]),
                                parts[5],
                                parts[6],
                                parts[7]
                            );
                            patients[count++] = patient;
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

                RefreshPatientGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void SavePatientsToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("patients.txt"))
                {
                    for (int i = 0; i < count; i++)
                    {
                        Patient p = patients[i];
                        string line = $"{p.Id},{p.Name},{p.Email},{p.Age},{p.Gender},{p.TreatmentPlan},{p.Diagnosis},{p.InsuranceProvider}";
                        writer.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message);
            }
        }

        private void RefreshPatientGrid()
        {
            dataGridViewOperations.DataSource = null;
            dataGridViewOperations.DataSource = patients.Take(count).ToList();
        }

        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            cmbGender.SelectedIndex = -1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Patient patient = new Patient(
                    int.Parse(textBox8.Text),
                    textBox1.Text,
                    textBox2.Text,
                    int.Parse(textBox3.Text),
                    (Gender_pat)Enum.Parse(typeof(Gender_pat), cmbGender.SelectedItem.ToString()),
                    textBox7.Text,
                    textBox5.Text,
                    textBox6.Text
                );

                patients[count++] = patient;
                RefreshPatientGrid();
                SavePatientsToFile();
                MessageBox.Show("Patient added successfully.");
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridViewOperations.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridViewOperations.SelectedRows[0].Index;

                try
                {
                    Patient updated = new Patient(
                        int.Parse(textBox8.Text),
                        textBox1.Text,
                        textBox2.Text,
                        int.Parse(textBox3.Text),
                        (Gender_pat)Enum.Parse(typeof(Gender_pat), cmbGender.SelectedItem.ToString()),
                        textBox7.Text,
                        textBox5.Text,
                        textBox6.Text
                    );

                    patients[rowIndex] = updated;
                    RefreshPatientGrid();
                    SavePatientsToFile();
                    MessageBox.Show("Patient updated successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update failed: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Select a patient to update.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridViewOperations.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridViewOperations.SelectedRows[0].Index;

                for (int i = rowIndex; i < count - 1; i++)
                {
                    patients[i] = patients[i + 1];
                }

                patients[--count] = null;

                RefreshPatientGrid();
                SavePatientsToFile();
                MessageBox.Show("Patient deleted.");
            }
            else
            {
                MessageBox.Show("Select a patient to delete.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

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
    }
}
