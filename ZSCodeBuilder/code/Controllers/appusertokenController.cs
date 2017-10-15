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
	/// App用户登陆Token
	/// </summary>
	public  class appusertokenController:Controller
	{
		D_appusertoken dappusertoken = new D_appusertoken();
		/// <summary>
		/// App用户登陆Token 列表
		/// </summary>
		public ActionResult appusertokenList(tb_appusertoken model)
		{
			int count = 0;
			ViewBag.appusertokenList = dappusertoken.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// App用户登陆Token 保存
		/// </summary>
		public JsonResult appusertokenSave(tb_appusertoken model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = dappusertoken.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = dappusertoken.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// App用户登陆Token 删除
		/// </summary>
		public JsonResult appusertokenDelete(tb_appusertoken model)
		{
			bool boolResult = dappusertoken.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// App用户登陆Token 详情
		/// </summary>
		public ActionResult appusertokenInfo(tb_appusertoken model)
		{
			model = dappusertoken.GetInfo(model);
			return View(model??new tb_appusertoken());
		}

	}
}

