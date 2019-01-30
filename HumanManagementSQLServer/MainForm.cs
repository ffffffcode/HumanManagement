using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HumanManagementSQLServer
{
    public partial class MainForm : Form
    {
        internal static DataSet dataSet = new DataSet();

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitForm()
        {
            DataSet deptTable = SqlHelper.GetTable();
            DataTable deptDetailTable = SqlHelper.GetTable("SELECT dept.dept_no, dept.dept_name, dept.remarks, dept.parent_dept_no, dept_1.dept_name AS parent_dept_name FROM dept LEFT OUTER JOIN dept AS dept_1 ON dept.parent_dept_no = dept_1.dept_no");
        }
    }
}
