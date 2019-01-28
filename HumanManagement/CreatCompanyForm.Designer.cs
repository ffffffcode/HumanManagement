namespace HumanManagement
{
    partial class CreatCompanyForm
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
            this.labCompanyNo = new System.Windows.Forms.Label();
            this.labCompanyName = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.labCompanyRemarks = new System.Windows.Forms.Label();
            this.txtCompanyNo = new System.Windows.Forms.TextBox();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtCompanyRemarks = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labCompanyNo
            // 
            this.labCompanyNo.AutoSize = true;
            this.labCompanyNo.Location = new System.Drawing.Point(29, 15);
            this.labCompanyNo.Name = "labCompanyNo";
            this.labCompanyNo.Size = new System.Drawing.Size(71, 12);
            this.labCompanyNo.TabIndex = 1;
            this.labCompanyNo.Text = "*公司编号：";
            // 
            // labCompanyName
            // 
            this.labCompanyName.AutoSize = true;
            this.labCompanyName.Location = new System.Drawing.Point(29, 42);
            this.labCompanyName.Name = "labCompanyName";
            this.labCompanyName.Size = new System.Drawing.Size(71, 12);
            this.labCompanyName.TabIndex = 5;
            this.labCompanyName.Text = "*公司名称：";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(157, 98);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(52, 98);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 13;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // labCompanyRemarks
            // 
            this.labCompanyRemarks.AutoSize = true;
            this.labCompanyRemarks.Location = new System.Drawing.Point(59, 69);
            this.labCompanyRemarks.Name = "labCompanyRemarks";
            this.labCompanyRemarks.Size = new System.Drawing.Size(41, 12);
            this.labCompanyRemarks.TabIndex = 9;
            this.labCompanyRemarks.Text = "备注：";
            // 
            // txtCompanyNo
            // 
            this.txtCompanyNo.BackColor = System.Drawing.Color.Yellow;
            this.txtCompanyNo.Location = new System.Drawing.Point(106, 11);
            this.txtCompanyNo.Name = "txtCompanyNo";
            this.txtCompanyNo.Size = new System.Drawing.Size(150, 21);
            this.txtCompanyNo.TabIndex = 3;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.BackColor = System.Drawing.Color.Yellow;
            this.txtCompanyName.Location = new System.Drawing.Point(106, 38);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(150, 21);
            this.txtCompanyName.TabIndex = 7;
            // 
            // txtCompanyRemarks
            // 
            this.txtCompanyRemarks.Location = new System.Drawing.Point(106, 65);
            this.txtCompanyRemarks.Name = "txtCompanyRemarks";
            this.txtCompanyRemarks.Size = new System.Drawing.Size(150, 21);
            this.txtCompanyRemarks.TabIndex = 11;
            // 
            // CreatCompanyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 129);
            this.Controls.Add(this.txtCompanyRemarks);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.txtCompanyNo);
            this.Controls.Add(this.labCompanyRemarks);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.labCompanyName);
            this.Controls.Add(this.labCompanyNo);
            this.KeyPreview = true;
            this.Name = "CreatCompanyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "初始化程序";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labCompanyNo;
        private System.Windows.Forms.Label labCompanyName;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label labCompanyRemarks;
        private System.Windows.Forms.TextBox txtCompanyNo;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.TextBox txtCompanyRemarks;
    }
}