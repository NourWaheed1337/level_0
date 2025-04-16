using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class form_main : Form
    {
            int doctors;
            int rooms;
            int workers;
            int patients;
        public form_main()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            LoadHospitalData();
        }

        private void form_main_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form form_main = new Form1();
            this.Hide();
            form_main.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void LoadHospitalData()
        {
            string filePath = "hospital_data.txt";

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);

                foreach (var line in lines)
                {
                    var parts = line.Split('=');
                    if (parts.Length == 2 && int.TryParse(parts[1], out int value))
                    {
                        switch (parts[0])
                        {
                            case "Doctors":
                                doctors = value;
                                break;
                            case "Rooms":
                                rooms = value;
                                break;
                            case "Workers":
                                workers = value;
                                break;
                            case "Patients":
                                patients = value;
                                break;
                        }
                    }
                }

                lblDoctors.Text = $"{doctors}";
                lblRooms.Text = $"{rooms}";
                lblWorkers.Text = $"{workers}";
                lbPatients.Text = $"{patients}";
            }
            else
            {
                MessageBox.Show("i can't see any files .");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lbPatients_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }

}