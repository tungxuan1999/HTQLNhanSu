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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new FirebaseBUS().ListenFirebaseToken();
        }

        private void btnBoPhan_Click(object sender, EventArgs e)
        {
            Department department = new Department();
            department.StartPosition = FormStartPosition.CenterParent;
            department.ShowDialog();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            account.StartPosition = FormStartPosition.CenterParent;
            account.ShowDialog();
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            HistoryLogin historyLogin = new HistoryLogin();
            historyLogin.StartPosition = FormStartPosition.CenterParent;
            historyLogin.ShowDialog();
        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
            Salary salary = new Salary();
            salary.StartPosition = FormStartPosition.CenterParent;
            salary.ShowDialog();
        }
    }
}
