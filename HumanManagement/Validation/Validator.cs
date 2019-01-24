using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HumanManagement.Validation
{
    class Validator
    {
        public bool Required { get; set; }

        public bool DeptNo { get; set; }

        public bool DeptName { get; set; }

        public bool EmployeeNo { get; set; }

        public bool EmployeeName { get; set; }

        public bool IdCardNo { get; set; }

        public bool IdCardDate { get; set; }

        public bool Date { get; set; }

        public bool Validate(string s)
        {
            bool result = true;
            if (Required)
            {
                result = result && (s.Length != 0);
            }
            if (DeptNo)
            {
                result = result && Regex.IsMatch(s, @"^[A-Za-z0-9]+$");//字母或数字
            }
            if (DeptName)
            {
                result = result && Regex.IsMatch(s, @"^[A-Za-z\u4e00-\u9fa5]+$");//字母或汉字
            }
            if (EmployeeNo)
            {
                result = result && Regex.IsMatch(s, @"^[A-Za-z0-9]{6}$");//字母或数字，6位
            }
            if (EmployeeName)
            {
                result = result && Regex.IsMatch(s, @"^[A-Za-z\u4e00-\u9fa5]{2,}$");//字母或汉字，2位以上
            }
            if (IdCardNo)
            {
                result = result && Regex.IsMatch(s, @"^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$|^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}([0-9]|X)$");//身份证
            }
            if (Date)
            {
                result = result && Regex.IsMatch(s, @"^\d{4}-\d{1,2}-\d{1,2}");//日期
            }
            return result;
        }
    }
}
