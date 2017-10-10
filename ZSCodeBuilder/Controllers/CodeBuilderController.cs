

using CodeHelper;
using DbObjects.SQL2012;
using IBuilder;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuilderModel;
using Utility;
using Comp;
using BuilderDALSQL;
using BuilderController;
using BuilderView;

namespace ZSCodeBuilder.Controllers
{
    public class CodeBuilderController : Controller
    {
        static string connStr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        DbObject db = new DbObject(connStr);
        IBuilderModel builderModel = null;
        IBuilderDAL builderDAL = null;
        string dbName = "ryxz";
        // GET: ZS
        public ActionResult Index()
        {
            // CreateDal();
            // CreateModel();
            //  CreateController();
            CreateListAndInfo();
            return View();
        }
        /// <summary>
        /// 生成model
        /// </summary>
        /// <returns></returns>
        public String CreateModel()
        {
    
            builderModel = new BuilderCSharpModel();
            var tables = db.GetTableViews(dbName);
            if (tables == null)
            {
                return "数据库表为空";
            }
            foreach (var item in tables)
            {
                List<ColumnInfo> list = db.GetColumnInfoList(dbName, item);
                builderModel.Fieldlist = list;
                builderModel.ModelName = item;
                builderModel.BaseClass = "BaseModel";
                DataRow tableDescRow = db.GetTablesExProperty(dbName).Select("objname='" + item + "'").FirstOrDefault();
                if (tableDescRow != null) { 
                builderModel.TableDescription = tableDescRow["value"]?.ToString();
                }
                string modelStr=  builderModel.CreatModel();
                Utils.CreateFile("/code/Model", item+".cs", modelStr);
            }

            return "生成成功";
        }
        public string CreateDal() {
        
            builderDAL = new BuilderCSharpDAL();
            var tables = db.GetTableViews(dbName);
            if (tables == null)
            {
                return "数据库表为空";
            }
            foreach (var item in tables)
            {
                string dalName = item.Replace("tb", "D");
                List<ColumnInfo> list = db.GetColumnInfoList(dbName, item);
                builderDAL.Fieldlist = list;
                builderDAL.TableName = item;
                builderDAL.ModelName = item;
                builderDAL.Modelpath = "Model";
                builderDAL.DbObject = db;
                builderDAL.Keys = list.Where(a=>a.IsPrimaryKey).ToList();
                builderDAL.DALpath = "DAL";
                builderDAL.DALName = dalName;
                string dalStr = builderDAL.GetDALCode(false, true, true, true, true, true, true);
                Utils.CreateFile("/code/DAL", dalName + ".cs", dalStr);
            }
            return "生成成功";
        }

        public string CreateController()
        {

            BuilderMvcController builderController = new BuilderMvcController();
            var tables = db.GetTableViews(dbName);
            if (tables == null)
            {
                return "数据库表为空";
            }
            foreach (var item in tables)
            {
                string actionName = item.Replace("tb_", "");
                List<ColumnInfo> list = db.GetColumnInfoList(dbName, item);
                builderController.ModelName = item;
                builderController.ActionName = actionName;
                builderController.Fieldlist = list;
                DataRow tableDescRow = db.GetTablesExProperty(dbName).Select("objname='" + item + "'").FirstOrDefault();
                if (tableDescRow != null)
                {
                    builderController.TableDescription = tableDescRow["value"]?.ToString();
                }
                builderController.NameSpace = "cnooc.property.manage.Controllers";
                builderController.BaseClass = "Controller";
                Utils.CreateFile("/code/Controllers", actionName + "Controller.cs", builderController.CreatController());
            }
            return "生成成功";
        }

        public string CreateListAndInfo()
        {
            string listfilePath =ConfigurationManager.AppSettings["TemplateDir"] + "list.cshtml";
            string listfilePath2 = ConfigurationManager.AppSettings["TemplateDir"] + "list2.cshtml";
            string infofilePath =ConfigurationManager.AppSettings["TemplateDir"] + "info.cshtml";
            BuilderMvcView builderMvcView = new BuilderMvcView();
            var tables = db.GetTableViews(dbName);
            if (tables == null)
            {
                return "数据库表为空";
            }
            
            foreach (var item in tables)
            {
                string actionName = item.Replace("tb_", "");
                List<ColumnInfo> list = db.GetColumnInfoList(dbName, item);
                builderMvcView.PrimaryKey = CodeCommon.GetPrimaryKey(list)?.ColumnName;
                //移除主键
                list.Remove(CodeCommon.GetPrimaryKey(list));
                builderMvcView.ModelName = item;
                builderMvcView.ActionName = actionName;
                builderMvcView.Fieldlist = list;
             
                DataRow tableDescRow = db.GetTablesExProperty(dbName).Select("objname='" + item + "'").FirstOrDefault();
                if (tableDescRow != null)
                {
                    builderMvcView.TableDescription = tableDescRow["value"]?.ToString();
                }
                //生成列表
                string listhtml= Utils.ReadFile(listfilePath);
                listhtml = listhtml.Replace("<#list:title#>", builderMvcView.TableDescription);
                listhtml = listhtml.Replace("<#list:infourl#>", builderMvcView.CreateEditUrl());
                listhtml = listhtml.Replace("<#list:table#>", builderMvcView.CreateTable());
                Utils.CreateFile("/code/Views/" + actionName, actionName + "List.cshtml", listhtml);
                //生成列表2
                string listhtml2 = Utils.ReadFile(listfilePath2);
                listhtml2 = listhtml2.Replace("<#list:title#>", builderMvcView.TableDescription);
                listhtml2 = listhtml2.Replace("<#list:infourl#>", builderMvcView.CreateEditUrl());
                listhtml2 = listhtml2.Replace("<#list:table#>", builderMvcView.CreateTable());
                Utils.CreateFile("/code/Views2/" + actionName, actionName + "List.cshtml", listhtml);
                //生成详情
                string infohtml = Utils.ReadFile(infofilePath);
                infohtml = infohtml.Replace("<#info:modelname#>", "Model."+item);
                infohtml = infohtml.Replace("<#info:title#>", builderMvcView.TableDescription);
                infohtml = infohtml.Replace("<#info:listurl#>", builderMvcView.CreateListUrl());
                infohtml = infohtml.Replace("<#list:infourl#>", builderMvcView.CreateEditUrl());
                infohtml = infohtml.Replace("<#info:saveurl#>", builderMvcView.CreateSaveUrl());
                infohtml = infohtml.Replace("<#info:form#>", builderMvcView.CreateInfoView());


                Utils.CreateFile("/code/Views/" + actionName, actionName + "Info.cshtml", infohtml);

            }
            return "生成成功";
        }
    }
}