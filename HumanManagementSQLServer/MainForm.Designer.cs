namespace HumanManagementSQLServer
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnListEmp = new System.Windows.Forms.Button();
            this.btnDelEmp = new System.Windows.Forms.Button();
            this.btnModEmp = new System.Windows.Forms.Button();
            this.btnAddEmp = new System.Windows.Forms.Button();
            this.btnDelDept = new System.Windows.Forms.Button();
            this.btnModDept = new System.Windows.Forms.Button();
            this.btnAddDept = new System.Windows.Forms.Button();
            this.tvHuman = new System.Windows.Forms.TreeView();
            this.splitContainerData = new System.Windows.Forms.SplitContainer();
            this.txtHumanData = new System.Windows.Forms.TextBox();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerData)).BeginInit();
            this.splitContainerData.Panel1.SuspendLayout();
            this.splitContainerData.Panel2.SuspendLayout();
            this.splitContainerData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnListEmp
            // 
            this.btnListEmp.Location = new System.Drawing.Point(21, 255);
            this.btnListEmp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnListEmp.Name = "btnListEmp";
            this.btnListEmp.Size = new System.Drawing.Size(129, 57);
            this.btnListEmp.TabIndex = 6;
            this.btnListEmp.Text = "查看员工列表";
            this.btnListEmp.UseVisualStyleBackColor = true;
            this.btnListEmp.Click += new System.EventHandler(this.btnListEmp_Click);
            // 
            // btnDelEmp
            // 
            this.btnDelEmp.Location = new System.Drawing.Point(348, 168);
            this.btnDelEmp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelEmp.Name = "btnDelEmp";
            this.btnDelEmp.Size = new System.Drawing.Size(129, 57);
            this.btnDelEmp.TabIndex = 5;
            this.btnDelEmp.Text = "删除员工";
            this.btnDelEmp.UseVisualStyleBackColor = true;
            this.btnDelEmp.Click += new System.EventHandler(this.btnDelEmp_Click);
            // 
            // btnModEmp
            // 
            this.btnModEmp.Location = new System.Drawing.Point(184, 168);
            this.btnModEmp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnModEmp.Name = "btnModEmp";
            this.btnModEmp.Size = new System.Drawing.Size(129, 57);
            this.btnModEmp.TabIndex = 4;
            this.btnModEmp.Text = "修改员工";
            this.btnModEmp.UseVisualStyleBackColor = true;
            this.btnModEmp.Click += new System.EventHandler(this.btnModEmp_Click);
            // 
            // btnAddEmp
            // 
            this.btnAddEmp.Location = new System.Drawing.Point(21, 168);
            this.btnAddEmp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddEmp.Name = "btnAddEmp";
            this.btnAddEmp.Size = new System.Drawing.Size(129, 57);
            this.btnAddEmp.TabIndex = 3;
            this.btnAddEmp.Text = "添加员工";
            this.btnAddEmp.UseVisualStyleBackColor = true;
            this.btnAddEmp.Click += new System.EventHandler(this.btnAddEmp_Click);
            // 
            // btnDelDept
            // 
            this.btnDelDept.Location = new System.Drawing.Point(348, 44);
            this.btnDelDept.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelDept.Name = "btnDelDept";
            this.btnDelDept.Size = new System.Drawing.Size(129, 57);
            this.btnDelDept.TabIndex = 2;
            this.btnDelDept.Text = "删除部门";
            this.btnDelDept.UseVisualStyleBackColor = true;
            this.btnDelDept.Click += new System.EventHandler(this.btnDelDept_Click);
            // 
            // btnModDept
            // 
            this.btnModDept.Location = new System.Drawing.Point(184, 44);
            this.btnModDept.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnModDept.Name = "btnModDept";
            this.btnModDept.Size = new System.Drawing.Size(129, 57);
            this.btnModDept.TabIndex = 1;
            this.btnModDept.Text = "修改部门";
            this.btnModDept.UseVisualStyleBackColor = true;
            this.btnModDept.Click += new System.EventHandler(this.btnModDept_Click);
            // 
            // btnAddDept
            // 
            this.btnAddDept.Location = new System.Drawing.Point(21, 44);
            this.btnAddDept.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddDept.Name = "btnAddDept";
            this.btnAddDept.Size = new System.Drawing.Size(129, 57);
            this.btnAddDept.TabIndex = 0;
            this.btnAddDept.Text = "添加部门";
            this.btnAddDept.UseVisualStyleBackColor = true;
            this.btnAddDept.Click += new System.EventHandler(this.btnAddDept_Click);
            // 
            // tvHuman
            // 
            this.tvHuman.AllowDrop = true;
            this.tvHuman.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvHuman.Location = new System.Drawing.Point(0, 0);
            this.tvHuman.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tvHuman.Name = "tvHuman";
            this.tvHuman.Size = new System.Drawing.Size(180, 576);
            this.tvHuman.TabIndex = 0;
            this.tvHuman.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvHuman_AfterSelect);
            // 
            // splitContainerData
            // 
            this.splitContainerData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerData.Location = new System.Drawing.Point(0, 0);
            this.splitContainerData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainerData.Name = "splitContainerData";
            // 
            // splitContainerData.Panel1
            // 
            this.splitContainerData.Panel1.Controls.Add(this.tvHuman);
            // 
            // splitContainerData.Panel2
            // 
            this.splitContainerData.Panel2.Controls.Add(this.txtHumanData);
            this.splitContainerData.Size = new System.Drawing.Size(387, 576);
            this.splitContainerData.SplitterDistance = 180;
            this.splitContainerData.SplitterWidth = 2;
            this.splitContainerData.TabIndex = 0;
            // 
            // txtHumanData
            // 
            this.txtHumanData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHumanData.Location = new System.Drawing.Point(0, 0);
            this.txtHumanData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtHumanData.Multiline = true;
            this.txtHumanData.Name = "txtHumanData";
            this.txtHumanData.ReadOnly = true;
            this.txtHumanData.Size = new System.Drawing.Size(205, 576);
            this.txtHumanData.TabIndex = 0;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.IsSplitterFixed = true;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.splitContainerData);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.btnListEmp);
            this.splitContainerMain.Panel2.Controls.Add(this.btnDelEmp);
            this.splitContainerMain.Panel2.Controls.Add(this.btnModEmp);
            this.splitContainerMain.Panel2.Controls.Add(this.btnAddEmp);
            this.splitContainerMain.Panel2.Controls.Add(this.btnDelDept);
            this.splitContainerMain.Panel2.Controls.Add(this.btnModDept);
            this.splitContainerMain.Panel2.Controls.Add(this.btnAddDept);
            this.splitContainerMain.Size = new System.Drawing.Size(888, 576);
            this.splitContainerMain.SplitterDistance = 387;
            this.splitContainerMain.SplitterWidth = 6;
            this.splitContainerMain.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 576);
            this.Controls.Add(this.splitContainerMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "人员管理窗口";
            this.splitContainerData.Panel1.ResumeLayout(false);
            this.splitContainerData.Panel2.ResumeLayout(false);
            this.splitContainerData.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerData)).EndInit();
            this.splitContainerData.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnListEmp;
        private System.Windows.Forms.Button btnDelEmp;
        private System.Windows.Forms.Button btnModEmp;
        private System.Windows.Forms.Button btnAddEmp;
        private System.Windows.Forms.Button btnDelDept;
        private System.Windows.Forms.Button btnModDept;
        private System.Windows.Forms.Button btnAddDept;
        private System.Windows.Forms.TreeView tvHuman;
        private System.Windows.Forms.SplitContainer splitContainerData;
        private System.Windows.Forms.TextBox txtHumanData;
        private System.Windows.Forms.SplitContainer splitContainerMain;
    }
}

