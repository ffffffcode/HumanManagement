namespace HumanManagementSQLServer
{
    partial class AddOrModEmpForm
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
            this.dtpEntryTime = new System.Windows.Forms.DateTimePicker();
            this.btnCannel = new System.Windows.Forms.Button();
            this.btnComfirm = new System.Windows.Forms.Button();
            this.labEntryTime = new System.Windows.Forms.Label();
            this.txtBirthplace = new System.Windows.Forms.TextBox();
            this.labBirthplace = new System.Windows.Forms.Label();
            this.txtBirthday = new System.Windows.Forms.TextBox();
            this.labBirthday = new System.Windows.Forms.Label();
            this.txtIdCardNo = new System.Windows.Forms.TextBox();
            this.labIdCardNo = new System.Windows.Forms.Label();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.labEmployeeName = new System.Windows.Forms.Label();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.labNo = new System.Windows.Forms.Label();
            this.txtDeptName = new System.Windows.Forms.TextBox();
            this.labDeptName = new System.Windows.Forms.Label();
            this.txtDeptNo = new System.Windows.Forms.TextBox();
            this.labDeptNo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpEntryTime
            // 
            this.dtpEntryTime.CustomFormat = "yyyy-MM-dd";
            this.dtpEntryTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEntryTime.Location = new System.Drawing.Point(484, 138);
            this.dtpEntryTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpEntryTime.Name = "dtpEntryTime";
            this.dtpEntryTime.Size = new System.Drawing.Size(223, 28);
            this.dtpEntryTime.TabIndex = 15;
            // 
            // btnCannel
            // 
            this.btnCannel.Location = new System.Drawing.Point(381, 190);
            this.btnCannel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCannel.Name = "btnCannel";
            this.btnCannel.Size = new System.Drawing.Size(112, 34);
            this.btnCannel.TabIndex = 17;
            this.btnCannel.Text = "取消";
            this.btnCannel.UseVisualStyleBackColor = true;
            this.btnCannel.Click += new System.EventHandler(this.btnCannel_Click);
            // 
            // btnComfirm
            // 
            this.btnComfirm.Location = new System.Drawing.Point(224, 190);
            this.btnComfirm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnComfirm.Name = "btnComfirm";
            this.btnComfirm.Size = new System.Drawing.Size(112, 34);
            this.btnComfirm.TabIndex = 16;
            this.btnComfirm.Text = "确定";
            this.btnComfirm.UseVisualStyleBackColor = true;
            this.btnComfirm.Click += new System.EventHandler(this.btnComfirm_Click);
            // 
            // labEntryTime
            // 
            this.labEntryTime.AutoSize = true;
            this.labEntryTime.Location = new System.Drawing.Point(378, 144);
            this.labEntryTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labEntryTime.Name = "labEntryTime";
            this.labEntryTime.Size = new System.Drawing.Size(98, 18);
            this.labEntryTime.TabIndex = 14;
            this.labEntryTime.Text = "入场时间：";
            // 
            // txtBirthplace
            // 
            this.txtBirthplace.Location = new System.Drawing.Point(123, 140);
            this.txtBirthplace.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBirthplace.Name = "txtBirthplace";
            this.txtBirthplace.Size = new System.Drawing.Size(223, 28);
            this.txtBirthplace.TabIndex = 13;
            // 
            // labBirthplace
            // 
            this.labBirthplace.AutoSize = true;
            this.labBirthplace.Location = new System.Drawing.Point(52, 144);
            this.labBirthplace.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labBirthplace.Name = "labBirthplace";
            this.labBirthplace.Size = new System.Drawing.Size(62, 18);
            this.labBirthplace.TabIndex = 12;
            this.labBirthplace.Text = "籍贯：";
            // 
            // txtBirthday
            // 
            this.txtBirthday.Location = new System.Drawing.Point(484, 99);
            this.txtBirthday.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBirthday.Name = "txtBirthday";
            this.txtBirthday.ReadOnly = true;
            this.txtBirthday.Size = new System.Drawing.Size(223, 28);
            this.txtBirthday.TabIndex = 11;
            // 
            // labBirthday
            // 
            this.labBirthday.AutoSize = true;
            this.labBirthday.Location = new System.Drawing.Point(414, 104);
            this.labBirthday.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labBirthday.Name = "labBirthday";
            this.labBirthday.Size = new System.Drawing.Size(62, 18);
            this.labBirthday.TabIndex = 10;
            this.labBirthday.Text = "生日：";
            // 
            // txtIdCardNo
            // 
            this.txtIdCardNo.BackColor = System.Drawing.Color.Yellow;
            this.txtIdCardNo.Location = new System.Drawing.Point(123, 99);
            this.txtIdCardNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIdCardNo.MaxLength = 18;
            this.txtIdCardNo.Name = "txtIdCardNo";
            this.txtIdCardNo.Size = new System.Drawing.Size(223, 28);
            this.txtIdCardNo.TabIndex = 9;
            this.txtIdCardNo.Leave += new System.EventHandler(this.txtIdCardNo_Leave);
            // 
            // labIdCardNo
            // 
            this.labIdCardNo.AutoSize = true;
            this.labIdCardNo.Location = new System.Drawing.Point(26, 104);
            this.labIdCardNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labIdCardNo.Name = "labIdCardNo";
            this.labIdCardNo.Size = new System.Drawing.Size(89, 18);
            this.labIdCardNo.TabIndex = 8;
            this.labIdCardNo.Text = "*身份证：";
            // 
            // txtEmpName
            // 
            this.txtEmpName.BackColor = System.Drawing.Color.Yellow;
            this.txtEmpName.Location = new System.Drawing.Point(484, 58);
            this.txtEmpName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(223, 28);
            this.txtEmpName.TabIndex = 7;
            // 
            // labEmployeeName
            // 
            this.labEmployeeName.AutoSize = true;
            this.labEmployeeName.Location = new System.Drawing.Point(405, 63);
            this.labEmployeeName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labEmployeeName.Name = "labEmployeeName";
            this.labEmployeeName.Size = new System.Drawing.Size(71, 18);
            this.labEmployeeName.TabIndex = 6;
            this.labEmployeeName.Text = "*姓名：";
            // 
            // txtNo
            // 
            this.txtNo.BackColor = System.Drawing.Color.Yellow;
            this.txtNo.Location = new System.Drawing.Point(123, 58);
            this.txtNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNo.MaxLength = 6;
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(223, 28);
            this.txtNo.TabIndex = 5;
            // 
            // labNo
            // 
            this.labNo.AutoSize = true;
            this.labNo.Location = new System.Drawing.Point(44, 63);
            this.labNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labNo.Name = "labNo";
            this.labNo.Size = new System.Drawing.Size(71, 18);
            this.labNo.TabIndex = 4;
            this.labNo.Text = "*工号：";
            // 
            // txtDeptName
            // 
            this.txtDeptName.Enabled = false;
            this.txtDeptName.Location = new System.Drawing.Point(484, 18);
            this.txtDeptName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDeptName.Name = "txtDeptName";
            this.txtDeptName.Size = new System.Drawing.Size(223, 28);
            this.txtDeptName.TabIndex = 3;
            // 
            // labDeptName
            // 
            this.labDeptName.AutoSize = true;
            this.labDeptName.Location = new System.Drawing.Point(378, 24);
            this.labDeptName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labDeptName.Name = "labDeptName";
            this.labDeptName.Size = new System.Drawing.Size(98, 18);
            this.labDeptName.TabIndex = 2;
            this.labDeptName.Text = "部门名称：";
            // 
            // txtDeptNo
            // 
            this.txtDeptNo.Enabled = false;
            this.txtDeptNo.Location = new System.Drawing.Point(123, 18);
            this.txtDeptNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDeptNo.Name = "txtDeptNo";
            this.txtDeptNo.Size = new System.Drawing.Size(223, 28);
            this.txtDeptNo.TabIndex = 1;
            // 
            // labDeptNo
            // 
            this.labDeptNo.AutoSize = true;
            this.labDeptNo.Location = new System.Drawing.Point(16, 24);
            this.labDeptNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labDeptNo.Name = "labDeptNo";
            this.labDeptNo.Size = new System.Drawing.Size(98, 18);
            this.labDeptNo.TabIndex = 0;
            this.labDeptNo.Text = "部门编号：";
            // 
            // AddOrModEmpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 243);
            this.Controls.Add(this.dtpEntryTime);
            this.Controls.Add(this.btnCannel);
            this.Controls.Add(this.btnComfirm);
            this.Controls.Add(this.labEntryTime);
            this.Controls.Add(this.txtBirthplace);
            this.Controls.Add(this.labBirthplace);
            this.Controls.Add(this.txtBirthday);
            this.Controls.Add(this.labBirthday);
            this.Controls.Add(this.txtIdCardNo);
            this.Controls.Add(this.labIdCardNo);
            this.Controls.Add(this.txtEmpName);
            this.Controls.Add(this.labEmployeeName);
            this.Controls.Add(this.txtNo);
            this.Controls.Add(this.labNo);
            this.Controls.Add(this.txtDeptName);
            this.Controls.Add(this.labDeptName);
            this.Controls.Add(this.txtDeptNo);
            this.Controls.Add(this.labDeptNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddOrModEmpForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddOrModEmpForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpEntryTime;
        private System.Windows.Forms.Button btnCannel;
        private System.Windows.Forms.Button btnComfirm;
        private System.Windows.Forms.Label labEntryTime;
        private System.Windows.Forms.TextBox txtBirthplace;
        private System.Windows.Forms.Label labBirthplace;
        private System.Windows.Forms.TextBox txtBirthday;
        private System.Windows.Forms.Label labBirthday;
        private System.Windows.Forms.TextBox txtIdCardNo;
        private System.Windows.Forms.Label labIdCardNo;
        private System.Windows.Forms.TextBox txtEmpName;
        private System.Windows.Forms.Label labEmployeeName;
        private System.Windows.Forms.TextBox txtNo;
        private System.Windows.Forms.Label labNo;
        private System.Windows.Forms.TextBox txtDeptName;
        private System.Windows.Forms.Label labDeptName;
        private System.Windows.Forms.TextBox txtDeptNo;
        private System.Windows.Forms.Label labDeptNo;
    }
}