using System.Drawing;

namespace BindingSourceSolution.Data
{
    /// <summary>
    /// 人员管理系统项目顶层的抽象数据结构，所有数据结构都继承该类。
    /// </summary>
    abstract class NodeInfo
    {
        /// <summary>
        /// 编号字段。
        /// </summary>
        private string _no;
        /// <summary>
        /// 获取或设置编号。
        /// </summary>
        /// <value>
        /// 编号
        /// </value>
        public string No
        {
            get { return _no; }
            set { _no = value; }
        }

        /// <summary>
        /// HumanManagement.Util.NodeType 枚举类型的字符串字段。
        /// </summary>
        private string _typeString;
        /// <summary>
        /// 获取或设置 HumanManagement.Util.NodeType 枚举类型的字符串
        /// </summary>
        /// <value>
        /// HumanManagement.Util.NodeType 枚举类型的字符串
        /// </value>
        public string TypeString
        {
            get { return _typeString; }
            set { _typeString = value; }
        }

        /// <summary>
        /// 节点的文本颜色字段。
        /// </summary>
        private Color _textColor;
        /// <summary>
        /// 获取或设置 节点的文本颜色。
        /// </summary>
        /// <value>
        /// 节点的文本颜色
        /// </value>
        public Color TextColor
        {
            get { return _textColor; }
            set { _textColor = value; }
        }
    }
}
