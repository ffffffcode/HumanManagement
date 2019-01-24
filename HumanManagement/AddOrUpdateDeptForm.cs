using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HumanManagement.Data;

namespace HumanManagement
{
    public partial class AddOrUpdateDeptForm : Form
    {
        private DeptInfo _deptInfo = new DeptInfo();
        internal DeptInfo DeptInfo
        {
            get
            {
                return this._deptInfo;
            }
            set
            {
                this._deptInfo = value;
                this.textBox1.Text = this._deptInfo.ParentDeptNo;
                this.textBox2.Text = this._deptInfo.ParentDeptName;
                this.maskedTextBox1.Text = this._deptInfo.No;
                this.maskedTextBox2.Text = this._deptInfo.DeptName;
                this.textBox5.Text = this._deptInfo.Remarks;
            }
        }

        public AddOrUpdateDeptForm()
        {
            InitializeComponent();
        }

        public AddOrUpdateDeptForm(string formName)
        {
            InitializeComponent();
            this.Text = formName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this._deptInfo.ParentDeptNo = this.textBox1.Text;
            this._deptInfo.ParentDeptName = this.textBox2.Text;
            this._deptInfo.No = this.maskedTextBox1.Text;
            this._deptInfo.DeptName = this.maskedTextBox2.Text;
            this._deptInfo.Remarks = this.textBox5.Text;
            this._deptInfo.TypeString = "部门";
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
