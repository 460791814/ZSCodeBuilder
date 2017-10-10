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
	/// 数据访问类:D_weixinlicense
	/// </summary>
	public partial class D_weixinlicense
	{
		public D_weixinlicense()
		{}
		#region  Method


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(tb_weixinlicense model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_weixinlicense(");
			strSql.Append("id,openid,addtime,subscribe,nickname,sex,city,country,province,language,headimgurl,subscribe_time,unionid,code,userType,userid)");
			strSql.Append(" values (");
			strSql.Append("@id,@openid,@addtime,@subscribe,@nickname,@sex,@city,@country,@province,@language,@headimgurl,@subscribe_time,@unionid,@code,@userType,@userid)");
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
		public bool Update(tb_weixinlicense model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder setSql=new StringBuilder();
			strSql.Append("update tb_weixinlicense set ");
			if(!String.IsNullOrEmpty(model.id))
			{
				setSql.Append( "id=@id,");
			}
			if(!String.IsNullOrEmpty(model.openid))
			{
				setSql.Append( "openid=@openid,");
			}
			if(model.addtime!=null)
			{
				setSql.Append( "addtime=@addtime,");
			}
			if(model.subscribe!=null)
			{
				setSql.Append( "subscribe=@subscribe,");
			}
			if(!String.IsNullOrEmpty(model.nickname))
			{
				setSql.Append( "nickname=@nickname,");
			}
			if(model.sex!=null)
			{
				setSql.Append( "sex=@sex,");
			}
			if(!String.IsNullOrEmpty(model.city))
			{
				setSql.Append( "city=@city,");
			}
			if(!String.IsNullOrEmpty(model.country))
			{
				setSql.Append( "country=@country,");
			}
			if(!String.IsNullOrEmpty(model.province))
			{
				setSql.Append( "province=@province,");
			}
			if(!String.IsNullOrEmpty(model.language))
			{
				setSql.Append( "language=@language,");
			}
			if(!String.IsNullOrEmpty(model.headimgurl))
			{
				setSql.Append( "headimgurl=@headimgurl,");
			}
			if(!String.IsNullOrEmpty(model.subscribe_time))
			{
				setSql.Append( "subscribe_time=@subscribe_time,");
			}
			if(!String.IsNullOrEmpty(model.unionid))
			{
				setSql.Append( "unionid=@unionid,");
			}
			if(!String.IsNullOrEmpty(model.code))
			{
				setSql.Append( "code=@code,");
			}
			if(!String.IsNullOrEmpty(model.userType))
			{
				setSql.Append( "userType=@userType,");
			}
			if(!String.IsNullOrEmpty(model.userid))
			{
				setSql.Append( "userid=@userid,");
			}
			strSql.Append(setSql.ToString().TrimEnd(','));
			strSql.Append(" where ");
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
		public bool Delete(tb_weixinlicense model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_weixinlicense ");
			strSql.Append(" where " );
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
		public List<tb_weixinlicense> GetList(tb_weixinlicense model, ref int total)
		{
			List<tb_weixinlicense> list;
			StringBuilder strSql=new StringBuilder();
			StringBuilder whereSql = new StringBuilder(" where 1 = 1 ");
			strSql.Append(" select  ROW_NUMBER() OVER(ORDER BY  desc) AS RID, * from tb_weixinlicense ");
			if(!String.IsNullOrEmpty(model.id))
			{
				whereSql.Append( " and id=@id");
			}
			if(!String.IsNullOrEmpty(model.openid))
			{
				whereSql.Append( " and openid=@openid");
			}
			if(model.addtime!=null)
			{
				whereSql.Append( " and addtime=@addtime");
			}
			if(model.subscribe!=null)
			{
				whereSql.Append( " and subscribe=@subscribe");
			}
			if(!String.IsNullOrEmpty(model.nickname))
			{
				whereSql.Append( " and nickname=@nickname");
			}
			if(model.sex!=null)
			{
				whereSql.Append( " and sex=@sex");
			}
			if(!String.IsNullOrEmpty(model.city))
			{
				whereSql.Append( " and city=@city");
			}
			if(!String.IsNullOrEmpty(model.country))
			{
				whereSql.Append( " and country=@country");
			}
			if(!String.IsNullOrEmpty(model.province))
			{
				whereSql.Append( " and province=@province");
			}
			if(!String.IsNullOrEmpty(model.language))
			{
				whereSql.Append( " and language=@language");
			}
			if(!String.IsNullOrEmpty(model.headimgurl))
			{
				whereSql.Append( " and headimgurl=@headimgurl");
			}
			if(!String.IsNullOrEmpty(model.subscribe_time))
			{
				whereSql.Append( " and subscribe_time=@subscribe_time");
			}
			if(!String.IsNullOrEmpty(model.unionid))
			{
				whereSql.Append( " and unionid=@unionid");
			}
			if(!String.IsNullOrEmpty(model.code))
			{
				whereSql.Append( " and code=@code");
			}
			if(!String.IsNullOrEmpty(model.userType))
			{
				whereSql.Append( " and userType=@userType");
			}
			if(!String.IsNullOrEmpty(model.userid))
			{
				whereSql.Append( " and userid=@userid");
			}
			strSql.Append(whereSql);
			string CountSql = "SELECT COUNT(1) as RowsCount FROM (" + strSql.ToString() + ") AS CountList";
			string pageSqlStr = "select * from ( " + strSql.ToString() + " ) as Temp_PageData where Temp_PageData.RID BETWEEN {0} AND {1}";
			pageSqlStr = string.Format(pageSqlStr, (model.PageSize * (model.PageIndex - 1) + 1).ToString(), (model.PageSize * model.PageIndex).ToString());
			using (IDbConnection conn = DapperHelper.OpenConnection())
			{
				list = conn.Query <tb_weixinlicense>(pageSqlStr, model)?.ToList();
				total = conn.ExecuteScalar<int>(CountSql, model);
			}
			return list;
		}


		#endregion  Method
	}
}

