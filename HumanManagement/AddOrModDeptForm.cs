using HumanManagement.Data;
using HumanManagement.Handler;
using HumanManagement.Util;
using HumanManagement.Validation;
using System;
using System.Windows.Forms;

namespace HumanManagement
{
    public partial class AddOrModDeptForm : Form
    {
        /// <summary>
        /// 交换数据委托。
        /// </summary>
        /// <param name="data">要交换的数据对象</param>
        internal void ExchangeDataHandler(object data)
        {
            DeptInfo = data as DeptInfo;
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
            set
            {
                _deptInfo = value;
                //将部门信息设置到对应的 TextBox 控件中
                DataBindingUtil.DataToControl(this, _deptInfo);
            }
        }

        public AddOrModDeptForm()
        {
            InitializeComponent();
            //为窗体添加 KeyDown 事件，使用Enter切换控件焦点
            KeyDown += new KeyEventHandler(FormKeyDownHandler.EnterToSelectNextControl);
        }

        /// <summary>
        /// 确定按钮点击事件，用于创建部门节点
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //创建校验器
            TextBoxValidator txtDeptNoValidator = new TextBoxValidatorBuilder().DeptNo().Bulid();
            TextBoxValidator txtDeptNameValidator = new TextBoxValidatorBuilder().DeptName().Bulid();
            //进行校验并提示
            if (!txtDeptNoValidator.Validate(txtNo))
            {
                txtNo.Focus();
                MessageBox.Show("部门编号由字母和数字组成");
            }
            else if (!txtDeptNameValidator.Validate(txtDeptName))
            {
                txtDeptName.Focus();
                MessageBox.Show("部门名称由字母和汉字组成");
            }
            //校验成功
            else
            {
                DataBindingUtil.ControlToData(_deptInfo, this);
                _deptInfo.TypeString = "部门";
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
