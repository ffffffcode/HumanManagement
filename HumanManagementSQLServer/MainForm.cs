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
        internal static DataSet dataSet = new DataSet();
        DataTable deptTable = SqlHelper.GetTable("SELECT dept_no, dept_name, remarks, parent_dept_no FROM dept", "dept");
        DataTable empTable = SqlHelper.GetTable("SELECT emp_no, emp_name, idcard_no, birthday, birthplace, entry_time, dept_no FROM emp", "emp");

        public MainForm()
        {
            InitializeComponent();
            InitForm();
        }

        private void InitForm()
        {
            dataSet.Tables.Add(deptTable);
            dataSet.Tables.Add(empTable);
            // 生成树
            CreateTreeNode();
            tvHuman.ExpandAll();
        }

        #region 生成树型人员组织结构

        /// <summary>
        /// 生成公司节点并调用CreateSubDeptTreeNode() CreateEmpTreeNode()方法，生成树
        /// </summary>
        private void CreateTreeNode()
        {
            foreach (DataRow row in deptTable.Select("parent_dept_no IS NULL"))
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
            foreach (DataRow row in deptTable.Select("parent_dept_no ='" + parentDeptNo + "'"))
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
            foreach (DataRow row in empTable.Select("dept_no = '" + deptNo + "'"))
            {
                TreeNode empTreeNode = new TreeNode()
                {
                    Text = row["emp_name"].ToString(),
                    Name = row["emp_no"].ToString(),
                    ForeColor = Color.Green,
                    Tag = new EmpInfo(row["emp_no"].ToString(), row["emp_name"].ToString(), row["idcard_no"].ToString(), row["birthday"].ToString(), row["birthplace"].ToString(), ((DateTime)row["entry_time"]).ToString("yyyy-MM-dd"), "员工")
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
                btnAddEmp.Enabled = true;
                btnModEmp.Enabled = false;
                btnDelEmp.Enabled = false;
                btnListEmp.Enabled = true;
            }
            if (NodeTypeUtil.IsEmp(selectedNode))
            {
                EmpInfo empInfo = (EmpInfo)selectedNode.Tag;
                txtHumanData.Text = empInfo.ToString();

                //修改按钮的Enabled属性，启用修改员工按钮和删除员工按钮，禁用所有功能的按钮
                btnAddDept.Enabled = false;
                btnModDept.Enabled = false;
                btnDelDept.Enabled = false;
                btnAddEmp.Enabled = false;
                btnModEmp.Enabled = true;
                btnDelEmp.Enabled = true;
                btnListEmp.Enabled = false;
            }
            if (NodeTypeUtil.IsCompany(selectedNode))
            {
                DeptInfo deptInfo = (DeptInfo)selectedNode.Tag;
                txtHumanData.Text = deptInfo.ToString();

                //修改按钮的Enabled属性，启用添加部门按钮，禁用其他按钮
                btnAddDept.Enabled = true;
                btnModDept.Enabled = false;
                btnDelDept.Enabled = false;
                btnAddEmp.Enabled = false;
                btnModEmp.Enabled = false;
                btnDelEmp.Enabled = false;
                btnListEmp.Enabled = false;
            }
        }

        /// <summary>
        /// 打开添加部门或修改部门窗体
        /// </summary>
        /// <param name="formText">窗体Text</param>
        /// <param name="schemaSql">表结构SQL</param>
        /// <param name="tableName">表明</param>
        /// <param name="columnValuePairs">表中首行的值</param>
        /// <returns></returns>
        private DeptInfo OpenAddOrModDeptForm(string formText, string schemaSql, string tableName, Dictionary<string, object> columnValuePairs)
        {
            //创建窗体
            AddOrModDeptForm addOrModDeptForm = new AddOrModDeptForm
            {
                Owner = this,
                Text = formText
            };

            DataTable dataTable = SqlHelper.GetTable(schemaSql, tableName);
            if (columnValuePairs != null)
            {
                DataRow newDataRow = dataTable.NewRow();
                foreach (KeyValuePair<string, object> item in columnValuePairs)
                {
                    newDataRow[item.Key] = item.Value;
                }
                dataTable.Rows.Add(newDataRow);
            }

            DataRow firstRow = dataTable.Rows[0];

            addOrModDeptForm.DataTable = dataTable;

            if (addOrModDeptForm.ShowDialog() == DialogResult.OK)
            {
                return new DeptInfo(firstRow["No"].ToString(), firstRow["DeptName"].ToString(), firstRow["Remarks"].ToString(), "部门");
            }
            return null;
        }

        /// <summary>
        /// 添加部门按钮点击事件，用于 添加部门。
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnAddDept_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvHuman.SelectedNode;

            //获取子窗体所需的表结构，该表用于父窗体与子窗体交换数据
            string schemeSql = "SELECT TOP 0 dept.dept_no AS No, dept.dept_name AS DeptName, dept.remarks AS Remarks, dept.parent_dept_no AS ParentDeptNo, parent_dept.dept_name AS ParentDeptName FROM dept LEFT OUTER JOIN dept AS parent_dept ON dept.parent_dept_no = parent_dept.dept_no";

            //为表的第一行添加数据，key为列名，value为值
            Dictionary<string, object> columnValuePairs = new Dictionary<string, object>
            {
                { "ParentDeptNo", selectedNode.Name },
                { "ParentDeptName", ((DeptInfo)selectedNode.Tag).DeptName }
            };

            // 打开部门窗口
            DeptInfo deptInfo = OpenAddOrModDeptForm(btnAddDept.Text, schemeSql, "dept", columnValuePairs);

            if (deptInfo != null)
            {
                //添加新部门节点
                TreeNode newTreeNode = new TreeNode
                {
                    Text = deptInfo.DeptName,
                    Name = deptInfo.No,
                    Tag = deptInfo
                };
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

            //获取子窗体所需的表结构，该表用于父窗体与子窗体交换数据

            string schemeSql = "SELECT dept.dept_no AS No, dept.dept_name AS DeptName, dept.remarks AS Remarks, dept.parent_dept_no AS ParentDeptNo, parent_dept.dept_name AS ParentDeptName FROM dept LEFT OUTER JOIN dept AS parent_dept ON dept.parent_dept_no = parent_dept.dept_no WHERE dept.dept_no = '" + selectedNode.Name + "'";

            // 打开部门窗口
            DeptInfo deptInfo = OpenAddOrModDeptForm(btnModDept.Text, schemeSql, "dept", null);

            if (deptInfo != null)
            {
                selectedNode.Text = deptInfo.DeptName;
                selectedNode.Tag = deptInfo;

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

        private EmpInfo OpenAddOrModEmpForm(string formText, string schemaSql, string tableName, Dictionary<string, object> columnValuePairs)
        {
            //创建窗体
            AddOrModEmpForm addOrModEmpForm = new AddOrModEmpForm
            {
                Owner = this,
                Text = formText
            };

            DataTable dataTable = SqlHelper.GetTable(schemaSql, tableName);
            if (columnValuePairs != null)
            {
                DataRow newDataRow = dataTable.NewRow();
                foreach (KeyValuePair<string, object> item in columnValuePairs)
                {
                    newDataRow[item.Key] = item.Value;
                }
                dataTable.Rows.Add(newDataRow);
            }

            DataRow firstRow = dataTable.Rows[0];

            addOrModEmpForm.DataTable = dataTable;

            if (addOrModEmpForm.ShowDialog() == DialogResult.OK)
            {
                return new EmpInfo(firstRow["No"].ToString(), firstRow["EmpName"].ToString(), firstRow["IdCardNo"].ToString(), firstRow["Birthday"].ToString(), firstRow["Birthplace"].ToString(), ((DateTime)firstRow["EntryTime"]).ToString("yyyy-MM-dd"), "员工");
            }
            return null;
        }

        /// <summary>
        /// 添加员工按钮点击事件，用于 添加员工。
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvHuman.SelectedNode;

            //获取子窗体所需的表结构，该表用于父窗体与子窗体交换数据
            string schemeSql = "SELECT TOP 0 emp.emp_no AS No, emp.emp_name AS EmpName, emp.idcard_no AS IdCardNo, emp.birthday AS Birthday, emp.birthplace AS Birthplace, emp.entry_time AS EntryTime, dept.dept_no AS DeptNo, dept.dept_name AS DeptName FROM dept LEFT OUTER JOIN emp ON dept.dept_no = emp.dept_no";

            //为表的第一行添加数据，key为列名，value为值
            Dictionary<string, object> columnValuePairs = new Dictionary<string, object>
            {
                { "DeptNo", selectedNode.Name },
                { "DeptName", ((DeptInfo)selectedNode.Tag).DeptName }
            };

            // 打开部门窗口
            EmpInfo empInfo = OpenAddOrModEmpForm(btnAddDept.Text, schemeSql, "emp", columnValuePairs);

            if (empInfo != null)
            {
                //添加新部门节点
                TreeNode newTreeNode = new TreeNode
                {
                    Text = empInfo.EmpName,
                    Name = empInfo.No,
                    ForeColor = Color.Green,
                    Tag = empInfo
                };
                selectedNode.Nodes.Add(newTreeNode);
            }
            /*//创建添加员工窗体
            AddOrModEmpForm addEmpform = new AddOrModEmpForm
            {
                Owner = this,
                Text = btnModEmp.Text
            };

            DataTable dataTable = SqlHelper.GetTable("SELECT TOP 0 emp.emp_no AS EmpNo, emp.emp_name AS EmpName, emp.idcard_no AS IdCardNo, emp.birthday AS Birthday, emp.birthplace AS Birthplace, emp.entry_time AS EntryTime, dept.dept_no AS DeptNo, dept.dept_name AS DeptName FROM dept LEFT OUTER JOIN emp ON dept.dept_no = emp.dept_no", "dept");
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
                    Text = dataRow["EmpName"].ToString(),
                    Name = dataRow["EmpNo"].ToString(),
                    ForeColor = Color.Green,
                    Tag = new EmpInfo(dataRow["EmpNo"].ToString(), dataRow["EmpName"].ToString(), dataRow["IdCardNo"].ToString(), dataRow["Birthday"].ToString(), dataRow["Birthplace"].ToString(), dataRow["EntryTime"].ToString(), "员工")
                };

                List<string> valueList = new List<string>
                {
                    "emp_no = '" + dataRow["EmpNo"].ToString() + "'",
                    "emp_name = '" + dataRow["EmpName"].ToString() + "'",
                    "idcard_no = '" + dataRow["IdCardNo"].ToString() + "'",
                    "birthday = '" + dataRow["Birthday"].ToString() + "'",
                    "birthplace = '" + dataRow["Birthplace"].ToString() + "'",
                    "entry_time = '" + dataRow["EntryTime"].ToString() + "'",
                    "dept_no = '" + selectedNode.Name + "'"
                };
                // TODO 异常处理
                SqlHelper.Insert("emp", valueList);

                selectedNode.Nodes.Add(newTreeNode);
            }*/
        }

        private void btnModEmp_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvHuman.SelectedNode;

            //创建修改员工窗体
            AddOrModEmpForm modEmpform = new AddOrModEmpForm
            {
                Owner = this,
                Text = btnModEmp.Text
            };

            DataTable dataTable = SqlHelper.GetTable("emp LEFT OUTER JOIN dept ON emp.dept_no = dept.dept_no", "emp.emp_no AS EmpNo, emp.emp_name AS EmpName, emp.idcard_no AS IdCardNo, emp.birthday AS Birthday, emp.birthplace AS Birthplace, emp.entry_time AS EntryTime, emp.dept_no AS DeptNo, dept.dept_name AS DeptName", "emp.emp_no = '" + selectedNode.Name + "'");
            modEmpform.DataTable = dataTable;

            //如果在 modEmpform 添加员工窗体中点击确定，则在添加员工节点到所选节点中
            if (modEmpform.ShowDialog() == DialogResult.OK)
            {
                DataRow dataRow = modEmpform.DataTable.Rows[0];

                List<string> valueList = new List<string>
                {
                    "emp_no = '" + dataRow["EmpNo"].ToString() + "'",
                    "emp_name = '" + dataRow["EmpName"].ToString() + "'",
                    "idcard_no = '" + dataRow["IdCardNo"].ToString() + "'",
                    "birthday = '" + dataRow["Birthday"].ToString() + "'",
                    "birthplace = '" + dataRow["Birthplace"].ToString() + "'",
                    "entry_time = '" + dataRow["EntryTime"].ToString() + "'",
                    "dept_no = '" + dataRow["DeptNo"].ToString() + "'"
                };
                // TODO 异常处理
                SqlHelper.Update("emp", valueList, "emp.emp_no = '" + selectedNode.Name + "'");

                selectedNode.Text = dataRow["EmpName"].ToString();
                selectedNode.Tag = new EmpInfo(dataRow["EmpNo"].ToString(), dataRow["EmpName"].ToString(), dataRow["IdCardNo"].ToString(), dataRow["Birthday"].ToString(), dataRow["Birthplace"].ToString(), dataRow["EntryTime"].ToString(), "员工");

                //修改完成后，触发 tvHuman_AfterSelect 事件，以在 tvHuman 控件中显示修改完成后的数据。
                tvHuman_AfterSelect(sender, null);
            }
        }

        private void btnDelEmp_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvHuman.SelectedNode;

            if (MessageBox.Show("是否删除 " + selectedNode.Text + " 节点", "请确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                SqlHelper.Delete("emp", "emp_no = '" + selectedNode.Name + "'");
                selectedNode.Remove();
            }
        }

        private void btnListEmp_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvHuman.SelectedNode;

            //创建查看员工清单窗体
            ListAndDeleteEmpForm listAndDeleteEmpForm = new ListAndDeleteEmpForm()
            {
                Owner = this
            };

            DataTable dataTable = SqlHelper.GetTable("emp LEFT OUTER JOIN dept ON emp.dept_no = dept.dept_no", "emp.emp_no AS EmpNo, emp.emp_name AS EmpName, emp.idcard_no AS IdCardNo, emp.birthday AS Birthday, emp.birthplace AS Birthplace, emp.entry_time AS EntryTime, emp.dept_no AS DeptNo, dept.dept_name AS DeptName", "dept.dept_no = '" + selectedNode.Name + "'");
            listAndDeleteEmpForm.DataTable = dataTable;


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
