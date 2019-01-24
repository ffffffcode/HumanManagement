using HumanManagement.Data;
using System;
using System.Windows.Forms;

namespace HumanManagement
{
    public partial class AddOrUpdateEmployeeForm : Form
    {
        private EmployeeInfo _employeeInfo;
        internal EmployeeInfo EmployeeInfo
        {
            get
            {
                return this._employeeInfo;
            }
            set
            {
                this._employeeInfo = value;
                this.textBox1.Text = this._employeeInfo.DeptNo;
                this.textBox2.Text = this._employeeInfo.DeptName;
                this.textBox3.Text = this._employeeInfo.No;
                this.textBox4.Text = this._employeeInfo.EmployeeName;
                this.textBox5.Text = this._employeeInfo.IdCardNo;
                this.textBox6.Text = this._employeeInfo.Birthday;
                this.textBox7.Text = this._employeeInfo.Birthplace;
                this.textBox8.Text = this._employeeInfo.EntryTime;
            }
        }

        public AddOrUpdateEmployeeForm()
        {
            InitializeComponent();
        }

        public AddOrUpdateEmployeeForm(string formName)
        {
            InitializeComponent();
            this.Text = formName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this._employeeInfo.DeptNo = this.textBox1.Text;
            this._employeeInfo.DeptName = this.textBox2.Text;
            this._employeeInfo.No = this.textBox3.Text;
            this._employeeInfo.EmployeeName = this.textBox4.Text;
            this._employeeInfo.IdCardNo = this.textBox5.Text;
            this._employeeInfo.Birthday = this.textBox6.Text;
            this._employeeInfo.Birthplace = this.textBox7.Text;
            this._employeeInfo.EntryTime = this.textBox8.Text;
            this._employeeInfo.TypeString = "员工";
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
