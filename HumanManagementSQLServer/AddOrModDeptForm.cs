using HumanManagementSQLServer.Data;
using HumanManagementSQLServer.Handler;
using HumanManagementSQLServer.Util;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HumanManagementSQLServer
{
    public partial class AddOrModDeptForm : Form
    {
        /// <summary>
        /// 校验信息列表字段。
        /// </summary>
        private List<CheckInfo> _chekcInfoList = null;

        private string _primary;

        /// <summary>
        /// 数据表字段。
        /// </summary>
        private DataTable _dataTable;
        /// <summary>
        /// 数据表
        /// </summary>
        internal DataTable DataTable
        {
            get { return _dataTable; }
            set
            {
                _dataTable = value;
                _primary = _dataTable.Rows[0]["No"].ToString();
                //将部门信息设置到对应的 TextBox 控件中
                DataBindingUtil.DataTableToControl(this, DataTable, "Dept");
            }
        }

        public AddOrModDeptForm()
        {
            InitializeComponent();
            //为窗体添加 KeyDown 事件，使用Enter切换控件焦点
            KeyDown += new KeyEventHandler(FormKeyDownHandler.EnterToSelectNextControl);
            // 添加校验信息
            _chekcInfoList = new List<CheckInfo>
            {
                new CheckInfo(txtNo, CheckType.DeptNo,"部门编号由字母、数字和下划线组成"),
                new CheckInfo(txtDeptName, CheckType.DeptName,"部门名称由字母和汉字组成")
            };
        }

        private bool CheckData()
        {
            foreach (CheckInfo item in _chekcInfoList)
            {
                if (!item.Check())
                {
                    item.Control.Focus();
                    MessageBox.Show(item.ErrorMessage);
                    return false;
                }
            }
            return true;
        }

        private void btnConfirm_Click(object sender, System.EventArgs e)
        {
            // 数据校验
            if (CheckData())
            {
                // 将数据写到dataTable中
                DataBindingUtil.ControlToDataTable(_dataTable, this, "Dept");

                DataRow firstRow = DataTable.Rows[0];

                // 构造SQL语句，具体看SqlHelper.CmdForInsertTable()
                List<string> valueList = new List<string>
                {
                    "dept_no = '" + firstRow["No"] + "'",
                    "dept_name = '" + firstRow["DeptName"] + "'",
                    "remarks = '" + firstRow["Remarks"] + "'",

                };

                // 添加部门逻辑
                if (Text.Equals("添加部门"))
                {
                    valueList.Add("parent_dept_no = '" + firstRow["ParentDeptNo"] + "'");

                    try
                    {
                        // 插入行
                        SqlHelper.Insert("dept", valueList);
                        DialogResult = DialogResult.OK;
                    }
                    catch (SqlException)
                    {
                        // 数据已经校验完成，发生异常则说明主键已存在
                        txtNo.Focus();
                        MessageBox.Show("已存在相同的部门编号");
                    }
                }

                // 修改部门逻辑
                if (Text.Equals("修改部门"))
                {
                    try
                    {
                        SqlHelper.Update("dept", valueList, "dept.dept_no = '" + _primary + "'");
                        DialogResult = DialogResult.OK;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("修改失败\n\r" + ex.Message);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
