using HumanManagement.Data;
using HumanManagement.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace HumanManagement
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 与子窗体交换数据的委托
        /// </summary>
        /// <param name="data">传送给子窗体的数据</param>
        /// <returns>子窗体返回的数据</returns>
        internal delegate void ExchangeDataHandler(object data);
        internal ExchangeDataHandler exchangeDataHandler;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 主窗体载入时，加载 human.xml 的数据到 tvHuman 控件中。
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            FileInfo data = new FileInfo("human.xml");
            //初始化文件存在，则加载
            if (data.Exists)
            {
                try
                {
                    ImportAndExportUtil.ImportXml("human.xml", true, tvHuman);
                }
                catch (XmlException exception)
                {
                    //如果发生XmlException异常则说明数据文件已损坏
                    string baseFileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + exception.GetType().Name;
                    //备份human.xml
                    data.CopyTo(baseFileName + ".xml", true);
                    using (StreamWriter streamWriter = new StreamWriter(baseFileName + ".log"))
                    {
                        streamWriter.Write(exception.Message);
                    }
                    //删除human.xml
                    data.Delete();
                    //重新加载窗体
                    MainForm_Load(sender, e);
                }
            }
            //初始化文件不存在，则进入初始化
            else
            {
                //创建初始化窗体（创建公司窗体）
                CreatCompanyForm creatCompanyForm = new CreatCompanyForm();
                creatCompanyForm.ShowDialog();
                //如果creatCompanyForm返回OK，则在tvHuman控件中添加公司节点
                if (creatCompanyForm.DialogResult == DialogResult.OK)
                {
                    tvHuman.Nodes.Clear();
                    DeptInfo deptInfo = creatCompanyForm.DeptInfo;
                    TreeNode companyTreeNode = new TreeNode(deptInfo.DeptName)
                    {
                        Tag = deptInfo
                    };
                    tvHuman.Nodes.Add(companyTreeNode);
                }
                //否则关闭主窗体
                else
                {
                    Close();
                }

            }
        }

        /// <summary>
        /// 主窗体关闭前，把 tvHuman 控件中的全部数据写到 human.xml 中。
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ImportAndExportUtil.ExportXml("human.xml", tvHuman.TopNode);
        }

        /// <summary>
        /// 选择 tvHuman 控件中的节点后，在 txtHumanData 控件中显示该节点信息，并更改按钮的启用属性。
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TreeViewEventArgs"/> instance containing the event data.</param>
        private void tvHuman_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = tvHuman.SelectedNode;
            if (NodeTypeUtil.IsDept(selectedNode))
            {
                DeptInfo deptInfo = (DeptInfo)selectedNode.Tag;
                txtHumanData.Text = deptInfo.ToString();

                //修改按钮的 Enabled 属性，启用属于部门功能的按钮，禁用输入员工功能的按钮
                btnAddDept.Enabled = true;
                btnModDept.Enabled = true;
                btnDelDept.Enabled = true;
                btnAddEmployee.Enabled = true;
                btnModEmployee.Enabled = false;
                btnDelEmployee.Enabled = false;
                btnListEmployee.Enabled = true;
            }
            if (NodeTypeUtil.IsEmployee(selectedNode))
            {
                EmployeeInfo employeeInfo = (EmployeeInfo)selectedNode.Tag;
                txtHumanData.Text = employeeInfo.ToString();

                //修改按钮的Enabled属性，启用修改员工按钮和删除员工按钮，禁用所有功能的按钮
                btnAddDept.Enabled = false;
                btnModDept.Enabled = false;
                btnDelDept.Enabled = false;
                btnAddEmployee.Enabled = false;
                btnModEmployee.Enabled = true;
                btnDelEmployee.Enabled = true;
                btnListEmployee.Enabled = false;
            }
            if (NodeTypeUtil.IsCompany(selectedNode))
            {
                DeptInfo deptInfo = (DeptInfo)selectedNode.Tag;
                txtHumanData.Text = deptInfo.ToString();

                //修改按钮的Enabled属性，启用添加部门按钮，禁用其他按钮
                btnAddDept.Enabled = true;
                btnModDept.Enabled = false;
                btnDelDept.Enabled = false;
                btnAddEmployee.Enabled = false;
                btnModEmployee.Enabled = false;
                btnDelEmployee.Enabled = false;
                btnListEmployee.Enabled = false;
            }
        }

        /// <summary>
        /// 添加部门按钮点击事件，用于 添加部门。
        /// </summary>
        /// <param name="sender">The source of the event.</param>ExchangeDataHandler
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnAddDept_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvHuman.SelectedNode;

            //创建添加部门窗体
            AddOrModDeptForm addDeptForm = new AddOrModDeptForm
            {
                Owner = this,
                Text = btnAddDept.Text
            };

            //把 addDeptForm.ExchangeDataHandler 方法添加到 exchangeDataHandler 委托中
            exchangeDataHandler = new ExchangeDataHandler(addDeptForm.ExchangeDataHandler);

            //要传给 addDeptForm 对象的数据
            DeptInfo deptInfo = new DeptInfo
            {
                ParentDeptNo = ((DeptInfo)selectedNode.Tag).No,
                ParentDeptName = selectedNode.Text
            };

            exchangeDataHandler(deptInfo);

            //如果在 addDeptForm 添加部门窗体中点击确定，则在所选的节点下添加部门
            if (addDeptForm.ShowDialog() == DialogResult.OK)
            {
                TreeNode newTreeNode = new TreeNode
                {
                    Text = addDeptForm.DeptInfo.DeptName,
                    Tag = addDeptForm.DeptInfo
                };
                selectedNode.Nodes.Add(newTreeNode);
            }
        }

        /// <summary>
        /// 修改部门按钮点击事件，用于 修改部门。
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnModDept_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvHuman.SelectedNode;

            //创建修改部门窗体
            AddOrModDeptForm modDeptForm = new AddOrModDeptForm
            {
                Owner = this,
                Text = btnModDept.Text
            };

            //把 modDeptForm.ExchangeDataHandler 方法添加到 exchangeDataHandler 委托中
            exchangeDataHandler = new ExchangeDataHandler(modDeptForm.ExchangeDataHandler);

            //要传给 modDeptForm 对象的数据
            DeptInfo deptInfo = new DeptInfo
            {
                ParentDeptNo = ((DeptInfo)selectedNode.Parent.Tag).No,
                ParentDeptName = selectedNode.Parent.Text,
                No = ((DeptInfo)selectedNode.Tag).No,
                DeptName = selectedNode.Text,
                Remarks = ((DeptInfo)selectedNode.Tag).Remarks
            };

            exchangeDataHandler(deptInfo);

            //如果在 modDeptForm 修改部门窗体中点击确定，则在修改部门信息
            if (modDeptForm.ShowDialog() == DialogResult.OK)
            {
                selectedNode.Text = modDeptForm.DeptInfo.DeptName;
                selectedNode.Tag = modDeptForm.DeptInfo;
                //修改完成后，触发 tvHuman_AfterSelect 事件，以在 tvHuman 控件中显示修改完成后的数据。
                tvHuman_AfterSelect(sender, null);
            }
        }

        /// <summary>
        /// 删除部门按钮点击事件，用于 删除部门。
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnDelDept_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvHuman.SelectedNode;
            {
                DialogResult result = DialogResult.Cancel;
                //如果还有所要删除的节点还有子节点，则列出子节点列表，询问用户是否删除
                if (selectedNode.Nodes.Count != 0)
                {
                    StringBuilder outMessage = new StringBuilder();
                    result = MessageBox.Show(selectedNode.Text + "\n" + TreeNodeUtil.GetChilderNodeTextList(selectedNode, outMessage) + "将会被删除，是否删除？", "请确认", MessageBoxButtons.OKCancel);
                }
                //如果所要删除的节点中没有子节点，则询问用户是否删除
                else
                {
                    result = MessageBox.Show("是否删除\"" + selectedNode.FullPath + "\"节点", "请确认", MessageBoxButtons.OKCancel);
                }
                //执行删除或什么都不做
                if (result == DialogResult.OK)
                {
                    selectedNode.Remove();
                }
            }
        }

        /// <summary>
        /// 添加员工按钮点击事件，用于 添加员工。
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvHuman.SelectedNode;

            //创建添加员工窗体
            AddOrModEmployeeForm addEmployForm = new AddOrModEmployeeForm
            {
                Owner = this,
                Text = btnAddEmployee.Text
            };

            //把 addEmployForm.ExchangeDataHandler 方法添加到 exchangeDataHandler 委托中
            exchangeDataHandler = new ExchangeDataHandler(addEmployForm.ExchangeDataHandler);

            //要传给 addEmployForm 对象的数据
            EmployeeInfo employeeInfo = new EmployeeInfo
            {
                DeptNo = ((DeptInfo)selectedNode.Tag).No,
                DeptName = selectedNode.Text,
            };

            exchangeDataHandler(employeeInfo);

            //如果在 addEmployForm 添加员工窗体中点击确定，则在添加员工节点到所选节点中
            if (addEmployForm.ShowDialog() == DialogResult.OK)
            {
                TreeNode newTreeNode = new TreeNode
                {
                    Text = addEmployForm.EmployeeInfo.EmployeeName,
                    Tag = addEmployForm.EmployeeInfo,
                    ForeColor = System.Drawing.Color.Green
                };
                selectedNode.Nodes.Add(newTreeNode);
            }
        }

        /// <summary>
        /// 修改员工按钮点击事件，用于 修改员工。
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnModEmployee_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvHuman.SelectedNode;

            //创建修改员工窗体
            AddOrModEmployeeForm modEmployeeform = new AddOrModEmployeeForm
            {
                Owner = this,
                Text = btnModEmployee.Text
            };

            //把 modEmployeeform.ExchangeDataHandler 方法添加到 exchangeDataHandler 委托中
            exchangeDataHandler = new ExchangeDataHandler(modEmployeeform.ExchangeDataHandler);

            //要传给 modEmployeeform 对象的数据
            EmployeeInfo employeeInfo = new EmployeeInfo
            {
                DeptNo = ((DeptInfo)selectedNode.Parent.Tag).No,
                DeptName = ((DeptInfo)selectedNode.Parent.Tag).DeptName,
                No = ((EmployeeInfo)selectedNode.Tag).No,
                EmployeeName = selectedNode.Text,
                IdCardNo = ((EmployeeInfo)selectedNode.Tag).IdCardNo,
                Birthday = ((EmployeeInfo)selectedNode.Tag).Birthday,
                Birthplace = ((EmployeeInfo)selectedNode.Tag).Birthplace,
                EntryTime = ((EmployeeInfo)selectedNode.Tag).EntryTime
            };

            exchangeDataHandler(employeeInfo);

            //如果在 modEmployeeform 添加员工窗体中点击确定，则在添加员工节点到所选节点中
            if (modEmployeeform.ShowDialog() == DialogResult.OK)
            {

                selectedNode.Text = modEmployeeform.EmployeeInfo.EmployeeName;
                selectedNode.Tag = modEmployeeform.EmployeeInfo;
                //修改完成后，触发 tvHuman_AfterSelect 事件，以在 tvHuman 控件中显示修改完成后的数据。
                tvHuman_AfterSelect(sender, null);
            }
        }

        /// <summary>
        /// 删除员工按钮点击事件，用于 删除员工。
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnDelEmployee_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvHuman.SelectedNode;
            EmployeeInfo employeeInfo = (EmployeeInfo)selectedNode.Tag;
            //提示用户是否删除
            DialogResult result = MessageBox.Show("是否删除节点？\r\n姓名：" + employeeInfo.EmployeeName + "\r\n身份证：" + employeeInfo.IdCardNo + "\r\n部门：" + selectedNode.Parent.Text, "是否删除", MessageBoxButtons.YesNo);
            //执行删除或什么都不做
            if (result == DialogResult.Yes)
            {
                selectedNode.Remove();
            }
        }

        /// <summary>
        /// 查看员工清单按钮点击事件，用于 查看员工清单。
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnListEmployee_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvHuman.SelectedNode;

            //创建查看员工清单窗体
            ListAndDeleteEmployeeForm listAndDeleteEmployeeForm = new ListAndDeleteEmployeeForm()
            {
                Owner = this
            };

            //把 modEmployeeform.ExchangeDataHandler 方法添加到 exchangeDataHandler 委托中
            exchangeDataHandler = new ExchangeDataHandler(listAndDeleteEmployeeForm.ExchangeDataHandler);

            //要传给 modEmployeeform 对象的数据
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("No", ((DeptInfo)selectedNode.Tag).No);
            data.Add("DeptName", selectedNode.Text);
            data.Add("TreeNodeCollection", selectedNode.Nodes);

            exchangeDataHandler(data);

            listAndDeleteEmployeeForm.ShowDialog();

            //从 listAndDeleteEmployeeForm 窗体中返回被删除的节点索引列表
            List<int> deletedTreeNodeIndexList = listAndDeleteEmployeeForm.DeletedTreeNodeIndexList;

            //根据节点索引列表删除节点
            if (deletedTreeNodeIndexList.Count != 0)
            {
                foreach (int item in deletedTreeNodeIndexList)
                {
                    selectedNode.Nodes.RemoveAt(item);
                }
            }
        }

        /// <summary>
        /// 导出所选节点按钮点击事件，用于 导出所选节点。
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnExportSelectedNode_Click(object sender, EventArgs e)
        {
            //保证所选节点不为空
            if (tvHuman.SelectedNode != null)
            {
                DoExport(tvHuman.SelectedNode);
            }
        }

        /// <summary>
        /// 导出所有节点按钮点击事件，用于 导出所有节点。
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnExportAllNode_Click(object sender, EventArgs e)
        {
            DoExport(tvHuman.TopNode);
        }

        /// <summary>
        /// 导出所选节点 和 导出所有节点 的抽象代码
        /// </summary>
        /// <param name="treeNode">要导出的 TreeNode 对象</param>
        private void DoExport(TreeNode treeNode)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "XML文档|*.xml",
                OverwritePrompt = true,
                Title = "请选择保存文件的路径"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ImportAndExportUtil.ExportXml(saveFileDialog.FileName, treeNode);
            }
        }

        /// <summary>
        /// 导入数据按钮点击事件，用于 导入数据。
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            string filename = txtImportingFilename.Text;
            if (!string.IsNullOrEmpty(filename))
            {
                FileInfo inputFile = new FileInfo(filename);
                if (inputFile.Exists)
                {
                    XmlDocument xml = new XmlDocument();
                    xml.Load(filename);
                    if (xml.DocumentElement.Attributes["类型"].Value == "公司")
                    {
                        if (MessageBox.Show("导入会覆盖现有数据，是否导入", "请确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            ImportAndExportUtil.ImportXml(filename, true, tvHuman);
                            txtHumanData.Text = "";
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }
                    ImportAndExportUtil.ImportXml(filename, false, tvHuman);
                }
                else
                {
                    MessageBox.Show("导入数据文件不存在。");
                }
            }
            else
            {
                MessageBox.Show("请选择导入数据文件。");
            }
        }

        /// <summary>
        /// 打开文件对话框，用于 选择导入数据时数据文件。
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Filter = "XML文档|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtImportingFilename.Text = openFileDialog.FileName;
            }
            else
            {
                txtImportingFilename.Text = "";
            }
        }
    }
}
