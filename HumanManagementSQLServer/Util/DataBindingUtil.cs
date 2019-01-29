using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace HumanManagementSQLServer.Util
{
    class DataBindingUtil
    {
        /// <summary>
        /// 将 data 参数的数据绑定到 control 参数的 TextBox 控件中
        /// </summary>
        /// <param name="control">要绑定的控件</param>
        /// <param name="data">数据来源</param>
        /// <returns></returns>
        public static bool DataToControl(Control control, object data)
        {
            if (control == null || data == null)
            {
                return false;
            }

            foreach (Control con in control.Controls)
            {
                string fieldName = con.Name.Substring(3);
                if (con is TextBox)
                {
                    object txtValue = GetObjectPropertyValue(data, fieldName);
                    if (txtValue != null)
                    {
                        con.Text = GetObjectPropertyValue(data, fieldName).ToString();
                    }
                }
                if (con is DateTimePicker)
                {
                    object dtpValue = GetObjectPropertyValue(data, fieldName);
                    if (dtpValue != null && (string)dtpValue != "")
                    {
                        (con as DateTimePicker).Value = DateTime.Parse(dtpValue.ToString());
                    }
                    else
                    {
                        (con as DateTimePicker).Value = DateTime.Now;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 设置对象的指定属性，如果是dx组件，系统会处理Properties中的属性。
        /// </summary>
        /// <param name="Obj">要设置属性的对象。</param>
        /// <param name="PropertyName">属性名称。</param>
        /// <returns>设置成功返回属性值，否则返回null。</returns>
        public static object GetObjectPropertyValue(object Obj, string PropertyName)
        {
            if (Obj == null || PropertyName == null || PropertyName == "")
                return null;

            //得到对象指定的属性。
            Type ObjType = Obj.GetType();
            PropertyInfo prop = ObjType.GetProperty(PropertyName, BindingFlags.Public | BindingFlags.Instance);
            //如果还是没有找到，则退出。
            if (prop != null && prop.CanRead)
            //if (prop != null)
            {
                try
                {
                    return prop.GetValue(Obj, null);
                }
                catch (Exception e)
                {
                    MessageBox.Show(string.Format("设置{0}属性失败,错误如下：{1}", PropertyName, e.Message));
                }
            }

            //如果没有找到，则查找是否有Properties属性，因为dx组件的很多属性是放在Properties。
            PropertyInfo[] PropertyList = ObjType.GetProperties();

            foreach (PropertyInfo CurProp in PropertyList)
            {
                if (CurProp.Name == "Properties" || CurProp.Name == "OptionsBehavior" || CurProp.Name == "MainView")
                {
                    Object PropertiesObj = CurProp.GetValue(Obj, null);
                    return GetObjectPropertyValue(PropertiesObj, PropertyName);
                }
            }
            return null;
        }

        /// <summary>
        /// 设置对象的指定属性，如果是dx组件，系统会处理Properties中的属性。
        /// </summary>
        /// <param name="Obj">要设置属性的对象。</param>
        /// <param name="PropertyName">属性名称。</param>
        /// <param name="PropertyValue">属性值。</param>
        /// <returns>设置成功返回True，否则返回False。</returns>
        public static bool SetObjectProperty(object Obj, string PropertyName, object PropertyValue)
        {
            if (Obj == null || PropertyName == null || PropertyName == "")
                return false;

            //得到对象指定的属性。
            Type ObjType = Obj.GetType();
            PropertyInfo prop = ObjType.GetProperty(PropertyName, BindingFlags.Public | BindingFlags.Instance);
            //如果还是没有找到，则退出。
            if (prop != null && prop.CanWrite)
            {
                try
                {
                    prop.SetValue(Obj, PropertyValue, null);
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(string.Format("设置{0}属性失败,错误如下：{1}", PropertyName, e.Message));
                }
            }

            //如果没有找到，则查找是否有Properties属性，因为dx组件的很多属性是放在Properties。
            PropertyInfo[] PropertyList = ObjType.GetProperties();

            foreach (PropertyInfo CurProp in PropertyList)
            {
                if (CurProp.Name == "Properties" || CurProp.Name == "OptionsBehavior" || CurProp.Name == "MainView")
                {
                    Object PropertiesObj = CurProp.GetValue(Obj, null);
                    return SetObjectProperty(PropertiesObj, PropertyName, PropertyValue);
                }
            }
            return false;
        }

        /// <summary>
        /// 将 control 参数的控件里的值设置到 data 参数中
        /// </summary>
        /// <param name="data">要设置的数据</param>
        /// <param name="control">数据来源的控件</param>
        /// <returns></returns>
        public static bool ControlToData(object data, Control control)
        {
            if (control == null || data == null)
            {
                return false;
            }

            foreach (Control con in control.Controls)
            {
                string fieldName = con.Name.Substring(3);
                if (con is TextBox)
                {
                    SetObjectProperty(data, fieldName, con.Text);
                }
                if (con is DateTimePicker)
                {
                    SetObjectProperty(data, fieldName, (con as DateTimePicker).Value.ToString("yyyy-MM-dd"));
                }
            }

            return true;
        }
    }
}
