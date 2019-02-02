namespace HumanManagementSQLServer
{
    partial class AddOrModDeptForm
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
            this.txtDeptName = new System.Windows.Forms.TextBox();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.labRemarks = new System.Windows.Forms.Label();
            this.labDeptName = new System.Windows.Forms.Label();
            this.labNo = new System.Windows.Forms.Label();
            this.txtParentDeptName = new System.Windows.Forms.TextBox();
            this.labParentDeptName = new System.Windows.Forms.Label();
            this.txtParentDeptNo = new System.Windows.Forms.TextBox();
            this.labParentDeptNo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDeptName
            // 
            this.txtDeptName.BackColor = System.Drawing.Color.Yellow;
            this.txtDeptName.Location = new System.Drawing.Point(172, 138);
            this.txtDeptName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDeptName.Name = "txtDeptName";
            this.txtDeptName.Size = new System.Drawing.Size(223, 28);
            this.txtDeptName.TabIndex = 7;
            // 
            // txtNo
            // 
            this.txtNo.BackColor = System.Drawing.Color.Yellow;
            this.txtNo.Location = new System.Drawing.Point(172, 98);
            this.txtNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(223, 28);
            this.txtNo.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(236, 220);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 34);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(78, 220);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(112, 34);
            this.btnConfirm.TabIndex = 10;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(172, 180);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(223, 28);
            this.txtRemarks.TabIndex = 9;
            // 
            // labRemarks
            // 
            this.labRemarks.AutoSize = true;
            this.labRemarks.Location = new System.Drawing.Point(102, 186);
            this.labRemarks.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labRemarks.Name = "labRemarks";
            this.labRemarks.Size = new System.Drawing.Size(62, 18);
            this.labRemarks.TabIndex = 8;
            this.labRemarks.Text = "备注：";
            // 
            // labDeptName
            // 
            this.labDeptName.AutoSize = true;
            this.labDeptName.Location = new System.Drawing.Point(57, 144);
            this.labDeptName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labDeptName.Name = "labDeptName";
            this.labDeptName.Size = new System.Drawing.Size(107, 18);
            this.labDeptName.TabIndex = 6;
            this.labDeptName.Text = "*部门名称：";
            // 
            // labNo
            // 
            this.labNo.AutoSize = true;
            this.labNo.Location = new System.Drawing.Point(57, 104);
            this.labNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labNo.Name = "labNo";
            this.labNo.Size = new System.Drawing.Size(107, 18);
            this.labNo.TabIndex = 4;
            this.labNo.Text = "*部门编号：";
            // 
            // txtParentDeptName
            // 
            this.txtParentDeptName.Enabled = false;
            this.txtParentDeptName.Location = new System.Drawing.Point(172, 58);
            this.txtParentDeptName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtParentDeptName.Name = "txtParentDeptName";
            this.txtParentDeptName.Size = new System.Drawing.Size(223, 28);
            this.txtParentDeptName.TabIndex = 3;
            // 
            // labParentDeptName
            // 
            this.labParentDeptName.AutoSize = true;
            this.labParentDeptName.Location = new System.Drawing.Point(30, 64);
            this.labParentDeptName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labParentDeptName.Name = "labParentDeptName";
            this.labParentDeptName.Size = new System.Drawing.Size(134, 18);
            this.labParentDeptName.TabIndex = 2;
            this.labParentDeptName.Text = "上级部门名称：";
            // 
            // txtParentDeptNo
            // 
            this.txtParentDeptNo.Enabled = false;
            this.txtParentDeptNo.Location = new System.Drawing.Point(172, 18);
            this.txtParentDeptNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtParentDeptNo.Name = "txtParentDeptNo";
            this.txtParentDeptNo.Size = new System.Drawing.Size(223, 28);
            this.txtParentDeptNo.TabIndex = 1;
            // 
            // labParentDeptNo
            // 
            this.labParentDeptNo.AutoSize = true;
            this.labParentDeptNo.Location = new System.Drawing.Point(30, 24);
            this.labParentDeptNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labParentDeptNo.Name = "labParentDeptNo";
            this.labParentDeptNo.Size = new System.Drawing.Size(134, 18);
            this.labParentDeptNo.TabIndex = 0;
            this.labParentDeptNo.Text = "上级部门编号：";
            // 
            // AddOrModDeptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 273);
            this.Controls.Add(this.txtDeptName);
            this.Controls.Add(this.txtNo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.labRemarks);
            this.Controls.Add(this.labDeptName);
            this.Controls.Add(this.labNo);
            this.Controls.Add(this.txtParentDeptName);
            this.Controls.Add(this.labParentDeptName);
            this.Controls.Add(this.txtParentDeptNo);
            this.Controls.Add(this.labParentDeptNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddOrModDeptForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddOrModDeptForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDeptName;
        private System.Windows.Forms.TextBox txtNo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label labRemarks;
        private System.Windows.Forms.Label labDeptName;
        private System.Windows.Forms.Label labNo;
        private System.Windows.Forms.TextBox txtParentDeptName;
        private System.Windows.Forms.Label labParentDeptName;
        private System.Windows.Forms.TextBox txtParentDeptNo;
        private System.Windows.Forms.Label labParentDeptNo;
    }
}