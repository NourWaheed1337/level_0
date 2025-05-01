using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void btnSaveInfo_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string email = textBox3.Text;

            string filePath = @"files\user_info.txt";

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                string userLine = $"{username},{password},{email}\n";
                File.AppendAllText(filePath, userLine + Environment.NewLine);
                MessageBox.Show("User info saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving user info:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnSaveInfo_Click(sender, e);
        }
    }
}
