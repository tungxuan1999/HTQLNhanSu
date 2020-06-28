using Client.BL;
using Client.Data;
using FireSharp.Extensions;
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
            ShowDetail();
        }

        private void ShowDetail()
        {
            textBox2.DataBindings.Clear();
            textBox2.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "ID", true, DataSourceUpdateMode.Never));
            textBox3.DataBindings.Clear();
            textBox3.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "username", true, DataSourceUpdateMode.Never));
            textBox5.DataBindings.Clear();
            textBox5.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "permisstion", true, DataSourceUpdateMode.Never));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AccountBUS.USERLOGIN newAccount = new AccountBUS.USERLOGIN()
            {
                ID=textBox2.Text,
                username=textBox3.Text,
                password=textBox4.Text,
                permission = textBox5.Text
            };
            bool result = accountBUS.Insert(new AccountBUS.TokenChange(newAccount, DataStatic.user, DataStatic.token));
            if (result)
            {
                MessageBox.Show("Registration Success");
                DataGridViewChanged();
            }
            else
            {
                MessageBox.Show("Registration Fail");
                DataGridViewChanged();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AccountBUS.USERLOGIN updateAccount = new AccountBUS.USERLOGIN()
            {
                ID = textBox2.Text,
                username = textBox3.Text,
                password = textBox4.Text,
                permission = textBox5.Text
            };
            bool result = accountBUS.Update(new AccountBUS.TokenChange(updateAccount, DataStatic.user, DataStatic.token));
            if (result)
            {
                MessageBox.Show("Update Success");
                DataGridViewChanged();
            }
            else
            {
                MessageBox.Show("Update Fail");
                DataGridViewChanged();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Delete?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                AccountBUS.USERLOGIN deleteAccount = new AccountBUS.USERLOGIN()
                {
                    ID = textBox2.Text,
                    username = textBox3.Text,
                    password = textBox4.Text,
                    permission = textBox5.Text
                };
                bool result = accountBUS.Delete(new AccountBUS.TokenChange(deleteAccount, DataStatic.user, DataStatic.token));
                if (result)
                {
                    MessageBox.Show("Delete Account Success");
                    DataGridViewChanged();
                }
                else
                {
                    MessageBox.Show("Delete Fail");
                    DataGridViewChanged();
                }
            }
            else
            {
                DataGridViewChanged();
            }
        }
    }
}
