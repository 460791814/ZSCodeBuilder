using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Data.SqlClient;
using Utility;
using IDBO;
using CodeHelper;
namespace BuilderDALSQL
{
    /// <summary>
    /// 数据访问层代码构造器（SQL方式）
    /// </summary>
    public class BuilderCSharpDAL : IBuilder.IBuilderDAL
    {
        #region 私有变量

        /// <summary>
        /// 标识列，或主键字段	
        /// </summary>
        protected string _IdentityKey = "";
        /// <summary>
        /// 标识列，或主键字段类型 
        /// </summary>
        protected string _IdentityKeyType = "int";

        #endregion

        #region 公有属性
        IDbObject dbobj;
        private string _dbname;
        private string _tablename;
        private string _modelname; //model类名
        private string _dalname;//dal类名    
        private List<ColumnInfo> _fieldlist;
        private List<ColumnInfo> _keys; //主键或条件字段列表    

        private string _namespace; //顶级命名空间名
        private string _folder; //所在文件夹
        private string _dbhelperName;//数据库访问类名
        private string _modelpath;
        private string _dalpath;
        private string _idalpath;
        private string _iclass;
        private string _procprefix;

        public IDbObject DbObject
        {
            set { dbobj = value; }
            get { return dbobj; }
        }
        public string DbName
        {
            set { _dbname = value; }
            get { return _dbname; }
        }
        public string TableName
        {
            set { _tablename = value; }
            get { return _tablename; }
        }


        /// <summary>
        /// 选择的字段集合
        /// </summary>
        public List<ColumnInfo> Fieldlist
        {
            set { _fieldlist = value; }
            get { return _fieldlist; }
        }

        public List<ColumnInfo> Keys
        {
            set
            {
                _keys = value;
                foreach (ColumnInfo key in _keys)
                {
                    _IdentityKey = key.ColumnName;
                    _IdentityKeyType = key.TypeName;
                    if (key.IsIdentity)
                    {
                        _IdentityKey = key.ColumnName;
                        _IdentityKeyType = CodeCommon.DbTypeToCS(key.TypeName);
                        break;
                    }
                }
            }
            get { return _keys; }
        }
        public string NameSpace
        {
            set { _namespace = value; }
            get { return _namespace; }
        }
        public string Folder
        {
            set { _folder = value; }
            get { return _folder; }
        }

        /*============================*/
        public string ModelName
        {
            set { _modelname = value; }
            get { return _modelname; }
        }
        /// <summary>
        /// 实体类的命名空间
        /// </summary>
        public string Modelpath
        {
            set { _modelpath = value; }
            get { return _modelpath; }
        }
        /// <summary>
        /// 实体类的整个命名空间 + 类名
        /// </summary>
        /// <summary>
        /// 实体类的整个命名空间 + 类名，即等于 Modelpath+ModelName
        /// </summary>
        public string ModelSpace
        {
            get { return ModelName; }
        }
        /*============================*/

        /// <summary>
        /// 数据层的命名空间
        /// </summary>
        public string DALpath
        {
            set { _dalpath = value; }
            get
            {
                return _dalpath;
            }
        }
        public string DALName
        {
            set { _dalname = value; }
            get { return _dalname; }
        }
        /*============================*/

        /// <summary>
        /// 接口的命名空间
        /// </summary>
        public string IDALpath
        {
            set { _idalpath = value; }
            get
            {
                return _idalpath;
            }
        }
        /// <summary>
        /// 接口类名
        /// </summary>
        public string IClass
        {
            set { _iclass = value; }
            get
            {
                return _iclass;
            }
        }

        public string DbHelperName
        {
            set { _dbhelperName = value; }
            get { return _dbhelperName; }
        }
        /// <summary>
        /// 存储过程前缀 
        /// </summary>       
        public string ProcPrefix
        {
            set { _procprefix = value; }
            get { return _procprefix; }
        }
        #endregion

        #region 构造属性

        /// <summary>
        /// 字段的 select * 列表
        /// </summary>
        public string Fieldstrlist
        {
            get
            {
                StringPlus _fields = new StringPlus();
                foreach (ColumnInfo obj in Fieldlist)
                {
                    _fields.Append(obj.ColumnName + ",");
                }
                _fields.DelLastComma();
                return _fields.Value;
            }
        }

        /// <summary>
        /// 不同数据库类的前缀
        /// </summary>
        public string DbParaHead
        {
            get
            {
                switch (dbobj.DbType)
                {
                    case "SQL2000":
                    case "SQL2005":
                    case "SQL2008":
                    case "SQL2012":
                        return "Sql";
                    case "Oracle":
                        return "Oracle";
                    case "MySQL":
                        return "MySql";
                    case "OleDb":
                        return "OleDb";
                    case "SQLite":
                        return "SQLite";
                    default:
                        return "Sql";
                }
            }

        }
        /// <summary>
        ///  不同数据库字段类型
        /// </summary>
        public string DbParaDbType
        {
            get
            {
                switch (dbobj.DbType)
                {
                    case "SQL2000":
                    case "SQL2005":
                    case "SQL2008":
                    case "SQL2012":
                        return "SqlDbType";
                    case "Oracle":
                        return "OracleType";
                    case "MySQL":
                        return "MySqlDbType";
                    case "OleDb":
                        return "OleDbType";
                    case "SQLite":
                        return "DbType";
                    default:
                        return "SqlDbType";
                }
            }
        }

