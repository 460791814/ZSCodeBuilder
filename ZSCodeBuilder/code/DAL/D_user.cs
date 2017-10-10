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
	/// 数据访问类:D_user
	/// </summary>
	public partial class D_user
	{
		public D_user()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(tb_user model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from tb_user");
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
		public bool Add(tb_user model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_user(");
			strSql.Append("id,code,nickname,phonenum,address,longitude,latitude,remark,createdate,updatedate,pwd,province,city,county,location,sex,job,age,constellation,hav,tall,schedule,sgin,hobby,birth,wx,issingle,company,companyaddress,realname,avatar,isdel,addtime)");
			strSql.Append(" values (");
			strSql.Append("@id,@code,@nickname,@phonenum,@address,@longitude,@latitude,@remark,@createdate,@updatedate,@pwd,@province,@city,@county,@location,@sex,@job,@age,@constellation,@hav,@tall,@schedule,@sgin,@hobby,@birth,@wx,@issingle,@company,@companyaddress,@realname,@avatar,@isdel,@addtime)");
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
		public bool Update(tb_user model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder setSql=new StringBuilder();
			strSql.Append("update tb_user set ");
			if(!String.IsNullOrEmpty(model.code))
			{
				setSql.Append( "code=@code,");
			}
			if(!String.IsNullOrEmpty(model.nickname))
			{
				setSql.Append( "nickname=@nickname,");
			}
			if(!String.IsNullOrEmpty(model.phonenum))
			{
				setSql.Append( "phonenum=@phonenum,");
			}
			if(!String.IsNullOrEmpty(model.address))
			{
				setSql.Append( "address=@address,");
			}
			if(model.longitude!=null)
			{
				setSql.Append( "longitude=@longitude,");
			}
			if(model.latitude!=null)
			{
				setSql.Append( "latitude=@latitude,");
			}
			if(!String.IsNullOrEmpty(model.remark))
			{
				setSql.Append( "remark=@remark,");
			}
			if(model.createdate!=null)
			{
				setSql.Append( "createdate=@createdate,");
			}
			if(model.updatedate!=null)
			{
				setSql.Append( "updatedate=@updatedate,");
			}
			if(!String.IsNullOrEmpty(model.pwd))
			{
				setSql.Append( "pwd=@pwd,");
			}
			if(!String.IsNullOrEmpty(model.province))
			{
				setSql.Append( "province=@province,");
			}
			if(!String.IsNullOrEmpty(model.city))
			{
				setSql.Append( "city=@city,");
			}
			if(!String.IsNullOrEmpty(model.county))
			{
				setSql.Append( "county=@county,");
			}
			if(!String.IsNullOrEmpty(model.location))
			{
				setSql.Append( "location=@location,");
			}
			if(!String.IsNullOrEmpty(model.sex))
			{
				setSql.Append( "sex=@sex,");
			}
			if(!String.IsNullOrEmpty(model.job))
			{
				setSql.Append( "job=@job,");
			}
			if(model.age!=null)
			{
				setSql.Append( "age=@age,");
			}
			if(!String.IsNullOrEmpty(model.constellation))
			{
				setSql.Append( "constellation=@constellation,");
			}
			if(!String.IsNullOrEmpty(model.hav))
			{
				setSql.Append( "hav=@hav,");
			}
			if(model.tall!=null)
			{
				setSql.Append( "tall=@tall,");
			}
			if(!String.IsNullOrEmpty(model.schedule))
			{
				setSql.Append( "schedule=@schedule,");
			}
			if(!String.IsNullOrEmpty(model.sgin))
			{
				setSql.Append( "sgin=@sgin,");
			}
			if(!String.IsNullOrEmpty(model.hobby))
			{
				setSql.Append( "hobby=@hobby,");
			}
			if(model.birth!=null)
			{
				setSql.Append( "birth=@birth,");
			}
			if(!String.IsNullOrEmpty(model.wx))
			{
				setSql.Append( "wx=@wx,");
			}
			if(!String.IsNullOrEmpty(model.issingle))
			{
				setSql.Append( "issingle=@issingle,");
			}
			if(!String.IsNullOrEmpty(model.company))
			{
				setSql.Append( "company=@company,");
			}
			if(!String.IsNullOrEmpty(model.companyaddress))
			{
				setSql.Append( "companyaddress=@companyaddress,");
			}
			if(!String.IsNullOrEmpty(model.realname))
			{
				setSql.Append( "realname=@realname,");
			}
			if(!String.IsNullOrEmpty(model.avatar))
			{
				setSql.Append( "avatar=@avatar,");
			}
			if(model.isdel)
			{
				setSql.Append( "isdel=@isdel,");
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
		public bool Delete(tb_user model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_user ");
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
			strSql.Append("delete from tb_user ");
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
		public List<tb_user> GetList(tb_user model, ref int total)
		{
			List<tb_user> list;
			StringBuilder strSql=new StringBuilder();
			StringBuilder whereSql = new StringBuilder(" where 1 = 1 ");
			strSql.Append(" select  ROW_NUMBER() OVER(ORDER BY id desc) AS RID, * from tb_user ");
			if(!String.IsNullOrEmpty(model.code))
			{
				whereSql.Append( " and code=@code");
			}
			if(!String.IsNullOrEmpty(model.nickname))
			{
				whereSql.Append( " and nickname=@nickname");
			}
			if(!String.IsNullOrEmpty(model.phonenum))
			{
				whereSql.Append( " and phonenum=@phonenum");
			}
			if(!String.IsNullOrEmpty(model.address))
			{
				whereSql.Append( " and address=@address");
			}
			if(model.longitude!=null)
			{
				whereSql.Append( " and longitude=@longitude");
			}
			if(model.latitude!=null)
			{
				whereSql.Append( " and latitude=@latitude");
			}
			if(!String.IsNullOrEmpty(model.remark))
			{
				whereSql.Append( " and remark=@remark");
			}
			if(model.createdate!=null)
			{
				whereSql.Append( " and createdate=@createdate");
			}
			if(model.updatedate!=null)
			{
				whereSql.Append( " and updatedate=@updatedate");
			}
			if(!String.IsNullOrEmpty(model.pwd))
			{
				whereSql.Append( " and pwd=@pwd");
			}
			if(!String.IsNullOrEmpty(model.province))
			{
				whereSql.Append( " and province=@province");
			}
			if(!String.IsNullOrEmpty(model.city))
			{
				whereSql.Append( " and city=@city");
			}
			if(!String.IsNullOrEmpty(model.county))
			{
				whereSql.Append( " and county=@county");
			}
			if(!String.IsNullOrEmpty(model.location))
			{
				whereSql.Append( " and location=@location");
			}
			if(!String.IsNullOrEmpty(model.sex))
			{
				whereSql.Append( " and sex=@sex");
			}
			if(!String.IsNullOrEmpty(model.job))
			{
				whereSql.Append( " and job=@job");
			}
			if(model.age!=null)
			{
				whereSql.Append( " and age=@age");
			}
			if(!String.IsNullOrEmpty(model.constellation))
			{
				whereSql.Append( " and constellation=@constellation");
			}
			if(!String.IsNullOrEmpty(model.hav))
			{
				whereSql.Append( " and hav=@hav");
			}
			if(model.tall!=null)
			{
				whereSql.Append( " and tall=@tall");
			}
			if(!String.IsNullOrEmpty(model.schedule))
			{
				whereSql.Append( " and schedule=@schedule");
			}
			if(!String.IsNullOrEmpty(model.sgin))
			{
				whereSql.Append( " and sgin=@sgin");
			}
			if(!String.IsNullOrEmpty(model.hobby))
			{
				whereSql.Append( " and hobby=@hobby");
			}
			if(model.birth!=null)
			{
				whereSql.Append( " and birth=@birth");
			}
			if(!String.IsNullOrEmpty(model.wx))
			{
				whereSql.Append( " and wx=@wx");
			}
			if(!String.IsNullOrEmpty(model.issingle))
			{
				whereSql.Append( " and issingle=@issingle");
			}
			if(!String.IsNullOrEmpty(model.company))
			{
				whereSql.Append( " and company=@company");
			}
			if(!String.IsNullOrEmpty(model.companyaddress))
			{
				whereSql.Append( " and companyaddress=@companyaddress");
			}
			if(!String.IsNullOrEmpty(model.realname))
			{
				whereSql.Append( " and realname=@realname");
			}
			if(!String.IsNullOrEmpty(model.avatar))
			{
				whereSql.Append( " and avatar=@avatar");
			}
			if(model.isdel)
			{
				whereSql.Append( " and isdel=@isdel");
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
				list = conn.Query <tb_user>(pageSqlStr, model)?.ToList();
				total = conn.ExecuteScalar<int>(CountSql, model);
			}
			return list;
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public tb_user GetInfo(tb_user model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select * from tb_user");
			strSql.Append("  where id=@id ");
			using (IDbConnection conn = DapperHelper.OpenConnection())
			{
				model = conn.Query <tb_user>(strSql.ToString(), model)?.FirstOrDefault();
			}
			return model;
		}
		#endregion  Method
	}
}

