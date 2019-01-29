using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HumanManagement.Data
{
    /// <summary>
    /// 控件类型
    /// </summary>
    public enum ConType
    {
        IsPhone,
        IsIdentity,
        IsNumber,
        IsEmail,
        IsDate,
        IsString
    }

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
        /// 字段类型
        /// </summary>
        public ConType _conType ;


        /// <summary>
        /// 初始类属性 <see cref="CheckInfo" /> class.
        /// </summary>
        /// <param name="conObj">The con object.</param>
        /// <param name="lenth">The lenth.</param>
        /// <param name="mustInput">if set to <c>true</c> [must input].</param>
        /// <param name="conType">Type of the con.</param>
        public CheckInfo(Control conObj, int lenth, bool mustInput=false,ConType conType=ConType.IsString)
        {
            ConObj = conObj;
            Lenth = lenth;
            MustInPut = mustInput;
            _conType = conType;
        }

        #region 检查数据 bool CheckData()
        /// <summary>
        /// 检查数据
        /// </summary>
        /// <returns></returns>
        public bool CheckData()
        {
            //长度判断


            //是否为空判断


            //字段类型的判断
            switch (_conType)
            {
                case ConType.IsPhone:

                    break;
                case ConType.IsIdentity:
                    break;
                case ConType.IsNumber:
                    return CheckIsNumber();                    
                case ConType.IsEmail:
                    break;
                case ConType.IsDate:
                    break;
                case ConType.IsString:
                    break;
                default:
                    break;
            }


            //if (Lenth > 0  && Value.Trim().Length > Lenth)
            //{
            //    //根据编辑控件名找到对应的标签控件

            //    //生成提示信息

            //    //定位焦点
            //    return false;
            //}
            return true;
        }
        #endregion

        #region 数字的判断 bool CheckIsNumber()
        /// <summary>
        /// 数字的判断
        /// </summary>
        /// <returns></returns>
        private bool CheckIsNumber()
        {
            //数字的判断

            return true;
        }
        #endregion
    }
}
