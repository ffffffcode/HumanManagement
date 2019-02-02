using System.Text;

namespace HumanManagementSQLServer.Data
{
    /// <summary>
    /// 员工节点的数据结构
    /// </summary>
    /// <seealso cref="HumanManagementSQLServer.Data.NodeInfo" />
    class EmpInfo : NodeInfo
    {
        /// <summary>
        /// 员工的部门编号字段。
        /// </summary>
        private string _deptNo;
        /// <summary>
        /// 获取或设置员工的部门编号。
        /// </summary>
        /// <value>
        /// 员工的部门编号
        /// </value>
        public string DeptNo { get { return _deptNo; } set { _deptNo = value; } }

        /// <summary>
        /// 员工的部门名称字段。
        /// </summary>
        private string _deptName;
        /// <summary>
        /// 获取或设置员工的部门名称。
        /// </summary>
        /// <value>
        /// The name of the dept.
        /// </value>
        public string DeptName { get { return _deptName; } set { _deptName = value; } }

        /// <summary>
        /// 员工的名称字段。
        /// </summary>
        private string _empName;
        /// <summary>
        /// 获取或设置员工的名称。
        /// </summary>
        /// <value>
        /// 员工的名称
        /// </value>
        public string EmpName { get { return _empName; } set { _empName = value; } }

        /// <summary>
        /// 员工的身份证字段。
        /// </summary>
        private string _idCardNo;
        /// <summary>
        /// 获取或设置员工的身份证。
        /// </summary>
        /// <value>
        /// 员工的身份证
        /// </value>
        public string IdCardNo { get { return _idCardNo; } set { _idCardNo = value; } }

        /// <summary>
        /// 员工的生日字段，模式为yyyy-MM-dd。
        /// </summary>
        private string _birthday;
        /// <summary>
        /// 获取或设置员工的生日，模式为yyyy-MM-dd。
        /// </summary>
        /// <value>
        /// 员工的生日
        /// </value>
        public string Birthday { get { return _birthday; } set { _birthday = value; } }

        /// <summary>
        /// 员工的籍贯字段。
        /// </summary>
        private string _birthplace;
        /// <summary>
        /// 获取或设置员工的籍贯。
        /// </summary>
        /// <value>
        /// 员工的籍贯
        /// </value>
        public string Birthplace { get { return _birthplace; } set { _birthplace = value; } }

        /// <summary>
        /// 员工的入厂时间字段。
        /// </summary>
        private string _entryTime;
        /// <summary>
        /// 获取或设置员工的入厂时间。
        /// </summary>
        /// <value>
        /// 员工的入厂时间
        /// </value>
        public string EntryTime { get { return _entryTime; } set { _entryTime = value; } }

        public EmpInfo()
        {
        }

        public EmpInfo(string empNo, string empName, string idCardNo, string birthday, string birthplace, string entryTime, string typeString)
        {
            base.No = empNo;
            _empName = empName;
            _idCardNo = idCardNo;
            _birthday = birthday;
            _birthplace = birthplace;
            _entryTime = entryTime;
            base.TypeString = typeString;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("编号：" + No);
            result.AppendLine("姓名：" + EmpName);
            result.AppendLine("身份证：" + IdCardNo);
            result.AppendLine("出生日期：" + Birthday);
            result.AppendLine("籍贯：" + Birthplace);
            result.AppendLine("入厂日期：" + EntryTime);
            return result.ToString();
        }
    }
}
