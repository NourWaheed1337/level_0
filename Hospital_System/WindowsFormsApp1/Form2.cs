using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        private List<Operation> operations = new List<Operation>();

        public Form2()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
            userControl31.Hide();
            userControl41.Hide();
            userControl51.Hide();
            userControl61.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userControl21.Hide();
            userControl31.Show();
            userControl41.Hide();
            userControl51.Hide();
            userControl61.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userControl31.Hide();
            userControl21.Show();
            userControl41.Hide();
            userControl51.Hide();
            userControl61.Hide();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            userControl31.Hide();
            userControl21.Hide();
            userControl41.Show();
            userControl51.Hide();
            userControl61.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            userControl31.Hide();
            userControl21.Hide();
            userControl41.Hide();
            userControl51.Show();
            userControl61.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            userControl31.Hide();
            userControl21.Hide();
            userControl41.Hide();
            userControl51.Hide();
            userControl61.Show();
        }
    }
}
