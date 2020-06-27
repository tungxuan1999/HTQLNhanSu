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
    public partial class Account : Form
    {
        AccountBUS accountBUS;
        List<String> listKey;
        public Account()
        {
            InitializeComponent();
            accountBUS = new AccountBUS();
        }

        private void Account_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            listKey = new List<string>();
            listKey.Add("Tất cả");
            listKey.AddRange(accountBUS.GetKey());

            comboBox1.DataSource = listKey;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataGridViewChanged();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridViewChanged();
        }

        private void DataGridViewChanged()
        {
            if(comboBox1.SelectedIndex == 0)
            {
                if(textBox1.Text == "")
                {
                    dataGridView1.DataSource = accountBUS.GETALL(DataStatic.user,DataStatic.token);
                }
                else
                {
                    dataGridView1.DataSource = accountBUS.SelectByName(DataStatic.user, DataStatic.token, textBox1.Text);
                }
            }
            else
            {
                if (textBox1.Text == "")
                {
                    dataGridView1.DataSource = accountBUS.SelectByPermisstion(DataStatic.user, DataStatic.token,listKey[comboBox1.SelectedIndex]);
                }
                else
                {
                    dataGridView1.DataSource = accountBUS.SelectByPermisstionName(DataStatic.user, DataStatic.token, listKey[comboBox1.SelectedIndex], textBox1.Text);
                }
            }
        }
    }
}
