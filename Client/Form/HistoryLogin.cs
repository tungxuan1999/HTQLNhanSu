using Client.BL;
using Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class HistoryLogin : Form
    {
        public HistoryLogin()
        {
            InitializeComponent();
        }

        private void HistoryLogin_Load(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            string Date = date.ToString("dd:MM:yyyy");
            textBox1.Text = DataStatic.user;
            textBox2.Text = date.ToString("dd");
            textBox3.Text = date.ToString("MM");
            textBox4.Text = date.ToString("yyyy");
            richTextBox1.Text = new FirebaseBUS().GetHistoyDate(textBox1.Text,Date).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(CheckNull())
            {
                String date = String.Format("{0}:{1}:{2}", textBox2.Text, textBox3.Text, textBox4.Text);
                richTextBox1.Text = new FirebaseBUS().GetHistoyDate(textBox1.Text, date).ToString();
            }
        }

        private bool CheckNull()
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("USER chưa có giá trị");
                return false;
            }

            if(textBox2.Text == "")
            {
                MessageBox.Show("Ngày chưa có giá trị");
                return false;
            }

            if(textBox3.Text == "")
            {
                MessageBox.Show("Tháng chưa có giá trị");
                return false;
            }

            if(textBox4.Text == "")
            {
                MessageBox.Show("Năm chưa có giá trị");
                return false;
            }

            return true;
        }
    }
}
