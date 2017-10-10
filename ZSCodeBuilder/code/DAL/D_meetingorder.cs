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
	/// 数据访问类:D_meetingorder
	/// </summary>
	public partial class D_meetingorder
	{
		public D_meetingorder()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(tb_meetingorder model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from tb_meetingorder");
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
		public bool Add(tb_meetingorder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_meetingorder(");
			strSql.Append("id,orderno,buildingid,buildingname,meetingroomid,meetingroomname,comboid,comboname,userid,username,userphone,meetingpersonnum,meetingdate,meetingAMorPM,status,linkman,linktel,meetingnum,remark,otherservice,isdel,addtime)");
			strSql.Append(" values (");
			strSql.Append("@id,@orderno,@buildingid,@buildingname,@meetingroomid,@meetingroomname,@comboid,@comboname,@userid,@username,@userphone,@meetingpersonnum,@meetingdate,@meetingAMorPM,@status,@linkman,@linktel,@meetingnum,@remark,@otherservice,@isdel,@addtime)");
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
		public bool Update(tb_meetingorder model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder setSql=new StringBuilder();
			strSql.Append("update tb_meetingorder set ");
			if(!String.IsNullOrEmpty(model.orderno))
			{
				setSql.Append( "orderno=@orderno,");
			}
			if(!String.IsNullOrEmpty(model.buildingid))
			{
				setSql.Append( "buildingid=@buildingid,");
			}
			if(!String.IsNullOrEmpty(model.buildingname))
			{
				setSql.Append( "buildingname=@buildingname,");
			}
			if(!String.IsNullOrEmpty(model.meetingroomid))
			{
				setSql.Append( "meetingroomid=@meetingroomid,");
			}
			if(!String.IsNullOrEmpty(model.meetingroomname))
			{
				setSql.Append( "meetingroomname=@meetingroomname,");
			}
			if(!String.IsNullOrEmpty(model.comboid))
			{
				setSql.Append( "comboid=@comboid,");
			}
			if(!String.IsNullOrEmpty(model.comboname))
			{
				setSql.Append( "comboname=@comboname,");
			}
			if(!String.IsNullOrEmpty(model.userid))
			{
				setSql.Append( "userid=@userid,");
			}
			if(!String.IsNullOrEmpty(model.username))
			{
				setSql.Append( "username=@username,");
			}
			if(!String.IsNullOrEmpty(model.userphone))
			{
				setSql.Append( "userphone=@userphone,");
			}
			if(model.meetingpersonnum!=null)
			{
				setSql.Append( "meetingpersonnum=@meetingpersonnum,");
			}
			if(model.meetingdate!=null)
			{
				setSql.Append( "meetingdate=@meetingdate,");
			}
			if(!String.IsNullOrEmpty(model.meetingAMorPM))
			{
				setSql.Append( "meetingAMorPM=@meetingAMorPM,");
			}
			if(!String.IsNullOrEmpty(model.status))
			{
				setSql.Append( "status=@status,");
			}
			if(!String.IsNullOrEmpty(model.linkman))
			{
				setSql.Append( "linkman=@linkman,");
			}
			if(!String.IsNullOrEmpty(model.linktel))
			{
				setSql.Append( "linktel=@linktel,");
			}
			if(model.meetingnum!=null)
			{
				setSql.Append( "meetingnum=@meetingnum,");
			}
			if(!String.IsNullOrEmpty(model.remark))
			{
				setSql.Append( "remark=@remark,");
			}
			if(!String.IsNullOrEmpty(model.otherservice))
			{
				setSql.Append( "otherservice=@otherservice,");
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
		public bool Delete(tb_meetingorder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_meetingorder ");
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
			strSql.Append("delete from tb_meetingorder ");
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
		public List<tb_meetingorder> GetList(tb_meetingorder model, ref int total)
		{
			List<tb_meetingorder> list;
			StringBuilder strSql=new StringBuilder();
			StringBuilder whereSql = new StringBuilder(" where 1 = 1 ");
			strSql.Append(" select  ROW_NUMBER() OVER(ORDER BY id desc) AS RID, * from tb_meetingorder ");
			if(!String.IsNullOrEmpty(model.orderno))
			{
				whereSql.Append( " and orderno=@orderno");
			}
			if(!String.IsNullOrEmpty(model.buildingid))
			{
				whereSql.Append( " and buildingid=@buildingid");
			}
			if(!String.IsNullOrEmpty(model.buildingname))
			{
				whereSql.Append( " and buildingname=@buildingname");
			}
			if(!String.IsNullOrEmpty(model.meetingroomid))
			{
				whereSql.Append( " and meetingroomid=@meetingroomid");
			}
			if(!String.IsNullOrEmpty(model.meetingroomname))
			{
				whereSql.Append( " and meetingroomname=@meetingroomname");
			}
			if(!String.IsNullOrEmpty(model.comboid))
			{
				whereSql.Append( " and comboid=@comboid");
			}
			if(!String.IsNullOrEmpty(model.comboname))
			{
				whereSql.Append( " and comboname=@comboname");
			}
			if(!String.IsNullOrEmpty(model.userid))
			{
				whereSql.Append( " and userid=@userid");
			}
			if(!String.IsNullOrEmpty(model.username))
			{
				whereSql.Append( " and username=@username");
			}
			if(!String.IsNullOrEmpty(model.userphone))
			{
				whereSql.Append( " and userphone=@userphone");
			}
			if(model.meetingpersonnum!=null)
			{
				whereSql.Append( " and meetingpersonnum=@meetingpersonnum");
			}
			if(model.meetingdate!=null)
			{
				whereSql.Append( " and meetingdate=@meetingdate");
			}
			if(!String.IsNullOrEmpty(model.meetingAMorPM))
			{
				whereSql.Append( " and meetingAMorPM=@meetingAMorPM");
			}
			if(!String.IsNullOrEmpty(model.status))
			{
				whereSql.Append( " and status=@status");
			}
			if(!String.IsNullOrEmpty(model.linkman))
			{
				whereSql.Append( " and linkman=@linkman");
			}
			if(!String.IsNullOrEmpty(model.linktel))
			{
				whereSql.Append( " and linktel=@linktel");
			}
			if(model.meetingnum!=null)
			{
				whereSql.Append( " and meetingnum=@meetingnum");
			}
			if(!String.IsNullOrEmpty(model.remark))
			{
				whereSql.Append( " and remark=@remark");
			}
			if(!String.IsNullOrEmpty(model.otherservice))
			{
				whereSql.Append( " and otherservice=@otherservice");
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
				list = conn.Query <tb_meetingorder>(pageSqlStr, model)?.ToList();
				total = conn.ExecuteScalar<int>(CountSql, model);
			}
			return list;
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public tb_meetingorder GetInfo(tb_meetingorder model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select * from tb_meetingorder");
			strSql.Append("  where id=@id ");
			using (IDbConnection conn = DapperHelper.OpenConnection())
			{
				model = conn.Query <tb_meetingorder>(strSql.ToString(), model)?.FirstOrDefault();
			}
			return model;
		}
		#endregion  Method
	}
}

