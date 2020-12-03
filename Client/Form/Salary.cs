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
    public partial class Salary : Form, Profile.ProfileClosing
    {
        Profile profile;
        SalaryBUS salaryBUS;
        List<String> listKey;
        public Salary()
        {
            InitializeComponent();
            salaryBUS = new SalaryBUS();
        }

        private void Salary_Load(object sender, EventArgs e)
        {
            listKey = new List<string>();
            listKey.Add("Tất cả");
            listKey.AddRange(new DepartmentBUS().GetKey().LISTposition);
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
            ShowDetail();
        }

        private void ShowDetail()
        {
            textBox2.DataBindings.Clear();
            textBox2.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "ID", true, DataSourceUpdateMode.Never));
            textBox3.DataBindings.Clear();
            textBox3.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Name", true, DataSourceUpdateMode.Never));
            textBox4.DataBindings.Clear();
            textBox4.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Position", true, DataSourceUpdateMode.Never));
            textBox5.DataBindings.Clear();
            textBox5.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Workingdays", true, DataSourceUpdateMode.Never));
            textBox6.DataBindings.Clear();
            textBox6.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Bonus", true, DataSourceUpdateMode.Never));
            textBox7.DataBindings.Clear();
            textBox7.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Salary", true, DataSourceUpdateMode.Never));
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SalaryBUS.payment updateSalary = new SalaryBUS.payment()
            {
                ID = textBox2.Text,
                Name = textBox3.Text,
                Position = textBox4.Text,
                Workingdays = int.Parse(textBox5.Text),
                Bonus = int.Parse(textBox6.Text),
                Salary = int.Parse(textBox7.Text)
            };
            bool result = salaryBUS.Update(new SalaryBUS.FilePut(DataStatic.user, DataStatic.token, updateSalary));
            if (result)
            {
                MessageBox.Show("Cập nhật thành công");
                ChangedDataGridView();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
        }

        private void btProfile_Click(object sender, EventArgs e)
        {
            if (profile == null)
            {
                if (textBox2.Text != "")
                {
                    profile = new Profile(this, textBox2.Text);
                    //profile.StartPosition = FormStartPosition.CenterParent;
                    profile.Show();
                    profile.Location = new Point(this.Left + this.Width, this.Top);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn item");
                }
            }
        }

        private void Salary_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (profile != null)
                profile.Close();
        }

        public void CheckClosing(bool check)
        {
            if(check)
            {
                profile = null;
            }
        }
    }
}
