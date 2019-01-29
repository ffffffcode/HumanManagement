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
            this.button1 = new System.Windows.Forms.Button();
            this.humanManagementDataSet = new BindingSourceSolution.HumanManagementDataSet();
            this.companyTableAdapter = new BindingSourceSolution.HumanManagementDataSetTableAdapters.companyTableAdapter();
            this.deptTableAdapter = new BindingSourceSolution.HumanManagementDataSetTableAdapters.deptTableAdapter();
            this.empTableAdapter = new BindingSourceSolution.HumanManagementDataSetTableAdapters.empTableAdapter();
            this.tableAdapterManager = new BindingSourceSolution.HumanManagementDataSetTableAdapters.TableAdapterManager();
            this.tvHuman = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.humanManagementDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(335, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // humanManagementDataSet
            // 
            this.humanManagementDataSet.DataSetName = "HumanManagementDataSet";
            this.humanManagementDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // companyTableAdapter
            // 
            this.companyTableAdapter.ClearBeforeFill = true;
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
            this.tableAdapterManager.companyTableAdapter = this.companyTableAdapter;
            this.tableAdapterManager.deptTableAdapter = this.deptTableAdapter;
            this.tableAdapterManager.empTableAdapter = this.empTableAdapter;
            this.tableAdapterManager.UpdateOrder = BindingSourceSolution.HumanManagementDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tvHuman
            // 
            this.tvHuman.Location = new System.Drawing.Point(12, 12);
            this.tvHuman.Name = "tvHuman";
            this.tvHuman.Size = new System.Drawing.Size(198, 364);
            this.tvHuman.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tvHuman);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "人员管理";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.humanManagementDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private HumanManagementDataSet humanManagementDataSet;
        private HumanManagementDataSetTableAdapters.companyTableAdapter companyTableAdapter;
        private HumanManagementDataSetTableAdapters.deptTableAdapter deptTableAdapter;
        private HumanManagementDataSetTableAdapters.empTableAdapter empTableAdapter;
        private HumanManagementDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TreeView tvHuman;
    }
}

