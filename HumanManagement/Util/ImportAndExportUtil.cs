using HumanManagement.Data;
using System.Windows.Forms;
using System.Xml;

namespace HumanManagement.Util
{
    class ImportAndExportUtil
    {
        /// <summary>
        /// 导出名为fileName，数据为treeNode的XML文档
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="treeNode">数据来源</param>
        public static void ExportXml(string fileName, TreeNode treeNode)
        {
            XmlDocument xml = new XmlDocument();
            xml.AppendChild(xml.CreateXmlDeclaration("1.0", "UTF-8", null));

            XmlElement xe = CreateXmlElementByTreeNode(treeNode, xml);
            xml.AppendChild(CreateXmlTree(treeNode.Nodes, xml, xe));

            xml.Save(fileName);
        }

        /// <summary>
        /// 通过遍历TreeNodeCollection对象创建XmlElement树，并作为parent的子节点
        /// </summary>
        /// <param name="treeNodes">数据来源</param>
        /// <param name="xml">目标XML文档</param>
        /// <param name="parent">生成对象的父节点</param>
        /// <returns></returns>
        public static XmlElement CreateXmlTree(TreeNodeCollection treeNodes, XmlDocument xml, XmlElement parent)
        {
            if (treeNodes.Count != 0)
            {
                foreach (TreeNode treeNode in treeNodes)
                {
                    XmlElement xe = CreateXmlElementByTreeNode(treeNode, xml);

                    parent.AppendChild(CreateXmlTree(treeNode.Nodes, xml, xe));
                }
            }
            return parent;
        }

        /// <summary>
        /// 通过treeNode生成XmlElement
        /// </summary>
        /// <param name="treeNode">数据来源</param>
        /// <param name="xml">目标XML文档</param>
        public static XmlElement CreateXmlElementByTreeNode(TreeNode treeNode, XmlDocument xml)
        {
            XmlElement xe = xml.CreateElement(treeNode.Text);

            XmlAttribute no = xml.CreateAttribute("编号");
            XmlAttribute typeString = xml.CreateAttribute("类型");

            if (NodeType.Dept == NodeTypeUtil.NodeTypeOf(treeNode) || NodeType.Company == NodeTypeUtil.NodeTypeOf(treeNode))
            {
                DeptInfo deptInfo = (DeptInfo)treeNode.Tag;
                no.Value = deptInfo.No;
                typeString.Value = deptInfo.TypeString;

                XmlAttribute remarks = xml.CreateAttribute("备注");
                remarks.Value = deptInfo.Remarks;
                xe.Attributes.Append(remarks);
            }
            if (NodeType.Employee == NodeTypeUtil.NodeTypeOf(treeNode))
            {
                EmployeeInfo employeeInfo = (EmployeeInfo)treeNode.Tag;
                no.Value = employeeInfo.No;
                typeString.Value = employeeInfo.TypeString;

                XmlAttribute idCardNo = xml.CreateAttribute("身份证");
                idCardNo.Value = employeeInfo.IdCardNo;
                xe.Attributes.Append(idCardNo);
                XmlAttribute birthday = xml.CreateAttribute("生日");
                birthday.Value = employeeInfo.Birthday;
                xe.Attributes.Append(birthday);
                XmlAttribute birthplace = xml.CreateAttribute("籍贯");
                birthplace.Value = employeeInfo.Birthplace;
                xe.Attributes.Append(birthplace);
                XmlAttribute entryTime = xml.CreateAttribute("入厂时间");
                entryTime.Value = employeeInfo.EntryTime;
                xe.Attributes.Append(entryTime);
            }

            xe.Attributes.Append(no);
            xe.Attributes.Append(typeString);

            return xe;
        }

        /// <summary>
        /// 导入名为fileName的XML文档到treeView控件中
        /// </summary>
        /// <param name="fileName">XML文件名</param>
        /// <param name="covered">是否覆盖现有treeView控件的节点</param>
        /// <param name="treeView">目标treeView控件</param>
        public static void ImportXml(string fileName, bool covered, TreeView treeView)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(fileName);
            TreeNode newTreeNode = new TreeNode(xml.DocumentElement.Name)
            {
                Tag = CreateTreeNodeTagElementByXmlNode(xml.DocumentElement)
            };

            CreateTreeNode(xml.DocumentElement, newTreeNode);
            if (covered)
            {
                treeView.Nodes.Clear();
                treeView.Nodes.Add(newTreeNode);
            }
            else
            {
                treeView.SelectedNode.Nodes.Add(newTreeNode);
            }
        }

        /// <summary>
        /// 通过遍历XmlNode创建TreeNode对象树，并作为parent的子节点
        /// </summary>
        /// <param name="xmlNode">数据来源</param>
        /// <param name="parent">生成对象的父节点</param>
        public static void CreateTreeNode(XmlNode xmlNode, TreeNode parent)
        {
            for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
            {
                TreeNode newTreeNode = new TreeNode
                {
                    Text = xmlNode.ChildNodes[i].Name,
                    Tag = CreateTreeNodeTagElementByXmlNode(xmlNode.ChildNodes[i])
                };

                parent.Nodes.Add(newTreeNode);
                CreateTreeNode(xmlNode.ChildNodes[i], parent.Nodes[i]);
            }
        }

        /// <summary>
        /// 通过XmlNode生成TreeNodeTag对象
        /// </summary>
        /// <param name="xmlNode">数据来源</param>
        /// <returns>TreeNodeTag对象</returns>
        public static NodeInfo CreateTreeNodeTagElementByXmlNode(XmlNode xmlNode)
        {
            NodeInfo nodeInfo = null;
            if (NodeType.Company == NodeTypeUtil.NodeTypeOf(xmlNode) || NodeType.Dept == NodeTypeUtil.NodeTypeOf(xmlNode))
            {
                nodeInfo = new DeptInfo(xmlNode.Attributes["编号"].Value, xmlNode.Name, xmlNode.Attributes["备注"].Value, xmlNode.Attributes["类型"].Value);
            }
            else if (NodeType.Employee == NodeTypeUtil.NodeTypeOf(xmlNode))
            {
                nodeInfo = new EmployeeInfo(xmlNode.Attributes["编号"].Value, xmlNode.Name, xmlNode.Attributes["身份证"].Value, xmlNode.Attributes["生日"].Value, xmlNode.Attributes["籍贯"].Value, xmlNode.Attributes["入厂时间"].Value, xmlNode.Attributes["类型"].Value);
            }
            return nodeInfo;
        }

    }
}
