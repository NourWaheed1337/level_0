using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class UserControl5 : UserControl
    {
        private Operation[] operations = new Operation[100];
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

        private void RefreshOperationGrid()
        {
            dataGridViewOperations.DataSource = null;
            dataGridViewOperations.DataSource = operations.Take(count).ToList();
        }

        private void ClearFields()
        {
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }

        private void SaveOperationsToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"files\operations.txt"))
                {
                    for (int i = 0; i < count; i++)
                    {
                        Operation op = operations[i];
                        string line = $"{op.Id},{op.OperationName},{op.Department},{op.ScheduledBy}," +
                                      $"{op.OperationDate:yyyy-MM-dd},{op.DurationMinutes}," +
                                      $"{op.PatientId},{op.SurgeonName},{op.Status},{op.Notes}";
                        writer.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during auto-save: " + ex.Message);
            }
        }

        private void LoadOperationsFromFile()
        {
            try
            {
                if (!File.Exists(@"files\operations.txt")) return;

                string[] lines = File.ReadAllLines(@"files\operations.txt");
                count = 0;

                foreach (string line in lines)
                {
                    try
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length == 10)
                        {
                            Operation op = new Operation(
                                int.Parse(parts[0]),
                                parts[1],
                                parts[2],
                                parts[3],
                                DateTime.Parse(parts[4]),
                                int.Parse(parts[5]),
                                int.Parse(parts[6]),
                                parts[7],
                                (OperationStatus)Enum.Parse(typeof(OperationStatus), parts[8]),
                                parts[9]
                            );

                            operations[count++] = op;
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

                RefreshOperationGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading data: " + ex.Message);
            }
        }


        public UserControl5()
        {
            InitializeComponent();
            cmbStatus.DataSource = Enum.GetValues(typeof(OperationStatus));
            MakeRoundedPanel(panel2, 10);
            MakeRoundedPanel(panel3, 10);
            LoadOperationsFromFile();
        }

        private void panel3_Paint(object sender, PaintEventArgs e) { }

        private void label6_Click(object sender, EventArgs e) { }

        private void panel4_Paint(object sender, PaintEventArgs e) { }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Operation op = new Operation(
                    int.Parse(textBox7.Text),
                    textBox6.Text,
                    textBox5.Text,
                    textBox3.Text,
                    dateTimePicker1.Value,
                    int.Parse(textBox1.Text),
                    int.Parse(textBox10.Text),
                    textBox9.Text,
                    (OperationStatus)cmbStatus.SelectedItem,
                    textBox8.Text
                );

                operations[count++] = op;
                RefreshOperationGrid();
                SaveOperationsToFile();
                MessageBox.Show("Operation added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridViewOperations.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridViewOperations.SelectedRows[0].Index;
                for (int i = rowIndex; i < count - 1; i++)
                {
                    operations[i] = operations[i + 1];
                }
                operations[count - 1] = null;
                count--;

                RefreshOperationGrid();
                MessageBox.Show("Operation deleted successfully.");
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
                    Operation updatedOp = new Operation(
                        int.Parse(textBox7.Text),
                        textBox6.Text,
                        textBox5.Text,
                        textBox3.Text,
                        dateTimePicker1.Value,
                        int.Parse(textBox1.Text),
                        int.Parse(textBox10.Text),
                        textBox9.Text,
                        (OperationStatus)cmbStatus.SelectedItem,
                        textBox8.Text
                    );

                    operations[rowIndex] = updatedOp;
                    RefreshOperationGrid();
                    MessageBox.Show("Data updated successfully.");
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
            SaveOperationsToFile();
        }
    }
}
