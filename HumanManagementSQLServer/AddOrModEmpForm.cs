using HumanManagementSQLServer.Data;
using HumanManagementSQLServer.Handler;
using HumanManagementSQLServer.Util;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace HumanManagementSQLServer
{
    public partial class AddOrModEmpForm : Form
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
        /// 数据表。
        /// </summary>
        internal DataTable DataTable
        {
            get { return _dataTable; }
            set
            {
                _dataTable = value;
                _primary = _dataTable.Rows[0]["No"].ToString();
                //将部门信息设置到对应的 TextBox 控件中
                DataBindingUtil.DataTableToControl(this, _dataTable, "Emp");
            }
        }

        public AddOrModEmpForm()
        {
            InitializeComponent();
            //为窗体添加 KeyDown 事件，使用Enter切换控件焦点
            KeyDown += new KeyEventHandler(FormKeyDownHandler.EnterToSelectNextControl);
        }

        private void btnComfirm_Click(object sender, System.EventArgs e)
        {
            DataBindingUtil.ControlToDataTable(_dataTable, this, "Emp");

            DataRow firstRow = DataTable.Rows[0];

            List<string> valueList = new List<string>
                {
                    "emp_no = '" + firstRow["EmpNo"].ToString() + "'",
                    "emp_name = '" + firstRow["EmpName"].ToString() + "'",
                    "idcard_no = '" + firstRow["IdCardNo"].ToString() + "'",
                    "birthday = '" + firstRow["Birthday"].ToString() + "'",
                    "birthplace = '" + firstRow["Birthplace"].ToString() + "'",
                    "entry_time = '" + firstRow["EntryTime"].ToString() + "'",
                    "dept_no = '" + firstRow["DetpNo"].ToString() + "'"
                };
            // TODO 异常处理
            SqlHelper.Insert("emp", valueList);

            DialogResult = DialogResult.OK;
        }

        private void btnCannel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void txtIdCardNo_Leave(object sender, System.EventArgs e)
        {
            txtBirthday.Text = txtIdCardNo.Text.Substring(6, 4) + "-" + txtIdCardNo.Text.Substring(10, 2) + "-" + txtIdCardNo.Text.Substring(12, 2);
        }
    }
}
