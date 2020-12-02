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
    public partial class Profile : Form
    {
        public interface ProfileClosing
        {
            void CheckClosing(bool check);
        }
        ProfileClosing profileClosing;
        public Profile(Form form)
        {
            InitializeComponent();
            profileClosing = (ProfileClosing)form;
        }

        private void Profile_FormClosing(object sender, FormClosingEventArgs e)
        {
            profileClosing.CheckClosing(true);
        }
    }
}
