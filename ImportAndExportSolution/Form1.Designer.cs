namespace ImportAndExportSolution
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode113 = new System.Windows.Forms.TreeNode("管理组");
            System.Windows.Forms.TreeNode treeNode114 = new System.Windows.Forms.TreeNode("陈部长");
            System.Windows.Forms.TreeNode treeNode115 = new System.Windows.Forms.TreeNode("管理部", new System.Windows.Forms.TreeNode[] {
            treeNode113,
            treeNode114});
            System.Windows.Forms.TreeNode treeNode116 = new System.Windows.Forms.TreeNode("梁工");
            System.Windows.Forms.TreeNode treeNode117 = new System.Windows.Forms.TreeNode("龚工");
            System.Windows.Forms.TreeNode treeNode118 = new System.Windows.Forms.TreeNode("系统组", new System.Windows.Forms.TreeNode[] {
            treeNode116,
            treeNode117});
            System.Windows.Forms.TreeNode treeNode119 = new System.Windows.Forms.TreeNode("谭工");
            System.Windows.Forms.TreeNode treeNode120 = new System.Windows.Forms.TreeNode("陈工");
            System.Windows.Forms.TreeNode treeNode121 = new System.Windows.Forms.TreeNode("网络组", new System.Windows.Forms.TreeNode[] {
            treeNode119,
            treeNode120});
            System.Windows.Forms.TreeNode treeNode122 = new System.Windows.Forms.TreeNode("李部长");
            System.Windows.Forms.TreeNode treeNode123 = new System.Windows.Forms.TreeNode("运维部", new System.Windows.Forms.TreeNode[] {
            treeNode118,
            treeNode121,
            treeNode122});
            System.Windows.Forms.TreeNode treeNode124 = new System.Windows.Forms.TreeNode("向工");
            System.Windows.Forms.TreeNode treeNode125 = new System.Windows.Forms.TreeNode("黄工");
            System.Windows.Forms.TreeNode treeNode126 = new System.Windows.Forms.TreeNode("开发1组", new System.Windows.Forms.TreeNode[] {
            treeNode124,
            treeNode125});
            System.Windows.Forms.TreeNode treeNode127 = new System.Windows.Forms.TreeNode("庄工");
            System.Windows.Forms.TreeNode treeNode128 = new System.Windows.Forms.TreeNode("开发2组", new System.Windows.Forms.TreeNode[] {
            treeNode127});
            System.Windows.Forms.TreeNode treeNode129 = new System.Windows.Forms.TreeNode("内部", new System.Windows.Forms.TreeNode[] {
            treeNode126,
            treeNode128});
            System.Windows.Forms.TreeNode treeNode130 = new System.Windows.Forms.TreeNode("陈工");
            System.Windows.Forms.TreeNode treeNode131 = new System.Windows.Forms.TreeNode("外部", new System.Windows.Forms.TreeNode[] {
            treeNode130});
            System.Windows.Forms.TreeNode treeNode132 = new System.Windows.Forms.TreeNode("欧部长");
            System.Windows.Forms.TreeNode treeNode133 = new System.Windows.Forms.TreeNode("开发部", new System.Windows.Forms.TreeNode[] {
            treeNode129,
            treeNode131,
            treeNode132});
            System.Windows.Forms.TreeNode treeNode134 = new System.Windows.Forms.TreeNode("廖工");
            System.Windows.Forms.TreeNode treeNode135 = new System.Windows.Forms.TreeNode("内部", new System.Windows.Forms.TreeNode[] {
            treeNode134});
            System.Windows.Forms.TreeNode treeNode136 = new System.Windows.Forms.TreeNode("汤工");
            System.Windows.Forms.TreeNode treeNode137 = new System.Windows.Forms.TreeNode("外部", new System.Windows.Forms.TreeNode[] {
            treeNode136});
            System.Windows.Forms.TreeNode treeNode138 = new System.Windows.Forms.TreeNode("李部长");
            System.Windows.Forms.TreeNode treeNode139 = new System.Windows.Forms.TreeNode("项目部", new System.Windows.Forms.TreeNode[] {
            treeNode135,
            treeNode137,
            treeNode138});
            System.Windows.Forms.TreeNode treeNode140 = new System.Windows.Forms.TreeNode("新络软件", new System.Windows.Forms.TreeNode[] {
            treeNode115,
            treeNode123,
            treeNode133,
            treeNode139});
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(457, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "导出所选";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(538, 183);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "导出全部";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(72, 12);
            this.treeView1.Name = "treeView1";
            treeNode113.Name = "节点5";
            treeNode113.Text = "管理组";
            treeNode114.Name = "节点16";
            treeNode114.Text = "陈部长";
            treeNode115.Name = "节点1";
            treeNode115.Text = "管理部";
            treeNode116.Name = "节点28";
            treeNode116.Text = "梁工";
            treeNode117.Name = "节点29";
            treeNode117.Text = "龚工";
            treeNode118.Name = "节点6";
            treeNode118.Text = "系统组";
            treeNode119.Name = "节点26";
            treeNode119.Text = "谭工";
            treeNode120.Name = "节点27";
            treeNode120.Text = "陈工";
            treeNode121.Name = "节点7";
            treeNode121.Text = "网络组";
            treeNode122.Name = "节点17";
            treeNode122.Text = "李部长";
            treeNode123.Name = "节点2";
            treeNode123.Text = "运维部";
            treeNode124.Name = "节点23";
            treeNode124.Text = "向工";
            treeNode125.Name = "节点24";
            treeNode125.Text = "黄工";
            treeNode126.Name = "节点12";
            treeNode126.Text = "开发1组";
            treeNode127.Name = "节点25";
            treeNode127.Text = "庄工";
            treeNode128.Name = "节点13";
            treeNode128.Text = "开发2组";
            treeNode129.Name = "节点8";
            treeNode129.Text = "内部";
            treeNode130.Name = "节点22";
            treeNode130.Text = "陈工";
            treeNode131.Name = "节点9";
            treeNode131.Text = "外部";
            treeNode132.Name = "节点18";
            treeNode132.Text = "欧部长";
            treeNode133.Name = "节点3";
            treeNode133.Text = "开发部";
            treeNode134.Name = "节点21";
            treeNode134.Text = "廖工";
            treeNode135.Name = "节点10";
            treeNode135.Text = "内部";
            treeNode136.Name = "节点20";
            treeNode136.Text = "汤工";
            treeNode137.Name = "节点11";
            treeNode137.Text = "外部";
            treeNode138.Name = "节点19";
            treeNode138.Text = "李部长";
            treeNode139.Name = "节点4";
            treeNode139.Text = "项目部";
            treeNode140.Name = "节点0";
            treeNode140.Text = "新络软件";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode140});
            this.treeView1.Size = new System.Drawing.Size(347, 426);
            this.treeView1.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(457, 212);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "导入所选";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(538, 212);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "导入全部";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

