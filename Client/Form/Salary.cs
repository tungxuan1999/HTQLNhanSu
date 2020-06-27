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
    public partial class Salary : Form
    {
        List<String> listKey;
        public Salary()
        {
            InitializeComponent();
        }

        private void Salary_Load(object sender, EventArgs e)
        {
            listKey = new List<string>();
            listKey.Add("Tất cả");
            listKey.AddRange(new SalaryBUS().GetKey());
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.DataSource = listKey;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangedDataGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangedDataGridView();
        }

        private void ChangedDataGridView()
        {
            if (comboBox1.SelectedIndex == 0)
            {
                if (textBox1.Text == "")
                {
                    dataGridView1.DataSource = new SalaryBUS().SelectALLPayment(DataStatic.user, DataStatic.token);
                }
                else
                {
                    dataGridView1.DataSource = new SalaryBUS().SelectByName(DataStatic.user, DataStatic.token, textBox1.Text);
                }
            }
            else
            {
                if (textBox1.Text == "")
                {
                    dataGridView1.DataSource = new SalaryBUS().SelectByPosition(DataStatic.user, DataStatic.token, listKey[comboBox1.SelectedIndex]);
                }
                else
                {
                    dataGridView1.DataSource = new SalaryBUS().SelectByPositionName(DataStatic.user, DataStatic.token, listKey[comboBox1.SelectedIndex], textBox1.Text);
                }
            }
        }
    }
}
