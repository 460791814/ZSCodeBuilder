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
	/// 数据访问类:D_park
	/// </summary>
	public partial class D_park
	{
		public D_park()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(tb_park model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from tb_park");
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
		public bool Add(tb_park model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_park(");
			strSql.Append("id,buildingid,parkname,address,parknumber,fee,isopen,addtime)");
			strSql.Append(" values (");
			strSql.Append("@id,@buildingid,@parkname,@address,@parknumber,@fee,@isopen,@addtime)");
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
		public bool Update(tb_park model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder setSql=new StringBuilder();
			strSql.Append("update tb_park set ");
			if(model.buildingid!=null)
			{
				setSql.Append( "buildingid=@buildingid,");
			}
			if(!String.IsNullOrEmpty(model.parkname))
			{
				setSql.Append( "parkname=@parkname,");
			}
			if(!String.IsNullOrEmpty(model.address))
			{
				setSql.Append( "address=@address,");
			}
			if(model.parknumber!=null)
			{
				setSql.Append( "parknumber=@parknumber,");
			}
			if(!String.IsNullOrEmpty(model.fee))
			{
				setSql.Append( "fee=@fee,");
			}
			if(model.isopen!=null)
			{
				setSql.Append( "isopen=@isopen,");
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
		public bool Delete(tb_park model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_park ");
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
			strSql.Append("delete from tb_park ");
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
		public List<tb_park> GetList(tb_park model, ref int total)
		{
			List<tb_park> list;
			StringBuilder strSql=new StringBuilder();
			StringBuilder whereSql = new StringBuilder(" where 1 = 1 ");
			strSql.Append(" select  ROW_NUMBER() OVER(ORDER BY id desc) AS RID, * from tb_park ");
			if(model.buildingid!=null)
			{
				whereSql.Append( " and buildingid=@buildingid");
			}
			if(!String.IsNullOrEmpty(model.parkname))
			{
				whereSql.Append( " and parkname=@parkname");
			}
			if(!String.IsNullOrEmpty(model.address))
			{
				whereSql.Append( " and address=@address");
			}
			if(model.parknumber!=null)
			{
				whereSql.Append( " and parknumber=@parknumber");
			}
			if(!String.IsNullOrEmpty(model.fee))
			{
				whereSql.Append( " and fee=@fee");
			}
			if(model.isopen!=null)
			{
				whereSql.Append( " and isopen=@isopen");
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
				list = conn.Query <tb_park>(pageSqlStr, model)?.ToList();
				total = conn.ExecuteScalar<int>(CountSql, model);
			}
			return list;
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public tb_park GetInfo(tb_park model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select * from tb_park");
			strSql.Append("  where id=@id ");
			using (IDbConnection conn = DapperHelper.OpenConnection())
			{
				model = conn.Query <tb_park>(strSql.ToString(), model)?.FirstOrDefault();
			}
			return model;
		}
		#endregion  Method
	}
}

