namespace HumanManagementSQLServer
{
    partial class MainForm
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
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.splitContainerData = new System.Windows.Forms.SplitContainer();
            this.tvHuman = new System.Windows.Forms.TreeView();
            this.txtHumanData = new System.Windows.Forms.TextBox();
            this.labImport = new System.Windows.Forms.Label();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.txtImportingFilename = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExportAllNode = new System.Windows.Forms.Button();
            this.btnExportSelectedNode = new System.Windows.Forms.Button();
            this.btnListEmployee = new System.Windows.Forms.Button();
            this.btnDelEmployee = new System.Windows.Forms.Button();
            this.btnModEmployee = new System.Windows.Forms.Button();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.btnDelDept = new System.Windows.Forms.Button();
            this.btnModDept = new System.Windows.Forms.Button();
            this.btnAddDept = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerData)).BeginInit();
            this.splitContainerData.Panel1.SuspendLayout();
            this.splitContainerData.Panel2.SuspendLayout();
            this.splitContainerData.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.IsSplitterFixed = true;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.splitContainerData);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.labImport);
            this.splitContainerMain.Panel2.Controls.Add(this.btnOpenFile);
            this.splitContainerMain.Panel2.Controls.Add(this.txtImportingFilename);
            this.splitContainerMain.Panel2.Controls.Add(this.btnImport);
            this.splitContainerMain.Panel2.Controls.Add(this.btnExportAllNode);
            this.splitContainerMain.Panel2.Controls.Add(this.btnExportSelectedNode);
            this.splitContainerMain.Panel2.Controls.Add(this.btnListEmployee);
            this.splitContainerMain.Panel2.Controls.Add(this.btnDelEmployee);
            this.splitContainerMain.Panel2.Controls.Add(this.btnModEmployee);
            this.splitContainerMain.Panel2.Controls.Add(this.btnAddEmployee);
            this.splitContainerMain.Panel2.Controls.Add(this.btnDelDept);
            this.splitContainerMain.Panel2.Controls.Add(this.btnModDept);
            this.splitContainerMain.Panel2.Controls.Add(this.btnAddDept);
            this.splitContainerMain.Size = new System.Drawing.Size(592, 384);
            this.splitContainerMain.SplitterDistance = 258;
            this.splitContainerMain.TabIndex = 0;
            // 
            // splitContainerData
            // 
            this.splitContainerData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerData.Location = new System.Drawing.Point(0, 0);
            this.splitContainerData.Name = "splitContainerData";
            // 
            // splitContainerData.Panel1
            // 
            this.splitContainerData.Panel1.Controls.Add(this.tvHuman);
            // 
            // splitContainerData.Panel2
            // 
            this.splitContainerData.Panel2.Controls.Add(this.txtHumanData);
            this.splitContainerData.Size = new System.Drawing.Size(258, 384);
            this.splitContainerData.SplitterDistance = 120;
            this.splitContainerData.SplitterWidth = 1;
            this.splitContainerData.TabIndex = 0;
            // 
            // tvHuman
            // 
            this.tvHuman.AllowDrop = true;
            this.tvHuman.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvHuman.Location = new System.Drawing.Point(0, 0);
            this.tvHuman.Name = "tvHuman";
            this.tvHuman.Size = new System.Drawing.Size(120, 384);
            this.tvHuman.TabIndex = 0;
            this.tvHuman.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvHuman_AfterSelect);
            // 
            // txtHumanData
            // 
            this.txtHumanData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHumanData.Location = new System.Drawing.Point(0, 0);
            this.txtHumanData.Multiline = true;
            this.txtHumanData.Name = "txtHumanData";
            this.txtHumanData.ReadOnly = true;
            this.txtHumanData.Size = new System.Drawing.Size(137, 384);
            this.txtHumanData.TabIndex = 0;
            // 
            // labImport
            // 
            this.labImport.AutoSize = true;
            this.labImport.Location = new System.Drawing.Point(12, 336);
            this.labImport.Name = "labImport";
            this.labImport.Size = new System.Drawing.Size(65, 12);
            this.labImport.TabIndex = 15;
            this.labImport.Text = "导入数据：";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(290, 332);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(28, 23);
            this.btnOpenFile.TabIndex = 14;
            this.btnOpenFile.Text = "...";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            // 
            // txtImportingFilename
            // 
            this.txtImportingFilename.Font = new System.Drawing.Font("宋体", 10F);
            this.txtImportingFilename.Location = new System.Drawing.Point(83, 332);
            this.txtImportingFilename.Name = "txtImportingFilename";
            this.txtImportingFilename.Size = new System.Drawing.Size(207, 23);
            this.txtImportingFilename.TabIndex = 13;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(232, 258);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(86, 38);
            this.btnImport.TabIndex = 9;
            this.btnImport.Text = "导入数据";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // btnExportAllNode
            // 
            this.btnExportAllNode.Location = new System.Drawing.Point(123, 258);
            this.btnExportAllNode.Name = "btnExportAllNode";
            this.btnExportAllNode.Size = new System.Drawing.Size(86, 38);
            this.btnExportAllNode.TabIndex = 8;
            this.btnExportAllNode.Text = "导出全部节点";
            this.btnExportAllNode.UseVisualStyleBackColor = true;
            // 
            // btnExportSelectedNode
            // 
            this.btnExportSelectedNode.Location = new System.Drawing.Point(14, 258);
            this.btnExportSelectedNode.Name = "btnExportSelectedNode";
            this.btnExportSelectedNode.Size = new System.Drawing.Size(86, 38);
            this.btnExportSelectedNode.TabIndex = 7;
            this.btnExportSelectedNode.Text = "导出所选节点";
            this.btnExportSelectedNode.UseVisualStyleBackColor = true;
            // 
            // btnListEmployee
            // 
            this.btnListEmployee.Location = new System.Drawing.Point(14, 170);
            this.btnListEmployee.Name = "btnListEmployee";
            this.btnListEmployee.Size = new System.Drawing.Size(86, 38);
            this.btnListEmployee.TabIndex = 6;
            this.btnListEmployee.Text = "查看员工列表";
            this.btnListEmployee.UseVisualStyleBackColor = true;
            // 
            // btnDelEmployee
            // 
            this.btnDelEmployee.Location = new System.Drawing.Point(232, 112);
            this.btnDelEmployee.Name = "btnDelEmployee";
            this.btnDelEmployee.Size = new System.Drawing.Size(86, 38);
            this.btnDelEmployee.TabIndex = 5;
            this.btnDelEmployee.Text = "删除员工";
            this.btnDelEmployee.UseVisualStyleBackColor = true;
            // 
            // btnModEmployee
            // 
            this.btnModEmployee.Location = new System.Drawing.Point(123, 112);
            this.btnModEmployee.Name = "btnModEmployee";
            this.btnModEmployee.Size = new System.Drawing.Size(86, 38);
            this.btnModEmployee.TabIndex = 4;
            this.btnModEmployee.Text = "修改员工";
            this.btnModEmployee.UseVisualStyleBackColor = true;
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Location = new System.Drawing.Point(14, 112);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(86, 38);
            this.btnAddEmployee.TabIndex = 3;
            this.btnAddEmployee.Text = "添加员工";
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            // 
            // btnDelDept
            // 
            this.btnDelDept.Location = new System.Drawing.Point(232, 29);
            this.btnDelDept.Name = "btnDelDept";
            this.btnDelDept.Size = new System.Drawing.Size(86, 38);
            this.btnDelDept.TabIndex = 2;
            this.btnDelDept.Text = "删除部门";
            this.btnDelDept.UseVisualStyleBackColor = true;
            // 
            // btnModDept
            // 
            this.btnModDept.Location = new System.Drawing.Point(123, 29);
            this.btnModDept.Name = "btnModDept";
            this.btnModDept.Size = new System.Drawing.Size(86, 38);
            this.btnModDept.TabIndex = 1;
            this.btnModDept.Text = "修改部门";
            this.btnModDept.UseVisualStyleBackColor = true;
            // 
            // btnAddDept
            // 
            this.btnAddDept.Location = new System.Drawing.Point(14, 29);
            this.btnAddDept.Name = "btnAddDept";
            this.btnAddDept.Size = new System.Drawing.Size(86, 38);
            this.btnAddDept.TabIndex = 0;
            this.btnAddDept.Text = "添加部门";
            this.btnAddDept.UseVisualStyleBackColor = true;
            this.btnAddDept.Click += new System.EventHandler(this.btnAddDept_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 384);
            this.Controls.Add(this.splitContainerMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "人员管理窗口";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainerData.Panel1.ResumeLayout(false);
            this.splitContainerData.Panel2.ResumeLayout(false);
            this.splitContainerData.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerData)).EndInit();
            this.splitContainerData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerData;
        private System.Windows.Forms.TreeView tvHuman;
        private System.Windows.Forms.TextBox txtHumanData;
        private System.Windows.Forms.Button btnAddDept;
        private System.Windows.Forms.Button btnDelDept;
        private System.Windows.Forms.Button btnModDept;
        private System.Windows.Forms.Button btnDelEmployee;
        private System.Windows.Forms.Button btnModEmployee;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.Button btnListEmployee;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExportAllNode;
        private System.Windows.Forms.Button btnExportSelectedNode;
        private System.Windows.Forms.Label labImport;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TextBox txtImportingFilename;
    }
}