using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Model;
using System.Linq;
using System.Collections.Generic;
using Dapper;
namespace DAL
{
	/// <summary>
	/// 数据访问类:D_role_module
	/// </summary>
	public partial class D_role_module
	{
		public D_role_module()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(tb_role_module model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from tb_role_module");
			strSql.Append("  where roleid=@roleid and moduleid=@moduleid ");
			using (IDbConnection conn = DapperHelper.OpenConnection())
			{
				int count = conn.Execute(strSql.ToString(), model);
				if (count > 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(tb_role_module model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_role_module(");
			strSql.Append("roleid,moduleid)");
			strSql.Append(" values (");
			strSql.Append("@roleid,@moduleid)");
			using (IDbConnection conn = DapperHelper.OpenConnection())
			{
				int count = conn.Execute(strSql.ToString(), model);
				if (count > 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(tb_role_module model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder setSql=new StringBuilder();
			strSql.Append("update tb_role_module set ");
			strSql.Append(setSql.ToString().TrimEnd(','));
			strSql.Append(" where roleid=@roleid and moduleid=@moduleid ");
			using (IDbConnection conn = DapperHelper.OpenConnection())
			{
				int count = conn.Execute(strSql.ToString(), model);
				if (count > 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(tb_role_module model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_role_module ");
			strSql.Append(" where roleid=@roleid and moduleid=@moduleid " );
			using (IDbConnection conn = DapperHelper.OpenConnection())
			{
				int count = conn.Execute(strSql.ToString(), model);
				if (count > 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<tb_role_module> GetList(tb_role_module model, ref int total)
		{
			List<tb_role_module> list;
			StringBuilder strSql=new StringBuilder();
			StringBuilder whereSql = new StringBuilder(" where 1 = 1 ");
			strSql.Append(" select  ROW_NUMBER() OVER(ORDER BY roleid desc) AS RID, * from tb_role_module ");
			strSql.Append(whereSql);
			string CountSql = "SELECT COUNT(1) as RowsCount FROM (" + strSql.ToString() + ") AS CountList";
			string pageSqlStr = "select * from ( " + strSql.ToString() + " ) as Temp_PageData where Temp_PageData.RID BETWEEN {0} AND {1}";
			pageSqlStr = string.Format(pageSqlStr, (model.PageSize * (model.PageIndex - 1) + 1).ToString(), (model.PageSize * model.PageIndex).ToString());
			using (IDbConnection conn = DapperHelper.OpenConnection())
			{
				list = conn.Query <tb_role_module>(pageSqlStr, model)?.ToList();
				total = conn.ExecuteScalar<int>(CountSql, model);
			}
			return list;
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public tb_role_module GetInfo(tb_role_module model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select * from tb_role_module");
			strSql.Append("  where roleid=@roleid and moduleid=@moduleid ");
			using (IDbConnection conn = DapperHelper.OpenConnection())
			{
				model = conn.Query <tb_role_module>(strSql.ToString(), model)?.FirstOrDefault();
			}
			return model;
		}
		#endregion  Method
	}
}

