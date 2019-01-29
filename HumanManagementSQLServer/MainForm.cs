using HumanManagementSQLServer.Data;
using HumanManagementSQLServer.DataSource;
using HumanManagementSQLServer.Util;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HumanManagementSQLServer

{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 与子窗体交换数据的委托
        /// </summary>
        /// <param name="data">传送给子窗体的数据</param>
        /// <returns>子窗体返回的数据</returns>
        internal delegate void ExchangeDataHandler(object data);
        internal ExchangeDataHandler exchangeDataHandler;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CreateTreeNode();
        }

        #region 生成树型人员组织结构

        /// <summary>
        /// 生成公司节点、第一级部门节点，并调用CreateSubDeptTreeNode() CreateEmpTreeNode()方法，生成树
        /// </summary>
        private void CreateTreeNode()
        {
            // 添加公司节点
            TreeNode companyTreeNode = new TreeNode()
            {
                Text = HumanManagementData.CompanyTable.Rows[0]["company_name"].ToString(),
                Name = HumanManagementData.CompanyTable.Rows[0]["company_no"].ToString(),
                Tag = new DeptInfo(HumanManagementData.CompanyTable.Rows[0]["company_no"].ToString(), HumanManagementData.CompanyTable.Rows[0]["company_name"].ToString(), HumanManagementData.CompanyTable.Rows[0]["remarks"].ToString(), "公司")
            };
            tvHuman.Nodes.Add(companyTreeNode);

            // 添加第一级部门节点
            HumanManagementDataSet.deptDataTable deptDataTable = HumanManagementData.DeptTableAdapter.GetDataByParentIsNull();

            foreach (HumanManagementDataSet.deptRow row in deptDataTable.Rows)
            {
                TreeNode deptTreeNode = new TreeNode()
                {
                    Text = row.dept_name,
                    Name = row.dept_no,
                    Tag = new DeptInfo(row.dept_no, row.dept_name, row.remarks, "部门")
                };
                companyTreeNode.Nodes.Add(deptTreeNode);

                CreateSubDeptTreeNode(deptTreeNode, deptTreeNode.Name);
                CreateEmpTreeNode(deptTreeNode, deptTreeNode.Name);
            }
        }

        /// <summary>
        /// 生成子部门节点
        /// </summary>
        /// <param name="parent">生成的部门节点的父节点</param>
        /// <param name="parentDeptNo">部门节点的父部门编号</param>
        private void CreateSubDeptTreeNode(TreeNode parent, string parentDeptNo)
        {
            HumanManagementDataSet.deptDataTable deptDataTable = HumanManagementData.DeptTableAdapter.GetDataByParent(parentDeptNo);

            foreach (HumanManagementDataSet.deptRow row in deptDataTable.Rows)
            {
                TreeNode deptTreeNode = new TreeNode()
                {
                    Text = row.dept_name,
                    Name = row.dept_no,
                    Tag = new DeptInfo(row.dept_no, row.dept_name, row.remarks, "部门")
                };
                parent.Nodes.Add(deptTreeNode);
                CreateSubDeptTreeNode(deptTreeNode, deptTreeNode.Name);
                CreateEmpTreeNode(deptTreeNode, deptTreeNode.Name);
            }
        }

        /// <summary>
        /// 生成员工节点
        /// </summary>
        /// <param name="parent">生成的员工节点的父节点</param>
        /// <param name="deptNo">员工所在的部门编号</param>
        private void CreateEmpTreeNode(TreeNode parent, string deptNo)
        {
            HumanManagementDataSet.empDataTable empDataTable = HumanManagementData.EmpTableAdapter.GetDataByDeptNo(deptNo);

            foreach (HumanManagementDataSet.empRow row in empDataTable.Rows)
            {
                TreeNode empTreeNode = new TreeNode()
                {
                    Text = row.emp_name,
                    Name = row.emp_no,
                    ForeColor = Color.Green,
                    Tag = new EmpInfo(row.emp_no, row.emp_name, row.idcard_no, row.birthday.ToString("yyyy-MM-dd"), row.birthplace, row.entry_time.ToString("yyyy-MM-dd"), "员工")
                };
                parent.Nodes.Add(empTreeNode);
            }
        }

        #endregion

        private void tvHuman_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = tvHuman.SelectedNode;
            if (NodeTypeUtil.IsDept(selectedNode))
            {
                DeptInfo deptInfo = (DeptInfo)selectedNode.Tag;
                txtHumanData.Text = deptInfo.ToString();

                //修改按钮的 Enabled 属性，启用属于部门功能的按钮，禁用输入员工功能的按钮
                btnAddDept.Enabled = true;
                btnModDept.Enabled = true;
                btnDelDept.Enabled = true;
                btnAddEmployee.Enabled = true;
                btnModEmployee.Enabled = false;
                btnDelEmployee.Enabled = false;
                btnListEmployee.Enabled = true;
            }
            if (NodeTypeUtil.IsEmployee(selectedNode))
            {
                EmpInfo employeeInfo = (EmpInfo)selectedNode.Tag;
                txtHumanData.Text = employeeInfo.ToString();

                //修改按钮的Enabled属性，启用修改员工按钮和删除员工按钮，禁用所有功能的按钮
                btnAddDept.Enabled = false;
                btnModDept.Enabled = false;
                btnDelDept.Enabled = false;
                btnAddEmployee.Enabled = false;
                btnModEmployee.Enabled = true;
                btnDelEmployee.Enabled = true;
                btnListEmployee.Enabled = false;
            }
            if (NodeTypeUtil.IsCompany(selectedNode))
            {
                DeptInfo deptInfo = (DeptInfo)selectedNode.Tag;
                txtHumanData.Text = deptInfo.ToString();

                //修改按钮的Enabled属性，启用添加部门按钮，禁用其他按钮
                btnAddDept.Enabled = true;
                btnModDept.Enabled = false;
                btnDelDept.Enabled = false;
                btnAddEmployee.Enabled = false;
                btnModEmployee.Enabled = false;
                btnDelEmployee.Enabled = false;
                btnListEmployee.Enabled = false;
            }
        }

        private void btnAddDept_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvHuman.SelectedNode;

            //创建添加部门窗体
            AddOrModDeptForm addDeptForm = new AddOrModDeptForm
            {
                Owner = this,
                Text = btnAddDept.Text
            };

            //把 addDeptForm.ExchangeDataHandler 方法添加到 exchangeDataHandler 委托中
            exchangeDataHandler = new ExchangeDataHandler(addDeptForm.ExchangeDataHandler);

            //要传给 addDeptForm 对象的数据
            DeptInfo deptInfo = new DeptInfo
            {
                ParentDeptNo = ((DeptInfo)selectedNode.Tag).No,
                ParentDeptName = selectedNode.Text
            };

            exchangeDataHandler(deptInfo);

            //如果在 addDeptForm 添加部门窗体中点击确定，则在所选的节点下添加部门
            if (addDeptForm.ShowDialog() == DialogResult.OK)
            {
                TreeNode newTreeNode = new TreeNode
                {
                    Text = addDeptForm.DeptInfo.DeptName,
                    Tag = addDeptForm.DeptInfo
                };
                selectedNode.Nodes.Add(newTreeNode);
            }
        }
    }
}
