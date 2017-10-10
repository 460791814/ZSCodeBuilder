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
	/// 数据访问类:D_pcctv
	/// </summary>
	public partial class D_pcctv
	{
		public D_pcctv()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(tb_pcctv model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from tb_pcctv");
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
		public bool Add(tb_pcctv model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_pcctv(");
			strSql.Append("pid,id,pcctvlevel,pcctvname,classification,remark)");
			strSql.Append(" values (");
			strSql.Append("@pid,@id,@pcctvlevel,@pcctvname,@classification,@remark)");
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
		public bool Update(tb_pcctv model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder setSql=new StringBuilder();
			strSql.Append("update tb_pcctv set ");
			if(!String.IsNullOrEmpty(model.pid))
			{
				setSql.Append( "pid=@pid,");
			}
			if(model.pcctvlevel!=null)
			{
				setSql.Append( "pcctvlevel=@pcctvlevel,");
			}
			if(!String.IsNullOrEmpty(model.pcctvname))
			{
				setSql.Append( "pcctvname=@pcctvname,");
			}
			if(!String.IsNullOrEmpty(model.classification))
			{
				setSql.Append( "classification=@classification,");
			}
			if(!String.IsNullOrEmpty(model.remark))
			{
				setSql.Append( "remark=@remark,");
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
		public bool Delete(tb_pcctv model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_pcctv ");
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
			strSql.Append("delete from tb_pcctv ");
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
		public List<tb_pcctv> GetList(tb_pcctv model, ref int total)
		{
			List<tb_pcctv> list;
			StringBuilder strSql=new StringBuilder();
			StringBuilder whereSql = new StringBuilder(" where 1 = 1 ");
			strSql.Append(" select  ROW_NUMBER() OVER(ORDER BY id desc) AS RID, * from tb_pcctv ");
			if(!String.IsNullOrEmpty(model.pid))
			{
				whereSql.Append( " and pid=@pid");
			}
			if(model.pcctvlevel!=null)
			{
				whereSql.Append( " and pcctvlevel=@pcctvlevel");
			}
			if(!String.IsNullOrEmpty(model.pcctvname))
			{
				whereSql.Append( " and pcctvname=@pcctvname");
			}
			if(!String.IsNullOrEmpty(model.classification))
			{
				whereSql.Append( " and classification=@classification");
			}
			if(!String.IsNullOrEmpty(model.remark))
			{
				whereSql.Append( " and remark=@remark");
			}
			strSql.Append(whereSql);
			string CountSql = "SELECT COUNT(1) as RowsCount FROM (" + strSql.ToString() + ") AS CountList";
			string pageSqlStr = "select * from ( " + strSql.ToString() + " ) as Temp_PageData where Temp_PageData.RID BETWEEN {0} AND {1}";
			pageSqlStr = string.Format(pageSqlStr, (model.PageSize * (model.PageIndex - 1) + 1).ToString(), (model.PageSize * model.PageIndex).ToString());
			using (IDbConnection conn = DapperHelper.OpenConnection())
			{
				list = conn.Query <tb_pcctv>(pageSqlStr, model)?.ToList();
				total = conn.ExecuteScalar<int>(CountSql, model);
			}
			return list;
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public tb_pcctv GetInfo(tb_pcctv model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select * from tb_pcctv");
			strSql.Append("  where id=@id ");
			using (IDbConnection conn = DapperHelper.OpenConnection())
			{
				model = conn.Query <tb_pcctv>(strSql.ToString(), model)?.FirstOrDefault();
			}
			return model;
		}
		#endregion  Method
	}
}

