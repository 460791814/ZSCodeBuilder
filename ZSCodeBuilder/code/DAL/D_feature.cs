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
	/// 数据访问类:D_feature
	/// </summary>
	public partial class D_feature
	{
		public D_feature()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(tb_feature model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from tb_feature");
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
		public bool Add(tb_feature model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_feature(");
			strSql.Append("id,img,type,code,version,remark,isdel,sortnum,addtime)");
			strSql.Append(" values (");
			strSql.Append("@id,@img,@type,@code,@version,@remark,@isdel,@sortnum,@addtime)");
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
		public bool Update(tb_feature model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder setSql=new StringBuilder();
			strSql.Append("update tb_feature set ");
			if(!String.IsNullOrEmpty(model.img))
			{
				setSql.Append( "img=@img,");
			}
			if(!String.IsNullOrEmpty(model.type))
			{
				setSql.Append( "type=@type,");
			}
			if(!String.IsNullOrEmpty(model.code))
			{
				setSql.Append( "code=@code,");
			}
			if(!String.IsNullOrEmpty(model.version))
			{
				setSql.Append( "version=@version,");
			}
			if(!String.IsNullOrEmpty(model.remark))
			{
				setSql.Append( "remark=@remark,");
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
		public bool Delete(tb_feature model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_feature ");
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
			strSql.Append("delete from tb_feature ");
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
		public List<tb_feature> GetList(tb_feature model, ref int total)
		{
			List<tb_feature> list;
			StringBuilder strSql=new StringBuilder();
			StringBuilder whereSql = new StringBuilder(" where 1 = 1 ");
			strSql.Append(" select  ROW_NUMBER() OVER(ORDER BY id desc) AS RID, * from tb_feature ");
			if(!String.IsNullOrEmpty(model.img))
			{
				whereSql.Append( " and img=@img");
			}
			if(!String.IsNullOrEmpty(model.type))
			{
				whereSql.Append( " and type=@type");
			}
			if(!String.IsNullOrEmpty(model.code))
			{
				whereSql.Append( " and code=@code");
			}
			if(!String.IsNullOrEmpty(model.version))
			{
				whereSql.Append( " and version=@version");
			}
			if(!String.IsNullOrEmpty(model.remark))
			{
				whereSql.Append( " and remark=@remark");
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
				list = conn.Query <tb_feature>(pageSqlStr, model)?.ToList();
				total = conn.ExecuteScalar<int>(CountSql, model);
			}
			return list;
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public tb_feature GetInfo(tb_feature model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select * from tb_feature");
			strSql.Append("  where id=@id ");
			using (IDbConnection conn = DapperHelper.OpenConnection())
			{
				model = conn.Query <tb_feature>(strSql.ToString(), model)?.FirstOrDefault();
			}
			return model;
		}
		#endregion  Method
	}
}

