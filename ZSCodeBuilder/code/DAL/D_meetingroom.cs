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
	/// 数据访问类:D_meetingroom
	/// </summary>
	public partial class D_meetingroom
	{
		public D_meetingroom()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(tb_meetingroom model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from tb_meetingroom");
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
		public bool Add(tb_meetingroom model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_meetingroom(");
			strSql.Append("id,buildingid,intro,phone,floor,roomnumber,desktype,hold,fee,isopen,roomtype,package,addtime)");
			strSql.Append(" values (");
			strSql.Append("@id,@buildingid,@intro,@phone,@floor,@roomnumber,@desktype,@hold,@fee,@isopen,@roomtype,@package,@addtime)");
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
		public bool Update(tb_meetingroom model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder setSql=new StringBuilder();
			strSql.Append("update tb_meetingroom set ");
			if(!String.IsNullOrEmpty(model.buildingid))
			{
				setSql.Append( "buildingid=@buildingid,");
			}
			if(!String.IsNullOrEmpty(model.intro))
			{
				setSql.Append( "intro=@intro,");
			}
			if(!String.IsNullOrEmpty(model.phone))
			{
				setSql.Append( "phone=@phone,");
			}
			if(!String.IsNullOrEmpty(model.floor))
			{
				setSql.Append( "floor=@floor,");
			}
			if(!String.IsNullOrEmpty(model.roomnumber))
			{
				setSql.Append( "roomnumber=@roomnumber,");
			}
			if(model.desktype!=null)
			{
				setSql.Append( "desktype=@desktype,");
			}
			if(!String.IsNullOrEmpty(model.hold))
			{
				setSql.Append( "hold=@hold,");
			}
			if(!String.IsNullOrEmpty(model.fee))
			{
				setSql.Append( "fee=@fee,");
			}
			if(model.isopen!=null)
			{
				setSql.Append( "isopen=@isopen,");
			}
			if(model.roomtype!=null)
			{
				setSql.Append( "roomtype=@roomtype,");
			}
			if(!String.IsNullOrEmpty(model.package))
			{
				setSql.Append( "package=@package,");
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
		public bool Delete(tb_meetingroom model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_meetingroom ");
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
			strSql.Append("delete from tb_meetingroom ");
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
		public List<tb_meetingroom> GetList(tb_meetingroom model, ref int total)
		{
			List<tb_meetingroom> list;
			StringBuilder strSql=new StringBuilder();
			StringBuilder whereSql = new StringBuilder(" where 1 = 1 ");
			strSql.Append(" select  ROW_NUMBER() OVER(ORDER BY id desc) AS RID, * from tb_meetingroom ");
			if(!String.IsNullOrEmpty(model.buildingid))
			{
				whereSql.Append( " and buildingid=@buildingid");
			}
			if(!String.IsNullOrEmpty(model.intro))
			{
				whereSql.Append( " and intro=@intro");
			}
			if(!String.IsNullOrEmpty(model.phone))
			{
				whereSql.Append( " and phone=@phone");
			}
			if(!String.IsNullOrEmpty(model.floor))
			{
				whereSql.Append( " and floor=@floor");
			}
			if(!String.IsNullOrEmpty(model.roomnumber))
			{
				whereSql.Append( " and roomnumber=@roomnumber");
			}
			if(model.desktype!=null)
			{
				whereSql.Append( " and desktype=@desktype");
			}
			if(!String.IsNullOrEmpty(model.hold))
			{
				whereSql.Append( " and hold=@hold");
			}
			if(!String.IsNullOrEmpty(model.fee))
			{
				whereSql.Append( " and fee=@fee");
			}
			if(model.isopen!=null)
			{
				whereSql.Append( " and isopen=@isopen");
			}
			if(model.roomtype!=null)
			{
				whereSql.Append( " and roomtype=@roomtype");
			}
			if(!String.IsNullOrEmpty(model.package))
			{
				whereSql.Append( " and package=@package");
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
				list = conn.Query <tb_meetingroom>(pageSqlStr, model)?.ToList();
				total = conn.ExecuteScalar<int>(CountSql, model);
			}
			return list;
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public tb_meetingroom GetInfo(tb_meetingroom model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select * from tb_meetingroom");
			strSql.Append("  where id=@id ");
			using (IDbConnection conn = DapperHelper.OpenConnection())
			{
				model = conn.Query <tb_meetingroom>(strSql.ToString(), model)?.FirstOrDefault();
			}
			return model;
		}
		#endregion  Method
	}
}

