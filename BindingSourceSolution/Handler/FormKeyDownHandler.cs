using System.Windows.Forms;

namespace BindingSourceSolution.Handler
{
    class FormKeyDownHandler
    {
        internal static void EnterToSelectNextControl(object sender, KeyEventArgs e)
        {
            Form form = sender as Form;
            if (e.KeyData == Keys.Enter)
            {
                form.SelectNextControl(form.ActiveControl, true, true, false, true);
            }
        }
    }
}
