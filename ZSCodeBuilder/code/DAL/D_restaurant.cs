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
	/// 数据访问类:D_restaurant
	/// </summary>
	public partial class D_restaurant
	{
		public D_restaurant()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(tb_restaurant model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from tb_restaurant");
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
		public bool Add(tb_restaurant model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_restaurant(");
			strSql.Append("id,buildingid,name,address,hold,phone,dinnertime,isopen,addtime)");
			strSql.Append(" values (");
			strSql.Append("@id,@buildingid,@name,@address,@hold,@phone,@dinnertime,@isopen,@addtime)");
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
		public bool Update(tb_restaurant model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder setSql=new StringBuilder();
			strSql.Append("update tb_restaurant set ");
			if(!String.IsNullOrEmpty(model.buildingid))
			{
				setSql.Append( "buildingid=@buildingid,");
			}
			if(!String.IsNullOrEmpty(model.name))
			{
				setSql.Append( "name=@name,");
			}
			if(!String.IsNullOrEmpty(model.address))
			{
				setSql.Append( "address=@address,");
			}
			if(!String.IsNullOrEmpty(model.hold))
			{
				setSql.Append( "hold=@hold,");
			}
			if(!String.IsNullOrEmpty(model.phone))
			{
				setSql.Append( "phone=@phone,");
			}
			if(!String.IsNullOrEmpty(model.dinnertime))
			{
				setSql.Append( "dinnertime=@dinnertime,");
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
		public bool Delete(tb_restaurant model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_restaurant ");
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
			strSql.Append("delete from tb_restaurant ");
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
		public List<tb_restaurant> GetList(tb_restaurant model, ref int total)
		{
			List<tb_restaurant> list;
			StringBuilder strSql=new StringBuilder();
			StringBuilder whereSql = new StringBuilder(" where 1 = 1 ");
			strSql.Append(" select  ROW_NUMBER() OVER(ORDER BY id desc) AS RID, * from tb_restaurant ");
			if(!String.IsNullOrEmpty(model.buildingid))
			{
				whereSql.Append( " and buildingid=@buildingid");
			}
			if(!String.IsNullOrEmpty(model.name))
			{
				whereSql.Append( " and name=@name");
			}
			if(!String.IsNullOrEmpty(model.address))
			{
				whereSql.Append( " and address=@address");
			}
			if(!String.IsNullOrEmpty(model.hold))
			{
				whereSql.Append( " and hold=@hold");
			}
			if(!String.IsNullOrEmpty(model.phone))
			{
				whereSql.Append( " and phone=@phone");
			}
			if(!String.IsNullOrEmpty(model.dinnertime))
			{
				whereSql.Append( " and dinnertime=@dinnertime");
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
				list = conn.Query <tb_restaurant>(pageSqlStr, model)?.ToList();
				total = conn.ExecuteScalar<int>(CountSql, model);
			}
			return list;
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public tb_restaurant GetInfo(tb_restaurant model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select * from tb_restaurant");
			strSql.Append("  where id=@id ");
			using (IDbConnection conn = DapperHelper.OpenConnection())
			{
				model = conn.Query <tb_restaurant>(strSql.ToString(), model)?.FirstOrDefault();
			}
			return model;
		}
		#endregion  Method
	}
}

