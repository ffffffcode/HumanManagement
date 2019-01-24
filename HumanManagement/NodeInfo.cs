using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HumanManagement.Data
{
    abstract class NodeInfo
    {
        private string _no;
        public string No
        {
            get { return this._no; }
            set { this._no = value; }
        }

        private string _typeString;
        public string TypeString
        {
            get { return this._typeString; }
            set { this._typeString = value; }
        }
    }
}
