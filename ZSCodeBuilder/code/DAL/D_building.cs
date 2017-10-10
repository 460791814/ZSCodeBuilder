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
	/// 数据访问类:D_building
	/// </summary>
	public partial class D_building
	{
		public D_building()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(tb_building model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from tb_building");
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
		public bool Add(tb_building model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_building(");
			strSql.Append("id,buildingname,administrative,provinceid,cityid,countyid,address,propertycompany,propertycompanyintro,traffic,customer,longitude,latitude,isdel,sortnum,addtime)");
			strSql.Append(" values (");
			strSql.Append("@id,@buildingname,@administrative,@provinceid,@cityid,@countyid,@address,@propertycompany,@propertycompanyintro,@traffic,@customer,@longitude,@latitude,@isdel,@sortnum,@addtime)");
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
		public bool Update(tb_building model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder setSql=new StringBuilder();
			strSql.Append("update tb_building set ");
			if(!String.IsNullOrEmpty(model.buildingname))
			{
				setSql.Append( "buildingname=@buildingname,");
			}
			if(!String.IsNullOrEmpty(model.administrative))
			{
				setSql.Append( "administrative=@administrative,");
			}
			if(!String.IsNullOrEmpty(model.provinceid))
			{
				setSql.Append( "provinceid=@provinceid,");
			}
			if(!String.IsNullOrEmpty(model.cityid))
			{
				setSql.Append( "cityid=@cityid,");
			}
			if(!String.IsNullOrEmpty(model.countyid))
			{
				setSql.Append( "countyid=@countyid,");
			}
			if(!String.IsNullOrEmpty(model.address))
			{
				setSql.Append( "address=@address,");
			}
			if(!String.IsNullOrEmpty(model.propertycompany))
			{
				setSql.Append( "propertycompany=@propertycompany,");
			}
			if(!String.IsNullOrEmpty(model.propertycompanyintro))
			{
				setSql.Append( "propertycompanyintro=@propertycompanyintro,");
			}
			if(!String.IsNullOrEmpty(model.traffic))
			{
				setSql.Append( "traffic=@traffic,");
			}
			if(!String.IsNullOrEmpty(model.customer))
			{
				setSql.Append( "customer=@customer,");
			}
			if(model.longitude!=null)
			{
				setSql.Append( "longitude=@longitude,");
			}
			if(model.latitude!=null)
			{
				setSql.Append( "latitude=@latitude,");
			}
			if(model.isdel)
			{
				setSql.Append( "isdel=@isdel,");
			}
			if(model.sortnum!=null)
			{
				setSql.Append( "sortnum=@sortnum,");
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
		public bool Delete(tb_building model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_building ");
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
			strSql.Append("delete from tb_building ");
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
		public List<tb_building> GetList(tb_building model, ref int total)
		{
			List<tb_building> list;
			StringBuilder strSql=new StringBuilder();
			StringBuilder whereSql = new StringBuilder(" where 1 = 1 ");
			strSql.Append(" select  ROW_NUMBER() OVER(ORDER BY id desc) AS RID, * from tb_building ");
			if(!String.IsNullOrEmpty(model.buildingname))
			{
				whereSql.Append( " and buildingname=@buildingname");
			}
			if(!String.IsNullOrEmpty(model.administrative))
			{
				whereSql.Append( " and administrative=@administrative");
			}
			if(!String.IsNullOrEmpty(model.provinceid))
			{
				whereSql.Append( " and provinceid=@provinceid");
			}
			if(!String.IsNullOrEmpty(model.cityid))
			{
				whereSql.Append( " and cityid=@cityid");
			}
			if(!String.IsNullOrEmpty(model.countyid))
			{
				whereSql.Append( " and countyid=@countyid");
			}
			if(!String.IsNullOrEmpty(model.address))
			{
				whereSql.Append( " and address=@address");
			}
			if(!String.IsNullOrEmpty(model.propertycompany))
			{
				whereSql.Append( " and propertycompany=@propertycompany");
			}
			if(!String.IsNullOrEmpty(model.propertycompanyintro))
			{
				whereSql.Append( " and propertycompanyintro=@propertycompanyintro");
			}
			if(!String.IsNullOrEmpty(model.traffic))
			{
				whereSql.Append( " and traffic=@traffic");
			}
			if(!String.IsNullOrEmpty(model.customer))
			{
				whereSql.Append( " and customer=@customer");
			}
			if(model.longitude!=null)
			{
				whereSql.Append( " and longitude=@longitude");
			}
			if(model.latitude!=null)
			{
				whereSql.Append( " and latitude=@latitude");
			}
			if(model.isdel)
			{
				whereSql.Append( " and isdel=@isdel");
			}
			if(model.sortnum!=null)
			{
				whereSql.Append( " and sortnum=@sortnum");
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
				list = conn.Query <tb_building>(pageSqlStr, model)?.ToList();
				total = conn.ExecuteScalar<int>(CountSql, model);
			}
			return list;
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public tb_building GetInfo(tb_building model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select * from tb_building");
			strSql.Append("  where id=@id ");
			using (IDbConnection conn = DapperHelper.OpenConnection())
			{
				model = conn.Query <tb_building>(strSql.ToString(), model)?.FirstOrDefault();
			}
			return model;
		}
		#endregion  Method
	}
}

