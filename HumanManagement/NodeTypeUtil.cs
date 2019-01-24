using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HumanManagement.Data;

namespace HumanManagement
{
    enum NodeType
    {
        Company, Dept, Employee, Null
    }

    class NodeTypeUtil
    {
        /// <summary>
        /// 判断参数selectedNode节点类型
        /// </summary>
        /// <param name="selectedNode"></param>
        /// <returns></returns>
        public static NodeType NodeTypeOf(System.Windows.Forms.TreeNode treeNode)
        {
            if (treeNode != null)
            {
                NodeInfo nodeInfo = (NodeInfo)treeNode.Tag;
                return NodeTypeOf(nodeInfo.TypeString);
            }
            return NodeType.Null;
        }

        /// <summary>
        /// 判断参数xmlNode节点类型
        /// </summary>
        /// <param name="xmlNode"></param>
        /// <returns></returns>
        public static NodeType NodeTypeOf(System.Xml.XmlNode xmlNode)
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
