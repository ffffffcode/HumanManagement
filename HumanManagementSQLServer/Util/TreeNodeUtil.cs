using System.Text;
using System.Windows.Forms;

namespace HumanManagementSQLServer.Util
{
    class TreeNodeUtil
    {
        //TODO 优化
        //删除部门时列出子节点
        public static string GetChilderNodeTextList(TreeNode parent, StringBuilder outMessage)
        {
            if (parent != null)
            {
                TreeNodeCollection childer = parent.Nodes;
                if (childer.Count != 0)
                {
                    foreach (TreeNode item in childer)
                    {
                        outMessage.AppendLine(item.FullPath);
                        GetChilderNodeTextList(item, outMessage);
                    }
                }
            }
            return outMessage.ToString();
        }
    }
}
