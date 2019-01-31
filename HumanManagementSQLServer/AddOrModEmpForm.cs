using HumanManagementSQLServer.Handler;
using HumanManagementSQLServer.Util;
using System.Data;
using System.Windows.Forms;

namespace HumanManagementSQLServer
{
    public partial class AddOrModEmpForm : Form
    {
        private DataTable _dataTable;
        internal DataTable DataTable
        {
            get { return _dataTable; }
            set
            {
                _dataTable = value;
                //将部门信息设置到对应的 TextBox 控件中
                DataBindingUtil.DataToControl(this, _dataTable, "Emp");
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
            DataBindingUtil.ControlToData(_dataTable, this, "Emp");
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