        /// <summary>
        /// 存储过程参数 调用符号@
        /// </summary>
        public string preParameter
        {
            get
            {
                switch (dbobj.DbType)
                {
                    case "SQL2000":
                    case "SQL2005":
                    case "SQL2008":
                    case "SQL2012":
                        return "@";
                    case "Oracle":
                        return ":";
                    //case "OleDb":
                    // break;
                    default:
                        return "@";

                }
            }
        }
        /// <summary>
        /// 列中是否有标识列
        /// </summary>
        public bool IsHasIdentity
        {
            get
            {
                bool isid = false;
                if (_keys.Count > 0)
                {
                    foreach (ColumnInfo key in _keys)
                    {
                        if (key.IsIdentity)
                        {
                            isid = true;
                        }
                    }
                }
                return isid;
            }
        }
        private string KeysNullTip
        {
            get
            {
                if (_keys.Count == 0)
                {
                    return "//该表无主键信息，请自定义主键/条件字段";
                }
                else
                {
                    return "";
                }
            }
        }

        //语言文件
        public Hashtable Languagelist
        {
            get
            {
                return CodeHelper.Language.LoadFromCfg("BuilderDALSQL.lan");
            }
        }
        #endregion

        #region 构造函数

        public BuilderCSharpDAL()
        {
        }
        public BuilderCSharpDAL(IDbObject idbobj)
        {
            dbobj = idbobj;
        }
        public BuilderCSharpDAL(IDbObject idbobj, string dbname, string tablename, string modelname, string dalName,
            List<ColumnInfo> fieldlist, List<ColumnInfo> keys, string namepace,
            string folder, string dbherlpername, string modelpath, string modelspace,
            string dalpath, string idalpath, string iclass)
        {
            dbobj = idbobj;
            _dbname = dbname;
            _tablename = tablename;
            _modelname = modelname;
            _namespace = namepace;
            _folder = folder;
            _dbhelperName = dbherlpername;
            _modelpath = modelpath;
            _dalpath = dalpath;
            _idalpath = idalpath;
            _iclass = iclass;
            Fieldlist = fieldlist;
            Keys = keys;
            foreach (ColumnInfo key in _keys)
            {
                _IdentityKey = key.ColumnName;
                _IdentityKeyType = key.TypeName;
                if (key.IsIdentity)
                {
                    _IdentityKey = key.ColumnName;
                    _IdentityKeyType = CodeCommon.DbTypeToCS(key.TypeName);
                    break;
                }
            }
        }

        #endregion


        #region  根据列信息 得到参数的列表

        /// <summary>
        /// 得到Where条件语句 - Parameter方式 (例如：用于Exists  Delete  GetModel 的where)
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public string GetWhereExpression(List<ColumnInfo> keys, bool IdentityisPrior)
        {
            StringPlus strClass = new StringPlus();
            ColumnInfo field = CodeHelper.CodeCommon.GetIdentityKey(keys);
            if ((IdentityisPrior) && (field != null)) //有标识字段
            {
                strClass.Append(field.ColumnName + "=" + preParameter + field.ColumnName);
            }
            else
            {
                foreach (ColumnInfo key in keys)
                {
                    if (key.IsPrimaryKey)
                    {
                        strClass.Append(key.ColumnName + "=" + preParameter + key.ColumnName + " and ");
                    }
                }
                strClass.DelLastChar("and");
            }
            return strClass.Value;
        }

        /// <summary>
        /// 生成sql语句中的参数列表(例如：用于 Exists  Delete  GetModel 的where参数赋值)
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public string GetPreParameter(List<ColumnInfo> keys, bool IdentityisPrior)
        {
            StringPlus strclass = new StringPlus();
            StringPlus strclass2 = new StringPlus();
            strclass.AppendSpaceLine(3, "" + DbParaHead + "Parameter[] parameters = {");

            ColumnInfo field = CodeHelper.CodeCommon.GetIdentityKey(keys);
            if ((IdentityisPrior) && (field != null)) //有标识字段
            {
                strclass.AppendSpaceLine(5, "new " + DbParaHead + "Parameter(\"" + preParameter + "" + field.ColumnName + "\", " + DbParaDbType + "." + CodeCommon.DbTypeLength(dbobj.DbType, field.TypeName, "") + ")");
                strclass2.AppendSpaceLine(3, "parameters[0].Value = " + field.ColumnName + ";");
            }
            else
            {
                int n = 0;
                foreach (ColumnInfo key in keys)
                {
                    if (key.IsPrimaryKey)
                    {
                        strclass.AppendSpaceLine(5, "new " + DbParaHead + "Parameter(\"" + preParameter + "" + key.ColumnName + "\", " + DbParaDbType + "." + CodeCommon.DbTypeLength(dbobj.DbType, key.TypeName, "") + "),");
                        strclass2.AppendSpaceLine(3, "parameters[" + n.ToString() + "].Value = " + key.ColumnName + ";");
                        n++;
                    }
                }
                strclass.DelLastComma();
            }
            strclass.AppendLine("};");
            strclass.Append(strclass2.Value);
            return strclass.Value;

        }

        #endregion

        #region 数据层(整个类)

        public string GetDALCode(bool Maxid, bool Exists, bool Add, bool Update, bool Delete, bool GetModel, bool List)
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendLine("using System;");
            strclass.AppendLine("using System.Data;");
            strclass.AppendLine("using System.Text;");
            switch (dbobj.DbType)
            {
                case "SQL2005":
                case "SQL2008":
                case "SQL2012":
                    strclass.AppendLine("using System.Data.SqlClient;");
                    break;
                case "SQL2000":
                    strclass.AppendLine("using System.Data.SqlClient;");
                    break;
                case "Oracle":
                    strclass.AppendLine("using System.Data.OracleClient;");
                    break;
                case "MySQL":
                    strclass.AppendLine("using MySql.Data.MySqlClient;");
                    break;
                case "OleDb":
                    strclass.AppendLine("using System.Data.OleDb;");
                    break;
                case "SQLite":
                    strclass.AppendLine("using System.Data.SQLite;");
                    break;
            }
            if (!string.IsNullOrEmpty(IDALpath))
            {
                strclass.AppendLine("using " + IDALpath + ";");
            }
            if (!string.IsNullOrEmpty(Modelpath))
            {
                strclass.AppendLine("using " + Modelpath + ";");
            }
            strclass.AppendLine("using System.Linq;");
            strclass.AppendLine("using System.Collections.Generic;");

