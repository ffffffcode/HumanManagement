using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HumanManagementSQLServer
{
    public sealed class SqlHelper
    {
        //数据库连接字符串
        private readonly static string connstr = @"Data Source=20190114-100739\SQLEXPRESS;Initial Catalog=HumanManagement;Integrated Security=True";

        private static List<bool> _isBusy = new List<bool>();
        private static List<SqlConnection> _connList = new List<SqlConnection>();//链接列表,解决打开链接消耗时间问题

        private SqlHelper() { }

        static SqlHelper()
        {
            //打开10个链接
            for (int i = 0; i < 10; i++)
            {
                SqlConnection conn = new SqlConnection(connstr);
                conn.Open();
                _connList.Add(conn);
                _isBusy.Add(false);
            }
        }

        /// <summary>
        /// 获得一个可用的链接
        /// </summary>
        /// <returns></returns>
        private static SqlConnection GetConnection()
        {
            int index = _isBusy.IndexOf(false);
            if (index == -1)
            {
                return null;
            }
            _isBusy[index] = true;
            SqlConnection conn = _connList[index];
            if (conn.State == ConnectionState.Closed)
            {
                //如果链接已经关闭,重新打开
                conn.Open();
            }
            return _connList[index];
        }

        /// <summary>
        /// 释放链接
        /// </summary>
        /// <param name="conn"></param>
        private static void FreeConnect(SqlConnection conn)
        {
            int index = _connList.IndexOf(conn);
            ConnectionState state = conn.State;
            _isBusy[index] = false;
        }

        #region 组织select命令

        public static string CmdForSelectTable(string tableName, string selctColumns, string whereStr)
        {
            string cmdstr = string.Format("SELECT {1} FROM [{0}] WHERE {2}", tableName, selctColumns, whereStr);
            return cmdstr;
        }

        public static string CmdForSelectTable(string tableName, string selctColumns, string whereStr, int top)
        {
            string cmdstr = string.Format("SELECT TOP {3} {1} FROM [{0}] WHERE {2}", tableName, selctColumns, whereStr, top);
            return cmdstr;
        }

        public static string CmdForSelectTable(string tableName, string selctColumns, string whereStr, string orderby)
        {
            string cmdstr = string.Format("SELECT {1} FROM [{0}] WHERE {2} ORDER BY {3}", tableName, selctColumns, whereStr, orderby);
            return cmdstr;
        }

        public static string CmdForSelectTable(string tableName, string selctColumns, string whereStr, int top, string orderby)
        {
            string topStr = "";
            string orderbyStr = "";
            if (top > 0)
            {
                topStr = "TOP " + top;
            }
            if (!string.IsNullOrEmpty(orderby))
            {
                orderbyStr = " ORDER BY " + orderby;
            }
            string cmdstr = string.Format("SELECT {3} {1} FROM [{0}] WHERE {2}{4}", tableName, selctColumns, whereStr, topStr, orderbyStr);
            return cmdstr;
        }

        public static string CmdForSelectMulitTable(List<string> tableNameList, string selctColumns, string whereStr, int top, string orderby)
        {
            string topStr = "";
            string orderbyStr = "";
            string tableName = "";
            foreach (string name in tableNameList)
            {
                tableName += name + " ";
            }
            if (top > 0)
            {
                topStr = "TOP " + top;
            }
            if (!string.IsNullOrEmpty(orderby))
            {
                orderbyStr = " ORDER BY " + orderby;
            }
            string cmdstr = string.Format("SELECT {3} {1} FROM {0} WHERE {2}{4}", tableName, selctColumns, whereStr, topStr, orderbyStr);
            return cmdstr;
        }
        #endregion

        #region 组织插入和更新命令
        private static string CmdForInsertTable(string tableName, List<string> valueList)
        {
            string columns = "";
            string values = "";
            foreach (string item in valueList)
            {
                int index = item.IndexOf('=');
                columns += item.Substring(0, index) + ",";
                values += item.Substring(index + 1) + ",";
            }
            columns = columns.Trim(',');
            values = values.Trim(',');
            string sqlstr = string.Format("INSERT INTO [{0}] ({1}) VALUES ({2})", tableName, columns, values);
            return sqlstr;
        }

        private static string CmdForUpdateTable(string tableName, List<string> valueList, string whereStr)
        {
            string setStr = "";
            foreach (string item in valueList)
            {
                setStr += item + ",";
            }
            setStr = setStr.Trim(',');
            string sqlstr = string.Format("UPDATE [{0}] SET {1} WHERE {2}", tableName, setStr, whereStr);
            return sqlstr;
        }
        #endregion

        #region 查询

        /// <summary>
        /// 获得表结构
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataTable GetTableSchema(string tableName)
        {
            string cmdStr = "SELECT TOP 0 * FROM [" + tableName + "]";
            SqlConnection conn = GetConnection();//公用            
            SqlCommand cmd = new SqlCommand(cmdStr, conn);
            DataTable table = null;
            try
            {
                SqlDataAdapter ad = new SqlDataAdapter(cmdStr, conn);
                table = new DataTable();
                ad.Fill(table);
            }
            catch
            {
                throw;
            }
            finally
            {
                FreeConnect(conn);
            }

            return table;
        }

        /// <summary>
        /// 根据命令，执行后返回表格
        /// </summary>
        /// <param name="cmdStr"></param>
        /// <returns></returns>
        public static DataTable GetTable(string cmdStr, string tableName)
        {
            SqlConnection conn = GetConnection();//公用            
            SqlCommand cmd = new SqlCommand(cmdStr, conn);
            DataTable table = null;
            try
            {
                SqlDataAdapter ad = new SqlDataAdapter(cmdStr, conn);
                table = new DataTable(tableName);
                ad.Fill(table);
            }
            catch
            {
                throw;
            }
            finally
            {
                FreeConnect(conn);
            }
            return table;
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="selctColumns"></param>
        /// <param name="whereStr"></param>
        /// <returns></returns>
        public static DataTable GetTable(string tableName, string selctColumns, string whereStr)
        {
            string cmdStr = string.Format("SELECT {1} FROM {0}", tableName, selctColumns);
            if (!string.IsNullOrEmpty(whereStr))
            {
                cmdStr += "  WHERE " + whereStr;
            }

            SqlConnection conn = GetConnection();//公用            
            SqlCommand cmd = new SqlCommand(cmdStr, conn);
            DataTable table = null;
            try
            {
                SqlDataAdapter ad = new SqlDataAdapter(cmdStr, conn);
                table = new DataTable();
                ad.Fill(table);
            }
            catch
            {
                throw;
            }
            finally
            {
                FreeConnect(conn);
            }
            return table;
        }

        /// <summary>
        /// 根据命令，执行后返回一个值
        /// </summary>
        /// <param name="cmdStr"></param>
        /// <returns></returns>
        public string GetValue(string cmdStr)
        {
            return null;
        }

        #endregion

        /// <summary>
        /// 添加一行数据
        /// </summary>
        public static void Insert(string tableName, List<string> valueList)
        {
            string cmdStr = CmdForInsertTable(tableName, valueList);
            SqlConnection conn = GetConnection();//公用            
            SqlCommand cmd = new SqlCommand(cmdStr, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                FreeConnect(conn);
            }
        }

        /// <summary>
        /// 批量添加数据
        /// </summary>
        public static void AddTable(string tableName, DataTable table)
        {

            SqlConnection conn = GetConnection();//公用 
            SqlBulkCopy bulk = new SqlBulkCopy(conn);
            bulk.DestinationTableName = tableName;
            try
            {
                bulk.WriteToServer(table);
            }
            catch
            {
                throw;
            }
            finally
            {
                FreeConnect(conn);
            }
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        public static bool Update(string tableName, List<string> valueList, string whereStr)
        {
            string cmdStr = CmdForUpdateTable(tableName, valueList, whereStr);
            SqlConnection conn = GetConnection();//公用            
            SqlCommand cmd = new SqlCommand(cmdStr, conn);
            bool ok = false;
            try
            {
                cmd.ExecuteNonQuery();
                ok = true;
            }
            catch
            {
                throw;
            }
            finally
            {
                FreeConnect(conn);
            }
            return ok;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public static bool Delete(string tableName, string whereStr)
        {
            string cmdStr = string.Format("DELETE FROM [{0}] WHERE ({1})", tableName, whereStr);
            SqlConnection conn = GetConnection();//公用            
            SqlCommand cmd = new SqlCommand(cmdStr, conn);
            bool ok = true;
            try
            {
                cmd.ExecuteNonQuery();
                ok = true;
            }
            catch
            {
                throw;
            }
            finally
            {
                FreeConnect(conn);
            }
            return ok;
        }

        /// <summary>
        /// 转化表格中一行数据
        /// </summary>
        public static Dictionary<string, object> ConventRowToModel(DataTable dt, int rowIndex)
        {
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            DataRow dr = dt.Rows[rowIndex];
            Dictionary<string, object> list = new Dictionary<string, object>();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string key = dt.Columns[i].ColumnName;
                object value = dr[i];
                list.Add(key, value);
            }
            return list;
        }

        /// <summary>
        /// 转化表格中一行数据
        /// </summary>
        public static Dictionary<string, object> ConventRowToModel(DataRow dataRow)
        {
            if (dataRow == null)
            {
                return null;
            }
            DataTable dt = dataRow.Table;
            Dictionary<string, object> list = new Dictionary<string, object>();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string key = dt.Columns[i].ColumnName;
                object value = dataRow[i];
                list.Add(key, value);
            }
            return list;
        }

        public static bool NotExcitd(string tableName, string primaryName, object primaryValue)
        {
            string cmdStr = "SELECT Count(*) FROM " + tableName + " WHERE " + primaryName + " = '" + primaryValue.ToString() + "'";
            SqlConnection conn = GetConnection();//公用            
            SqlCommand cmd = new SqlCommand(cmdStr, conn);
            try
            {
                if ((int)cmd.ExecuteScalar() == 0)
                {
                    return true;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                FreeConnect(conn);
            }
            return false;
        }
    }
}
