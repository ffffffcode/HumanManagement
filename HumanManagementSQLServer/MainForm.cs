using HumanManagementSQLServer.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HumanManagementSQLServer
{
    public partial class MainForm : Form
    {
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
            tvHuman.TopNode.ExpandAll();
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
            HumanManagementDataSet.empDataTable empDataTable = this.empTableAdapter.GetDataByDeptNo(deptNo);
            DataTable dataTable = SqlHelper.CmdForSelectTable("emp",)

            foreach (HumanManagementDataSet.empRow row in empTable.Select("deptNo = '"+))
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
    }
}
