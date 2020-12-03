using Client.BL;
using Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Profile : Form
    {
        FirebaseBUS firebaseBUS;
        String id;
        public interface ProfileClosing
        {
            void CheckClosing(bool check);
        }
        ProfileClosing profileClosing;
        public Profile(Form form, String id)
        {
            InitializeComponent();
            profileClosing = (ProfileClosing)form;
            firebaseBUS = new FirebaseBUS();
            this.id = id;
        }

        private void Profile_FormClosing(object sender, FormClosingEventArgs e)
        {
            profileClosing.CheckClosing(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //To where your opendialog box get starting location. My initial directory location is desktop.
            openFileDialog1.InitialDirectory = "C://Desktop";
            //Your opendialog box title name.
            openFileDialog1.Title = "Select image to be upload.";
            //which type image format you want to upload in database. just add them.
            openFileDialog1.Filter = "Image Only(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            //FilterIndex property represents the index of the filter currently selected in the file dialog box.
            openFileDialog1.FilterIndex = 1;
            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                        //label1.Text = path;fire
                        pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload image.");
                }
            }
            catch (Exception ex)
            {
                //it will give if file is already exits..
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, ImageFormat.Jpeg);

                byte[] aa = ms.GetBuffer();

                String bb = Convert.ToBase64String(aa);

                MessageBox.Show(new AccountBUS().PostImage(new AccountBUS.ImageChange { id = this.id, imagebitmap = bb, token = DataStatic.token, username = DataStatic.user }));
                //firebaseBUS.UploadImage(bb, "default");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hình ảnh");
            }
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            String imagebitmap = new AccountBUS().GetImage(new AccountBUS.ImageChange { id = this.id, imagebitmap = "", token = DataStatic.token, username = DataStatic.user });
            if (imagebitmap != null)
            {
                imagebitmap = imagebitmap.Remove(imagebitmap.Length - 1, 1).Remove(0, 1);
                byte[] imageBytes = Convert.FromBase64String(imagebitmap);
                //Console.WriteLine(imagebitmap);
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    pictureBox1.Image = Image.FromStream(ms);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }
    }
}
