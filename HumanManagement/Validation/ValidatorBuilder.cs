using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HumanManagement.Validation
{
    class ValidatorBuilder
    {
        private Validator validator = new Validator();

        public ValidatorBuilder Required()
        {
            validator.Required = true;
            return this;
        }

        public ValidatorBuilder Required(bool required)
        {
            validator.Required = required;
            return this;
        }

        public ValidatorBuilder DeptNo()
        {
            validator.DeptNo = true;
            return this;
        }

        public ValidatorBuilder DeptNo(bool deptNo)
        {
            validator.DeptNo = deptNo;
            return this;
        }

        public ValidatorBuilder DeptName()
        {
            validator.DeptName = true;
            return this;
        }

        public ValidatorBuilder DeptName(bool deptName)
        {
            validator.DeptName = deptName;
            return this;
        }

        public ValidatorBuilder EmployeeNo()
        {
            validator.EmployeeNo = true;
            return this;
        }

        public ValidatorBuilder EmployeeNo(bool employeeNo)
        {
            validator.EmployeeNo = employeeNo;
            return this;
        }

        public ValidatorBuilder EmployeeName()
        {
            validator.EmployeeName = true;
            return this;
        }

        public ValidatorBuilder EmployeeName(bool employeeName)
        {
            validator.EmployeeName = employeeName;
            return this;
        }

        public ValidatorBuilder IdCardNo()
        {
            validator.IdCardNo = true;
            return this;
        }

        public ValidatorBuilder IdCardNo(bool idCardNo)
        {
            validator.IdCardNo = idCardNo;
            return this;
        }

        public ValidatorBuilder IdCardDate()
        {
            validator.IdCardDate = true;
            return this;
        }

        public ValidatorBuilder IdCardDate(bool idCardDate)
        {
            validator.IdCardDate = idCardDate;
            return this;
        }

        public ValidatorBuilder Date()
        {
            validator.Date = true;
            return this;
        }

        public ValidatorBuilder Date(bool date)
        {
            validator.Date = date;
            return this;
        }

        public Validator Bulid()
        {
            return this.validator;
        }
    }
}
