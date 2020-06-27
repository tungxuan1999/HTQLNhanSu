using Client.BL;
using Client.Data;
using Client.Interface;
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
    public partial class Login : Form, ILoginInterface
    {
        Form1 f;
        public static Login login;
        public Login()
        {
            InitializeComponent();
            login = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String token = new AccountBUS().LoginAccount(new AccountBUS.Account(textBox1.Text, textBox2.Text));
            if (token != "")
            {
                DataStatic.token = token;
                DataStatic.user = textBox1.Text;
                Hide();
                f = new Form1();
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowDialog();
                Close();
            }
        }

        public void CheckLogout(bool check)
        {
            if (check)
            {
                MessageBox.Show("Tài khoản đang đăng nhập ở nơi khác");
                Application.Exit();
            }
        }
    }
}
