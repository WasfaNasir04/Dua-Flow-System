
namespace Dura_Flow_System
{
    partial class staffManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(staffManage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Leaves = new System.Windows.Forms.Button();
            this.Attendance = new System.Windows.Forms.Button();
            this.EmployeeRegister = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.mainpanel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.mainpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.Leaves);
            this.panel1.Controls.Add(this.Attendance);
            this.panel1.Controls.Add(this.EmployeeRegister);
            this.panel1.Controls.Add(this.panelLogo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 622);
            this.panel1.TabIndex = 0;
            // 
            // Leaves
            // 
            this.Leaves.BackColor = System.Drawing.Color.SteelBlue;
            this.Leaves.Dock = System.Windows.Forms.DockStyle.Top;
            this.Leaves.FlatAppearance.BorderSize = 0;
            this.Leaves.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Leaves.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Leaves.ForeColor = System.Drawing.Color.White;
            this.Leaves.Image = ((System.Drawing.Image)(resources.GetObject("Leaves.Image")));
            this.Leaves.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Leaves.Location = new System.Drawing.Point(0, 300);
            this.Leaves.Name = "Leaves";
            this.Leaves.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.Leaves.Size = new System.Drawing.Size(250, 100);
            this.Leaves.TabIndex = 2;
            this.Leaves.Text = "   Leaves";
            this.Leaves.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Leaves.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Leaves.UseVisualStyleBackColor = false;
            this.Leaves.Click += new System.EventHandler(this.GRN_Click);
            // 
            // Attendance
            // 
            this.Attendance.BackColor = System.Drawing.Color.SteelBlue;
            this.Attendance.Dock = System.Windows.Forms.DockStyle.Top;
            this.Attendance.FlatAppearance.BorderSize = 0;
            this.Attendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Attendance.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Attendance.ForeColor = System.Drawing.Color.White;
            this.Attendance.Image = ((System.Drawing.Image)(resources.GetObject("Attendance.Image")));
            this.Attendance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Attendance.Location = new System.Drawing.Point(0, 200);
            this.Attendance.Name = "Attendance";
            this.Attendance.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.Attendance.Size = new System.Drawing.Size(250, 100);
            this.Attendance.TabIndex = 1;
            this.Attendance.Text = "    Attendance";
            this.Attendance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Attendance.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Attendance.UseVisualStyleBackColor = false;
            this.Attendance.Click += new System.EventHandler(this.production_Click);
            // 
            // EmployeeRegister
            // 
            this.EmployeeRegister.BackColor = System.Drawing.Color.SteelBlue;
            this.EmployeeRegister.Dock = System.Windows.Forms.DockStyle.Top;
            this.EmployeeRegister.FlatAppearance.BorderSize = 0;
            this.EmployeeRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EmployeeRegister.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmployeeRegister.ForeColor = System.Drawing.Color.White;
            this.EmployeeRegister.Image = ((System.Drawing.Image)(resources.GetObject("EmployeeRegister.Image")));
            this.EmployeeRegister.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EmployeeRegister.Location = new System.Drawing.Point(0, 100);
            this.EmployeeRegister.Name = "EmployeeRegister";
            this.EmployeeRegister.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.EmployeeRegister.Size = new System.Drawing.Size(250, 100);
            this.EmployeeRegister.TabIndex = 0;
            this.EmployeeRegister.Text = "    Employee \r\n    Registration";
            this.EmployeeRegister.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EmployeeRegister.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EmployeeRegister.UseVisualStyleBackColor = false;
            this.EmployeeRegister.Click += new System.EventHandler(this.stock_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.White;
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(250, 100);
            this.panelLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(36, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(250, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(771, 100);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bookman Old Style", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Ivory;
            this.label1.Location = new System.Drawing.Point(177, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(390, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "    STAFF MANAGEMENT";
            // 
            // mainpanel
            // 
            this.mainpanel.Controls.Add(this.pictureBox2);
            this.mainpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainpanel.Location = new System.Drawing.Point(250, 100);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(771, 522);
            this.mainpanel.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(771, 522);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // staffManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 622);
            this.Controls.Add(this.mainpanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "staffManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StaffManage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.dashboard_FormClosing);
            this.Load += new System.EventHandler(this.StockManage_Load);
            this.panel1.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.mainpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Leaves;
        private System.Windows.Forms.Button Attendance;
        private System.Windows.Forms.Button EmployeeRegister;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel mainpanel;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}