namespace HumanManagement
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
            this.labParentDeptNo = new System.Windows.Forms.Label();
            this.txtParentDeptNo = new System.Windows.Forms.TextBox();
            this.txtParentDeptName = new System.Windows.Forms.TextBox();
            this.labParentDeptName = new System.Windows.Forms.Label();
            this.labDeptNo = new System.Windows.Forms.Label();
            this.labDeptName = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.labRemarks = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtDeptNo = new System.Windows.Forms.TextBox();
            this.txtDeptName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labParentDeptNo
            // 
            this.labParentDeptNo.AutoSize = true;
            this.labParentDeptNo.Location = new System.Drawing.Point(20, 16);
            this.labParentDeptNo.Name = "labParentDeptNo";
            this.labParentDeptNo.Size = new System.Drawing.Size(89, 12);
            this.labParentDeptNo.TabIndex = 0;
            this.labParentDeptNo.Text = "上级部门编号：";
            // 
            // txtParentDeptNo
            // 
            this.txtParentDeptNo.Enabled = false;
            this.txtParentDeptNo.Location = new System.Drawing.Point(115, 12);
            this.txtParentDeptNo.Name = "txtParentDeptNo";
            this.txtParentDeptNo.Size = new System.Drawing.Size(150, 21);
            this.txtParentDeptNo.TabIndex = 1;
            // 
            // txtParentDeptName
            // 
            this.txtParentDeptName.Enabled = false;
            this.txtParentDeptName.Location = new System.Drawing.Point(115, 39);
            this.txtParentDeptName.Name = "txtParentDeptName";
            this.txtParentDeptName.Size = new System.Drawing.Size(150, 21);
            this.txtParentDeptName.TabIndex = 3;
            // 
            // labParentDeptName
            // 
            this.labParentDeptName.AutoSize = true;
            this.labParentDeptName.Location = new System.Drawing.Point(20, 43);
            this.labParentDeptName.Name = "labParentDeptName";
            this.labParentDeptName.Size = new System.Drawing.Size(89, 12);
            this.labParentDeptName.TabIndex = 2;
            this.labParentDeptName.Text = "上级部门名称：";
            // 
            // labDeptNo
            // 
            this.labDeptNo.AutoSize = true;
            this.labDeptNo.Location = new System.Drawing.Point(38, 69);
            this.labDeptNo.Name = "labDeptNo";
            this.labDeptNo.Size = new System.Drawing.Size(71, 12);
            this.labDeptNo.TabIndex = 4;
            this.labDeptNo.Text = "*部门编号：";
            // 
            // labDeptName
            // 
            this.labDeptName.AutoSize = true;
            this.labDeptName.Location = new System.Drawing.Point(38, 96);
            this.labDeptName.Name = "labDeptName";
            this.labDeptName.Size = new System.Drawing.Size(71, 12);
            this.labDeptName.TabIndex = 6;
            this.labDeptName.Text = "*部门名称：";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(115, 120);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(150, 21);
            this.txtRemarks.TabIndex = 9;
            // 
            // labRemarks
            // 
            this.labRemarks.AutoSize = true;
            this.labRemarks.Location = new System.Drawing.Point(68, 124);
            this.labRemarks.Name = "labRemarks";
            this.labRemarks.Size = new System.Drawing.Size(41, 12);
            this.labRemarks.TabIndex = 8;
            this.labRemarks.Text = "备注：";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(52, 147);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 10;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(157, 147);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtDeptNo
            // 
            this.txtDeptNo.BackColor = System.Drawing.Color.Yellow;
            this.txtDeptNo.Location = new System.Drawing.Point(115, 65);
            this.txtDeptNo.Name = "txtDeptNo";
            this.txtDeptNo.Size = new System.Drawing.Size(150, 21);
            this.txtDeptNo.TabIndex = 5;
            // 
            // txtDeptName
            // 
            this.txtDeptName.BackColor = System.Drawing.Color.Yellow;
            this.txtDeptName.Location = new System.Drawing.Point(115, 92);
            this.txtDeptName.Name = "txtDeptName";
            this.txtDeptName.Size = new System.Drawing.Size(150, 21);
            this.txtDeptName.TabIndex = 7;
            // 
            // AddOrModDeptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 182);
            this.Controls.Add(this.txtDeptName);
            this.Controls.Add(this.txtDeptNo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.labRemarks);
            this.Controls.Add(this.labDeptName);
            this.Controls.Add(this.labDeptNo);
            this.Controls.Add(this.txtParentDeptName);
            this.Controls.Add(this.labParentDeptName);
            this.Controls.Add(this.txtParentDeptNo);
            this.Controls.Add(this.labParentDeptNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "AddOrModDeptForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddOrUpdateDeptForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labParentDeptNo;
        private System.Windows.Forms.TextBox txtParentDeptNo;
        private System.Windows.Forms.TextBox txtParentDeptName;
        private System.Windows.Forms.Label labParentDeptName;
        private System.Windows.Forms.Label labDeptNo;
        private System.Windows.Forms.Label labDeptName;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label labRemarks;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtDeptNo;
        private System.Windows.Forms.TextBox txtDeptName;
    }
}