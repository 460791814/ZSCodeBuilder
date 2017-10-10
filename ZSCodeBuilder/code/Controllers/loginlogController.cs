using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using Model;
using Comp;
namespace cnooc.property.manage.Controllers
{
	/// <summary>
	/// 登陆日志
	/// </summary>
	public  class loginlogController:Controller
	{
		D_loginlog dloginlog = new D_loginlog();
		/// <summary>
		/// 登陆日志 列表
		/// </summary>
		public ActionResult loginlogList(tb_loginlog model)
		{
			int count = 0;
			ViewBag.loginlogList = dloginlog.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 登陆日志 保存
		/// </summary>
		public bool loginlogSave(tb_loginlog model)
		{
			if (model == null)
			{
				return false;
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				 return dloginlog.Update(model);
			}
			model.id = Guid.NewGuid().ToString("N");
			return dloginlog.Add(model);
		}

		/// <summary>
		/// 登陆日志 删除
		/// </summary>
		public bool loginlogDelete(tb_loginlog model)
		{
			return dloginlog.Delete(model);
		}

		/// <summary>
		/// 登陆日志 详情
		/// </summary>
		public ActionResult loginlogInfo(tb_loginlog model)
		{
			model = dloginlog.GetInfo(model);
			return View(model??new tb_loginlog());
		}

	}
}

