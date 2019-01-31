using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HumanManagementSQLServer.Data
{
    /// <summary>
    /// 校验类型
    /// </summary>
    public enum CheckType
    {
        Required,
        DeptNo,
        DeptName,
        EmployeeNo,
        EmployeeName,
        IdCardNo
    }

    /// <summary>
    /// 数据检测类
    /// </summary>
    public class CheckInfo
    {
        public Control _control;

        /// <summary>
        /// 校验类型
        /// </summary>
        public CheckType _checkType;

        /// <summary>
        /// 初始类属性 <see cref="CheckInfo" /> class.
        /// </summary>
        /// <param name="conObj">The con object.</param>
        /// <param name="lenth">The lenth.</param>
        /// <param name="mustInput">if set to <c>true</c> [must input].</param>
        /// <param name="conType">Type of the con.</param>
        public CheckInfo(Control control, CheckType checkType)
        {
            this._control = control;
            this._checkType = checkType;
        }

        #region 检查数据 bool CheckData()
        /// <summary>
        /// 检查数据
        /// </summary>
        /// <returns></returns>
        public bool Check()
        {
            switch (_checkType)
            {
                case CheckType.Required:
                    return CheckRequired(_control.Text);
                case CheckType.DeptNo:
                    return CheckDeptNo(_control.Text);
                case CheckType.DeptName:
                    return CheckDeptName(_control.Text);
                case CheckType.EmployeeNo:
                    return CheckEmployeeNo(_control.Text);
                case CheckType.EmployeeName:
                    return CheckEmployeeName(_control.Text);
                case CheckType.IdCardNo:
                    return CheckIdCardNo(_control.Text);
                default:
                    return true;
            }
        }
        #endregion

        /// <summary>
        /// 非空判断
        /// </summary>
        /// <returns></returns>
        private bool CheckRequired(string value)
        {
            if (value.Length != 0)
            {
                return true;
            }
            return false;
        }

        private bool CheckDeptNo(string value)
        {
            return Regex.IsMatch(value, @"^[A-Za-z0-9]+$");//字母或数字
        }

        private bool CheckDeptName(string value)
        {
            return Regex.IsMatch(value, @"^[A-Za-z\u4e00-\u9fa5]+$");//字母或汉字
        }

        private bool CheckEmployeeNo(string value)
        {
            return Regex.IsMatch(value, @"^[A-Za-z0-9]{6}$");//字母或数字，6位
        }

        private bool CheckEmployeeName(string value)
        {
            return Regex.IsMatch(value, @"^[A-Za-z\u4e00-\u9fa5]{2,}$");//字母或汉字，2位以上
        }

        private bool CheckIdCardNo(string value)
        {
            return Regex.IsMatch(value, @"^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$|^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}([0-9]|X)$");//身份证
        }
    }
}
