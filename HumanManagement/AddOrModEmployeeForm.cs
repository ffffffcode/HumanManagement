using HumanManagement.Data;
using HumanManagement.Handler;
using HumanManagement.Util;
using HumanManagement.Validation;
using System;
using System.Collections.Generic;
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
            EmployeeInfo = data as EmployeeInfo;
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
                DataBindingUtil.DataToControl(this, _employeeInfo);
            }
        }

        public AddOrModEmployeeForm()
        {
            InitializeComponent();
            //为窗体添加 KeyDown 事件，使用Enter切换控件焦点
            KeyDown += new KeyEventHandler(FormKeyDownHandler.EnterToSelectNextControl);
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
            if (!txtEmployeeNoValidator.Validate(txtNo))
            {
                txtNo.Focus();
                MessageBox.Show("工号为6位，由字母和数字组成");
            }
            else if (!txtEmployeeNameValidator.Validate(txtEmployeeName))
            {
                txtEmployeeName.Focus();
                MessageBox.Show("姓名为2位以上，由字母和汉字组成");
            }
            else if (!txtIdCardNoValidator.Validate(txtIdCardNo))
            {
                txtIdCardNo.Focus();
                MessageBox.Show("身份证为15位或18位");
            }
            //校验成功
            else
            {
                DataBindingUtil.ControlToData(_employeeInfo, this);
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

        private void txtIdCardNo_Leave(object sender, EventArgs e)
        {
            TextBoxValidator txtIdCardNoValidator = new TextBoxValidatorBuilder().IdCardNo().Bulid();
            if (txtIdCardNoValidator.Validate(txtIdCardNo))
            {
                txtBirthday.Text = txtIdCardNo.Text.Substring(6, 4) + "-" + txtIdCardNo.Text.Substring(10, 2) + "-" + txtIdCardNo.Text.Substring(12, 2);
            }
            else
            {
                txtBirthday.Text = "";
            }
        }
    }
}
