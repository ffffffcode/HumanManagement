using HumanManagementSQLServer.Data;
using HumanManagementSQLServer.Handler;
using HumanManagementSQLServer.Util;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace HumanManagementSQLServer
{
    public partial class AddOrModDeptForm : Form
    {


        private DataTable _dataTable;
        internal DataTable DataTable
        {
            get { return _dataTable; }
            set
            {
                _dataTable = value;
                //将部门信息设置到对应的 TextBox 控件中
                DataBindingUtil.DataToControl(this, _dataTable, "Dept");
            }
        }

        private List<CheckInfo> chekcInfoList = null;

        public AddOrModDeptForm()
        {
            InitializeComponent();
            //为窗体添加 KeyDown 事件，使用Enter切换控件焦点
            KeyDown += new KeyEventHandler(FormKeyDownHandler.EnterToSelectNextControl);

            chekcInfoList = new List<CheckInfo>();
            chekcInfoList.Add(new CheckInfo(txtNo, CheckType.DeptNo));
            chekcInfoList.Add(new CheckInfo(txtDeptName, CheckType.DeptName));
        }

        private bool CheckData()
        {
            foreach (CheckInfo item in chekcInfoList)
            {
                if (!item.Check())
                {
                    item._control.Focus();
                    return false;
                }
            }
            return true;
        }

        private void btnConfirm_Click(object sender, System.EventArgs e)
        {
            if (this.Text == "修改部门" && SqlHelper.Excited("dept", "dept_no", txtNo.Text))
            {
                txtNo.Focus();
                MessageBox.Show("部门编号已存在");
            }

            if (CheckData())
            {
                DataBindingUtil.ControlToData(_dataTable, this, "Dept");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("输入非法");
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
