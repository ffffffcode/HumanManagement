using HumanManagement.Data;
using HumanManagement.Validation;
using System;
using System.Windows.Forms;

namespace HumanManagement
{
    public partial class CreatCompanyForm : Form
    {
        /// <summary>
        /// 公司信息字段。
        /// </summary>
        private DeptInfo _deptInfo = new DeptInfo();
        /// <summary>
        /// 获取或设置公司信息。
        /// </summary>
        /// <value>
        /// 公司信息
        /// </value>
        internal DeptInfo DeptInfo
        {
            get { return _deptInfo; }
        }

        public CreatCompanyForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 确定按钮点击事件，用于创建公司节点
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //创建校验器
            TextBoxValidator txtCompanyNoValidator = new TextBoxValidatorBuilder().DeptNo().Bulid();
            TextBoxValidator txtCompanyValidator = new TextBoxValidatorBuilder().DeptName().Bulid();
            //进行校验并提示
            if (!txtCompanyNoValidator.Validate(txtCompanyNo))
            {
                MessageBox.Show("公司编号由字母和数字组成");
            }
            else if (!txtCompanyValidator.Validate(txtCompanyName))
            {
                MessageBox.Show("公司名称由字母和汉字组成");
            }
            //校验成功
            else
            {
                _deptInfo.No = txtCompanyNo.Text;
                _deptInfo.DeptName = txtCompanyName.Text;
                _deptInfo.Remarks = txtCompanyRemarks.Text;
                _deptInfo.TypeString = "公司";
                DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// 退出程序
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
