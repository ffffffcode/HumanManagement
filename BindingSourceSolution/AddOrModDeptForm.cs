using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BindingSourceSolution
{
    public partial class AddOrModDeptForm : Form
    {
        public AddOrModDeptForm()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void AddOrModDeptForm_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“humanManagementDataSet.deptDetail”中。您可以根据需要移动或删除它。
            this.deptDetailTableAdapter.Fill(this.humanManagementDataSet.deptDetail);
        }
    }
}
