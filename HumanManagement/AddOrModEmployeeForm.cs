using HumanManagement.Data;
using HumanManagement.Validation;
using System;
using System.Windows.Forms;

namespace HumanManagement
{
    public partial class AddOrModEmployeeForm : Form
    {
        /// <summary>
        /// 交换数据委托。
        /// </summary>
        /// <param name="data">要交换的数据对象</param>
        internal void ExchangeDataHandler(object data)
        {
            _employeeInfo = data as EmployeeInfo;
        }

        /// <summary>
        /// 员工信息字段。
        /// </summary>
        private EmployeeInfo _employeeInfo = new EmployeeInfo();
        /// <summary>
        /// 获取或设置员工信息。
        /// </summary>
        /// <value>
        /// 员工信息
        /// </value>
        internal EmployeeInfo EmployeeInfo
        {
            get { return _employeeInfo; }
            set
            {
                _employeeInfo = value;
                //将员工信息设置到对应的 TextBox 控件中
                txtDeptNo.Text = _employeeInfo.DeptNo;
                txtDeptName.Text = _employeeInfo.DeptName;
                txtEmployeeNo.Text = _employeeInfo.No;
                txtEmployeeName.Text = _employeeInfo.EmployeeName;
                txtIdCardNo.Text = _employeeInfo.IdCardNo;
                txtBirthday.Text = _employeeInfo.Birthday;
                txtBirthplace.Text = _employeeInfo.Birthplace;
                if (_employeeInfo.EntryTime != null && _employeeInfo.EntryTime != "")
                {
                    dtpEntryTime.Value = DateTime.Parse(_employeeInfo.EntryTime);
                }
                else
                {
                    dtpEntryTime.Value = DateTime.Now;
                }
            }
        }

        public AddOrModEmployeeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 确定按钮点击事件，用于创建员工节点
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //创建校验器
            TextBoxValidator txtEmployeeNoValidator = new TextBoxValidatorBuilder().EmployeeNo().Bulid();
            TextBoxValidator txtEmployeeNameValidator = new TextBoxValidatorBuilder().EmployeeName().Bulid();
            TextBoxValidator txtIdCardNoValidator = new TextBoxValidatorBuilder().IdCardNo().Bulid();
            //进行校验并提示
            if (txtEmployeeNoValidator.Validate(txtEmployeeNo))
            {
                MessageBox.Show("工号为6位，由字母和数字组成");
            }
            else if (txtEmployeeNameValidator.Validate(txtEmployeeName))
            {
                MessageBox.Show("姓名为2位以上，由字母和汉字组成");
            }
            else if (txtIdCardNoValidator.Validate(txtIdCardNo))
            {
                MessageBox.Show("身份证为15位或18位");
            }
            //校验成功
            else
            {
                _employeeInfo.DeptNo = txtDeptNo.Text;
                _employeeInfo.DeptName = txtDeptName.Text;
                _employeeInfo.No = txtEmployeeNo.Text;
                _employeeInfo.EmployeeName = txtEmployeeName.Text;
                _employeeInfo.IdCardNo = txtIdCardNo.Text;
                _employeeInfo.Birthday = txtBirthday.Text;
                _employeeInfo.Birthplace = txtBirthplace.Text;
                _employeeInfo.EntryTime = dtpEntryTime.Value.ToString("yyyy-MM-dd");
                _employeeInfo.TypeString = "员工";
                DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// 取消，回到主窗体
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
