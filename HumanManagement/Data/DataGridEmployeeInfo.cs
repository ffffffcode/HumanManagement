namespace HumanManagement.Data
{
    /// <summary>
    /// 用于传给 System.Windows.Forms.DataGridView 控件展示的数据结构
    /// </summary>
    /// <seealso cref="HumanManagement.Data.NodeInfo" />
    class DataGridEmployeeInfo : NodeInfo
    {
        /// <summary>
        /// 员工的名称字段。
        /// </summary>
        private string _employeeName;
        /// <summary>
        /// 获取或设置员工的名称。
        /// </summary>
        /// <value>
        /// 员工的名称
        /// </value>
        public string EmployeeName { get { return _employeeName; } set { _employeeName = value; } }

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

        /// <summary>
        /// 节点原始的索引字段。
        /// </summary>
        private string _index;
        /// <summary>
        /// 获取或设置节点原始的索引。
        /// </summary>
        /// <value>
        /// 节点原始的索引
        /// </value>
        public string Index { get { return _index; } set { _index = value; } }

        public string[] ToStringArray()
        {
            return new string[] { No, EmployeeName, IdCardNo, Birthday, Birthplace, EntryTime, Index };
        }
    }
}
