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
    public partial class Department : Form
    {
        DepartmentBUS departmentBUS;
        DepartmentBUS.Key key;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeDataGridView();
        }
    }
}
