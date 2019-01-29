using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagementSQLServer.DataSource
{
    class HumanManagementData
    {
        private static readonly HumanManagementDataSetTableAdapters.companyTableAdapter _companyTableAdapter = new HumanManagementDataSetTableAdapters.companyTableAdapter();
        public static HumanManagementDataSetTableAdapters.companyTableAdapter CompanyTableAdapter { get { return _companyTableAdapter; } }

        private static readonly HumanManagementDataSetTableAdapters.deptTableAdapter _deptTableAdapter = new HumanManagementDataSetTableAdapters.deptTableAdapter();
        public static HumanManagementDataSetTableAdapters.deptTableAdapter DeptTableAdapter { get { return _deptTableAdapter; } }

        private static readonly HumanManagementDataSetTableAdapters.empTableAdapter _empTableAdapter = new HumanManagementDataSetTableAdapters.empTableAdapter();
        public static HumanManagementDataSetTableAdapters.empTableAdapter EmpTableAdapter { get { return _empTableAdapter; } }

        private static readonly DataTable _companyTable = _companyTableAdapter.GetData();
        public static DataTable CompanyTable { get { return _companyTable; } }

        private static readonly DataTable _deptTable = _deptTableAdapter.GetData();
        public static DataTable DeptTable { get { return _deptTable; } }

        private static readonly DataTable _empTable = _empTableAdapter.GetData();
        public static DataTable EmpTable { get { return _empTable; } }
    }
}