           strclass.AppendLine("using Dapper;");
            strclass.AppendLine("namespace " + DALpath);
            strclass.AppendLine("{");
            strclass.AppendSpaceLine(1, "/// <summary>");
            strclass.AppendSpaceLine(1, "/// " + Languagelist["summary"].ToString() + ":" + DALName);
            strclass.AppendSpaceLine(1, "/// </summary>");
            strclass.AppendSpace(1, "public partial class " + DALName);
            if (!string.IsNullOrEmpty(IClass))
            {
                strclass.Append(":" + IClass);
            }
            strclass.AppendLine("");
            strclass.AppendSpaceLine(1, "{");
            strclass.AppendSpaceLine(2, "public " + DALName + "()");
            strclass.AppendSpaceLine(2, "{}");
            strclass.AppendSpaceLine(2, "#region  Method");


            #region  方法代码
            if (Maxid)
            {
                strclass.AppendLine(CreatGetMaxID());
            }
            if (Exists)
            {
                strclass.AppendLine(CreatExists());
            }
            if (Add)
            {
                strclass.AppendLine(CreatAdd());
            }
            if (Update)
            {
                strclass.AppendLine(CreatUpdate());
            }
            if (Delete)
            {
                strclass.AppendLine(CreatDelete());
            }

 
            strclass.AppendLine(CreatGetListAndCount());
            strclass.AppendLine(CreatGetList());
            strclass.AppendLine(CreatGetInfo());
            #endregion

            strclass.AppendSpaceLine(2, "#endregion  Method");




            strclass.AppendSpaceLine(1, "}");
            strclass.AppendLine("}");
            strclass.AppendLine("");

            return strclass.ToString();
        }

        private string CreatGetInfo()
        {
            StringPlus strclass = new StringPlus();
            if (_keys.Count > 0)
            {
                string strInparam = CodeHelper.CodeCommon.GetInParameter(Keys, false);
                if (!string.IsNullOrEmpty(strInparam))
                {
                    strclass.AppendLine("");
                    strclass.AppendSpaceLine(2, "/// <summary>");
                    strclass.AppendSpaceLine(2, "/// " + Languagelist["summaryGetModel"].ToString());
                    strclass.AppendSpaceLine(2, "/// </summary>");
                    strclass.AppendSpaceLine(2, "public "+ ModelSpace + " GetInfo(" + ModelSpace + " model)");
                    strclass.AppendSpaceLine(2, "{");
                 
                    strclass.AppendSpaceLine(3, "StringBuilder strSql = new StringBuilder();");
                    strclass.AppendSpaceLine(3, "strSql.Append(\"select * from " + _tablename + "\");");
                    strclass.AppendSpaceLine(3, "strSql.Append(\"  where " + CodeCommon.GetWhereParameterExpression(this.Keys, true, this.dbobj.DbType) + "\");");

                    strclass.AppendSpaceLine(3, "using (IDbConnection conn = DapperHelper.OpenConnection())");
                    strclass.AppendSpaceLine(3, "{");
                    strclass.AppendSpaceLine(4, "model = conn.Query <" + ModelSpace + ">(strSql.ToString(), model)?.FirstOrDefault();");
                    strclass.AppendSpaceLine(3, "}");
                    strclass.AppendSpaceLine(3, "return model;");

                    strclass.AppendSpace(2, "}");
                }
            }
            return strclass.ToString();
        }

        #endregion


        #region 数据层(方法)

        /// <summary>
        /// 得到某字段最大值的方法代码(只有主键是int型的情况下生成)
        /// </summary>
        /// <param name="TabName"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string CreatGetMaxID()
        {
            StringPlus strclass = new StringPlus();
            if (_keys.Count > 0)
            {
                string keyname = "";
                foreach (ColumnInfo obj in _keys)
                {
                    if (CodeCommon.DbTypeToCS(obj.TypeName) == "int")
                    {
                        keyname = obj.ColumnName;
                        if (obj.IsPrimaryKey)
                        {
                            strclass.AppendLine("");
                            strclass.AppendSpaceLine(2, "/// <summary>");
                            strclass.AppendSpaceLine(2, "/// " + Languagelist["summaryGetMaxId"].ToString());
                            strclass.AppendSpaceLine(2, "/// </summary>");
                            strclass.AppendSpaceLine(2, "public int GetMaxId()");
                            strclass.AppendSpaceLine(2, "{");
                            strclass.AppendSpaceLine(2, "return " + DbHelperName + ".GetMaxID(\"" + keyname + "\", \"" + _tablename + "\"); ");
                            strclass.AppendSpaceLine(2, "}");
                            break;
                        }
                    }
                }
            }
            return strclass.ToString();
        }

