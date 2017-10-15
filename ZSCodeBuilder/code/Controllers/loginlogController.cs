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
		public JsonResult loginlogSave(tb_loginlog model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = dloginlog.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = dloginlog.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 登陆日志 删除
		/// </summary>
		public JsonResult loginlogDelete(tb_loginlog model)
		{
			bool boolResult = dloginlog.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
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

