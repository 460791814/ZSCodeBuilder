using CodeHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace BuilderView
{
    public class BuilderMvcView
    {
        protected List<ColumnInfo> _fieldlist;
        /// <summary>
        /// 控制器名称
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// model类名
        /// </summary>
        public string ModelName
        {
            set;
            get;
        }
        /// <summary>
        /// 主键
        /// </summary>
        public string PrimaryKey { set; get; }
        /// <summary>
        /// 选择的字段集合
        /// </summary>
        public List<ColumnInfo> Fieldlist
        {
            set { _fieldlist = value; }
            get { return _fieldlist; }
        }

        public string TableDescription { get; set; }

        /// <summary>
        /// 创建列表页
        /// </summary>
        /// <returns></returns>
        public string CreateTable()
        {
            StringPlus stringPlus = new StringPlus();
            stringPlus.AppendSpaceLine(1, "<table class=\"table table-striped table-bordered table-hover\">");
            stringPlus.AppendSpaceLine(2, "<thead>");
            stringPlus.AppendSpaceLine(3, "<tr>");
            stringPlus.AppendLine(CreatTh());
            stringPlus.AppendSpaceLine(3, "</tr>");
            stringPlus.AppendSpaceLine(2, "</thead>");

            stringPlus.AppendSpaceLine(2, "<tbody>");

            stringPlus.AppendLine(CreatTd());

            stringPlus.AppendSpaceLine(2, "</tbody>");
            stringPlus.AppendSpaceLine(1, "</table>");
            return stringPlus.Value;

        }
        public String CreateEditUrl()
        {
            return "/" + ActionName + "/" + ActionName + "Edit";
        }
        public String CreateListUrl()
        {
            return "/" + ActionName + "/" + ActionName + "List";
        }
        /// <summary>
        /// 生成删除地址
        /// </summary>
        /// <returns></returns>
        public string CreateDelUrl()
        {
            return "/" + ActionName + "/" + ActionName + "Delete";
        }
        /// <summary>
        /// 保存地址
        /// </summary>
        /// <returns></returns>
        public string CreateSaveUrl()
        {
            return "/" + ActionName + "/" + ActionName + "Save";
        }
        private string CreatTd()
        {
            StringPlus stringPlus = new StringPlus();
            stringPlus.AppendSpaceLine(3, "@{");
            stringPlus.AppendSpaceLine(4, "var " + ActionName + "List = ViewBag." + ActionName + "List as List<" + ModelName + ">;");
            stringPlus.AppendSpaceLine(4, " if (" + ActionName + "List != null && " + ActionName + "List.Count > 0)");
            stringPlus.AppendSpaceLine(4, "{");

            stringPlus.AppendSpaceLine(5, "for (int i = 0; i < " + ActionName + "List.Count; i++)");
            stringPlus.AppendSpaceLine(5, "{");

            stringPlus.AppendSpaceLine(6, "<tr>");
            stringPlus.AppendSpaceLine(7, "<td>@(i+1)</td>");
            List<ColumnInfo> tempList = new List<ColumnInfo>();
            tempList.AddRange(_fieldlist);
            tempList.Remove(CodeCommon.GetPrimaryKey(tempList));
            foreach (var item in tempList)
            {
                if (string.IsNullOrEmpty(item.Description)) { continue; }
                stringPlus.AppendSpaceLine(7, "<td>@" + ActionName + "List[i]." + item.ColumnName + "</td>");
            }
            stringPlus.AppendSpaceLine(7, "<td>");
            stringPlus.AppendSpaceLine(8, "<div class=\" action-buttons\">");
            stringPlus.AppendSpaceLine(9, "<a class=\"green\" href=\"javascript: void(0)\" onclick=\"zstools.edit('" + CreateEditUrl() + "?" + PrimaryKey + "=@" + ActionName + "List[i]." + PrimaryKey + "')\" > 编辑</a>");
            stringPlus.AppendSpaceLine(9, "<a class=\"red\" href=\"javascript: void(0)\" onclick=\"zstools.del('" + CreateDelUrl() + "?" + PrimaryKey + "=@" + ActionName + "List[i]." + PrimaryKey + "',this)\" > 删除</a>");
            stringPlus.AppendSpaceLine(8, "</div>");
            stringPlus.AppendSpaceLine(7, "</td>");

            stringPlus.AppendSpaceLine(6, "</tr>");

            stringPlus.AppendSpaceLine(5, "}");
            stringPlus.AppendSpaceLine(4, "}");
            stringPlus.AppendSpaceLine(3, "}");

            return stringPlus.Value;
        }

        private string CreatTh()
        {
            StringPlus stringPlus = new StringPlus();
            stringPlus.AppendSpaceLine(4, "<th>序号</th>");
            foreach (var item in _fieldlist)
            {
                if (string.IsNullOrEmpty(item.Description)) { continue; }
                stringPlus.AppendSpaceLine(4, "<th>" + item.Description + "</th>");
            }
            stringPlus.AppendSpaceLine(4, "<th>操作</th>");
            return stringPlus.Value;
        }

        /// <summary>
        /// 创建详情页
        /// </summary>
        /// <returns></returns>
        public string CreateInfoView()
        {
            StringPlus stringPlus = new StringPlus();
            StringPlus stringPlus1 = new StringPlus();
            stringPlus.AppendSpaceLine(1, "<form action=\""+CreateSaveUrl()+"\"   role=\"form\">");
            stringPlus.AppendSpaceLine(2, "<input type=\"hidden\" id=\"" + PrimaryKey + "\" name=\"" + PrimaryKey + "\" value=\"@Model." + PrimaryKey + "\" />");
            List<ColumnInfo> tempList = new List<ColumnInfo>();
            tempList.AddRange(_fieldlist);
            tempList.Remove(CodeCommon.GetPrimaryKey(tempList));
            //移除没有注释的字段
            tempList.RemoveAll(a=>string.IsNullOrEmpty( a.Description));
            for (int i = 1; i < tempList.Count + 1; i++)
            {
                string columnName = tempList[i - 1].ColumnName;
                string description = tempList[i - 1].Description+":";
      
    
          
                    stringPlus.AppendSpaceLine(2, "<div class=\"form-group\">");

                    stringPlus.AppendSpaceLine(3, "<label>" + description + "</label>");
                    stringPlus.AppendSpaceLine(3, "<input type=\"text\" id=\"" + columnName + "\" name=\"" + columnName + "\" class=\"form-control \" value=\"@Model." + columnName + "\">");
                stringPlus.AppendSpaceLine(2, "</div>");
            }
         
 
            stringPlus.AppendSpaceLine(2, "<div style=\"width:100%; text-align:right; \"><button type=\"button\" class=\"btn btn-primary\" onclick=\"zstools.save()\">保存</button></div>");
            stringPlus.AppendSpaceLine(1, "</form>");
            return stringPlus.Value;
        }
    }
}