        /// <summary>
        /// 得到Exists方法的代码
        /// </summary>
        /// <param name="_tablename"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string CreatExists()
        {
            StringPlus strclass = new StringPlus();
            if (_keys.Count > 0)
            {
                string strInparam = CodeHelper.CodeCommon.GetInParameter(Keys, false);
                if (!string.IsNullOrEmpty(strInparam))
                {
                    strclass.AppendLine("");
                    strclass.AppendSpaceLine(2, "/// <summary>");
                    strclass.AppendSpaceLine(2, "/// " + Languagelist["summaryExists"].ToString());
                    strclass.AppendSpaceLine(2, "/// </summary>");
                    strclass.AppendSpaceLine(2, "public bool Exists(" + TableName + " model)");
                    strclass.AppendSpaceLine(2, "{");
                    strclass.AppendSpaceLine(3, "StringBuilder strSql = new StringBuilder();");
                    strclass.AppendSpaceLine(3, "strSql.Append(\"select count(1) from " + _tablename + "\");");
                    strclass.AppendSpaceLine(3, "strSql.Append(\"  where "+ CodeCommon.GetWhereParameterExpression(this.Keys,true, this.dbobj.DbType) + "\");");

                    strclass.AppendSpaceLine(3, "using (IDbConnection conn = DapperHelper.OpenConnection())");
                    strclass.AppendSpaceLine(3, "{");
                    strclass.AppendSpaceLine(4, "int count = conn.Execute(strSql.ToString(), model);");
                    strclass.AppendSpaceLine(4, "if (count > 0)");
                    strclass.AppendSpaceLine(4, "{");
                    strclass.AppendSpaceLine(5, "return true;");
                    strclass.AppendSpaceLine(4, "}");
                    strclass.AppendSpaceLine(4, "else");
                    strclass.AppendSpaceLine(4, "{");
                    strclass.AppendSpaceLine(5, "return false;");
                    strclass.AppendSpaceLine(4, "}");
                    strclass.AppendSpaceLine(3, "}");


                    strclass.AppendSpace(2, "}");
                }
            }
            return strclass.ToString();
        }
        /// <summary>
        /// 得到Add()的代码
        /// </summary>        
        public string CreatAdd()
        {

            StringPlus stringPlus = new StringPlus();
            StringPlus stringPlus2 = new StringPlus();
            StringPlus stringPlus3 = new StringPlus();

            stringPlus.AppendLine();
            stringPlus.AppendSpaceLine(2, "/// <summary>");
            stringPlus.AppendSpaceLine(2, "/// " + this.Languagelist["summaryadd"].ToString());
            stringPlus.AppendSpaceLine(2, "/// </summary>");
            string text = "bool";
            if ((this.dbobj.DbType == "SQL2000" || this.dbobj.DbType == "SQL2005" || this.dbobj.DbType == "SQL2008" || this.dbobj.DbType == "SQL2012" || this.dbobj.DbType == "SQLite") && this.IsHasIdentity)
            {
                text = "int";
                if (this._IdentityKeyType != "int")
                {
                    text = this._IdentityKeyType;
                }
            }
            string text2 = string.Concat(new string[]
            {
        CodeCommon.Space(2),
        "public ",
        text,
        " Add(",
        this.ModelSpace,
        " model)"
            });
            stringPlus.AppendLine(text2);
            stringPlus.AppendSpaceLine(2, "{");
            stringPlus.AppendSpaceLine(3, "StringBuilder strSql=new StringBuilder();");
            stringPlus.AppendSpaceLine(3, "strSql.Append(\"insert into " + this._tablename + "(\");");
            stringPlus2.AppendSpace(3, "strSql.Append(\"");
            int num = 0;
            foreach (ColumnInfo current in this.Fieldlist)
            {
                string columnName = current.ColumnName;
                string typeName = current.TypeName;
                bool arg_1E5_0 = current.IsIdentity;
                string length = current.Length;
                bool arg_1F6_0 = current.Nullable;
                if (!current.IsIdentity)
                {

                    stringPlus2.Append(columnName + ",");
                    stringPlus3.Append(this.preParameter + columnName + ",");

                    num++;
                }
            }
            stringPlus2.DelLastComma();
            stringPlus3.DelLastComma();

            stringPlus2.AppendLine(")\");");
            stringPlus.Append(stringPlus2.ToString());
            stringPlus.AppendSpaceLine(3, "strSql.Append(\" values (\");");
            stringPlus.AppendSpaceLine(3, "strSql.Append(\"" + stringPlus3.ToString() + ")\");");
            if ((this.dbobj.DbType == "SQL2000" || this.dbobj.DbType == "SQL2005" || this.dbobj.DbType == "SQL2008" || this.dbobj.DbType == "SQL2012") && this.IsHasIdentity)
            {
                stringPlus.AppendSpaceLine(3, "strSql.Append(\";select @@IDENTITY\");");
            }
            if (this.dbobj.DbType == "SQLite" && this.IsHasIdentity)
            {
                stringPlus.AppendSpaceLine(3, "strSql.Append(\";select LAST_INSERT_ROWID()\");");
            }



            if (text == "void")
            {

                stringPlus.AppendSpaceLine(3, "using (IDbConnection conn = DapperHelper.OpenConnection())");
                stringPlus.AppendSpaceLine(3, "{");
                stringPlus.AppendSpaceLine(4, "int count = conn.Execute(strSql.ToString(), model);");
                stringPlus.AppendSpaceLine(3, "}");
            }
            else if (text == "bool")
            {
                stringPlus.AppendSpaceLine(3, "using (IDbConnection conn = DapperHelper.OpenConnection())");
                stringPlus.AppendSpaceLine(3, "{");
                stringPlus.AppendSpaceLine(4, "int count = conn.Execute(strSql.ToString(), model);");
                stringPlus.AppendSpaceLine(4, "if (count > 0)");
                stringPlus.AppendSpaceLine(4, "{");
                stringPlus.AppendSpaceLine(5, "return true;");
                stringPlus.AppendSpaceLine(4, "}");
                stringPlus.AppendSpaceLine(4, "else");
                stringPlus.AppendSpaceLine(4, "{");
                stringPlus.AppendSpaceLine(5, "return false;");
                stringPlus.AppendSpaceLine(4, "}");
                stringPlus.AppendSpaceLine(3, "}");
            }
            else
            {
                stringPlus.AppendSpaceLine(3, "using (IDbConnection conn = DapperHelper.OpenConnection())");
                stringPlus.AppendSpaceLine(3, "{");
                stringPlus.AppendSpaceLine(4, "object obj = conn.ExecuteScalar(strSql.ToString(), model);");
                stringPlus.AppendSpaceLine(4, "if (obj == null)");
                stringPlus.AppendSpaceLine(4, "{");
                stringPlus.AppendSpaceLine(5, "return 0;");
                stringPlus.AppendSpaceLine(4, "}");
                stringPlus.AppendSpaceLine(4, "else");
                stringPlus.AppendSpaceLine(4, "{");
                string a;
                if ((a = text) != null)
                {
                    if (!(a == "int"))
                    {
                        if (!(a == "long"))
                        {
                            if (a == "decimal")
                            {
                                stringPlus.AppendSpaceLine(5, "return Convert.ToDecimal(obj);");
                            }
                        }
                        else
                        {
                            stringPlus.AppendSpaceLine(5, "return Convert.ToInt64(obj);");
                        }
                    }
                    else
                    {
                        stringPlus.AppendSpaceLine(5, "return Convert.ToInt32(obj);");
                    }
                }
                stringPlus.AppendSpaceLine(4, "}");
                stringPlus.AppendSpaceLine(3, "}");
            }

            stringPlus.AppendSpace(2, "}");
            return stringPlus.ToString();
        }

