using HumanManagementSQLServer.Data;
using HumanManagementSQLServer.Util;
using System;
using System.Collections.Generic;
using System.Data;
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

        internal static DataSet dataSet = new DataSet();
        DataTable deptTable = SqlHelper.GetTable("SELECT dept_no, dept_name, remarks, parent_dept_no FROM dept", "dept");
        DataTable deptDetailTable = SqlHelper.GetTable("SELECT dept.dept_no, dept.dept_name, dept.remarks, dept.parent_dept_no, dept_1.dept_name AS parent_dept_name FROM dept LEFT OUTER JOIN dept AS dept_1 ON dept.parent_dept_no = dept_1.dept_no", "detpDetail");
        DataTable empTable = SqlHelper.GetTable("SELECT emp_no, emp_name, idcard_no, birthday, birthplace, entry_time, dept_no FROM dbo.emp", "emp");
        DataTable empDetailTable = SqlHelper.GetTable("SELECT emp.emp_no, emp.emp_name, emp.idcard_no, emp.birthday, emp.birthplace, emp.entry_time, emp.dept_no, dept.dept_name FROM emp LEFT OUTER JOIN dept ON emp.dept_no = dept.dept_no", "empDetail");

        public MainForm()
        {
            InitializeComponent();
            InitForm();
        }

        private void InitForm()
        {
            dataSet.Tables.Add(deptTable);
            dataSet.Tables.Add(deptDetailTable);
            dataSet.Tables.Add(empTable);
            dataSet.Tables.Add(empDetailTable);

            CreateTreeNode();
            tvHuman.ExpandAll();
        }

        #region 生成树型人员组织结构

        /// <summary>
        /// 生成公司节点并调用CreateSubDeptTreeNode() CreateEmpTreeNode()方法，生成树
        /// </summary>
        private void CreateTreeNode()
        {
            foreach (DataRow row in this.deptTable.Select("parent_dept_no IS NULL"))
            {
                TreeNode deptTreeNode = new TreeNode()
                {
                    Text = row["dept_name"].ToString(),
                    Name = row["dept_no"].ToString(),
                    Tag = new DeptInfo(row["dept_no"].ToString(), row["dept_name"].ToString(), row["remarks"].ToString(), "公司")
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
            foreach (DataRow row in this.deptTable.Select("parent_dept_no ='" + parentDeptNo + "'"))
            {
                TreeNode deptTreeNode = new TreeNode()
                {
                    Text = row["dept_name"].ToString(),
                    Name = row["dept_no"].ToString(),
                    Tag = new DeptInfo(row["dept_no"].ToString(), row["dept_name"].ToString(), row["remarks"].ToString(), "部门")
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
            foreach (DataRow row in this.empTable.Select("dept_no = '" + deptNo + "'"))
            {
                TreeNode empTreeNode = new TreeNode()
                {
                    Text = row["emp_name"].ToString(),
                    Name = row["emp_no"].ToString(),
                    ForeColor = Color.Green,
                    Tag = new EmpInfo(row["emp_no"].ToString(), row["emp_name"].ToString(), row["idcard_no"].ToString(), ((DateTime)row["birthday"]).ToString("yyyy-MM-dd"), row["birthplace"].ToString(), ((DateTime)row["entry_time"]).ToString("yyyy-MM-dd"), "员工")
                };
                parent.Nodes.Add(empTreeNode);
            }
        }
        #endregion

        /// <summary>
        /// 选择 tvHuman 控件中的节点后，在 txtHumanData 控件中显示该节点信息，并更改按钮的启用属性。
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TreeViewEventArgs"/> instance containing the event data.</param>
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
                EmpInfo empInfo = (EmpInfo)selectedNode.Tag;
                txtHumanData.Text = empInfo.ToString();

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

        // TODO 完成
        private void btnAddDept_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvHuman.SelectedNode;

            //创建添加部门窗体
            AddOrModDeptForm addDeptForm = new AddOrModDeptForm
            {
                Owner = this,
                Text = btnAddDept.Text
            };

            addDeptForm.ParentDeptNo = selectedNode.Name;
            addDeptForm.ParentDeptName = (selectedNode.Tag as DeptInfo).DeptName;

            //如果在 addDeptForm 添加部门窗体中点击确定，则在所选的节点下添加部门
            if (addDeptForm.ShowDialog() == DialogResult.OK)
            {
                DeptInfo deptInfo = addDeptForm.DeptInfo;
                TreeNode newTreeNode = new TreeNode
                {
                    Text = deptInfo.DeptName,
                    Name = deptInfo.No,
                    Tag = new DeptInfo(deptInfo.No, deptInfo.DeptName, deptInfo.Remarks, "部门")
                };

                List<string> valueList = new List<string>();
                valueList.Add("dept_no = '" + deptInfo.No + "'");
                valueList.Add("dept_name = '" + deptInfo.DeptName + "'");
                valueList.Add("remarks = '" + deptInfo.Remarks + "'");
                valueList.Add("parent_dept_no = '" + selectedNode.Name + "'");
                // TODO 异常处理
                SqlHelper.AddRow("dept", valueList);

                selectedNode.Nodes.Add(newTreeNode);
            }
        }

        /// <summary>
        /// 修改部门按钮点击事件，用于 修改部门。
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnModDept_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvHuman.SelectedNode;

            //创建修改部门窗体
            AddOrModDeptForm modDeptForm = new AddOrModDeptForm
            {
                Owner = this,
                Text = btnModDept.Text
            };

            DataTable dataTable = SqlHelper.GetTable("dept LEFT OUTER JOIN dept AS dept_1 ON dept.parent_dept_no = dept_1.dept_no", "dept.dept_no AS DeptNo, dept.dept_name AS DeptName, dept.remarks AS Remarks, dept.parent_dept_no AS ParentDeptNo, dept_1.dept_name AS ParentDeptName", "dept.dept_no = '" + selectedNode.Name + "'");
            modDeptForm.DataTable = dataTable;

            //如果在 modDeptForm 修改部门窗体中点击确定，则在修改部门信息
            if (modDeptForm.ShowDialog() == DialogResult.OK)
            {
                DataRow dataRow = modDeptForm.DataTable.Rows[0];

                List<string> valueList = new List<string>();
                valueList.Add("dept_no = '" + dataRow["DeptNo"].ToString() + "'");
                valueList.Add("dept_name = '" + dataRow["DeptName"].ToString() + "'");
                valueList.Add("remarks = '" + dataRow["Remarks"].ToString() + "'");
                // TODO 异常处理
                SqlHelper.Update("dept", valueList, "dept.dept_no = '" + selectedNode.Name + "'");

                selectedNode.Text = dataRow["DeptName"].ToString();
                selectedNode.Tag = new DeptInfo(dataRow["DeptNo"].ToString(), dataRow["DeptName"].ToString(), dataRow["Remarks"].ToString(), "部门");

                //修改完成后，触发 tvHuman_AfterSelect 事件，以在 tvHuman 控件中显示修改完成后的数据。
                tvHuman_AfterSelect(sender, null);
            }
        }

        /// <summary>
        /// 删除部门按钮点击事件，用于 删除部门。
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnDelDept_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvHuman.SelectedNode;

            if (MessageBox.Show("是否删除 " + selectedNode.Text + " 节点", "请确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                SqlHelper.Delete("dept", "dept_no = '" + selectedNode.Name + "'");
                selectedNode.Remove();
            }
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvHuman.SelectedNode;
            //创建添加员工窗体
            AddOrModEmpForm addEmpform = new AddOrModEmpForm
            {
                Owner = this,
                Text = btnModEmployee.Text
            };

            DataTable dataTable = SqlHelper.GetTable("SELECT TOP 0 emp.emp_no AS EmpNo, emp.emp_name AS EmployeeName, emp.idcard_no AS IdCardNo, emp.birthday AS Birthday, emp.birthplace AS Birthplace, emp.entry_time AS EntryTime, dept.dept_no AS DeptNo, dept.dept_name AS DeptName FROM dept LEFT OUTER JOIN emp ON dept.dept_no = emp.dept_no", "dept");
            DataRow newDataRow = dataTable.NewRow();
            newDataRow["DeptNo"] = selectedNode.Name;
            newDataRow["DeptName"] = ((DeptInfo)selectedNode.Tag).DeptName;
            dataTable.Rows.Add(newDataRow);

            addEmpform.DataTable = dataTable;

            if (addEmpform.ShowDialog() == DialogResult.OK)
            {
                DataRow dataRow = addEmpform.DataTable.Rows[0];
                TreeNode newTreeNode = new TreeNode
                {
                    Text = dataRow["EmployeeName"].ToString(),
                    Name = dataRow["EmpNo"].ToString(),
                    ForeColor = Color.Green,
                    Tag = new EmpInfo(dataRow["EmpNo"].ToString(), dataRow["EmployeeName"].ToString(), dataRow["IdCardNo"].ToString(), dataRow["Birthday"].ToString(), dataRow["Birthplace"].ToString(), dataRow["EntryTime"].ToString(), "员工")
                };

                List<string> valueList = new List<string>();
                valueList.Add("emp_no = '" + dataRow["EmpNo"].ToString() + "'");
                valueList.Add("emp_name = '" + dataRow["EmployeeName"].ToString() + "'");
                valueList.Add("idcard_no = '" + dataRow["IdCardNo"].ToString() + "'");
                valueList.Add("birthday = '" + dataRow["Birthday"].ToString() + "'");
                valueList.Add("birthplace = '" + dataRow["Birthplace"].ToString() + "'");
                valueList.Add("entry_time = '" + dataRow["EntryTime"].ToString() + "'");
                valueList.Add("dept_no = '" + selectedNode.Name + "'");
                // TODO 异常处理
                SqlHelper.AddRow("emp", valueList);

                selectedNode.Nodes.Add(newTreeNode);
            }
        }

        private void btnModEmployee_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvHuman.SelectedNode;

            //创建修改员工窗体
            AddOrModEmpForm modEmpform = new AddOrModEmpForm
            {
                Owner = this,
                Text = btnModEmployee.Text
            };

            DataTable dataTable = SqlHelper.GetTable("emp LEFT OUTER JOIN dept ON emp.dept_no = dept.dept_no", "emp.emp_no AS EmpNo, emp.emp_name AS EmployeeName, emp.idcard_no AS IdCardNo, emp.birthday AS Birthday, emp.birthplace AS Birthplace, emp.entry_time AS EntryTime, emp.dept_no AS DeptNo, dept.dept_name AS DeptName", "emp.emp_no = '" + selectedNode.Name + "'");
            modEmpform.DataTable = dataTable;

            //如果在 modEmployeeform 添加员工窗体中点击确定，则在添加员工节点到所选节点中
            if (modEmpform.ShowDialog() == DialogResult.OK)
            {
                DataRow dataRow = modEmpform.DataTable.Rows[0];

                List<string> valueList = new List<string>();
                valueList.Add("emp_no = '" + dataRow["EmpNo"].ToString() + "'");
                valueList.Add("emp_name = '" + dataRow["EmployeeName"].ToString() + "'");
                valueList.Add("idcard_no = '" + dataRow["IdCardNo"].ToString() + "'");
                valueList.Add("birthday = '" + dataRow["Birthday"].ToString() + "'");
                valueList.Add("birthplace = '" + dataRow["Birthplace"].ToString() + "'");
                valueList.Add("entry_time = '" + dataRow["EntryTime"].ToString() + "'");
                valueList.Add("dept_no = '" + dataRow["DeptNo"].ToString() + "'");
                // TODO 异常处理
                SqlHelper.Update("emp", valueList, "emp.emp_no = '" + selectedNode.Name + "'");

                selectedNode.Text = dataRow["EmployeeName"].ToString();
                selectedNode.Tag = new EmpInfo(dataRow["EmpNo"].ToString(), dataRow["EmployeeName"].ToString(), dataRow["IdCardNo"].ToString(), dataRow["Birthday"].ToString(), dataRow["Birthplace"].ToString(), dataRow["EntryTime"].ToString(), "员工");

                //修改完成后，触发 tvHuman_AfterSelect 事件，以在 tvHuman 控件中显示修改完成后的数据。
                tvHuman_AfterSelect(sender, null);
            }
        }

        private void btnDelEmployee_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvHuman.SelectedNode;

            if (MessageBox.Show("是否删除 " + selectedNode.Text + " 节点", "请确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                SqlHelper.Delete("emp", "emp_no = '" + selectedNode.Name + "'");
                selectedNode.Remove();
            }
        }

        private void btnListEmployee_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvHuman.SelectedNode;

            //创建查看员工清单窗体
            ListAndDeleteEmpForm listAndDeleteEmpForm = new ListAndDeleteEmpForm()
            {
                Owner = this
            };

            DataTable dataTable = SqlHelper.GetTable("emp LEFT OUTER JOIN dept ON emp.dept_no = dept.dept_no", "emp.emp_no AS EmpNo, emp.emp_name AS EmployeeName, emp.idcard_no AS IdCardNo, emp.birthday AS Birthday, emp.birthplace AS Birthplace, emp.entry_time AS EntryTime, emp.dept_no AS DeptNo, dept.dept_name AS DeptName", "dept.dept_no = '" + selectedNode.Name + "'");
            listAndDeleteEmpForm.DataTable = dataTable;

            //把 modEmployeeform.ExchangeDataHandler 方法添加到 exchangeDataHandler 委托中
            exchangeDataHandler = new ExchangeDataHandler(listAndDeleteEmpForm.ExchangeDataHandler);

            //要传给 modEmployeeform 对象的数据
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("No", ((DeptInfo)selectedNode.Tag).No);
            data.Add("DeptName", selectedNode.Text);

            exchangeDataHandler(data);

            listAndDeleteEmpForm.ShowDialog();

            //从 listAndDeleteEmpForm 窗体中返回被删除的节点索引列表
            List<string> deletedTreeNodeKeyList = listAndDeleteEmpForm.DeletedTreeNodeKeyList;

            //根据节点索引列表删除节点
            if (deletedTreeNodeKeyList.Count != 0)
            {
                foreach (string key in deletedTreeNodeKeyList)
                {
                    SqlHelper.Delete("emp", "emp_no = '" + key + "'");
                    selectedNode.Nodes.RemoveByKey(key);
                }
            }
        }
    }
}
