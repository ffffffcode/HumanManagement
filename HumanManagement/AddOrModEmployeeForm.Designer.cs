namespace HumanManagement
{
    partial class AddOrModEmployeeForm
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
            this.txtDeptNo = new System.Windows.Forms.TextBox();
            this.labDeptNo = new System.Windows.Forms.Label();
            this.txtDeptName = new System.Windows.Forms.TextBox();
            this.labDeptName = new System.Windows.Forms.Label();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.labNo = new System.Windows.Forms.Label();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.labEmployeeName = new System.Windows.Forms.Label();
            this.txtIdCardNo = new System.Windows.Forms.TextBox();
            this.labIdCardNo = new System.Windows.Forms.Label();
            this.txtBirthday = new System.Windows.Forms.TextBox();
            this.labBirthday = new System.Windows.Forms.Label();
            this.txtBirthplace = new System.Windows.Forms.TextBox();
            this.labBirthplace = new System.Windows.Forms.Label();
            this.labEntryTime = new System.Windows.Forms.Label();
            this.btnCannel = new System.Windows.Forms.Button();
            this.btnComfirm = new System.Windows.Forms.Button();
            this.dtpEntryTime = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // txtDeptNo
            // 
            this.txtDeptNo.Enabled = false;
            this.txtDeptNo.Location = new System.Drawing.Point(82, 12);
            this.txtDeptNo.Name = "txtDeptNo";
            this.txtDeptNo.Size = new System.Drawing.Size(150, 21);
            this.txtDeptNo.TabIndex = 0;
            // 
            // labDeptNo
            // 
            this.labDeptNo.AutoSize = true;
            this.labDeptNo.Location = new System.Drawing.Point(11, 16);
            this.labDeptNo.Name = "labDeptNo";
            this.labDeptNo.Size = new System.Drawing.Size(65, 12);
            this.labDeptNo.TabIndex = 2;
            this.labDeptNo.Text = "部门编号：";
            // 
            // txtDeptName
            // 
            this.txtDeptName.Enabled = false;
            this.txtDeptName.Location = new System.Drawing.Point(323, 12);
            this.txtDeptName.Name = "txtDeptName";
            this.txtDeptName.Size = new System.Drawing.Size(150, 21);
            this.txtDeptName.TabIndex = 4;
            // 
            // labDeptName
            // 
            this.labDeptName.AutoSize = true;
            this.labDeptName.Location = new System.Drawing.Point(252, 16);
            this.labDeptName.Name = "labDeptName";
            this.labDeptName.Size = new System.Drawing.Size(65, 12);
            this.labDeptName.TabIndex = 4;
            this.labDeptName.Text = "部门名称：";
            // 
            // txtNo
            // 
            this.txtNo.BackColor = System.Drawing.Color.Yellow;
            this.txtNo.Location = new System.Drawing.Point(82, 39);
            this.txtNo.MaxLength = 6;
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(150, 21);
            this.txtNo.TabIndex = 1;
            // 
            // labNo
            // 
            this.labNo.AutoSize = true;
            this.labNo.Location = new System.Drawing.Point(29, 42);
            this.labNo.Name = "labNo";
            this.labNo.Size = new System.Drawing.Size(47, 12);
            this.labNo.TabIndex = 6;
            this.labNo.Text = "*工号：";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.BackColor = System.Drawing.Color.Yellow;
            this.txtEmployeeName.Location = new System.Drawing.Point(323, 39);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(150, 21);
            this.txtEmployeeName.TabIndex = 5;
            // 
            // labEmployeeName
            // 
            this.labEmployeeName.AutoSize = true;
            this.labEmployeeName.Location = new System.Drawing.Point(270, 42);
            this.labEmployeeName.Name = "labEmployeeName";
            this.labEmployeeName.Size = new System.Drawing.Size(47, 12);
            this.labEmployeeName.TabIndex = 8;
            this.labEmployeeName.Text = "*姓名：";
            // 
            // txtIdCardNo
            // 
            this.txtIdCardNo.BackColor = System.Drawing.Color.Yellow;
            this.txtIdCardNo.Location = new System.Drawing.Point(82, 66);
            this.txtIdCardNo.MaxLength = 18;
            this.txtIdCardNo.Name = "txtIdCardNo";
            this.txtIdCardNo.Size = new System.Drawing.Size(150, 21);
            this.txtIdCardNo.TabIndex = 2;
            this.txtIdCardNo.Leave += new System.EventHandler(this.txtIdCardNo_Leave);
            // 
            // labIdCardNo
            // 
            this.labIdCardNo.AutoSize = true;
            this.labIdCardNo.Location = new System.Drawing.Point(17, 69);
            this.labIdCardNo.Name = "labIdCardNo";
            this.labIdCardNo.Size = new System.Drawing.Size(59, 12);
            this.labIdCardNo.TabIndex = 10;
            this.labIdCardNo.Text = "*身份证：";
            // 
            // txtBirthday
            // 
            this.txtBirthday.Enabled = false;
            this.txtBirthday.Location = new System.Drawing.Point(323, 66);
            this.txtBirthday.Name = "txtBirthday";
            this.txtBirthday.Size = new System.Drawing.Size(150, 21);
            this.txtBirthday.TabIndex = 6;
            // 
            // labBirthday
            // 
            this.labBirthday.AutoSize = true;
            this.labBirthday.Location = new System.Drawing.Point(276, 69);
            this.labBirthday.Name = "labBirthday";
            this.labBirthday.Size = new System.Drawing.Size(41, 12);
            this.labBirthday.TabIndex = 12;
            this.labBirthday.Text = "生日：";
            // 
            // txtBirthplace
            // 
            this.txtBirthplace.Location = new System.Drawing.Point(82, 93);
            this.txtBirthplace.Name = "txtBirthplace";
            this.txtBirthplace.Size = new System.Drawing.Size(150, 21);
            this.txtBirthplace.TabIndex = 3;
            // 
            // labBirthplace
            // 
            this.labBirthplace.AutoSize = true;
            this.labBirthplace.Location = new System.Drawing.Point(35, 96);
            this.labBirthplace.Name = "labBirthplace";
            this.labBirthplace.Size = new System.Drawing.Size(41, 12);
            this.labBirthplace.TabIndex = 14;
            this.labBirthplace.Text = "籍贯：";
            // 
            // labEntryTime
            // 
            this.labEntryTime.AutoSize = true;
            this.labEntryTime.Location = new System.Drawing.Point(252, 96);
            this.labEntryTime.Name = "labEntryTime";
            this.labEntryTime.Size = new System.Drawing.Size(65, 12);
            this.labEntryTime.TabIndex = 16;
            this.labEntryTime.Text = "入场时间：";
            // 
            // btnCannel
            // 
            this.btnCannel.Location = new System.Drawing.Point(254, 127);
            this.btnCannel.Name = "btnCannel";
            this.btnCannel.Size = new System.Drawing.Size(75, 23);
            this.btnCannel.TabIndex = 9;
            this.btnCannel.Text = "取消";
            this.btnCannel.UseVisualStyleBackColor = true;
            this.btnCannel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnComfirm
            // 
            this.btnComfirm.Location = new System.Drawing.Point(149, 127);
            this.btnComfirm.Name = "btnComfirm";
            this.btnComfirm.Size = new System.Drawing.Size(75, 23);
            this.btnComfirm.TabIndex = 8;
            this.btnComfirm.Text = "确定";
            this.btnComfirm.UseVisualStyleBackColor = true;
            this.btnComfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // dtpEntryTime
            // 
            this.dtpEntryTime.CustomFormat = "yyyy-MM-dd";
            this.dtpEntryTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEntryTime.Location = new System.Drawing.Point(323, 92);
            this.dtpEntryTime.Name = "dtpEntryTime";
            this.dtpEntryTime.Size = new System.Drawing.Size(150, 21);
            this.dtpEntryTime.TabIndex = 7;
            // 
            // AddOrModEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 162);
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
            this.Controls.Add(this.txtEmployeeName);
            this.Controls.Add(this.labEmployeeName);
            this.Controls.Add(this.txtNo);
            this.Controls.Add(this.labNo);
            this.Controls.Add(this.txtDeptName);
            this.Controls.Add(this.labDeptName);
            this.Controls.Add(this.txtDeptNo);
            this.Controls.Add(this.labDeptNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "AddOrModEmployeeForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddOrUpdateEmployeeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDeptNo;
        private System.Windows.Forms.Label labDeptNo;
        private System.Windows.Forms.TextBox txtDeptName;
        private System.Windows.Forms.Label labDeptName;
        private System.Windows.Forms.TextBox txtNo;
        private System.Windows.Forms.Label labNo;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Label labEmployeeName;
        private System.Windows.Forms.TextBox txtIdCardNo;
        private System.Windows.Forms.Label labIdCardNo;
        private System.Windows.Forms.TextBox txtBirthday;
        private System.Windows.Forms.Label labBirthday;
        private System.Windows.Forms.TextBox txtBirthplace;
        private System.Windows.Forms.Label labBirthplace;
        private System.Windows.Forms.Label labEntryTime;
        private System.Windows.Forms.Button btnCannel;
        private System.Windows.Forms.Button btnComfirm;
        private System.Windows.Forms.DateTimePicker dtpEntryTime;
    }
}