using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HumanManagement.Data
{
    class EmployeeInfo : NodeInfo
    {
        private string _deptNo;
        public string DeptNo { get { return this._deptNo; } set { this._deptNo = value; } }

        private string _deptName;
        public string DeptName { get { return this._deptName; } set { this._deptName = value; } }

        private string _employeeName;
        public string EmployeeName { get { return this._employeeName; } set { this._employeeName = value; } }

        private string _idCardNo;
        public string IdCardNo { get { return this._idCardNo; } set { this._idCardNo = value; } }

        private string _birthday;
        public string Birthday { get { return this._birthday; } set { this._birthday = value; } }

        private string _birthplace;
        public string Birthplace { get { return this._birthplace; } set { this._birthplace = value; } }

        private string _entryTime;
        public string EntryTime { get { return this._entryTime; } set { this._entryTime = value; } }

        public EmployeeInfo()
        {
        }

        public EmployeeInfo(string employeeNo, string employeeName, string idCardNo, string birthday, string birthplace, string entryTime, string typeString)
        {
            base.No = employeeNo;
            this._employeeName = employeeName;
            this._idCardNo = idCardNo;
            this._birthday = birthday;
            this._birthplace = birthplace;
            this._entryTime = entryTime;
            base.TypeString = typeString;
        }

        public string[] ToStringArray()
        {
            return new string[] { No, EmployeeName, IdCardNo, Birthday, Birthplace, EntryTime };
        }
    }
}
