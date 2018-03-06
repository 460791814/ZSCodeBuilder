using CodeHelper;
using DbObjects.SQL2012;
using Model.zTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZSCodeBuilder.Controllers
{
    public class CodeController : Controller
    {
        // GET: Code
        public ActionResult BuilderCode()
        {
            return View();
        }

        /// <summary>
        /// 获取树节点集合
        /// </summary>
        [Route("code/getdatabasetree")]
        public JsonResult GetTreeNodeList(string connstring)
        {
            connstring = "Data Source=59.110.156.135;Initial Catalog=qsjt;User ID=projectuser;Password=KjYV9.xg.9b[#3sE1=%r";

            List<E_TreeNode> NodeList = new List<E_TreeNode>();

            DbObject db = new DbObject(connstring);
            string dbName = "qsjt";
            var tables = db.GetTableViews(dbName);
            foreach (var item in tables)
            {
                E_TreeNode nodetable = new E_TreeNode();
                nodetable.id = 0;
                nodetable.name = item;
                nodetable.nodetype = 1;
                string actionName = item.Replace("tb_", "");
                List<ColumnInfo> ColumnList = db.GetColumnInfoList(dbName, item);
                List<E_TreeNode> columnnodelist = new List<E_TreeNode>();
                foreach (var columnitem in ColumnList)
                {
                    E_TreeNode nodecolumn = new E_TreeNode();
                    nodecolumn.id = 0;
                    nodecolumn.name = columnitem.ColumnName + "（" + columnitem.TypeName + "）" + columnitem.Description;
                    nodecolumn.children = null;
                    nodetable.nodetype = 2;
                    columnnodelist.Add(nodecolumn);
                }
                nodetable.children = columnnodelist;
                NodeList.Add(nodetable);
            }
            return Json(NodeList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 生成对象实体
        /// </summary>
        public ActionResult BuilderModel()
        {

            return PartialView("~/Views/Code/BuilderModel.cshtml");
        }

        /// <summary>
        /// 生成对象操作
        /// </summary>
        public ActionResult BuilderDAL()
        {
            return PartialView("~/Views/Code/BuilderDAL.cshtml");
        }

        /// <summary>
        /// 生成对象控制器
        /// </summary>
        public ActionResult BuilderControllers()
        {
            return PartialView("~/Views/Code/BuilderControllers.cshtml");
        }

        /// <summary>
        /// 生成对象列表页
        /// </summary>
        public ActionResult BuilderPageList()
        {
            return PartialView("~/Views/Code/BuilderPageList.cshtml");
        }

        /// <summary>
        /// 生成对象编辑页
        /// </summary>
        public ActionResult BuilderPageEdit()
        {
            return PartialView("~/Views/Code/BuilderPageEdit.cshtml");
        }
    }
}