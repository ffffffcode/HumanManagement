using System.Text;

namespace HumanManagement.Data
{
    /// <summary>
    /// 部门节点的数据结构
    /// </summary>
    /// <seealso cref="HumanManagement.Data.NodeInfo" />
    class DeptInfo : NodeInfo
    {
        /// <summary>
        /// 部门的上级部门编号字段。
        /// </summary>
        private string _parentDeptNo;
        /// <summary>
        /// 获取或设置部门的上级部门编号。
        /// </summary>
        /// <value>
        /// 部门的上级部门编号
        /// </value>
        public string ParentDeptNo
        {
            get { return _parentDeptNo; }
            set { _parentDeptNo = value; }
        }

        /// <summary>
        /// 部门的上级部门名称字段。
        /// </summary>
        private string _parentDeptName;
        /// <summary>
        /// 获取或设置部门的上级部门名称。
        /// </summary>
        /// <value>
        /// 部门的上级部门名称
        /// </value>
        public string ParentDeptName
        {
            get { return _parentDeptName; }
            set { _parentDeptName = value; }
        }

        /// <summary>
        /// 部门名称字段。
        /// </summary>
        private string _deptName;
        /// <summary>
        /// 获取或设置部门名称。
        /// </summary>
        /// <value>
        /// 部门名称
        /// </value>
        public string DeptName
        {
            get { return _deptName; }
            set { _deptName = value; }
        }

        /// <summary>
        /// 部门的备注字段。
        /// </summary>
        private string _remarks;
        /// <summary>
        /// 获取或设置部门的备注。
        /// </summary>
        /// <value>
        /// 部门的备注
        /// </value>
        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

        public DeptInfo()
        {
        }

        public DeptInfo(string deptNo, string deptName, string remarks, string typeString)
        {
            base.No = deptNo;
            _deptName = deptName;
            _remarks = remarks;
            base.TypeString = typeString;
        }

        public DeptInfo(string parentDeptNo, string parentDeptName, string deptNo, string deptName, string remarks)
        {
            _parentDeptNo = parentDeptNo;
            _parentDeptName = parentDeptName;
            base.No = deptNo;
            _deptName = deptName;
            _remarks = remarks;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("编号：" + No);
            result.AppendLine("名称：" + DeptName);
            result.AppendLine("备注：" + Remarks);
            return result.ToString();
        }
    }
}
