using HumanManagement.Data;
using HumanManagement.Util;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HumanManagement
{
    public partial class ListAndDeleteEmployeeForm : Form
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
            TreeNodeCollection = map["TreeNodeCollection"] as TreeNodeCollection;
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

        /// <summary>
        /// 要转换为List<DataGridEmployeeInfo>的TreeNodeCollection对象。
        /// </summary>
        private TreeNodeCollection _treeNodeCollection;
        /// <summary>
        /// 获取或设置要在DataGridView控件中显示的TreeNodeCollection对象。
        /// </summary>
        /// <value>
        /// 要转换为List<DataGridEmployeeInfo>的TreeNodeCollection对象
        /// </value>
        public TreeNodeCollection TreeNodeCollection
        {
            get { return _treeNodeCollection; }
            set
            {
                _treeNodeCollection = value;
                //设置该属性时，使用该属性生成可在DataGridView控件中使用的List<DataGridEmployeeInfo>对象
                List<DataGridEmployeeInfo> dataGridEmployeeInfos = new List<DataGridEmployeeInfo>();
                foreach (TreeNode item in _treeNodeCollection)
                {
                    if (NodeTypeUtil.IsEmployee(item))
                    {
                        EmployeeInfo employeeInfo = (EmployeeInfo)item.Tag;
                        DataGridEmployeeInfo dataGridEmployeeInfo = new DataGridEmployeeInfo
                        {
                            No = employeeInfo.No,
                            EmployeeName = employeeInfo.EmployeeName,
                            IdCardNo = employeeInfo.IdCardNo,
                            Birthday = employeeInfo.Birthday,
                            Birthplace = employeeInfo.Birthplace,
                            EntryTime = employeeInfo.EntryTime,
                            Index = item.Index.ToString()
                        };
                        dataGridEmployeeInfos.Add(dataGridEmployeeInfo);
                    }
                }
                _dataGridEmployeeInfos = dataGridEmployeeInfos;
            }
        }

        /// <summary>
        /// 在 DataGridView 控件中被删除的树节点的索引值集合。
        /// </summary>
        private List<int> _deletedTreeNodeIndexList = new List<int>();
        /// <summary>
        /// 获取或设置在 DataGridView 控件中被删除的树节点的索引值集合。
        /// </summary>
        /// <value>
        /// 在 DataGridView 控件中被删除的树节点的索引值集合
        /// </value>
        public List<int> DeletedTreeNodeIndexList
        {
            get { return _deletedTreeNodeIndexList; }
            set { _deletedTreeNodeIndexList = value; }
        }

        /// <summary>
        /// 要在 DataGridView 控件中显示的List<DataGridEmployeeInfo>对象
        /// </summary>
        private List<DataGridEmployeeInfo> _dataGridEmployeeInfos;
        /// <summary>
        /// 获取或设置要在 DataGridView 控件中显示的 List<DataGridEmployeeInfo> 对象。
        /// </summary>
        /// <value>
        /// 要在 DataGridView 控件中显示的List<DataGridEmployeeInfo>对象
        /// </value>
        internal List<DataGridEmployeeInfo> DataGridEmployeeInfos
        {
            get { return _dataGridEmployeeInfos; }
            set { _dataGridEmployeeInfos = value; }
        }

        public ListAndDeleteEmployeeForm()
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
                int index = int.Parse(item.Cells[6].Value.ToString());
                _deletedTreeNodeIndexList.Add(index);
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
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 当窗体显示前，从 _employeeInfos 字段中读取数据到 dataGridView1 控件中
        /// 把部门编号和部门名称设置给textBox控件
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ListAndDeleteEmployeeForm_Load(object sender, EventArgs e)
        {
            txtDeptNo.Text = _deptNo;
            txtDeptName.Text = _deptName;
            foreach (DataGridEmployeeInfo item in _dataGridEmployeeInfos)
            {
                dgvEmployeeList.Rows.Add(item.ToStringArray());
            }
        }

    }
}
