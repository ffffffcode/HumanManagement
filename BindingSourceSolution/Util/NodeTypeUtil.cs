using BindingSourceSolution.Data;
using System.Windows.Forms;
using System.Xml;

namespace BindingSourceSolution.Util
{
    /// <summary>
    /// 节点类型枚举
    /// </summary>
    enum NodeType
    {
        Company = 1, Dept, Employee, Null
    }

    class NodeTypeUtil
    {
        /// <summary>
        /// 指示 treeNode 参数是否为公司节点
        /// </summary>
        /// <param name="treeNode">要判断的TreeNode对象</param>
        /// <returns>
        ///   <c>true</c> 如果该 treeNode 参数为公司节点; 否则, <c>false</c>.
        /// </returns>
        public static bool IsCompany(TreeNode treeNode)
        {
            return NodeType.Company == NodeTypeOf(treeNode);
        }

        /// <summary>
        /// 指示 xmlNode 参数是否为公司节点
        /// </summary>
        /// <param name="xmlNode">要判断的XML节点</param>
        /// <returns>
        ///   <c>true</c> 如果该 xmlNode 参数为公司节点; 否则, <c>false</c>.
        /// </returns>
        public static bool IsCompany(XmlNode xmlNode)
        {
            return NodeType.Company == NodeTypeOf(xmlNode);
        }

        /// <summary>
        /// 指示 treeNode 参数是否为部门节点
        /// </summary>
        /// <param name="treeNode">要判断的TreeNode对象</param>
        /// <returns>
        ///   <c>true</c> 如果该 treeNode 参数为部门节点; 否则, <c>false</c>.
        /// </returns>
        public static bool IsDept(TreeNode treeNode)
        {
            return NodeType.Dept == NodeTypeOf(treeNode);
        }

        /// <summary>
        /// 指示 xmlNode 参数是否为部门节点
        /// </summary>
        /// <param name="xmlNode">要判断的XML节点</param>
        /// <returns>
        ///   <c>true</c> 如果该 xmlNode 参数为部门节点; 否则, <c>false</c>.
        /// </returns>
        public static bool IsDept(XmlNode xmlNode)
        {
            return NodeType.Dept == NodeTypeOf(xmlNode);
        }

        /// <summary>
        /// 指示 treeNode 参数是否为员工节点
        /// </summary>
        /// <param name="treeNode">要判断的TreeNode对象</param>
        /// <returns>
        ///   <c>true</c> 如果该 treeNode 参数为员工节点; 否则, <c>false</c>.
        /// </returns>
        public static bool IsEmployee(TreeNode treeNode)
        {
            return NodeType.Employee == NodeTypeOf(treeNode);
        }

        /// <summary>
        /// 指示 xmlNode 参数是否为员工节点
        /// </summary>
        /// <param name="xmlNode">要判断的XML节点</param>
        /// <returns>
        ///   <c>true</c> 如果该 xmlNode 参数为员工节点; 否则, <c>false</c>.
        /// </returns>
        public static bool IsEmployee(XmlNode xmlNode)
        {
            return NodeType.Employee == NodeTypeOf(xmlNode);
        }

        /// <summary>
        /// 判断参数 treeNode 参数节点类型
        /// </summary>
        /// <param name="treeNode"></param>
        /// <returns>treeNode 参数节点类型，返回类型为 HumanManagement.Util.NodeType 枚举</returns>
        public static NodeType NodeTypeOf(TreeNode treeNode)
        {
            if (treeNode != null)
            {
                NodeInfo nodeInfo = (NodeInfo)treeNode.Tag;
                return NodeTypeOf(nodeInfo.TypeString);
            }
            return NodeType.Null;
        }

        /// <summary>
        /// 判断参数 xmlNode 参数节点类型
        /// </summary>
        /// <param name="xmlNode"></param>
        /// <returns>xmlNode 参数节点类型，返回类型为 HumanManagement.Util.NodeType 枚举</returns>
        public static NodeType NodeTypeOf(XmlNode xmlNode)
        {

            if (xmlNode != null)
            {
                return NodeTypeOf(xmlNode.Attributes["类型"].Value);
            }
            return NodeType.Null;
        }

        private static NodeType NodeTypeOf(string s)
        {
            switch (s)
            {
                case "公司":
                    return NodeType.Company;
                case "部门":
                    return NodeType.Dept;
                case "员工":
                    return NodeType.Employee;
                default:
                    return NodeType.Null;
            }
        }
    }
}
