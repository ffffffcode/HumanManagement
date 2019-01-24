using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using HumanManagement.Data;

namespace HumanManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //TODO 添加初始化逻辑代码
            FileInfo data = new FileInfo("tree.xml");
            if (!data.Exists)
            {
                CreatCompanyForm form = new CreatCompanyForm();
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    MessageBox.Show("OK");
                }
                else
                {
                    this.Close();
                }
            }
            
            else
            {
                try
                {
                    XmlDocument xml = new XmlDocument();
                    xml.Load("tree.xml");
                    TreeNode treeNode = new TreeNode();
                    ReadTree(xml, xml, treeNode);
                    treeNode = treeNode.FirstNode;
                    treeView1.Nodes.Clear();
                    treeView1.Nodes.Add(treeNode);
                }
                catch (XmlException exception)
                {
                    string baseFileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + exception.GetType().Name;
                    //如果发生XmlException异常则说明数据文件已损坏
                    data.CopyTo(baseFileName + ".xml", true);
                    using (StreamWriter streamWriter = new StreamWriter(baseFileName + ".log"))
                    {
                        streamWriter.Write(exception.Message);
                    }
                    data.Delete();
                    this.Form1_Load(sender, e);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            WirteTree(treeView1.Nodes);
        }

        //在textBox2中显示节点信息
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            if (NodeType.Company == NodeTypeUtil.NodeTypeOf(selectedNode) || NodeType.Dept == NodeTypeUtil.NodeTypeOf(selectedNode))
            {
                DeptInfo deptInfo = (DeptInfo)selectedNode.Tag;
                StringBuilder text = new StringBuilder();
                text.AppendLine("编号：" + deptInfo.No);
                text.AppendLine("名称：" + selectedNode.Text);
                text.AppendLine("备注：" + deptInfo.Remarks);
                textBox2.Text = text.ToString();
            }
            if (NodeType.Employee == NodeTypeUtil.NodeTypeOf(selectedNode))
            {
                EmployeeInfo employeeInfo = (EmployeeInfo)selectedNode.Tag;
                StringBuilder text = new StringBuilder();
                text.AppendLine("编号：" + employeeInfo.No);
                text.AppendLine("姓名：" + selectedNode.Text);
                text.AppendLine("身份证：" + employeeInfo.IdCardNo);
                text.AppendLine("出生日期：" + employeeInfo.Birthday);
                text.AppendLine("籍贯：" + employeeInfo.Birthplace);
                text.AppendLine("入厂日期：" + employeeInfo.EntryTime);
                textBox2.Text = text.ToString();
            }
        }

        //添加部门
        private void button1_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            if (NodeType.Company == NodeTypeUtil.NodeTypeOf(selectedNode) || NodeType.Dept == NodeTypeUtil.NodeTypeOf(selectedNode))
            {
                AddOrUpdateDeptForm form = new AddOrUpdateDeptForm
                {
                    Owner = this,
                    Text = button1.Text
                };

                DeptInfo deptInfo = new DeptInfo
                {
                    ParentDeptNo = ((DeptInfo)selectedNode.Tag).No,
                    ParentDeptName = selectedNode.Text
                };

                form.DeptInfo = deptInfo;

                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    TreeNode newTreeNode = new TreeNode
                    {
                        Text = form.DeptInfo.DeptName,
                        Tag = form.DeptInfo
                    };
                    selectedNode.Nodes.Add(newTreeNode);
                }
            }
            else
            {
                MessageBox.Show("请在公司节点下添加部门。", "请确认");
            }
        }

        //修改部门
        private void button2_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            if (NodeType.Dept == NodeTypeUtil.NodeTypeOf(selectedNode))
            {
                AddOrUpdateDeptForm form = new AddOrUpdateDeptForm
                {
                    Owner = this,
                    Text = button2.Text
                };

                DeptInfo deptInfo = new DeptInfo
                {
                    ParentDeptNo = ((DeptInfo)selectedNode.Parent.Tag).No,
                    ParentDeptName = selectedNode.Parent.Text,
                    No = ((DeptInfo)selectedNode.Tag).No,
                    DeptName = selectedNode.Text,
                    Remarks = ((DeptInfo)selectedNode.Tag).Remarks
                };

                form.DeptInfo = deptInfo;

                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {

                    selectedNode.Text = form.DeptInfo.DeptName;
                    selectedNode.Tag = form.DeptInfo;
                    //修改完成后，触发treeView1_AfterSelect事件，以在textBox中显示修改完成后的数据。
                    treeView1_AfterSelect(sender, null);
                }
            }
            else
            {
                MessageBox.Show("请选择要修改的部门。", "请确认");
            }
        }

        //删除部门
        private void button3_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            if (NodeType.Dept == NodeTypeUtil.NodeTypeOf(selectedNode))
            {
                DialogResult result = DialogResult.Cancel;
                if (selectedNode.Nodes.Count != 0)
                {
                    StringBuilder outMessage = new StringBuilder();
                    result = MessageBox.Show(selectedNode.Text + "\n" + GetChilderNodeTextList(selectedNode, outMessage) + "将会被删除，是否删除？", "请确认", MessageBoxButtons.OKCancel);
                }
                else
                {
                    result = MessageBox.Show("是否删除\"" + selectedNode.Text + "\"节点", "请确认", MessageBoxButtons.OKCancel);
                }

                if (result == DialogResult.OK)
                {
                    selectedNode.Remove();
                }
            }
            else
            {
                MessageBox.Show("请选择部门。", "请确认");
            }
        }


        //添加员工
        private void button4_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            if (NodeType.Dept == NodeTypeUtil.NodeTypeOf(selectedNode))
            {
                AddOrUpdateEmployeeForm form = new AddOrUpdateEmployeeForm
                {
                    Owner = this,
                    Text = button4.Text
                };

                EmployeeInfo employeeInfo = new EmployeeInfo
                {
                    DeptNo = ((DeptInfo)selectedNode.Tag).No,
                    DeptName = selectedNode.Text,
                };

                form.EmployeeInfo = employeeInfo;

                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    TreeNode newTreeNode = new TreeNode
                    {
                        Text = form.EmployeeInfo.EmployeeName,
                        Tag = form.EmployeeInfo
                    };
                    selectedNode.Nodes.Add(newTreeNode);
                }
            }
            else
            {
                MessageBox.Show("请选择部门");
            }
        }

        //修改员工
        private void button5_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            if (NodeType.Employee == NodeTypeUtil.NodeTypeOf(selectedNode))
            {
                AddOrUpdateEmployeeForm form = new AddOrUpdateEmployeeForm
                {
                    Owner = this,
                    Text = button2.Text
                };

                EmployeeInfo employeeInfo = new EmployeeInfo
                {
                    No = ((EmployeeInfo)selectedNode.Tag).No,
                    EmployeeName = selectedNode.Text,
                    IdCardNo = ((EmployeeInfo)selectedNode.Tag).IdCardNo,
                    Birthday = ((EmployeeInfo)selectedNode.Tag).Birthday,
                    Birthplace = ((EmployeeInfo)selectedNode.Tag).Birthplace,
                    EntryTime = ((EmployeeInfo)selectedNode.Tag).EntryTime
                };

                form.EmployeeInfo = employeeInfo;

                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {

                    selectedNode.Text = form.EmployeeInfo.EmployeeName;
                    selectedNode.Tag = form.EmployeeInfo;
                    //修改完成后，触发treeView1_AfterSelect事件，以在textBox中显示修改完成后的数据。
                    treeView1_AfterSelect(sender, null);
                }
            }
            else
            {
                MessageBox.Show("请选择要修改的部门。", "请确认");
            }
        }

        //删除员工
        private void button6_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            if (NodeType.Employee == NodeTypeUtil.NodeTypeOf(selectedNode))
            {
                EmployeeInfo employeeInfo = (EmployeeInfo)selectedNode.Tag;
                DialogResult result = MessageBox.Show("是否删除节点？\r\n姓名：" + employeeInfo.EmployeeName + "\r\n身份证：" + employeeInfo.IdCardNo + "\r\n部门：" + selectedNode.Parent.Text, "是否删除", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    selectedNode.Remove();
                }
            }
        }

        //显示员工清单
        private void button7_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            if (NodeType.Dept == NodeTypeUtil.NodeTypeOf(selectedNode))
            {
                ListAndDeleteEmployeeForm form = new ListAndDeleteEmployeeForm()
                {
                    Owner = this
                };

                form.DeptNo = ((DeptInfo)selectedNode.Tag).No;
                form.DeptName = selectedNode.Text;
                List<EmployeeInfo> employeeInfos = new List<EmployeeInfo>();
                foreach (TreeNode item in selectedNode.Nodes)
                {
                    if (NodeType.Employee == NodeTypeUtil.NodeTypeOf(item))
                    {
                        employeeInfos.Add((EmployeeInfo)item.Tag);
                    }
                }
                form.EmployeeInfos = employeeInfos;

                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择部门。", "请确认");
            }
        }

        /// <summary>
        /// 写树时遍历功能，被“写树功能”调用
        /// </summary>
        /// <param name="nodeCollection">treeView控件的Nodes属性</param>
        /// <param name="xml">要写出的XML文档</param>
        /// <param name="parent">第一个XML节点（这是递归属性）</param>
        private void NodeTraverse(TreeNodeCollection nodeCollection, XmlDocument xml, XmlNode parent)
        {
            if (nodeCollection.Count != 0)
            {
                foreach (TreeNode treeNode in nodeCollection)
                {
                    XmlElement xe = xml.CreateElement(treeNode.Text);
                    XmlAttribute no = xml.CreateAttribute("编号");
                    XmlAttribute typeString = xml.CreateAttribute("类型");

                    if (NodeType.Company == NodeTypeUtil.NodeTypeOf(treeNode) || NodeType.Dept == NodeTypeUtil.NodeTypeOf(treeNode))
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

                    parent.AppendChild(xe);
                    NodeTraverse(treeNode.Nodes, xml, xe);
                }
            }
        }

        /// <summary>
        /// 写树功能，将treeView控件数据写出到同级目录下名为“tree.xml”的文件中
        /// </summary>
        /// <param name="nodeCollection">treeView控件的Nodes属性</param>
        private void WirteTree(TreeNodeCollection nodeCollection)
        {
            //创建XMl及其声明
            XmlDocument xml = new XmlDocument();
            XmlDeclaration xmlDecl = xml.CreateXmlDeclaration("1.0", "UTF-8", null);
            xml.AppendChild(xmlDecl);

            NodeTraverse(nodeCollection, xml, xml);
            xml.Save("tree.xml");
        }

        /// <summary>
        /// 读树功能，将xml参数中的数据（同级目录的“tree.xml”）读到treeView控件中
        /// </summary>
        /// <param name="xml">要读入的XMl文档</param>
        /// <param name="node">第一个XML节点（这是递归属性）</param>
        /// <param name="src">treeView控件的Nodes属性</param>
        private void ReadTree(XmlDocument xml, XmlNode node, TreeNode src)
        {
            int index = 0;
            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                index = i;
                if (node.ChildNodes[i].Name == "xml")
                {
                    node.RemoveChild(node.ChildNodes[i]);
                    i--;
                }
                else
                {
                    NodeInfo nodeInfo = null;
                    if (NodeType.Company == NodeTypeUtil.NodeTypeOf(node.ChildNodes[i]) || NodeType.Dept == NodeTypeUtil.NodeTypeOf(node.ChildNodes[i]))
                    {
                        nodeInfo = new DeptInfo(node.ChildNodes[i].Attributes["编号"].Value, node.ChildNodes[i].Name, node.ChildNodes[i].Attributes["备注"].Value, node.ChildNodes[i].Attributes["类型"].Value);
                    }
                    else if (NodeType.Employee == NodeTypeUtil.NodeTypeOf(node.ChildNodes[i]))
                    {
                        nodeInfo = new EmployeeInfo(node.ChildNodes[i].Attributes["编号"].Value, node.ChildNodes[i].Name, node.ChildNodes[i].Attributes["身份证"].Value, node.ChildNodes[i].Attributes["生日"].Value, node.ChildNodes[i].Attributes["籍贯"].Value, node.ChildNodes[i].Attributes["入厂时间"].Value, node.ChildNodes[i].Attributes["类型"].Value);
                    }
                    TreeNode newTreeNode = new TreeNode();
                    newTreeNode.Text = node.ChildNodes[i].Name;
                    newTreeNode.Tag = nodeInfo;
                    src.Nodes.Add(newTreeNode);
                    ReadTree(xml, node.ChildNodes[i], src.Nodes[index]);
                }
            }
        }

        private string GetChilderNodeTextList(TreeNode parent, StringBuilder outMessage)
        {
            if (parent != null)
            {
                TreeNodeCollection childer = parent.Nodes;
                if (childer.Count != 0)
                {
                    foreach (TreeNode item in childer)
                    {
                        outMessage.AppendLine(item.Text);
                        GetChilderNodeTextList(item, outMessage);
                    }
                }
            }
            return outMessage.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            WirteTree(treeView1.Nodes);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("tree.xml");
            TreeNode treeNode = new TreeNode();
            ReadTree(xml, xml, treeNode);
            treeNode = treeNode.FirstNode;
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(treeNode);
        }

    }
}
