using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BindingSourceSolution
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.deptTableAdapter.Fill(this.humanManagementDataSet.dept);
            this.empTableAdapter.Fill(this.humanManagementDataSet.emp);
            this.deptDetailTableAdapter.Fill(this.humanManagementDataSet.deptDetail);
            CreateTreeNode();
        }

        #region 生成树型人员组织结构

        /// <summary>
        /// 生成公司节点、第一级部门节点，并调用CreateSubDeptTreeNode() CreateEmpTreeNode()方法，生成树
        /// </summary>
        private void CreateTreeNode()
        {

            foreach (HumanManagementDataSet.deptRow row in this.humanManagementDataSet.dept.Select("parent_dept_no IS NULL"))
            {
                TreeNode deptTreeNode = new TreeNode()
                {
                    Text = row.dept_name,
                    Name = row.dept_no,
                    //Tag = new DeptInfo(row.dept_no, row.dept_name, row.remarks, "部门")
                };
                tvHuman.Nodes.Add(deptTreeNode);
                CreateSubDeptTreeNode(deptTreeNode, deptTreeNode.Name);
            }
        }

        /// <summary>
        /// 生成子部门节点
        /// </summary>
        /// <param name="parent">生成的部门节点的父节点</param>
        /// <param name="parentDeptNo">部门节点的父部门编号</param>
        private void CreateSubDeptTreeNode(TreeNode parent, string parentDeptNo)
        {
            string select = "parent_dept_no ='" + parentDeptNo + "'";
            foreach (HumanManagementDataSet.deptRow row in this.humanManagementDataSet.dept.Select(select))
            {
                TreeNode deptTreeNode = new TreeNode()
                {
                    Text = row.dept_name,
                    Name = row.dept_no,
                    //Tag = new DeptInfo(row.dept_no, row.dept_name, row.remarks, "部门")
                };
                parent.Nodes.Add(deptTreeNode);
                CreateSubDeptTreeNode(deptTreeNode, deptTreeNode.Name);
                //CreateEmpTreeNode(deptTreeNode, deptTreeNode.Name);
            }
        }
        #endregion

        private void btnAddDept_Click(object sender, EventArgs e)
        {
            AddOrModDeptForm addOrModDeptForm = new AddOrModDeptForm();
            addOrModDeptForm.deptDetailBindingSource.DataSource = this.humanManagementDataSet.deptDetail;
            if (addOrModDeptForm.ShowDialog() == DialogResult.OK)
            {
                this.tableAdapterManager.UpdateAll(this.humanManagementDataSet);
            }
        }

        private void btnModDept_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvHuman.SelectedNode;

            AddOrModDeptForm addOrModDeptForm = new AddOrModDeptForm();
            DataRow[] dataRows = this.humanManagementDataSet.deptDetail.Select("dept_no = '" + selectedNode.Name + "'");
            addOrModDeptForm.deptDetailBindingSource.DataSource = dataRows;
            if (addOrModDeptForm.ShowDialog() == DialogResult.OK)
            {
                this.deptTableAdapter.Update(dataRows);
            }
        }
    }
}
