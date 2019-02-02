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
        EmpNo,
        EmpName,
        IdCardNo
    }

    /// <summary>
    /// 数据检测类
    /// </summary>
    public class CheckInfo
    {

        /// <summary>
        /// 要校验的控件
        /// </summary>
        public Control Control { get; set; }

        /// <summary>
        /// 校验类型
        /// </summary>
        public CheckType CheckType { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 初始化类
        /// </summary>
        /// <param name="control">要校验的控件</param>
        /// <param name="checkType">校验类型</param>
        /// <param name="message">错误信息</param>
        public CheckInfo(Control control, CheckType checkType, string errorMessage)
        {
            Control = control;
            CheckType = checkType;
            ErrorMessage = errorMessage;
        }

        #region 检查数据 bool CheckData()
        /// <summary>
        /// 检查数据
        /// </summary>
        /// <returns></returns>
        public bool Check()
        {
            switch (CheckType)
            {
                case CheckType.Required:
                    return CheckRequired(Control.Text);
                case CheckType.DeptNo:
                    return CheckDeptNo(Control.Text);
                case CheckType.DeptName:
                    return CheckDeptName(Control.Text);
                case CheckType.EmpNo:
                    return CheckEmpNo(Control.Text);
                case CheckType.EmpName:
                    return CheckEmpName(Control.Text);
                case CheckType.IdCardNo:
                    return CheckIdCardNo(Control.Text);
                default:
                    return true;
            }
        }
        #endregion

        /// <summary>
        /// 非空判断
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool CheckRequired(string value)
        {
            if (value.Length != 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 部门编号判断
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool CheckDeptNo(string value)
        {
            return Regex.IsMatch(value, @"^[A-Za-z0-9_]+$");//字母或数字
        }

        /// <summary>
        /// 部门名称判断
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool CheckDeptName(string value)
        {
            return Regex.IsMatch(value, @"^[A-Za-z\u4e00-\u9fa5]+$");//字母或汉字
        }

        /// <summary>
        /// 员工编号判断
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool CheckEmpNo(string value)
        {
            return Regex.IsMatch(value, @"^[A-Za-z0-9]{6}$");//字母或数字，6位
        }

        /// <summary>
        /// 员工姓名判断
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool CheckEmpName(string value)
        {
            return Regex.IsMatch(value, @"^[A-Za-z\u4e00-\u9fa5]{2,}$");//字母或汉字，2位以上
        }

        /// <summary>
        /// 身份证判断
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool CheckIdCardNo(string value)
        {
            return Regex.IsMatch(value, @"^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$|^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}([0-9]|X)$");//身份证
        }
    }
}
