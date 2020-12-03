using Client.BL;
using Client.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Department : Form, Profile.ProfileClosing
    {
        DepartmentBUS departmentBUS;
        DepartmentBUS.Key key;
        Profile profile;

        public Department()
        {
            InitializeComponent();
            departmentBUS = new DepartmentBUS();
        }

        private void Department_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = departmentBUS.SelectALL(DataStatic.user,DataStatic.token);
            key = departmentBUS.GetKey();
            List<String> listKey = new List<string>();
            listKey.Add("Tất cả");
            listKey.AddRange(key.LISTdepartment);

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.DataSource = listKey;
            ShowDetail();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeDataGridView();
        }

        private void ChangeDataGridView()
        {
            if (comboBox1.SelectedIndex == 0)
            {
                if (textBox1.Text == "")
                {
                    dataGridView1.DataSource = departmentBUS.SelectALL(DataStatic.user, DataStatic.token);
                }
                else
                {
                    dataGridView1.DataSource = departmentBUS.SelectALLByName(DataStatic.user, DataStatic.token, textBox1.Text);
                }
            }
            else
            {
                if (textBox1.Text == "")
                {
                    dataGridView1.DataSource = departmentBUS.SelectByDepartment(DataStatic.user, DataStatic.token, key.LISTdepartment[comboBox1.SelectedIndex - 1]);
                }
                else
                {
                    dataGridView1.DataSource = departmentBUS.SelectByDepartmentName(DataStatic.user, DataStatic.token, key.LISTdepartment[comboBox1.SelectedIndex - 1], textBox1.Text);
                }
            }
            ShowDetail();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeDataGridView();
        }

        private void ShowDetail()
        {
            textBox2.DataBindings.Clear();
            textBox2.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "ID", true, DataSourceUpdateMode.Never));
            textBox3.DataBindings.Clear();
            textBox3.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Name", true, DataSourceUpdateMode.Never));
            textBox4.DataBindings.Clear();
            textBox4.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Address", true, DataSourceUpdateMode.Never));
            textBox5.DataBindings.Clear();
            textBox5.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Email", true, DataSourceUpdateMode.Never));
            comboBox2.DataBindings.Clear();
            comboBox2.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Position", true, DataSourceUpdateMode.Never));
            comboBox3.DataBindings.Clear();
            comboBox3.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Department", true, DataSourceUpdateMode.Never));
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DepartmentBUS.Employee newEmployee = new DepartmentBUS.Employee(textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, comboBox2.Text.ToString(), comboBox3.Text.ToString());
            bool result = departmentBUS.Insert(new DepartmentBUS.FilePut(newEmployee, DataStatic.user, DataStatic.token));
            if (result)
            {
                MessageBox.Show("Thêm thành công");
                ChangeDataGridView();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DepartmentBUS.Employee updateEmployee = new DepartmentBUS.Employee(textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, comboBox2.Text.ToString(), comboBox3.Text.ToString());
            bool result = departmentBUS.Update(new DepartmentBUS.FilePut(updateEmployee, DataStatic.user, DataStatic.token));
            if (result)
            {
                MessageBox.Show("Cập nhật thành công");
                ChangeDataGridView();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc xóa không", "Xóa?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DepartmentBUS.Employee deleteEmployee = new DepartmentBUS.Employee(textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, comboBox2.Text.ToString(), comboBox3.Text.ToString());
                bool result = departmentBUS.Delete(new DepartmentBUS.FilePut(deleteEmployee, DataStatic.user, DataStatic.token));
                if (result)
                {
                    MessageBox.Show("Xóa thành công");
                    ChangeDataGridView();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại");
                }
            }
            else
            {
                ChangeDataGridView();
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

        private void Department_FormClosing(object sender, FormClosingEventArgs e)
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
