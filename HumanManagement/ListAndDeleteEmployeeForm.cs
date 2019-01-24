using HumanManagement.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HumanManagement
{
    public partial class ListAndDeleteEmployeeForm : Form
    {
        private string _deptNo;

        public string DeptNo
        {
            get { return _deptNo; }
            set { _deptNo = value; }
        }

        private string _deptName;
        public string DeptName
        {
            get { return _deptName; }
            set { _deptName = value; }
        }

        private List<EmployeeInfo> _employeeInfos;
        internal List<EmployeeInfo> EmployeeInfos
        {
            get { return _employeeInfos; }
            set { _employeeInfos = value; }
        }

        public ListAndDeleteEmployeeForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListAndDeleteEmployeeForm_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = this._deptNo;
            this.textBox2.Text = this._deptName;
            foreach (EmployeeInfo employeeInfo in this._employeeInfos)
            {
                dataGridView1.Rows.Add(employeeInfo.ToStringArray());
            }
        }
    }
}
