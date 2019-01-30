namespace BindingSourceSolution
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
            this.tvHuman = new System.Windows.Forms.TreeView();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.splitContainerData = new System.Windows.Forms.SplitContainer();
            this.txtHumanData = new System.Windows.Forms.TextBox();
            this.btnListEmployee = new System.Windows.Forms.Button();
            this.btnDelEmployee = new System.Windows.Forms.Button();
            this.btnModEmployee = new System.Windows.Forms.Button();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.btnDelDept = new System.Windows.Forms.Button();
            this.btnModDept = new System.Windows.Forms.Button();
            this.btnAddDept = new System.Windows.Forms.Button();
            this.humanManagementDataSet = new BindingSourceSolution.HumanManagementDataSet();
            this.deptTableAdapter = new BindingSourceSolution.HumanManagementDataSetTableAdapters.deptTableAdapter();
            this.empTableAdapter = new BindingSourceSolution.HumanManagementDataSetTableAdapters.empTableAdapter();
            this.tableAdapterManager = new BindingSourceSolution.HumanManagementDataSetTableAdapters.TableAdapterManager();
            this.deptDetailTableAdapter = new BindingSourceSolution.HumanManagementDataSetTableAdapters.deptDetailTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerData)).BeginInit();
            this.splitContainerData.Panel1.SuspendLayout();
            this.splitContainerData.Panel2.SuspendLayout();
            this.splitContainerData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.humanManagementDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tvHuman
            // 
            this.tvHuman.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvHuman.Location = new System.Drawing.Point(0, 0);
            this.tvHuman.Name = "tvHuman";
            this.tvHuman.Size = new System.Drawing.Size(120, 384);
            this.tvHuman.TabIndex = 0;
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
            this.splitContainerMain.Panel2.Controls.Add(this.btnListEmployee);
            this.splitContainerMain.Panel2.Controls.Add(this.btnDelEmployee);
            this.splitContainerMain.Panel2.Controls.Add(this.btnModEmployee);
            this.splitContainerMain.Panel2.Controls.Add(this.btnAddEmployee);
            this.splitContainerMain.Panel2.Controls.Add(this.btnDelDept);
            this.splitContainerMain.Panel2.Controls.Add(this.btnModDept);
            this.splitContainerMain.Panel2.Controls.Add(this.btnAddDept);
            this.splitContainerMain.Size = new System.Drawing.Size(592, 384);
            this.splitContainerMain.SplitterDistance = 258;
            this.splitContainerMain.SplitterWidth = 1;
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
            this.splitContainerData.TabIndex = 2;
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
            // btnListEmployee
            // 
            this.btnListEmployee.Location = new System.Drawing.Point(14, 244);
            this.btnListEmployee.Name = "btnListEmployee";
            this.btnListEmployee.Size = new System.Drawing.Size(86, 38);
            this.btnListEmployee.TabIndex = 6;
            this.btnListEmployee.Text = "查看员工列表";
            this.btnListEmployee.UseVisualStyleBackColor = true;
            // 
            // btnDelEmployee
            // 
            this.btnDelEmployee.Location = new System.Drawing.Point(232, 186);
            this.btnDelEmployee.Name = "btnDelEmployee";
            this.btnDelEmployee.Size = new System.Drawing.Size(86, 38);
            this.btnDelEmployee.TabIndex = 5;
            this.btnDelEmployee.Text = "删除员工";
            this.btnDelEmployee.UseVisualStyleBackColor = true;
            // 
            // btnModEmployee
            // 
            this.btnModEmployee.Location = new System.Drawing.Point(123, 186);
            this.btnModEmployee.Name = "btnModEmployee";
            this.btnModEmployee.Size = new System.Drawing.Size(86, 38);
            this.btnModEmployee.TabIndex = 4;
            this.btnModEmployee.Text = "修改员工";
            this.btnModEmployee.UseVisualStyleBackColor = true;
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Location = new System.Drawing.Point(14, 186);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(86, 38);
            this.btnAddEmployee.TabIndex = 3;
            this.btnAddEmployee.Text = "添加员工";
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            // 
            // btnDelDept
            // 
            this.btnDelDept.Location = new System.Drawing.Point(232, 103);
            this.btnDelDept.Name = "btnDelDept";
            this.btnDelDept.Size = new System.Drawing.Size(86, 38);
            this.btnDelDept.TabIndex = 2;
            this.btnDelDept.Text = "删除部门";
            this.btnDelDept.UseVisualStyleBackColor = true;
            // 
            // btnModDept
            // 
            this.btnModDept.Location = new System.Drawing.Point(123, 103);
            this.btnModDept.Name = "btnModDept";
            this.btnModDept.Size = new System.Drawing.Size(86, 38);
            this.btnModDept.TabIndex = 1;
            this.btnModDept.Text = "修改部门";
            this.btnModDept.UseVisualStyleBackColor = true;
            this.btnModDept.Click += new System.EventHandler(this.btnModDept_Click);
            // 
            // btnAddDept
            // 
            this.btnAddDept.Location = new System.Drawing.Point(14, 103);
            this.btnAddDept.Name = "btnAddDept";
            this.btnAddDept.Size = new System.Drawing.Size(86, 38);
            this.btnAddDept.TabIndex = 0;
            this.btnAddDept.Text = "添加部门";
            this.btnAddDept.UseVisualStyleBackColor = true;
            this.btnAddDept.Click += new System.EventHandler(this.btnAddDept_Click);
            // 
            // humanManagementDataSet
            // 
            this.humanManagementDataSet.DataSetName = "HumanManagementDataSet";
            this.humanManagementDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // deptTableAdapter
            // 
            this.deptTableAdapter.ClearBeforeFill = true;
            // 
            // empTableAdapter
            // 
            this.empTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.deptTableAdapter = this.deptTableAdapter;
            this.tableAdapterManager.empTableAdapter = this.empTableAdapter;
            this.tableAdapterManager.UpdateOrder = BindingSourceSolution.HumanManagementDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // deptDetailTableAdapter
            // 
            this.deptDetailTableAdapter.ClearBeforeFill = true;
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
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainerData.Panel1.ResumeLayout(false);
            this.splitContainerData.Panel2.ResumeLayout(false);
            this.splitContainerData.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerData)).EndInit();
            this.splitContainerData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.humanManagementDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private HumanManagementDataSet humanManagementDataSet;
        private HumanManagementDataSetTableAdapters.deptTableAdapter deptTableAdapter;
        private HumanManagementDataSetTableAdapters.empTableAdapter empTableAdapter;
        private HumanManagementDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TreeView tvHuman;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerData;
        private System.Windows.Forms.TextBox txtHumanData;
        private System.Windows.Forms.Button btnListEmployee;
        private System.Windows.Forms.Button btnDelEmployee;
        private System.Windows.Forms.Button btnModEmployee;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.Button btnDelDept;
        private System.Windows.Forms.Button btnModDept;
        private System.Windows.Forms.Button btnAddDept;
        private HumanManagementDataSetTableAdapters.deptDetailTableAdapter deptDetailTableAdapter;
    }
}