        /// <summary>
        /// 得到Update（）的代码
        /// </summary>
        /// <param name="DbName"></param>
        /// <param name="_tablename"></param>
        /// <param name="_key"></param>
        /// <param name="ModelName"></param>
        /// <returns></returns>
        public string CreatUpdate()
        {

            StringPlus stringPlus = new StringPlus();
            stringPlus.AppendLine("");
            stringPlus.AppendSpaceLine(2, "/// <summary>");
            stringPlus.AppendSpaceLine(2, "/// " + Languagelist["summaryUpdate"].ToString());
            stringPlus.AppendSpaceLine(2, "/// </summary>");
            stringPlus.AppendSpaceLine(2, "public bool Update(" + ModelSpace + " model)");
            stringPlus.AppendSpaceLine(2, "{");
            stringPlus.AppendSpaceLine(3, "StringBuilder strSql=new StringBuilder();");
            stringPlus.AppendSpaceLine(3, "StringBuilder setSql=new StringBuilder();");
            stringPlus.AppendSpaceLine(3, "strSql.Append(\"update " + _tablename + " set \");");
            if (Fieldlist.Count == 0)
            {
                Fieldlist = Keys;
            }

            foreach (ColumnInfo field in Fieldlist)
            {

                string columnName = field.ColumnName;
                string columnType = field.TypeName;
                string Length = field.Length;
                bool IsIdentity = field.IsIdentity;
                bool isPK = field.IsPrimaryKey;
                bool nullable = field.Nullable;

                if (field.IsIdentity || field.IsPrimaryKey || (Keys.Contains(field)))
                {
                    continue;
                }
                if (columnType.ToLower() == "timestamp")
                {
                    continue;
                }
                #region 字段赋值
                switch (CodeCommon.DbTypeToCS(columnType))
                {
                    case "int":
                    case "long":
                    case "decimal":
                    case "float":
                    case "DateTime":
                        {
                            if (nullable)
                            {
                                stringPlus.AppendSpaceLine(3, "if(model." + columnName + "!=null)");
                                stringPlus.AppendSpaceLine(3, "{");
                                stringPlus.AppendSpaceLine(4, "setSql.Append( \"" + columnName + "=@" + columnName + ",\");");
                                stringPlus.AppendSpaceLine(3, "}");
                            }
                            else
                            {
                                stringPlus.AppendSpaceLine(3, "if(model." + columnName + ">0)");
                                stringPlus.AppendSpaceLine(3, "{");
                                stringPlus.AppendSpaceLine(4, "setSql.Append( \"" + columnName + "=@" + columnName + ",\");");
                                stringPlus.AppendSpaceLine(3, "}");
                            }
                        }
                        break;
                    case "string":
                        {
                            stringPlus.AppendSpaceLine(3, "if(!String.IsNullOrEmpty(model." + columnName + "))");
                            stringPlus.AppendSpaceLine(3, "{");
                            stringPlus.AppendSpaceLine(4, "setSql.Append( \"" + columnName + "=@" + columnName + ",\");");
                            stringPlus.AppendSpaceLine(3, "}");
                        }
                        break;
                    case "bool":
                        {
                            stringPlus.AppendSpaceLine(3, "if(model." + columnName + ")");
                            stringPlus.AppendSpaceLine(3, "{");
                            stringPlus.AppendSpaceLine(4, "setSql.Append( \"" + columnName + "=@" + columnName + ",\");");
                            stringPlus.AppendSpaceLine(3, "}");
                        }
                        break;
                    case "byte[]":
                        {
                            stringPlus.AppendSpaceLine(3, "if(model." + columnName + "!=null)");
                            stringPlus.AppendSpaceLine(3, "{");
                            stringPlus.AppendSpaceLine(4, "setSql.Append( \"" + columnName + "=@" + columnName + ",\");");
                            stringPlus.AppendSpaceLine(3, "}");
                        }
                        break;
                    case "uniqueidentifier":
                    case "Guid":
                        {
                            stringPlus.AppendSpaceLine(3, "if(!String.IsNullOrEmpty(model." + columnName + "))");
                            stringPlus.AppendSpaceLine(3, "{");
                            stringPlus.AppendSpaceLine(4, "setSql.Append( \"" + columnName + "=@" + columnName + ",\");");
                            stringPlus.AppendSpaceLine(3, "}");
                        }
                        break;
                    default:
                        stringPlus.AppendSpaceLine(3, "if(model." + columnName + "!=null)");
                        stringPlus.AppendSpaceLine(3, "{");
                        stringPlus.AppendSpaceLine(4, "setSql.Append( \"" + columnName + "=@" + columnName + ",\");");
                        stringPlus.AppendSpaceLine(3, "}");
                        break;
                }
                #endregion

            }
            //String identityName = Fieldlist.Find(field => field.IsIdentity || field.IsPrimaryKey || (Keys.Contains(field)))?.ColumnName;
            //stringPlus.AppendSpaceLine(3, "setSql.Append(DapperHelper.CreateUpdateSql(model,new string[] { \"" + identityName + "\" }));");
            stringPlus.AppendSpaceLine(3, "strSql.Append(setSql.ToString().TrimEnd(','));");

            stringPlus.AppendSpaceLine(3, "strSql.Append(\" where " + CodeCommon.GetWhereParameterExpression(this.Keys, false, this.dbobj.DbType) + "\");");

            stringPlus.AppendSpaceLine(3, "using (IDbConnection conn = DapperHelper.OpenConnection())");
            stringPlus.AppendSpaceLine(3, "{");
            stringPlus.AppendSpaceLine(4, "int count = conn.Execute(strSql.ToString(), model);");
            stringPlus.AppendSpaceLine(4, "if (count > 0)");
            stringPlus.AppendSpaceLine(4, "{");
            stringPlus.AppendSpaceLine(5, "return true;");
            stringPlus.AppendSpaceLine(4, "}");
            stringPlus.AppendSpaceLine(4, "else");
            stringPlus.AppendSpaceLine(4, "{");
            stringPlus.AppendSpaceLine(5, "return false;");
            stringPlus.AppendSpaceLine(4, "}");
            stringPlus.AppendSpaceLine(3, "}");

            stringPlus.AppendSpace(2, "}");
            return stringPlus.ToString();
        }
        /// <summary>
        /// 得到Delete的代码
        /// </summary>
        /// <param name="_tablename"></param>
        /// <param name="_key"></param>
        /// <returns></returns>
        public string CreatDelete()
        {
            StringPlus stringPlus = new StringPlus();
            stringPlus.AppendLine("");
            stringPlus.AppendSpaceLine(2, "/// <summary>");
            stringPlus.AppendSpaceLine(2, "/// " + Languagelist["summaryDelete"].ToString());
            stringPlus.AppendSpaceLine(2, "/// </summary>");
            stringPlus.AppendSpaceLine(2, "public bool Delete(" + ModelSpace + " model)");
            stringPlus.AppendSpaceLine(2, "{");
            stringPlus.AppendSpaceLine(3, "StringBuilder strSql=new StringBuilder();");

            stringPlus.AppendSpaceLine(3, "strSql.Append(\"delete from " + _tablename + " \");");

            stringPlus.AppendSpaceLine(3, "strSql.Append(\" where " + CodeCommon.GetWhereParameterExpression(this.Keys, false, this.dbobj.DbType) + "\" );");

            stringPlus.AppendSpaceLine(3, "using (IDbConnection conn = DapperHelper.OpenConnection())");
            stringPlus.AppendSpaceLine(3, "{");
            stringPlus.AppendSpaceLine(4, "int count = conn.Execute(strSql.ToString(), model);");
            stringPlus.AppendSpaceLine(4, "if (count > 0)");
            stringPlus.AppendSpaceLine(4, "{");
            stringPlus.AppendSpaceLine(5, "return true;");
            stringPlus.AppendSpaceLine(4, "}");
            stringPlus.AppendSpaceLine(4, "else");
            stringPlus.AppendSpaceLine(4, "{");
            stringPlus.AppendSpaceLine(5, "return false;");
            stringPlus.AppendSpaceLine(4, "}");
            stringPlus.AppendSpaceLine(3, "}");


            stringPlus.AppendSpace(2, "}");





            #region 批量删除方法

            string keyField = "";
            if (Keys.Count == 1)
            {
                keyField = Keys[0].ColumnName;
            }
            else
            {
                foreach (ColumnInfo field in Keys)
                {
                    if (field.IsIdentity)
                    {
                        keyField = field.ColumnName;
                        break;
                    }
                }
            }
            if (keyField.Trim().Length > 0)
            {
                stringPlus.AppendSpaceLine(2, "/// <summary>");
                stringPlus.AppendSpaceLine(2, "/// " + Languagelist["summaryDeletelist"].ToString());
                stringPlus.AppendSpaceLine(2, "/// </summary>");
                stringPlus.AppendSpaceLine(2, "public bool DeleteList(string " + keyField + "list )");
                stringPlus.AppendSpaceLine(2, "{");
                stringPlus.AppendSpaceLine(3, "StringBuilder strSql=new StringBuilder();");
                stringPlus.AppendSpaceLine(3, "strSql.Append(\"delete from " + _tablename + " \");");
                stringPlus.AppendSpaceLine(3, "strSql.Append(\" where " + keyField + " in (\"+" + keyField + "list + \")  \");");
                stringPlus.AppendSpaceLine(3, "using (IDbConnection conn = DapperHelper.OpenConnection())");
                stringPlus.AppendSpaceLine(3, "{");
                stringPlus.AppendSpaceLine(4, "int count = conn.Execute(strSql.ToString());");
                stringPlus.AppendSpaceLine(4, "if (count > 0)");
                stringPlus.AppendSpaceLine(4, "{");
                stringPlus.AppendSpaceLine(5, "return true;");
                stringPlus.AppendSpaceLine(4, "}");
                stringPlus.AppendSpaceLine(4, "else");
                stringPlus.AppendSpaceLine(4, "{");
                stringPlus.AppendSpaceLine(5, "return false;");
                stringPlus.AppendSpaceLine(4, "}");
                stringPlus.AppendSpaceLine(3, "}");
                stringPlus.AppendSpaceLine(2, "}");
            }
            #endregion



            return stringPlus.ToString();
        }






