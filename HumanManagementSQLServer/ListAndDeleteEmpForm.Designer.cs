namespace HumanManagementSQLServer
{
    partial class ListAndDeleteEmpForm
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
            this.dgvEmployeeList = new System.Windows.Forms.DataGridView();
            this.txtDeptName = new System.Windows.Forms.TextBox();
            this.labDeptName = new System.Windows.Forms.Label();
            this.txtDeptNo = new System.Windows.Forms.TextBox();
            this.labDeptNo = new System.Windows.Forms.Label();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.btnDelSelectedEmployee = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmployeeList
            // 
            this.dgvEmployeeList.AllowUserToAddRows = false;
            this.dgvEmployeeList.AllowUserToOrderColumns = true;
            this.dgvEmployeeList.AllowUserToResizeRows = false;
            this.dgvEmployeeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeeList.Location = new System.Drawing.Point(6, 56);
            this.dgvEmployeeList.Name = "dgvEmployeeList";
            this.dgvEmployeeList.ReadOnly = true;
            this.dgvEmployeeList.RowHeadersVisible = false;
            this.dgvEmployeeList.RowTemplate.Height = 23;
            this.dgvEmployeeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployeeList.Size = new System.Drawing.Size(463, 170);
            this.dgvEmployeeList.TabIndex = 26;
            // 
            // txtDeptName
            // 
            this.txtDeptName.Enabled = false;
            this.txtDeptName.Location = new System.Drawing.Point(318, 12);
            this.txtDeptName.Name = "txtDeptName";
            this.txtDeptName.Size = new System.Drawing.Size(150, 21);
            this.txtDeptName.TabIndex = 25;
            // 
            // labDeptName
            // 
            this.labDeptName.AutoSize = true;
            this.labDeptName.Location = new System.Drawing.Point(247, 16);
            this.labDeptName.Name = "labDeptName";
            this.labDeptName.Size = new System.Drawing.Size(65, 12);
            this.labDeptName.TabIndex = 24;
            this.labDeptName.Text = "部门名称：";
            // 
            // txtDeptNo
            // 
            this.txtDeptNo.Enabled = false;
            this.txtDeptNo.Location = new System.Drawing.Point(77, 12);
            this.txtDeptNo.Name = "txtDeptNo";
            this.txtDeptNo.Size = new System.Drawing.Size(150, 21);
            this.txtDeptNo.TabIndex = 23;
            // 
            // labDeptNo
            // 
            this.labDeptNo.AutoSize = true;
            this.labDeptNo.Location = new System.Drawing.Point(6, 16);
            this.labDeptNo.Name = "labDeptNo";
            this.labDeptNo.Size = new System.Drawing.Size(65, 12);
            this.labDeptNo.TabIndex = 22;
            this.labDeptNo.Text = "部门编号：";
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.Location = new System.Drawing.Point(252, 247);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(75, 23);
            this.btnCloseForm.TabIndex = 28;
            this.btnCloseForm.Text = "关闭";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // btnDelSelectedEmployee
            // 
            this.btnDelSelectedEmployee.Location = new System.Drawing.Point(116, 247);
            this.btnDelSelectedEmployee.Name = "btnDelSelectedEmployee";
            this.btnDelSelectedEmployee.Size = new System.Drawing.Size(99, 23);
            this.btnDelSelectedEmployee.TabIndex = 27;
            this.btnDelSelectedEmployee.Text = "删除选定员工";
            this.btnDelSelectedEmployee.UseVisualStyleBackColor = true;
            this.btnDelSelectedEmployee.Click += new System.EventHandler(this.btnDelSelectedEmployee_Click);
            // 
            // ListAndDeleteEmpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 282);
            this.Controls.Add(this.dgvEmployeeList);
            this.Controls.Add(this.txtDeptName);
            this.Controls.Add(this.labDeptName);
            this.Controls.Add(this.txtDeptNo);
            this.Controls.Add(this.labDeptNo);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.btnDelSelectedEmployee);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListAndDeleteEmpForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "员工清单";
            this.Load += new System.EventHandler(this.ListAndDeleteEmpForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmployeeList;
        private System.Windows.Forms.TextBox txtDeptName;
        private System.Windows.Forms.Label labDeptName;
        private System.Windows.Forms.TextBox txtDeptNo;
        private System.Windows.Forms.Label labDeptNo;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Button btnDelSelectedEmployee;
    }
}