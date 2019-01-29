namespace HumanManagementSQLServer.Validation
{
    /// <summary>
    /// System.Windows.Forms.TextBox 控件的校验生成器，用于构造校验器。
    /// </summary>
    class TextBoxValidatorBuilder
    {
        private TextBoxValidator validator = new TextBoxValidator();

        public TextBoxValidatorBuilder Required()
        {
            validator.Required = true;
            return this;
        }

        public TextBoxValidatorBuilder Required(bool required)
        {
            validator.Required = required;
            return this;
        }

        public TextBoxValidatorBuilder DeptNo()
        {
            validator.DeptNo = true;
            return this;
        }

        public TextBoxValidatorBuilder DeptNo(bool deptNo)
        {
            validator.DeptNo = deptNo;
            return this;
        }

        public TextBoxValidatorBuilder DeptName()
        {
            validator.DeptName = true;
            return this;
        }

        public TextBoxValidatorBuilder DeptName(bool deptName)
        {
            validator.DeptName = deptName;
            return this;
        }

        public TextBoxValidatorBuilder EmployeeNo()
        {
            validator.EmployeeNo = true;
            return this;
        }

        public TextBoxValidatorBuilder EmployeeNo(bool employeeNo)
        {
            validator.EmployeeNo = employeeNo;
            return this;
        }

        public TextBoxValidatorBuilder EmployeeName()
        {
            validator.EmployeeName = true;
            return this;
        }

        public TextBoxValidatorBuilder EmployeeName(bool employeeName)
        {
            validator.EmployeeName = employeeName;
            return this;
        }

        public TextBoxValidatorBuilder IdCardNo()
        {
            validator.IdCardNo = true;
            return this;
        }

        public TextBoxValidatorBuilder IdCardNo(bool idCardNo)
        {
            validator.IdCardNo = idCardNo;
            return this;
        }

        public TextBoxValidatorBuilder Date()
        {
            validator.Date = true;
            return this;
        }

        public TextBoxValidatorBuilder Date(bool date)
        {
            validator.Date = date;
            return this;
        }

        public TextBoxValidator Bulid()
        {
            return this.validator;
        }
    }
}
