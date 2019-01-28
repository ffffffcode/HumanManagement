using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HumanManagement.Data
{
    /// <summary>
    /// 数据检测类
    /// </summary>
    public class CheckInfo
    {
        public Control ConObj = null;
        /// <summary>
        /// 值类型,默认为string
        /// </summary>
        public string ValueType = "string";

        /// <summary>
        /// 长度
        /// </summary>
        public int Lenth = -1;

        /// <summary>
        /// 必须录入
        /// </summary>
        public bool MustInPut = false;

        /// <summary>
        /// 初始类属性 <see cref="CheckInfo"/> class.
        /// </summary>
        /// <param name="lenth">The lenth.</param>
        /// <param name="mustInput">if set to <c>true</c> [must input].</param>
        public CheckInfo(Control conObj, int lenth, bool mustInput)
        {
            ConObj = conObj;
            Lenth = lenth;
            MustInPut = mustInput;
        }

        /// <summary>
        /// 检查数据.
        /// </summary>
        /// <param name="Value">The value.</param>
        /// <returns></returns>
        public bool CheckData(string Value)
        {
            if (Lenth > 0 && ValueType == "string" && Value.Trim().Length > Lenth)
            {
                //找到对应的标签控件
                return false;
            }
            return true;
        }
    }
}
