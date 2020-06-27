namespace Client
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAttendance = new System.Windows.Forms.Button();
            this.btnTaiKhoan = new System.Windows.Forms.Button();
            this.btnSalary = new System.Windows.Forms.Button();
            this.btnBoPhan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAttendance
            // 
            this.btnAttendance.Location = new System.Drawing.Point(233, 107);
            this.btnAttendance.Margin = new System.Windows.Forms.Padding(2);
            this.btnAttendance.Name = "btnAttendance";
            this.btnAttendance.Size = new System.Drawing.Size(130, 45);
            this.btnAttendance.TabIndex = 3;
            this.btnAttendance.Text = "Lịch sử sử dụng";
            this.btnAttendance.UseVisualStyleBackColor = true;
            this.btnAttendance.Click += new System.EventHandler(this.btnAttendance_Click);
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.Location = new System.Drawing.Point(233, 33);
            this.btnTaiKhoan.Margin = new System.Windows.Forms.Padding(2);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(130, 45);
            this.btnTaiKhoan.TabIndex = 1;
            this.btnTaiKhoan.Text = "Quản lý tài khoản";
            this.btnTaiKhoan.UseVisualStyleBackColor = true;
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);
            // 
            // btnSalary
            // 
            this.btnSalary.Location = new System.Drawing.Point(41, 107);
            this.btnSalary.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalary.Name = "btnSalary";
            this.btnSalary.Size = new System.Drawing.Size(130, 45);
            this.btnSalary.TabIndex = 2;
            this.btnSalary.Text = "Quản lý lương";
            this.btnSalary.UseVisualStyleBackColor = true;
            this.btnSalary.Click += new System.EventHandler(this.btnSalary_Click);
            // 
            // btnBoPhan
            // 
            this.btnBoPhan.Location = new System.Drawing.Point(41, 33);
            this.btnBoPhan.Margin = new System.Windows.Forms.Padding(2);
            this.btnBoPhan.Name = "btnBoPhan";
            this.btnBoPhan.Size = new System.Drawing.Size(130, 45);
            this.btnBoPhan.TabIndex = 0;
            this.btnBoPhan.Text = "Quản lý nhân viên";
            this.btnBoPhan.UseVisualStyleBackColor = true;
            this.btnBoPhan.Click += new System.EventHandler(this.btnBoPhan_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 193);
            this.Controls.Add(this.btnAttendance);
            this.Controls.Add(this.btnTaiKhoan);
            this.Controls.Add(this.btnSalary);
            this.Controls.Add(this.btnBoPhan);
            this.Name = "Form1";
            this.Text = "Hệ thống quản lý nhân sự";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAttendance;
        private System.Windows.Forms.Button btnTaiKhoan;
        private System.Windows.Forms.Button btnSalary;
        private System.Windows.Forms.Button btnBoPhan;
    }
}

