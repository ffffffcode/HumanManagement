using HumanManagementSQLServer.Util;
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
    public partial class ListAndDeleteEmpForm : Form
    {
        /// <summary>
        /// 交换数据委托。
        /// </summary>
        /// <param name="data">要交换的数据对象</param>
        internal void ExchangeDataHandler(object data)
        {
            Dictionary<string, object> map = data as Dictionary<string, object>;
            _deptNo = map["No"].ToString();
            _deptName = map["DeptName"].ToString();
        }

        /// <summary>
        /// 部门编号字段。
        /// </summary>
        private string _deptNo;
        /// <summary>
        /// 获取或设置部门编号。
        /// </summary>
        /// <value>
        /// 部门编号
        /// </value>
        public string DeptNo
        {
            get { return _deptNo; }
            set { _deptNo = value; }
        }

        /// <summary>
        /// 部门名称字段。
        /// </summary>
        private string _deptName;
        /// <summary>
        /// 获取或设置部门名称。
        /// </summary>
        /// <value>
        /// 部门名称
        /// </value>
        public string DeptName
        {
            get { return _deptName; }
            set { _deptName = value; }
        }

        private DataTable _dataTable;
        public DataTable DataTable
        {
            set
            {
                _dataTable = value;
                dgvEmployeeList.DataSource = _dataTable;
            }
        }

        /// <summary>
        /// 在 DataGridView 控件中被删除的树节点的索引值集合。
        /// </summary>
        private List<string> _deletedTreeNodeKeyList = new List<string>();
        /// <summary>
        /// 获取或设置在 DataGridView 控件中被删除的树节点的索引值集合。
        /// </summary>
        /// <value>
        /// 在 DataGridView 控件中被删除的树节点的索引值集合
        /// </value>
        public List<string> DeletedTreeNodeKeyList
        {
            get { return _deletedTreeNodeKeyList; }
        }

        public ListAndDeleteEmpForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 删除选定员工
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnDelSelectedEmployee_Click(object sender, EventArgs e)
        {
            //遍历所选的行，记录下行的index属性，然后删除行
            //_deletedTreeNodeIndexList最后返回给父窗体，父窗体根据_deletedTreeNodeIndexList删除TreeView中的节点
            foreach (DataGridViewRow item in dgvEmployeeList.SelectedRows)
            {
                string empNo = item.Cells[0].Value.ToString();
                _deletedTreeNodeKeyList.Add(empNo);
                dgvEmployeeList.Rows.Remove(item);
            }
        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void ListAndDeleteEmpForm_Load(object sender, EventArgs e)
        {
            txtDeptNo.Text = _deptNo;
            txtDeptName.Text = _deptName;
        }
    }
}
