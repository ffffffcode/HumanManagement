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
    public partial class AddOrModEmpForm : Form
    {
        public AddOrModEmpForm()
        {
            InitializeComponent();
        }

        private void btnComfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCannel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtIdCardNo_Leave(object sender, EventArgs e)
        {
            txtBirthday.Text = txtIdCardNo.Text.Substring(6, 4) + "-" + txtIdCardNo.Text.Substring(10, 2) + "-" + txtIdCardNo.Text.Substring(12, 2) + " 00:00:00";
        }
    }
}
