using BindingSourceSolution.Data;
using BindingSourceSolution.Util;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BindingSourceSolution
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            this.deptTableAdapter.Fill(this.humanManagementDataSet.dept);
            this.empTableAdapter.Fill(this.humanManagementDataSet.emp);
            this.deptDetailTableAdapter.Fill(this.humanManagementDataSet.deptDetail);
            this.empDetailTableAdapter.Fill(this.humanManagementDataSet.empDetail);
            CreateTreeNode();
            tvHuman.TopNode.ExpandAll();
        }

        #region 生成树型人员组织结构

        /// <summary>
        /// 生成公司节点并调用CreateSubDeptTreeNode() CreateEmpTreeNode()方法，生成树
        /// </summary>
        private void CreateTreeNode()
        {
            foreach (HumanManagementDataSet.deptRow row in this.humanManagementDataSet.dept.Select("parent_dept_no IS NULL"))
            {
                TreeNode deptTreeNode = new TreeNode()
                {
                    Text = row.dept_name,
                    Name = row.dept_no,
                    Tag = new DeptInfo(row.dept_no, row.dept_name, row.remarks, "公司")
                };
                tvHuman.Nodes.Add(deptTreeNode);
                CreateSubDeptTreeNode(deptTreeNode, deptTreeNode.Name);
                CreateEmpTreeNode(deptTreeNode, deptTreeNode.Name);
            }
        }

        /// <summary>
        /// 生成部门节点
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
            HumanManagementDataSet.empDataTable empDataTable = this.empTableAdapter.GetDataByDeptNo(deptNo);

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
            AddOrModDeptForm addDeptForm = new AddOrModDeptForm()
            {
                Text = btnAddDept.Text
            };

            DataRow dataRow = this.humanManagementDataSet.deptDetail.Select("dept_no = '" + selectedNode.Name + "'")[0];
            HumanManagementDataSet.deptDetailRow newDataRow = this.humanManagementDataSet.deptDetail.NewdeptDetailRow();
            
            newDataRow.ItemArray = new string[5] { "", "", "", dataRow["dept_no"].ToString(), dataRow["dept_name"].ToString() };
            this.humanManagementDataSet.deptDetail.Rows.Add(newDataRow);

            addDeptForm.deptDetailBindingSource.DataSource = newDataRow;

            if (addDeptForm.ShowDialog() == DialogResult.OK)
            {
                this.deptTableAdapter.Update(newDataRow);
                TreeNode newTreeNode = new TreeNode()
                {
                    Text = newDataRow.dept_name,
                    Name = newDataRow.dept_no,
                    Tag = new DeptInfo(newDataRow.dept_no, newDataRow.dept_name, newDataRow.remarks, "部门")
                };
                selectedNode.Nodes.Add(newTreeNode);
            }
            else
            {
                this.humanManagementDataSet.deptDetail.Rows.Remove(newDataRow);
            }
        }

        private void btnModDept_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvHuman.SelectedNode;

            AddOrModDeptForm modDeptForm = new AddOrModDeptForm()
            {
                Text = btnModDept.Text
            };

            DataRow[] dataRows = this.humanManagementDataSet.deptDetail.Select("dept_no = '" + selectedNode.Name + "'");

            modDeptForm.deptDetailBindingSource.DataSource = dataRows;

            if (modDeptForm.ShowDialog() == DialogResult.OK)
            {
                this.deptTableAdapter.Update(dataRows);
            }
        }

        private void btnDelDept_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvHuman.SelectedNode;

            HumanManagementDataSet.deptRow dataRow = this.humanManagementDataSet.dept.Select("dept_no = '" + selectedNode.Name + "'")[0] as HumanManagementDataSet.deptRow;

            if (MessageBox.Show("是否删除 " + selectedNode.Text + " 节点", "请确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.deptTableAdapter.Delete(dataRow.dept_no, dataRow.dept_name, dataRow.remarks, dataRow.parent_dept_no);
                this.tableAdapterManager.UpdateAll(this.humanManagementDataSet);
                selectedNode.Remove();
            }
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvHuman.SelectedNode;
            AddOrModEmpForm addEmpForm = new AddOrModEmpForm()
            {
                Text = btnAddDept.Text
            };

            DataRow dataRow = this.humanManagementDataSet.deptDetail.Select("dept_no = '" + selectedNode.Name + "'")[0];
            HumanManagementDataSet.empDetailRow newDataRow = this.humanManagementDataSet.empDetail.NewempDetailRow();
            newDataRow.ItemArray = new object[8] { "", "", "", DBNull.Value, "", DBNull.Value, dataRow["dept_no"].ToString(), dataRow["dept_name"].ToString() };
            this.humanManagementDataSet.empDetail.Rows.Add(newDataRow);
           
            addEmpForm.empDetailBindingSource.DataSource = newDataRow;

            if (addEmpForm.ShowDialog() == DialogResult.OK)
            {
                this.empTableAdapter.Update(newDataRow);
                TreeNode newTreeNode = new TreeNode()
                {
                    Text = newDataRow.emp_name,
                    Name = newDataRow.emp_no,
                    Tag = new EmpInfo(newDataRow.emp_no, newDataRow.emp_name, newDataRow.idcard_no, newDataRow.birthday.ToString("yyyy-MM-dd"), newDataRow.birthplace, newDataRow.entry_time.ToString("yyyy-MM-dd"), "员工")
                };
                selectedNode.Nodes.Add(newTreeNode);
            }
            else
            {
                this.humanManagementDataSet.empDetail.Rows.Remove(newDataRow);
            }
        }

        private void btnModEmployee_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvHuman.SelectedNode;

            AddOrModEmpForm modEmpForm = new AddOrModEmpForm()
            {
                Text = btnModDept.Text
            };

            DataRow[] dataRows = this.humanManagementDataSet.empDetail.Select("emp_no = '" + selectedNode.Name + "'");

            modEmpForm.empDetailBindingSource.DataSource = dataRows;

            if (modEmpForm.ShowDialog() == DialogResult.OK)
            {
                this.empTableAdapter.Update(dataRows);
            }
        }

        private void btnDelEmployee_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvHuman.SelectedNode;

            HumanManagementDataSet.empRow dataRow = this.humanManagementDataSet.emp.Select("emp_no = '" + selectedNode.Name + "'")[0] as HumanManagementDataSet.empRow;

            if (MessageBox.Show("是否删除 " + selectedNode.Text + " 节点", "请确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.empTableAdapter.Delete(dataRow.emp_no, dataRow.emp_name, dataRow.idcard_no, dataRow.birthday, dataRow.birthplace, dataRow.entry_time, dataRow.dept_no);
                this.tableAdapterManager.UpdateAll(this.humanManagementDataSet);
                selectedNode.Remove();
            }
        }
    }
}
