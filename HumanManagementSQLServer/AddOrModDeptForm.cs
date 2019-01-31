using HumanManagementSQLServer.Handler;
using HumanManagementSQLServer.Util;
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

        public AddOrModDeptForm()
        {
            InitializeComponent();
            //为窗体添加 KeyDown 事件，使用Enter切换控件焦点
            KeyDown += new KeyEventHandler(FormKeyDownHandler.EnterToSelectNextControl);
        }

        private void btnConfirm_Click(object sender, System.EventArgs e)
        {
            DataBindingUtil.ControlToData(_dataTable, this, "Dept");
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
