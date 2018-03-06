using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.zTree
{
    /// <summary>
    /// 树节点
    /// </summary>
    public class E_TreeNode
    {
        /// <summary>
        /// 节点ID
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 节点名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 节点类型
        /// </summary>
        public int nodetype { get; set; }

        /// <summary>
        /// 子节点
        /// </summary>
        public List<E_TreeNode> children { get; set; }
    }
}
