using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ImportAndExportSolution
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExportXml("export.xml", treeView1.SelectedNode);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExportXml("export.xml", treeView1.TopNode);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ImportXml("export.xml", false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ImportXml("export.xml", true);
        }


        /// <summary>
        /// 导出名为fileName，数据为treeNode的XML
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="treeNode">数据</param>
        private void ExportXml(string fileName, TreeNode treeNode)
        {
            XmlDocument xml = new XmlDocument();
            xml.AppendChild(xml.CreateXmlDeclaration("1.0", "UTF-8", null));

            XmlElement xe = xml.CreateElement(treeNode.Text);
            xml.AppendChild(CreateXmlTree(treeNode.Nodes, xml, xe));

            xml.Save(fileName);
        }

        /// <summary>
        /// 通过遍历TreeNodeCollection对象创建XmlElement树，parent为该XmlElement树的父节点
        /// </summary>
        /// <param name="treeNodes">要遍历的TreeNodeCollection对象</param>
        /// <param name="xml">目标XML文档</param>
        /// <param name="parent">XmlElement树的父节点</param>
        /// <returns></returns>
        private XmlElement CreateXmlTree(TreeNodeCollection treeNodes, XmlDocument xml, XmlElement parent)
        {
            if (treeNodes.Count != 0)
            {
                foreach (TreeNode treeNode in treeNodes)
                {
                    XmlElement xe = xml.CreateElement(treeNode.Text);
                    parent.AppendChild(CreateXmlTree(treeNode.Nodes, xml, xe));
                }
            }
            return parent;
        }


        private void ImportXml(string fileName, bool clear)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(fileName);
            TreeNode newTreeNode = new TreeNode(xml.DocumentElement.Name);
            CreateTreeNode(xml.DocumentElement, newTreeNode);
            if (clear)
            {
                treeView1.Nodes.Clear();
                treeView1.Nodes.Add(newTreeNode);
            }
            else
            {
                treeView1.SelectedNode.Nodes.Add(newTreeNode);
            }
        }

        private void CreateTreeNode(XmlNode xmlElement, TreeNode parent)
        {
                for (int i = 0; i < xmlElement.ChildNodes.Count; i++)
                {
                    TreeNode newTreeNode = new TreeNode();
                    newTreeNode.Text = xmlElement.ChildNodes[i].Name;
                    parent.Nodes.Add(newTreeNode);
                    CreateTreeNode(xmlElement.ChildNodes[i], parent.Nodes[i]);
                }
        }
    }
}
