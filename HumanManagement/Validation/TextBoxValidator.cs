using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HumanManagement.Validation
{
    /// <summary>
    /// System.Windows.Forms.TextBox 控件的校验器
    /// </summary>
    class TextBoxValidator
    {
        /// <summary>
        /// 指示 System.Windows.Forms.TextBox 控件的值能否为空。
        /// </summary>
        /// <value>
        ///   <c>true</c> 如果要求 TextBox 控件的值非 null 或空字符串 ("")；否则为 <c>false</c>.
        /// </value>
        public bool Required { get; set; }

        /// <summary>
        /// 指示 System.Windows.Forms.TextBox 控件的值是否为部门编号。
        /// </summary>
        /// <value>
        ///   <c>true</c> 如果要求 TextBox 控件为的值部门编号；否则为 <c>false</c>.
        /// </value>
        public bool DeptNo { get; set; }

        /// <summary>
        /// 指示 System.Windows.Forms.TextBox 控件的值能否为部门名称。
        /// </summary>
        /// <value>
        ///   <c>true</c> 如果要求 TextBox 控件的值为部门名称；否则为 <c>false</c>.
        /// </value>
        public bool DeptName { get; set; }

        /// <summary>
        /// 指示 System.Windows.Forms.TextBox 控件的值是否为工号。
        /// </summary>
        /// <value>
        ///   <c>true</c> 如果要求 TextBox 控件的值为工号；否则为 <c>false</c>.
        /// </value>
        public bool EmployeeNo { get; set; }

        /// <summary>
        /// 指示 System.Windows.Forms.TextBox 控件的值能否为员工姓名。
        /// </summary>
        /// <value>
        ///   <c>true</c> 如果要求 TextBox 控件的值为员工姓名；否则为 <c>false</c>.
        /// </value>
        public bool EmployeeName { get; set; }

        /// <summary>
        /// 指示 System.Windows.Forms.TextBox 控件的值是否为身份证。
        /// </summary>
        /// <value>
        ///   <c>true</c> 如果要求 TextBox 控件的值为身份证；否则为 <c>false</c>.
        /// </value>
        public bool IdCardNo { get; set; }

        /// <summary>
        /// 指示 System.Windows.Forms.TextBox 控件的值是否为yyyy-MM-dd格式的日期。
        /// </summary>
        /// <value>
        ///   <c>true</c> 如果要求 TextBox 控件的值为yyyy-MM-dd格式的日期；否则为 <c>false</c>.
        /// </value>
        public bool Date { get; set; }

        /// <summary>
        /// 校验 textBox 参数的 Text 属性是否符合该 TextBoxValidator 对象的要求
        /// </summary>
        /// <param name="textBox">要校验的 System.Windows.Forms.TextBox 控件</param>
        /// <returns></returns>
        public bool Validate(TextBox textBox)
        {
            return Validate(textBox.Text);
        }

        /// <summary>
        /// 校验 value 参数是否符合该 TextBoxValidator 对象的要求
        /// </summary>
        /// <param name="value">要校验的字符串</param>
        /// <returns>符合要求返回 true；否则返回 false</returns>
        public bool Validate(string value)
        {
            bool result = true;
            if (Required)
            {
                result = result && (value.Length != 0);
            }
            if (DeptNo)
            {
                result = result && Regex.IsMatch(value, @"^[A-Za-z0-9]+$");//字母或数字
            }
            if (DeptName)
            {
                result = result && Regex.IsMatch(value, @"^[A-Za-z\u4e00-\u9fa5]+$");//字母或汉字
            }
            if (EmployeeNo)
            {
                result = result && Regex.IsMatch(value, @"^[A-Za-z0-9]{6}$");//字母或数字，6位
            }
            if (EmployeeName)
            {
                result = result && Regex.IsMatch(value, @"^[A-Za-z\u4e00-\u9fa5]{2,}$");//字母或汉字，2位以上
            }
            if (IdCardNo)
            {
                result = result && Regex.IsMatch(value, @"^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$|^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}([0-9]|X)$");//身份证
            }
            if (Date)
            {
                result = result && Regex.IsMatch(value, @"^\d{4}-\d{1,2}-\d{1,2}");//日期
            }
            return result;
        }
    }
}
