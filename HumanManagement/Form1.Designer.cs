using System.Data;
using HumanManagement.Data;
namespace HumanManagement
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("张三");
            HumanManagement.Data.EmployeeInfo employeeInfo1 = new HumanManagement.Data.EmployeeInfo();
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("王五");
            HumanManagement.Data.EmployeeInfo employeeInfo2 = new HumanManagement.Data.EmployeeInfo();
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("开发1组", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            HumanManagement.Data.DeptInfo deptInfo1 = new HumanManagement.Data.DeptInfo();
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("陈六");
            HumanManagement.Data.EmployeeInfo employeeInfo3 = new HumanManagement.Data.EmployeeInfo();
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("开发2组", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            HumanManagement.Data.DeptInfo deptInfo2 = new HumanManagement.Data.DeptInfo();
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("开发部", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode3,
            treeNode5});
            HumanManagement.Data.DeptInfo deptInfo3 = new HumanManagement.Data.DeptInfo();
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("李四");
            HumanManagement.Data.EmployeeInfo employeeInfo4 = new HumanManagement.Data.EmployeeInfo();
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("运维部", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            HumanManagement.Data.DeptInfo deptInfo4 = new HumanManagement.Data.DeptInfo();
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("新络软件", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode8});
            HumanManagement.Data.DeptInfo deptInfo5 = new HumanManagement.Data.DeptInfo();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "添加部门";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(122, 26);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 40);
            this.button2.TabIndex = 1;
            this.button2.Text = "修改部门";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(231, 26);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 40);
            this.button3.TabIndex = 2;
            this.button3.Text = "删除部门";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(13, 111);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(86, 40);
            this.button4.TabIndex = 5;
            this.button4.Text = "添加员工";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(122, 111);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(86, 40);
            this.button5.TabIndex = 4;
            this.button5.Text = "修改员工";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(231, 111);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(86, 40);
            this.button6.TabIndex = 3;
            this.button6.Text = "删除员工";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(13, 171);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(86, 40);
            this.button7.TabIndex = 6;
            this.button7.Text = "查看员工清单";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(13, 256);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(86, 40);
            this.button8.TabIndex = 7;
            this.button8.Text = "导出所选节点";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(122, 258);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(86, 40);
            this.button9.TabIndex = 8;
            this.button9.Text = "导出全部节点";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 10F);
            this.textBox1.Location = new System.Drawing.Point(82, 328);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(207, 23);
            this.textBox1.TabIndex = 9;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(231, 258);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(86, 40);
            this.button10.TabIndex = 11;
            this.button10.Text = "导入数据";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(289, 328);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(28, 23);
            this.button11.TabIndex = 10;
            this.button11.Text = "...";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点3";
            employeeInfo1.Birthday = "1997-11-06";
            employeeInfo1.Birthplace = "广东广州";
            employeeInfo1.DeptName = null;
            employeeInfo1.DeptNo = null;
            employeeInfo1.EmployeeName = "张三";
            employeeInfo1.EntryTime = "2019-01-11";
            employeeInfo1.IdCardNo = "441811199711064456";
            employeeInfo1.No = "G123456";
            employeeInfo1.TypeString = "员工";
            treeNode1.Tag = employeeInfo1;
            treeNode1.Text = "张三";
            treeNode2.Name = "节点1";
            employeeInfo2.Birthday = "1997-11-06";
            employeeInfo2.Birthplace = "广东广州";
            employeeInfo2.DeptName = null;
            employeeInfo2.DeptNo = null;
            employeeInfo2.EmployeeName = "王五";
            employeeInfo2.EntryTime = "2019-01-11";
            employeeInfo2.IdCardNo = "441811199711064456";
            employeeInfo2.No = "G3";
            employeeInfo2.TypeString = "员工";
            treeNode2.Tag = employeeInfo2;
            treeNode2.Text = "王五";
            treeNode3.Name = "节点0";
            deptInfo1.DeptName = "开发1组";
            deptInfo1.No = "Z1";
            deptInfo1.ParentDeptName = null;
            deptInfo1.ParentDeptNo = null;
            deptInfo1.Remarks = "1组";
            deptInfo1.TypeString = "部门";
            treeNode3.Tag = deptInfo1;
            treeNode3.Text = "开发1组";
            treeNode4.Name = "节点3";
            employeeInfo3.Birthday = null;
            employeeInfo3.Birthplace = null;
            employeeInfo3.DeptName = null;
            employeeInfo3.DeptNo = null;
            employeeInfo3.EmployeeName = "陈六";
            employeeInfo3.EntryTime = null;
            employeeInfo3.IdCardNo = null;
            employeeInfo3.No = "G4";
            employeeInfo3.TypeString = "员工";
            treeNode4.Tag = employeeInfo3;
            treeNode4.Text = "陈六";
            treeNode5.Name = "节点2";
            deptInfo2.DeptName = "开发2组";
            deptInfo2.No = "Z2";
            deptInfo2.ParentDeptName = null;
            deptInfo2.ParentDeptNo = null;
            deptInfo2.Remarks = "2组";
            deptInfo2.TypeString = "部门";
            treeNode5.Tag = deptInfo2;
            treeNode5.Text = "开发2组";
            treeNode6.Name = "节点1";
            deptInfo3.DeptName = "开发部";
            deptInfo3.No = "D1";
            deptInfo3.ParentDeptName = null;
            deptInfo3.ParentDeptNo = null;
            deptInfo3.Remarks = "开发";
            deptInfo3.TypeString = "部门";
            treeNode6.Tag = deptInfo3;
            treeNode6.Text = "开发部";
            treeNode7.Name = "节点4";
            employeeInfo4.Birthday = null;
            employeeInfo4.Birthplace = null;
            employeeInfo4.DeptName = null;
            employeeInfo4.DeptNo = null;
            employeeInfo4.EmployeeName = "李四";
            employeeInfo4.EntryTime = null;
            employeeInfo4.IdCardNo = null;
            employeeInfo4.No = "G2";
            employeeInfo4.TypeString = "员工";
            treeNode7.Tag = employeeInfo4;
            treeNode7.Text = "李四";
            treeNode8.Name = "节点2";
            deptInfo4.DeptName = "运维部";
            deptInfo4.No = "D2";
            deptInfo4.ParentDeptName = null;
            deptInfo4.ParentDeptNo = null;
            deptInfo4.Remarks = "运维";
            deptInfo4.TypeString = "部门";
            treeNode8.Tag = deptInfo4;
            treeNode8.Text = "运维部";
            treeNode9.Name = "节点0";
            deptInfo5.DeptName = "新络软件";
            deptInfo5.No = "C";
            deptInfo5.ParentDeptName = null;
            deptInfo5.ParentDeptNo = null;
            deptInfo5.Remarks = "公司";
            deptInfo5.TypeString = "公司";
            treeNode9.Tag = deptInfo5;
            treeNode9.Text = "新络软件";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9});
            this.treeView1.Size = new System.Drawing.Size(119, 384);
            this.treeView1.TabIndex = 13;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Location = new System.Drawing.Point(0, 0);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(138, 384);
            this.textBox2.TabIndex = 16;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.button2);
            this.splitContainer1.Panel2.Controls.Add(this.button3);
            this.splitContainer1.Panel2.Controls.Add(this.button10);
            this.splitContainer1.Panel2.Controls.Add(this.button6);
            this.splitContainer1.Panel2.Controls.Add(this.button11);
            this.splitContainer1.Panel2.Controls.Add(this.button5);
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Panel2.Controls.Add(this.button4);
            this.splitContainer1.Panel2.Controls.Add(this.button9);
            this.splitContainer1.Panel2.Controls.Add(this.button7);
            this.splitContainer1.Panel2.Controls.Add(this.button8);
            this.splitContainer1.Size = new System.Drawing.Size(593, 384);
            this.splitContainer1.SplitterDistance = 258;
            this.splitContainer1.TabIndex = 17;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.textBox2);
            this.splitContainer2.Size = new System.Drawing.Size(258, 384);
            this.splitContainer2.SplitterDistance = 119;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 332);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "导入数据：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 384);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "人员管理窗口";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label1;
    }
}

