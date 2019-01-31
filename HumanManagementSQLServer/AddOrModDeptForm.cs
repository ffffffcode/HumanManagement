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
        /// <summary>
        /// 部门编号字段。
        /// </summary>
        private string _parentDeptNo;
        /// <summary>
        /// 获取或设置部门编号。
        /// </summary>
        /// <value>
        /// 部门编号
        /// </value>
        public string ParentDeptNo
        {
            get { return _parentDeptNo; }
            set
            {
                _parentDeptNo = value;
                this.txtParentDeptNo.Text = this._parentDeptNo;
            }
        }

        /// <summary>
        /// 部门名称字段。
        /// </summary>
        private string _parentDeptName;
        /// <summary>
        /// 获取或设置部门名称。
        /// </summary>
        /// <value>
        /// 部门名称
        /// </value>
        public string ParentDeptName
        {
            get { return _parentDeptName; }
            set
            {
                _parentDeptName = value;
                this.txtParentDeptName.Text = this._parentDeptName;
            }
        }

        /// <summary>
        /// 部门信息字段。
        /// </summary>
        private DeptInfo _deptInfo = new DeptInfo();
        /// <summary>
        /// 获取或设置部门信息。
        /// </summary>
        /// <value>
        /// 部门信息
        /// </value>
        internal DeptInfo DeptInfo
        {
            get { return _deptInfo; }
        }

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
            if (CheckData())
            {
                if (_dataTable != null && !SqlHelper.Excited("dept", "dept_no", txtNo.Text))
                {
                    DataBindingUtil.ControlToData(_dataTable, this, "Dept");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    txtNo.Focus();
                    MessageBox.Show("部门编号已存在");
                }
                if (_deptInfo != null)
                {
                    DataBindingUtil.ControlToData(_deptInfo, this);
                    this.DialogResult = DialogResult.OK;
                }
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
