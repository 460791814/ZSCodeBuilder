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
	/// 数据访问类:D_operationlog
	/// </summary>
	public partial class D_operationlog
	{
		public D_operationlog()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(tb_operationlog model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from tb_operationlog");
			strSql.Append("  where id=@id ");
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
		public bool Add(tb_operationlog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_operationlog(");
			strSql.Append("id,username,ip,target,action,addtime)");
			strSql.Append(" values (");
			strSql.Append("@id,@username,@ip,@target,@action,@addtime)");
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
		public bool Update(tb_operationlog model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder setSql=new StringBuilder();
			strSql.Append("update tb_operationlog set ");
			if(!String.IsNullOrEmpty(model.username))
			{
				setSql.Append( "username=@username,");
			}
			if(!String.IsNullOrEmpty(model.ip))
			{
				setSql.Append( "ip=@ip,");
			}
			if(!String.IsNullOrEmpty(model.target))
			{
				setSql.Append( "target=@target,");
			}
			if(!String.IsNullOrEmpty(model.action))
			{
				setSql.Append( "action=@action,");
			}
			if(model.addtime!=null)
			{
				setSql.Append( "addtime=@addtime,");
			}
			strSql.Append(setSql.ToString().TrimEnd(','));
			strSql.Append(" where id=@id ");
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
		public bool Delete(tb_operationlog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_operationlog ");
			strSql.Append(" where id=@id " );
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
		}		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_operationlog ");
			strSql.Append(" where id in ("+idlist + ")  ");
			using (IDbConnection conn = DapperHelper.OpenConnection())
			{
				int count = conn.Execute(strSql.ToString());
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
		public List<tb_operationlog> GetList(tb_operationlog model, ref int total)
		{
			List<tb_operationlog> list;
			StringBuilder strSql=new StringBuilder();
			StringBuilder whereSql = new StringBuilder(" where 1 = 1 ");
			strSql.Append(" select  ROW_NUMBER() OVER(ORDER BY id desc) AS RID, * from tb_operationlog ");
			if(!String.IsNullOrEmpty(model.username))
			{
				whereSql.Append( " and username=@username");
			}
			if(!String.IsNullOrEmpty(model.ip))
			{
				whereSql.Append( " and ip=@ip");
			}
			if(!String.IsNullOrEmpty(model.target))
			{
				whereSql.Append( " and target=@target");
			}
			if(!String.IsNullOrEmpty(model.action))
			{
				whereSql.Append( " and action=@action");
			}
			if(model.addtime!=null)
			{
				whereSql.Append( " and addtime=@addtime");
			}
			strSql.Append(whereSql);
			string CountSql = "SELECT COUNT(1) as RowsCount FROM (" + strSql.ToString() + ") AS CountList";
			string pageSqlStr = "select * from ( " + strSql.ToString() + " ) as Temp_PageData where Temp_PageData.RID BETWEEN {0} AND {1}";
			pageSqlStr = string.Format(pageSqlStr, (model.PageSize * (model.PageIndex - 1) + 1).ToString(), (model.PageSize * model.PageIndex).ToString());
			using (IDbConnection conn = DapperHelper.OpenConnection())
			{
				list = conn.Query <tb_operationlog>(pageSqlStr, model)?.ToList();
				total = conn.ExecuteScalar<int>(CountSql, model);
			}
			return list;
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public tb_operationlog GetInfo(tb_operationlog model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select * from tb_operationlog");
			strSql.Append("  where id=@id ");
			using (IDbConnection conn = DapperHelper.OpenConnection())
			{
				model = conn.Query <tb_operationlog>(strSql.ToString(), model)?.FirstOrDefault();
			}
			return model;
		}
		#endregion  Method
	}
}

