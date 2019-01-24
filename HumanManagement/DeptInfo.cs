using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HumanManagement.Data
{
    class DeptInfo : NodeInfo
    {
        private string _parentDeptNo;
        public string ParentDeptNo
        {
            get { return this._parentDeptNo; }
            set { this._parentDeptNo = value; }
        }

        private string _parentDeptName;
        public string ParentDeptName
        {
            get { return this._parentDeptName; }
            set { this._parentDeptName = value; }
        }

        private string _deptName;
        public string DeptName
        {
            get { return this._deptName; }
            set { this._deptName = value; }
        }

        private string _remarks;
        public string Remarks
        {
            get { return this._remarks; }
            set { this._remarks = value; }
        }

        public DeptInfo()
        {
        }

        public DeptInfo(string deptNo, string deptName, string remarks, string typeString)
        {
            base.No = deptNo;
            this._deptName = deptName;
            this._remarks = remarks;
            base.TypeString = typeString;
        }

        public DeptInfo(string parentDeptNo, string parentDeptName, string deptNo, string deptName, string remarks)
        {
            this._parentDeptNo = parentDeptNo;
            this._parentDeptName = parentDeptName;
            base.No = deptNo;
            this._deptName = deptName;
            this._remarks = remarks;
        }
    }
}