        /// <summary>
        /// 得到GetList()的代码
        /// </summary>
        /// <param name="_tablename"></param>
        /// <param name="_key"></param>
        /// <returns></returns>
        public string CreatGetListAndCount()
        {
            StringPlus stringPlus = new StringPlus();
            stringPlus.AppendSpaceLine(2, "/// <summary>");
            stringPlus.AppendSpaceLine(2, "/// " + Languagelist["summaryGetList"].ToString());
            stringPlus.AppendSpaceLine(2, "/// </summary>");
            stringPlus.AppendSpaceLine(2, "public List<"+ ModelSpace+ "> GetListAndCount(" + ModelSpace + " model, ref int total)");
            stringPlus.AppendSpaceLine(2, "{");
            stringPlus.AppendSpaceLine(3, "List<"+ ModelSpace+ "> list;");
            stringPlus.AppendSpaceLine(3, "StringBuilder strSql=new StringBuilder();");
            stringPlus.AppendSpaceLine(3, "StringBuilder whereSql = new StringBuilder(\" where 1 = 1 \");");
            stringPlus.AppendSpaceLine(3, "strSql.Append(\" select  ROW_NUMBER() OVER(ORDER BY "+CodeCommon.GetPrimaryKey(Keys)?.ColumnName + " desc) AS RID, * from "+ _tablename + " \");");

            foreach (ColumnInfo field in Fieldlist)
            {
                string columnName = field.ColumnName;
                string columnType = field.TypeName;
                bool nullable = field.Nullable;
                if (field.IsPrimaryKey) {
                    continue;
                }
                #region 字段赋值
                switch (CodeCommon.DbTypeToCS(columnType))
                {
                    case "int":
                    case "long":
                    case "decimal":
                    case "float":
                    case "DateTime":
                        {
                            if (nullable)
                            {
                                stringPlus.AppendSpaceLine(3, "if(model." + columnName + "!=null)");
                                stringPlus.AppendSpaceLine(3, "{");
                                stringPlus.AppendSpaceLine(4, "whereSql.Append( \" and " + columnName + "=@" + columnName + "\");");
                                stringPlus.AppendSpaceLine(3, "}");
                            }
                            else
                            {
                                stringPlus.AppendSpaceLine(3, "if(model." + columnName + ">0)");
                                stringPlus.AppendSpaceLine(3, "{");
                                stringPlus.AppendSpaceLine(4, "whereSql.Append( \" and " + columnName + "=@" + columnName + "\");");
                                stringPlus.AppendSpaceLine(3, "}");
                            }
                        }
                        break;
                    case "string":
                        {
                            stringPlus.AppendSpaceLine(3, "if(!String.IsNullOrEmpty(model." + columnName + "))");
                            stringPlus.AppendSpaceLine(3, "{");
                            stringPlus.AppendSpaceLine(4, "whereSql.Append( \" and " + columnName + "=@" + columnName + "\");");
                            stringPlus.AppendSpaceLine(3, "}");
                        }
                        break;
                    case "bool":
                        {
                            stringPlus.AppendSpaceLine(3, "if(model." + columnName + ")");
                            stringPlus.AppendSpaceLine(3, "{");
                            stringPlus.AppendSpaceLine(4, "whereSql.Append( \" and " + columnName + "=@" + columnName + "\");");
                            stringPlus.AppendSpaceLine(3, "}");
                        }
                        break;
                    case "byte[]":
                        {
                            stringPlus.AppendSpaceLine(3, "if(model." + columnName + "!=null)");
                            stringPlus.AppendSpaceLine(3, "{");
                            stringPlus.AppendSpaceLine(4, "whereSql.Append( \" and " + columnName + "=@" + columnName + "\");");
                            stringPlus.AppendSpaceLine(3, "}");
                        }
                        break;
                    case "uniqueidentifier":
                    case "Guid":
                        {
                            stringPlus.AppendSpaceLine(3, "if(!String.IsNullOrEmpty(model." + columnName + "))");
                            stringPlus.AppendSpaceLine(3, "{");
                            stringPlus.AppendSpaceLine(4, "whereSql.Append( \" and " + columnName + "=@" + columnName + "\");");
                            stringPlus.AppendSpaceLine(3, "}");
                        }
                        break;
                    default:
                        stringPlus.AppendSpaceLine(3, "if(model." + columnName + "!=null)");
                        stringPlus.AppendSpaceLine(3, "{");
                        stringPlus.AppendSpaceLine(4, "whereSql.Append( \" and " + columnName + "=@" + columnName + "\");");
                        stringPlus.AppendSpaceLine(3, "}");
                        break;
                }
                #endregion

            }


            stringPlus.AppendSpaceLine(3,"strSql.Append(whereSql);");
            stringPlus.AppendSpaceLine(3, "string CountSql = \"SELECT COUNT(1) as RowsCount FROM (\" + strSql.ToString() + \") AS CountList\";");
            stringPlus.AppendSpaceLine(3, "string pageSqlStr = \"select * from ( \" + strSql.ToString() + \" ) as Temp_PageData where Temp_PageData.RID BETWEEN {0} AND {1}\";");
            stringPlus.AppendSpaceLine(3, "pageSqlStr = string.Format(pageSqlStr, (model.pagesize * (model.pageindex - 1) + 1).ToString(), (model.pagesize * model.pageindex).ToString());");
            stringPlus.AppendSpaceLine(3, "using (IDbConnection conn = DapperHelper.OpenConnection())");
            stringPlus.AppendSpaceLine(3, "{");
            stringPlus.AppendSpaceLine(4, "list = conn.Query <"+ ModelSpace + ">(pageSqlStr, model)?.ToList();");
            stringPlus.AppendSpaceLine(4, "total = conn.ExecuteScalar<int>(CountSql, model);");
            stringPlus.AppendSpaceLine(3, "}");
            stringPlus.AppendSpaceLine(3, "return list;");
            stringPlus.AppendSpaceLine(2, "}");

            return stringPlus.Value;
        }
        /// <summary>
        /// 得到GetList()的代码
        /// </summary>
        /// <param name="_tablename"></param>
        /// <param name="_key"></param>
        /// <returns></returns>
        public string CreatGetList()
        {
            StringPlus stringPlus = new StringPlus();
            stringPlus.AppendSpaceLine(2, "/// <summary>");
            stringPlus.AppendSpaceLine(2, "/// " + Languagelist["summaryGetList"].ToString());
            stringPlus.AppendSpaceLine(2, "/// </summary>");
            stringPlus.AppendSpaceLine(2, "public List<" + ModelSpace + "> GetAll(" + ModelSpace + " model)");
            stringPlus.AppendSpaceLine(2, "{");
            stringPlus.AppendSpaceLine(3, "List<" + ModelSpace + "> list;");
            stringPlus.AppendSpaceLine(3, "StringBuilder strSql=new StringBuilder();");
            stringPlus.AppendSpaceLine(3, "StringBuilder whereSql = new StringBuilder(\" where 1 = 1 \");");
            stringPlus.AppendSpaceLine(3, "strSql.Append(\" select * from " + _tablename + " \");");

            foreach (ColumnInfo field in Fieldlist)
            {
                string columnName = field.ColumnName;
                string columnType = field.TypeName;
                bool nullable = field.Nullable;
                //if (field.IsPrimaryKey)
                //{
                //    continue;
                //}
                #region 字段赋值
                switch (CodeCommon.DbTypeToCS(columnType))
                {
                    case "int":
                    case "long":
                    case "decimal":
                    case "float":
                    case "DateTime":
                        {
                            if (nullable)
                            {
                                stringPlus.AppendSpaceLine(3, "if(model." + columnName + "!=null)");
                                stringPlus.AppendSpaceLine(3, "{");
                                stringPlus.AppendSpaceLine(4, "whereSql.Append( \" and " + columnName + "=@" + columnName + "\");");
                                stringPlus.AppendSpaceLine(3, "}");
                            }
                            else
                            {
                                stringPlus.AppendSpaceLine(3, "if(model." + columnName + ">0)");
                                stringPlus.AppendSpaceLine(3, "{");
                                stringPlus.AppendSpaceLine(4, "whereSql.Append( \" and " + columnName + "=@" + columnName + "\");");
                                stringPlus.AppendSpaceLine(3, "}");
                            }
                        }
                        break;
                    case "string":
                        {
                            stringPlus.AppendSpaceLine(3, "if(!String.IsNullOrEmpty(model." + columnName + "))");
                            stringPlus.AppendSpaceLine(3, "{");
                            stringPlus.AppendSpaceLine(4, "whereSql.Append( \" and " + columnName + "=@" + columnName + "\");");
                            stringPlus.AppendSpaceLine(3, "}");
                        }
                        break;
                    case "bool":
                        {
                            stringPlus.AppendSpaceLine(3, "if(model." + columnName + ")");
                            stringPlus.AppendSpaceLine(3, "{");
                            stringPlus.AppendSpaceLine(4, "whereSql.Append( \" and " + columnName + "=@" + columnName + "\");");
                            stringPlus.AppendSpaceLine(3, "}");
                        }
                        break;
                    case "byte[]":
                        {
                            stringPlus.AppendSpaceLine(3, "if(model." + columnName + "!=null)");
                            stringPlus.AppendSpaceLine(3, "{");
                            stringPlus.AppendSpaceLine(4, "whereSql.Append( \" and " + columnName + "=@" + columnName + "\");");
                            stringPlus.AppendSpaceLine(3, "}");
                        }
                        break;
                    case "uniqueidentifier":
                    case "Guid":
                        {
                            stringPlus.AppendSpaceLine(3, "if(!String.IsNullOrEmpty(model." + columnName + "))");
                            stringPlus.AppendSpaceLine(3, "{");
                            stringPlus.AppendSpaceLine(4, "whereSql.Append( \" and " + columnName + "=@" + columnName + "\");");
                            stringPlus.AppendSpaceLine(3, "}");
                        }
                        break;
                    default:
                        stringPlus.AppendSpaceLine(3, "if(model." + columnName + "!=null)");
                        stringPlus.AppendSpaceLine(3, "{");
                        stringPlus.AppendSpaceLine(4, "whereSql.Append( \" and " + columnName + "=@" + columnName + "\");");
                        stringPlus.AppendSpaceLine(3, "}");
                        break;
                }
                #endregion

            }


            stringPlus.AppendSpaceLine(3, "strSql.Append(whereSql);");
      
           // stringPlus.AppendSpaceLine(3, "string pageSqlStr = \"select * from ( \" + strSql.ToString() + \" ) as Temp_PageData where Temp_PageData.RID BETWEEN {0} AND {1}\";");
           // stringPlus.AppendSpaceLine(3, "pageSqlStr = string.Format(pageSqlStr, (model.pagesize * (model.pageindex - 1) + 1).ToString(), (model.pagesize * model.pageindex).ToString());");
            stringPlus.AppendSpaceLine(3, "using (IDbConnection conn = DapperHelper.OpenConnection())");
            stringPlus.AppendSpaceLine(3, "{");
            stringPlus.AppendSpaceLine(4, "list = conn.Query <" + ModelSpace + ">(strSql.ToString(), model)?.ToList();");
 
            stringPlus.AppendSpaceLine(3, "}");
            stringPlus.AppendSpaceLine(3, "return list;");
            stringPlus.AppendSpaceLine(2, "}");

            return stringPlus.Value;
        }
        #endregion//数据层


    }
}
